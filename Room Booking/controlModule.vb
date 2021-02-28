Imports System.Data
Imports System.Data.SqlClient

Module controlModule
    Public strCon As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anshad V\source\repos\Room Booking\Room Booking\Database1.mdf;Integrated Security=SSPI"
    Public connection As SqlConnection
    Public cmd As SqlCommand
    Public datast As DataSet

    Public bindingsrc As BindingSource
    Public reader As SqlDataAdapter
    Public sql As String
End Module
