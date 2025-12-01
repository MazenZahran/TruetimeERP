Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Native
Imports DevExpress.XtraReports.UI

Namespace SinglePageReport
	Public NotInheritable Class SinglePageHelper
		Private Sub New()
		End Sub
		Public Shared Sub GenerateSinglePageReport(ByVal report As XtraReport)
			Dim sumHeight As Single = 0

			report.CreateDocument()

			Dim pageSettings As XtraPageSettingsBase = report.PrintingSystem.PageSettings

			XtraPageSettingsBase.ApplyPageSettings(pageSettings, PaperKind.Custom, New Size(pageSettings.Bounds.Width, pageSettings.Bounds.Height * report.Pages.Count), pageSettings.Margins, pageSettings.MinMargins, pageSettings.Landscape)

			Dim iterator As New NestedBrickIterator(report.Pages(0).InnerBricks)
			Do While iterator.MoveNext()
				If TypeOf iterator.CurrentBrick Is VisualBrick Then
					Dim brick As VisualBrick = CType(iterator.CurrentBrick, VisualBrick)
					Dim bottomPos As Single = brick.Rect.Bottom

					If bottomPos > sumHeight Then
						sumHeight = bottomPos
					End If
				End If
			Loop

			sumHeight = GraphicsUnitConverter.Convert(sumHeight, GraphicsUnit.Document, GraphicsUnit.Inch) * 100

			Dim totalPageHeight As Integer = pageSettings.Margins.Top + pageSettings.Margins.Bottom + Convert.ToInt32(sumHeight)

			XtraPageSettingsBase.ApplyPageSettings(pageSettings, PaperKind.Custom, New Size(pageSettings.Bounds.Width, totalPageHeight), pageSettings.Margins, pageSettings.MinMargins, pageSettings.Landscape)
		End Sub
	End Class
End Namespace

