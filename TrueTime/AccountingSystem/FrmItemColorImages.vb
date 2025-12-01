Imports System.Data.SqlClient
Imports System.IO

Public Class FrmItemColorImages
    Public Property ItemNo As Integer

    ' Controls for Add Image panel
    Private PanelAddImage As Panel
    Private PictureBoxNew As PictureBox
    Private BtnSaveImage As DevExpress.XtraEditors.SimpleButton
    Private BtnCancelImage As DevExpress.XtraEditors.SimpleButton

    ' Track which image is being edited
    Private EditingImageID As Integer = 0

    Public Sub New(itemNo As Integer)
        InitializeComponent()
        Me.ItemNo = itemNo

        ' Initialize Add Image panel
        InitAddImagePanel()
    End Sub

    Private Sub FrmItemColorImages_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtProductName.Text = GetItemName(ItemNo)
        LoadColorsList(ItemNo)

        ' Select first color by default
        If ListBoxColors.Items.Count > 0 Then
            ListBoxColors.SelectedIndex = 0
        End If
    End Sub

    ' ------------------------
    ' Handle color selection
    ' ------------------------
    Private Sub ListBoxColors_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBoxColors.SelectedIndexChanged
        If ListBoxColors.SelectedItem IsNot Nothing Then
            Dim selectedColor = ListBoxColors.SelectedItem.ToString()
            LoadImagesForColor(ItemNo, selectedColor)
        End If
    End Sub

    ' ------------------------
    ' Load images for selected color only
    ' ------------------------
    ' ------------------------
    ' Load images for selected color only
    ' ------------------------
    Private Sub LoadImagesForColor(itemNo As Integer, colorName As String)
        FlowLayoutImages.Controls.Clear()

        Dim dtColors As DataTable = GetItemColors(itemNo)
        Dim filteredRows = dtColors.Select("ColorName = '" & colorName.Replace("'", "''") & "'")

        Dim lblHeader As New Label() With {
        .Text = colorName,
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .AutoSize = True,
        .Margin = New Padding(10, 20, 10, 5)
        }
        ' FlowLayoutImages.Controls.Add(lblHeader)

        Dim hasImages As Boolean = filteredRows.Any(Function(r) Not IsDBNull(r("Image")) AndAlso CType(r("Image"), Byte()).Length > 0)
        If Not hasImages Then
            ' If no images for this color, show a centered message
            Dim lblNoImages As New Label() With {
                .Text = "لا يوجد صور",
                .Font = New Font("Segoe UI", 12, FontStyle.Bold),
                .ForeColor = Color.DarkGray,
                .AutoSize = True,
                .TextAlign = ContentAlignment.MiddleCenter
            }
            lblNoImages.Left = (FlowLayoutImages.ClientSize.Width - lblNoImages.Width) \ 2
            lblNoImages.Top = (FlowLayoutImages.ClientSize.Height - lblNoImages.Height) \ 2
            FlowLayoutImages.Controls.Add(lblNoImages)
        Else
            ' Add image cards
            For Each row As DataRow In filteredRows
                If IsDBNull(row("Image")) Then Continue For

                Dim imageID As Integer = CInt(row("ImageID"))
                Dim imgBytes() As Byte = CType(row("Image"), Byte())
                If imgBytes.Length = 0 Then Continue For

                Using ms As New MemoryStream(imgBytes)
                    Dim img As Image = Image.FromStream(ms)

                    ' Create image card
                    Dim card As New Panel() With {
                    .Size = New Size(180, 200),
                    .BackColor = Color.White,
                    .Margin = New Padding(10),
                    .Padding = New Padding(5)
                }
                    AddHandler card.Paint, Sub(s, pe)
                                               ControlPaint.DrawBorder(pe.Graphics, card.ClientRectangle, Color.LightGray, ButtonBorderStyle.Solid)
                                           End Sub

                    ' PictureBox
                    Dim pic As New PictureBox() With {
                    .Size = New Size(160, 120),
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .Image = img,
                    .Location = New Point(10, 10)
                }
                    card.Controls.Add(pic)

                    ' Label
                    Dim lbl As New Label() With {
                    .Text = colorName,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Font = New Font("Segoe UI", 9, FontStyle.Bold),
                    .Top = pic.Bottom + 5,
                    .Left = 10,
                    .Width = 160,
                    .Height = 25
                }
                    card.Controls.Add(lbl)

                    ' Edit button
                    Dim btnEdit As New Button() With {
                    .Text = "تعديل",
                    .Size = New Size(75, 30),
                    .Location = New Point(10, lbl.Bottom + 5),
                    .BackColor = Color.FromArgb(33, 150, 243),
                    .ForeColor = Color.White,
                    .FlatStyle = FlatStyle.Flat
                }
                    btnEdit.FlatAppearance.BorderSize = 0
                    AddHandler btnEdit.Click, Sub()
                                                  EditingImageID = imageID
                                                  PictureBoxNew.Image = pic.Image
                                                  PanelAddImage.Visible = True
                                                  PanelAddImage.BringToFront()
                                                  PanelAddImage.Focus()
                                              End Sub
                    card.Controls.Add(btnEdit)

                    ' Delete button
                    Dim btnDelete As New Button() With {
                    .Text = "حذف",
                    .Size = New Size(75, 30),
                    .Location = New Point(95, lbl.Bottom + 5),
                    .BackColor = Color.FromArgb(244, 67, 54),
                    .ForeColor = Color.White,
                    .FlatStyle = FlatStyle.Flat
                }
                    btnDelete.FlatAppearance.BorderSize = 0
                    AddHandler btnDelete.Click, Sub()
                                                    DeleteImage(imageID)
                                                End Sub
                    card.Controls.Add(btnDelete)

                    FlowLayoutImages.Controls.Add(card)
                End Using
            Next
        End If
    End Sub


    ' ------------------------
    ' Load colors list
    ' ------------------------
    Private Sub LoadColorsList(itemNo As Integer)
        ListBoxColors.Items.Clear()
        Dim dtColors As DataTable = GetItemColors(itemNo)
        Dim added As New HashSet(Of String)

        For Each row As DataRow In dtColors.Rows
            Dim colorName As String = row("ColorName").ToString()
            If Not added.Contains(colorName) Then
                ListBoxColors.Items.Add(colorName)
                added.Add(colorName)
            End If
        Next

        If ListBoxColors.Items.Count = 0 Then
            ListBoxColors.Items.Add("لا يوجد ألوان لهذا الصنف")
            BtnAddImage.Visible = False   ' Hide Add button if no colors
        Else
            BtnAddImage.Visible = True    ' Show Add button if there are colors
        End If
    End Sub


    ' ------------------------
    ' Get item name
    ' ------------------------
    Private Function GetItemName(itemNo As Integer) As String
        Dim itemName As String = ""
        Dim connStr As String = GlobalVariables.connectionString
        Dim query As String = "SELECT ItemName FROM dbo.Items WHERE ItemNo = @ItemNo"

        Using con As New SqlConnection(connStr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ItemNo", itemNo)
                Try
                    con.Open()
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then itemName = result.ToString()
                Catch ex As Exception
                    MessageBox.Show("Error loading item name: " & ex.Message)
                End Try
            End Using
        End Using

        Return itemName
    End Function

    ' ------------------------
    ' Get all images for item colors
    ' ------------------------
    Private Function GetItemColors(itemNo As Integer) As DataTable
        Dim dt As New DataTable()
        Dim connStr As String = GlobalVariables.connectionString
        Dim query As String = "
            SELECT DISTINCT 
                img.ImageID,
                ic.ColorName,
                ic.ID AS ColorID,
                img.Image
            FROM dbo.Items_units iu
            INNER JOIN dbo.ItemsColors ic ON iu.Color = ic.ID
            LEFT JOIN dbo.ItemColorImages img ON img.ItemID = iu.item_id AND img.ColorID = ic.ID
            WHERE iu.item_id = @ItemID AND iu.Color IS NOT NULL
            ORDER BY ic.ColorName, img.ImageID
        "

        Using con As New SqlConnection(connStr)
            Using cmd As New SqlCommand(query, con)
                cmd.Parameters.AddWithValue("@ItemID", itemNo)
                Try
                    con.Open()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                Catch ex As Exception
                    MessageBox.Show("Error loading item colors: " & ex.Message)
                End Try
            End Using
        End Using

        Return dt
    End Function

    ' ------------------------
    ' Delete image
    ' ------------------------
    Private Sub DeleteImage(imageID As Integer)
        If MessageBox.Show("هل أنت متأكد من حذف الصورة؟", "تأكيد الحذف", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
        End If

        Try
            Using con As New SqlConnection(GlobalVariables.connectionString)
                Using cmd As New SqlCommand("DELETE FROM ItemColorImages WHERE ImageID=@ImageID", con)
                    cmd.Parameters.AddWithValue("@ImageID", imageID)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ' Reload images for selected color
            If ListBoxColors.SelectedItem IsNot Nothing Then
                LoadImagesForColor(ItemNo, ListBoxColors.SelectedItem.ToString())
            End If
        Catch ex As Exception
            MessageBox.Show("خطأ عند حذف الصورة: " & ex.Message)
        End Try
    End Sub

    ' ------------------------
    ' Add/Edit Image Panel
    ' ------------------------
    Private Sub InitAddImagePanel()
        PanelAddImage = New Panel() With {
            .Size = New Size(400, 300),
            .BackColor = Color.WhiteSmoke,
            .BorderStyle = BorderStyle.FixedSingle,
            .Visible = False,
            .Left = (Me.Width - 400) \ 2,
            .Top = (Me.Height - 300) \ 2,
            .TabStop = True
        }
        Me.Controls.Add(PanelAddImage)
        PanelAddImage.BringToFront()

        PictureBoxNew = New PictureBox() With {
            .Size = New Size(360, 200),
            .Location = New Point(20, 20),
            .BorderStyle = BorderStyle.FixedSingle,
            .SizeMode = PictureBoxSizeMode.Zoom,
            .AllowDrop = True
        }
        PanelAddImage.Controls.Add(PictureBoxNew)

        AddHandler PanelAddImage.KeyDown, AddressOf PanelAddImage_KeyDown

        BtnSaveImage = New DevExpress.XtraEditors.SimpleButton() With {
            .Text = "Save",
            .Size = New Size(100, 30),
            .Location = New Point(80, 230)
        }
        AddHandler BtnSaveImage.Click, AddressOf BtnSaveImage_Click
        PanelAddImage.Controls.Add(BtnSaveImage)

        BtnCancelImage = New DevExpress.XtraEditors.SimpleButton() With {
            .Text = "Cancel",
            .Size = New Size(100, 30),
            .Location = New Point(220, 230)
        }
        AddHandler BtnCancelImage.Click, AddressOf BtnCancelImage_Click
        PanelAddImage.Controls.Add(BtnCancelImage)

        ' Mouse paste context menu
        Dim ctx As New ContextMenuStrip()
        ctx.Items.Add("Paste", Nothing, Sub()
                                            If Clipboard.ContainsImage() Then
                                                PictureBoxNew.Image = Clipboard.GetImage()
                                            End If
                                        End Sub)
        PictureBoxNew.ContextMenuStrip = ctx
    End Sub

    Private Sub PanelAddImage_KeyDown(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.V Then
            If Clipboard.ContainsImage() Then
                PictureBoxNew.Image = Clipboard.GetImage()
            End If
        End If
    End Sub

    Private Sub BtnCancelImage_Click(sender As Object, e As EventArgs)
        PictureBoxNew.Image = Nothing
        EditingImageID = 0
        PanelAddImage.Visible = False
    End Sub

    ' ------------------------
    ' Save pasted image (Add or Edit)
    ' ------------------------
    Private Sub BtnSaveImage_Click(sender As Object, e As EventArgs)
        If PictureBoxNew.Image Is Nothing Then
            MessageBox.Show("اختر صورة أولاً")
            Return
        End If

        If ListBoxColors.SelectedItem Is Nothing Then
            MessageBox.Show("اختر اللون أولاً")
            Return
        End If

        Dim selectedColorName = ListBoxColors.SelectedItem.ToString()
        Dim colorRow = GetColorRowByName(selectedColorName)
        If colorRow Is Nothing Then
            MessageBox.Show("خطأ: اللون غير موجود")
            Return
        End If
        Dim colorID As Integer = CInt(colorRow("ColorID"))

        Try
            Dim ms As New MemoryStream()
            PictureBoxNew.Image.Save(ms, Imaging.ImageFormat.Jpeg)
            Dim imgBytes() As Byte = ms.ToArray()

            Using con As New SqlConnection(GlobalVariables.connectionString)
                Using cmd As New SqlCommand()
                    cmd.Connection = con
                    con.Open()

                    If EditingImageID > 0 Then
                        cmd.CommandText = "UPDATE ItemColorImages SET Image=@Image WHERE ImageID=@ImageID"
                        cmd.Parameters.AddWithValue("@Image", imgBytes)
                        cmd.Parameters.AddWithValue("@ImageID", EditingImageID)
                    Else
                        cmd.CommandText = "INSERT INTO ItemColorImages(ItemID, ColorID, Image, SortOrder, IsMain) VALUES (@ItemID, @ColorID, @Image, 1, 0)"
                        cmd.Parameters.AddWithValue("@ItemID", ItemNo)
                        cmd.Parameters.AddWithValue("@ColorID", colorID)
                        cmd.Parameters.AddWithValue("@Image", imgBytes)
                    End If

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show(If(EditingImageID > 0, "تم تعديل الصورة بنجاح", "تمت إضافة الصورة بنجاح"))

            ' Reset
            EditingImageID = 0
            PanelAddImage.Visible = False
            PictureBoxNew.Image = Nothing

            ' Reload images for selected color
            LoadImagesForColor(ItemNo, selectedColorName)
        Catch ex As Exception
            MessageBox.Show("خطأ عند حفظ الصورة: " & ex.Message)
        End Try
    End Sub

    Private Function GetColorRowByName(colorName As String) As DataRow
        Dim dt = GetItemColors(ItemNo)
        For Each r As DataRow In dt.Rows
            If r("ColorName").ToString() = colorName Then Return r
        Next
        Return Nothing
    End Function

    ' ------------------------
    ' Show Add Image panel
    ' ------------------------
    Private Sub BtnAddImage_Click(sender As Object, e As EventArgs) Handles BtnAddImage.Click
        If ListBoxColors.SelectedItem Is Nothing Then
            MessageBox.Show("اختر اللون أولاً")
            Return
        End If

        EditingImageID = 0
        PictureBoxNew.Image = Nothing
        PanelAddImage.Visible = True
        PanelAddImage.BringToFront()
        PanelAddImage.Focus()
    End Sub

End Class
