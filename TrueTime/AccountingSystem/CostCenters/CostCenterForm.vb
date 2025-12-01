Imports System.Drawing.Imaging
Imports System.IO
Imports DevExpress.XtraEditors

Public Class CostCenterForm
    Private _costCenter As New CostCenterClass()
    Private _isNewRecord As Boolean = True
    Private _costCenterTypes As DataTable
    Private _suppliers As DataTable

    ''' <summary>
    ''' Initializes form data and controls
    ''' </summary>
    Private Sub CostCenterForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCostCenterTypes()
        LoadSuppliers()
        InitializeForm()
        Me.TextEditCostName.Select()
    End Sub

    ''' <summary>
    ''' Loads data for cost center types dropdown
    ''' </summary>
    Private Sub LoadCostCenterTypes()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT ID, Type FROM [CostCenterTypes] ORDER BY Type")
            _costCenterTypes = sql.SQLDS.Tables(0)
            SearchLookUpEditCostCenterTypeID.Properties.DataSource = _costCenterTypes
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في تحميل أنواع مراكز التكلفة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Loads data for suppliers dropdown
    ''' </summary>
    Private Sub LoadSuppliers()
        Try
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery("SELECT RefNo, RefName FROM Referencess WHERE RefType = 1 ORDER BY RefName")
            _suppliers = sql.SQLDS.Tables(0)
            SearchLookUpEditSupplier.Properties.DataSource = _suppliers
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في تحميل الموردين: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Initializes form with default values or existing record
    ''' </summary>
    Public Sub InitializeForm()
        If _isNewRecord Then
            Me.Text = "جديد"
            CheckEditCostCenterStatus.Checked = True
            DateEditStartDate.EditValue = Today
            TextEditCostName.Focus()
            TrackCompletionRate.EditValue = 0
            BarButtonItemDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        End If
    End Sub

    ''' <summary>
    ''' Loads an existing cost center for editing
    ''' </summary>
    ''' <param name="costCenterId">The ID of the cost center to load</param>
    Public Sub LoadCostCenter(costCenterId As Integer)
        Try
            _costCenter = CostCenterClass.Get(costCenterId)
            If _costCenter IsNot Nothing Then
                _isNewRecord = False
                DisplayCostCenterData()
            Else
                XtraMessageBox.Show("لم يتم العثور على مركز التكلفة المطلوب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                _isNewRecord = True
            End If
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في تحميل بيانات مركز التكلفة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Displays the cost center data in the form controls
    ''' </summary>
    Private Sub DisplayCostCenterData()
        TextEditCostID.Text = _costCenter.CostID.ToString()
        TextEditCostName.Text = _costCenter.CostName
        SearchLookUpEditCostCenterTypeID.EditValue = _costCenter.CostCenterTypeID
        If _costCenter.CostCenterImage IsNot Nothing Then
            Using ms As New MemoryStream(_costCenter.CostCenterImage)
                ImageCostCenterImage.Image = Image.FromStream(ms)
            End Using
        End If
        DateEditStartDate.EditValue = _costCenter.StartDate
        DateEditEndDate.EditValue = _costCenter.EndDate
        MemoEditNotes.Text = _costCenter.Notes
        CheckEditCostCenterStatus.Checked = If(_costCenter.CostCenterStatus.HasValue, _costCenter.CostCenterStatus.Value, False)
        SearchLookUpEditSupplier.EditValue = _costCenter.Supplier
        TrackCompletionRate.EditValue = If(_costCenter.CompletionRate.HasValue, _costCenter.CompletionRate.Value, 0)
    End Sub

    Private Function CollectFormData() As Boolean
        Try
            If String.IsNullOrWhiteSpace(TextEditCostName.Text) Then
                XtraMessageBox.Show("الرجاء إدخال اسم مركز التكلفة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                TextEditCostName.Focus()
                Return False
            End If

            If Not _isNewRecord Then
                _costCenter.CostID = Integer.Parse(TextEditCostID.Text)
            End If

            _costCenter.CostName = TextEditCostName.Text
            _costCenter.CostCenterTypeID = If(SearchLookUpEditCostCenterTypeID.EditValue IsNot Nothing, CType(SearchLookUpEditCostCenterTypeID.EditValue, Integer?), Nothing)

            ' Handle the image more safely
            If ImageCostCenterImage.Image IsNot Nothing Then
                Try
                    ' Create a new bitmap from the image to avoid format issues
                    Using newBitmap As New Bitmap(ImageCostCenterImage.Image)
                        Using ms As New MemoryStream()
                            ' Always save as JPEG which is well-supported
                            newBitmap.Save(ms, ImageFormat.Jpeg)
                            _costCenter.CostCenterImage = ms.ToArray()
                        End Using
                    End Using
                Catch ex As Exception
                    ' If there's an issue with the image, log it but continue
                    Console.WriteLine("Image processing error: " & ex.ToString())

                    ' Optionally provide a fallback
                    Using ms As New MemoryStream()
                        ' Create a small empty bitmap if you want to save something
                        Using emptyBitmap As New Bitmap(10, 10)
                            emptyBitmap.Save(ms, ImageFormat.Jpeg)
                            _costCenter.CostCenterImage = ms.ToArray()
                        End Using
                    End Using
                End Try
            Else
                ' No image selected, set to null
                _costCenter.CostCenterImage = Nothing
            End If

            _costCenter.StartDate = If(DateEditStartDate.EditValue IsNot Nothing, CType(DateEditStartDate.EditValue, Date?), Nothing)
            _costCenter.EndDate = If(DateEditEndDate.EditValue IsNot Nothing, CType(DateEditEndDate.EditValue, Date?), Nothing)
            _costCenter.Notes = MemoEditNotes.Text
            _costCenter.CostCenterStatus = CheckEditCostCenterStatus.Checked
            _costCenter.Supplier = If(SearchLookUpEditSupplier.EditValue IsNot Nothing, CType(SearchLookUpEditSupplier.EditValue, Integer?), Nothing)
            _costCenter.CompletionRate = If(TrackCompletionRate.EditValue IsNot Nothing, CType(TrackCompletionRate.EditValue, Integer?), Nothing)
            Return True
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في جمع البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Console.WriteLine(ex.ToString)
            Return False
        End Try
    End Function


    ''' <summary>
    ''' Saves the cost center data
    ''' </summary>
    Private Sub SaveCostCenter()
        If Not CollectFormData() Then Return

        Try
            If _isNewRecord Then
                ' Create new cost center
                Dim newId As Integer = _costCenter.Create()
                If newId > 0 Then
                    XtraMessageBox.Show("تم إنشاء مركز التكلفة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    _isNewRecord = False
                    TextEditCostID.Text = newId.ToString()
                    _costCenter.CostID = newId
                Else
                    XtraMessageBox.Show("فشل في إنشاء مركز التكلفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                ' Update existing cost center
                If _costCenter.Update() Then
                    XtraMessageBox.Show("تم تحديث مركز التكلفة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    XtraMessageBox.Show("فشل في تحديث مركز التكلفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في حفظ البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Deletes the current cost center
    ''' </summary>
    Private Sub DeleteCostCenter()
        If _isNewRecord Then
            XtraMessageBox.Show("لا يمكن حذف مركز تكلفة جديد", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Check if there are related records in the Journal table
            Dim sql As New SQLControl
            sql.SqlTrueAccountingRunQuery($"SELECT COUNT(*) FROM [Journal] WHERE [DocCostCenter] = {_costCenter.CostID}")
            Dim relatedRecordsCount As Integer = Convert.ToInt32(sql.SQLDS.Tables(0).Rows(0)(0))

            If relatedRecordsCount > 0 Then
                XtraMessageBox.Show("لا يمكن حذف مركز التكلفة لوجود سجلات مرتبطة في جدول اليومية", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في التحقق من السجلات المرتبطة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Dim result As DialogResult = XtraMessageBox.Show("هل أنت متأكد من حذف مركز التكلفة؟", "تأكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Try
                If CostCenterClass.Delete(_costCenter.CostID) Then
                    XtraMessageBox.Show("تم حذف مركز التكلفة بنجاح", "تم", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                Else
                    XtraMessageBox.Show("فشل في حذف مركز التكلفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                XtraMessageBox.Show("خطأ في حذف البيانات: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Clears the form and resets for a new entry
    ''' </summary>
    Private Sub ClearForm()
        _costCenter = New CostCenterClass()
        _isNewRecord = True
        TextEditCostID.Text = "جديد"
        TextEditCostName.Text = String.Empty
        SearchLookUpEditCostCenterTypeID.EditValue = Nothing
        ImageCostCenterImage.Image = Nothing
        DateEditStartDate.EditValue = Today
        DateEditEndDate.EditValue = Nothing
        MemoEditNotes.Text = String.Empty
        CheckEditCostCenterStatus.Checked = True
        SearchLookUpEditSupplier.EditValue = Nothing
        TextEditCostName.Focus()
    End Sub

    ''' <summary>
    ''' Event handler for Save button click
    ''' </summary>
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveCostCenter()
    End Sub

    ''' <summary>
    ''' Event handler for Delete button click
    ''' </summary>
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItemDelete.ItemClick
        DeleteCostCenter()
    End Sub

    ''' <summary>
    ''' Event handler for Close button click
    ''' </summary>
    Private Sub BarButtonClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonClose.ItemClick
        Close()
    End Sub

    ''' <summary>
    ''' Event handler for clicking on the image control
    ''' </summary>
    Private Sub ImageCostCenterImage_Click(sender As Object, e As EventArgs) Handles ImageCostCenterImage.DoubleClick
        Try
            Dim openFileDialog As New OpenFileDialog With {
                .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                .Title = "اختر صورة"
            }

            If openFileDialog.ShowDialog() = DialogResult.OK Then
                ImageCostCenterImage.Image = Image.FromFile(openFileDialog.FileName)
            End If
        Catch ex As Exception
            XtraMessageBox.Show("خطأ في تحميل الصورة: " & ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class