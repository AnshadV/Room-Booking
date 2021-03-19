Imports System.Data
Imports System.Data.SqlClient

Module controlModule
    Public str As String = " Data Source = (LocalDB) \ MSSQLLocalDB;AttachDbFilename=" & Application.StartupPath & "\Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True"
    Dim Conn As New SqlConnection(str)
    Public connection As SqlConnection
    Public cmd As SqlCommand
    Public datast As DataSet

    Public bindingsrc As BindingSource
    Public reader As SqlDataAdapter
    Public sql As String
End Module
