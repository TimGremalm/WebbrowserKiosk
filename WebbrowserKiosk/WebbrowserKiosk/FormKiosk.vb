Imports System.Text.RegularExpressions

Public Class FormKiosk
	Private InputBuffer As String = ""

	Private Sub FormKiosk_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub

	Private Sub WebBrowser1_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles WebBrowser1.PreviewKeyDown
		Dim KeyString As String = Chr(e.KeyCode)

		'If digit, add to buffer
		Dim Pattern As String = "^[0-9]+$"
		Dim r As Regex = New Regex(Pattern, RegexOptions.IgnoreCase)
		Dim m As Match = r.Match(KeyString)
		If m.Success Then
			InputBuffer &= KeyString
		End If

		'If enter, navigate to URL
		If e.KeyCode = Keys.Return Then
			WebBrowser1.Navigate("http://192.168.0.1:8000/profile/" & InputBuffer)
			InputBuffer = ""
		End If
	End Sub
End Class