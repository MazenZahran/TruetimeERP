Imports GMap.NET.MapProviders
Imports GMap.NET.WindowsForms.Markers
Imports GMap.NET
Imports GMap.NET.WindowsForms

Public Class AttTransOnMap
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMaps.Instance.Mode = AccessMode.ServerOnly
        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMapControl1.Position = New GMap.NET.PointLatLng(TextEdit1.Text.Trim(), TextEdit2.Text.Trim())
        GMapControl1.ShowCenter = False

        Dim markers As GMapOverlay = New GMapOverlay("Markers")
        Dim marker As GMapMarker = New GMarkerGoogle(New PointLatLng(TextEdit1.Text.Trim(), TextEdit2.Text.Trim()), GMarkerGoogleType.red)
        markers.Markers.Add(marker)
        GMapControl1.Overlays.Add(markers)
        GMapControl1.MinZoom = 5
        GMapControl1.MaxZoom = 100
        GMapControl1.Zoom = 20
        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver




    End Sub

    Private Sub AttTransOnMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMaps.Instance.Mode = AccessMode.ServerOnly
        GMapControl1.MapProvider = GoogleMapProvider.Instance
        GMapControl1.Position = New GMap.NET.PointLatLng(TextEdit1.Text.Trim(), TextEdit2.Text.Trim())
        GMapControl1.ShowCenter = False

        Dim markers As GMapOverlay = New GMapOverlay("Markers")
        Dim marker As GMapMarker = New GMarkerGoogle(New PointLatLng(TextEdit1.Text.Trim(), TextEdit2.Text.Trim()), GMarkerGoogleType.red)
        markers.Markers.Add(marker)
        GMapControl1.Overlays.Add(markers)
        GMapControl1.MinZoom = 5
        GMapControl1.MaxZoom = 100
        GMapControl1.Zoom = 20
        marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
    End Sub

End Class