Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.DashboardCommon
Imports DevExpress.DataAccess
Imports DevExpress.XtraSplashScreen

Namespace Win_Dashboards
    Partial Public Class Dashboard3
        Inherits DevExpress.DashboardCommon.Dashboard
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Dashboard3_DataLoading(sender As Object, e As DashboardDataLoadingEventArgs) Handles Me.DataLoading
            OverlayWindowOptions.Default.UseDirectX = False
        End Sub
    End Class
End Namespace