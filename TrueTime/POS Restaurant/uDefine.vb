Imports System.Runtime.InteropServices

Public Class uDefine
    <DllImport("pcboxdllv1.dll")>
    Public Shared Function pcbox_InitAndOpenComm(ByVal comn As Integer) As Integer
    End Function
    <DllImport("pcboxdllv1.dll")>
    Public Shared Function pcbox_CloseComm() As Integer
    End Function
    <DllImport("pcboxdllv1.dll")>
    Public Shared Sub pcbox_tare()
    End Sub
    <DllImport("pcboxdllv1.dll")>
    Public Shared Sub pcbox_zero()
    End Sub
    <DllImport("pcboxdllv1.dll")>
    Public Shared Sub pcbox_reset()
    End Sub
    <DllImport("pcboxdllv1.dll")>
    Public Shared Function pcbox_GetWeight(ByRef NetWeight As Integer, ByRef TareWeight As Integer, ByRef IsStable As Integer, ByRef AtZero As Integer, ByRef AtTare As Integer) As Integer
    End Function





End Class
