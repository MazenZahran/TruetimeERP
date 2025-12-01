Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraSplashScreen
Imports System.Drawing
'...
Class CustomOverlayPainter
    Inherits OverlayWindowPainterBase
    'Defines the string’s font.
    Shared ReadOnly drawFont As Font

    Shared Sub New()
        drawFont = New Font("Tahoma", 18)
    End Sub

    Protected Overrides Sub Draw(context As OverlayWindowCustomDrawContext)
        'The Handled event parameter should be set to true  
        'to disable the default drawing algorithm.
        context.Handled = True
        'Provides access to the drawing surface. 
        Dim cache As GraphicsCache = context.DrawArgs.Cache
        'Adjust the TextRenderingHint option 
        'to improve the image quality. 
        cache.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias
        'Overlapped control bounds.
        Dim bounds As Rectangle = context.DrawArgs.Bounds
        'Draws the default background.  
        context.DrawBackground()
        'Create the string to draw. 
        Dim drawString As String = "Please wait..."
        'Get the system black brush. 
        Dim drawBrush As Brush = Brushes.Black
        'Calculate the size of the message string. 
        Dim textSize As SizeF = cache.CalcTextSize(drawString, drawFont)
        'A point that specifies the upper-left corner of the rectangle where the string should be drawn.
        Dim drawPoint As PointF = New PointF(bounds.Left + bounds.Width / 2 - textSize.Width / 2, bounds.Top + bounds.Height / 2 - textSize.Height / 2)
        'Draw the string on the screen.
        cache.DrawString(drawString, drawFont, drawBrush, drawPoint)
    End Sub
End Class
