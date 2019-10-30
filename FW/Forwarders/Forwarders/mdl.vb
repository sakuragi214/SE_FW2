Imports System.Data.SqlClient

Module mdl
    Public conn As New SqlConnection("Data Source=LAPTOP-SQ6GSPQV; Initial Catalog=FW;Integrated Security=True;")
    Public adapter As New SqlDataAdapter
    Public ds As DataSet
    Public connStr As String
End Module
