
Imports System.Data.SqlClient

Public Class Form1

    Dim conexion As New SqlClient.SqlConnection
    Dim comando As New SqlClient.SqlCommand
    Dim adaptador As New SqlClient.SqlDataAdapter
    Dim resultado As SqlClient.SqlDataReader = Nothing
    Dim misDatos As New DataSet
    Public conectar As New SqlClient.SqlConnection

    Dim dataAdapter As SqlDataAdapter
    Dim dataReader As SqlDataReader
    Dim dataSet As New DataSet

    Dim connectionString As String = "server=172.16.1.109; user id=sa; password=Dsdsistemas2012; database=dsd_mazatlan;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ClientsLoad()
    End Sub

    Private Function consulta(con As String)
        conexion.Close()
        conexion.ConnectionString = connectionString
        Try
            If (abrir()) Then
                comando.CommandText = con
                comando.Connection = conexion
                comando.CommandTimeout = 0
                resultado = comando.ExecuteReader()
            End If
        Catch ex As SqlClient.SqlException
            MessageBox.Show("Error al realizar la funcion Consulta. " + ex.Message, "Sistema DSD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return resultado
    End Function

    Private Function abrir()
        Dim exito As Boolean = False
        Try
            If conexion.State = ConnectionState.Closed Then
                conexion.Open()
                exito = True
            End If
        Catch ex As SqlClient.SqlException
            MessageBox.Show("Error al conectar al Servidor. " + ex.Message, "Sistema DSD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return exito
    End Function

    Public Function cerrar()
        Dim exito As Boolean = False
        Try
            If conexion.State = ConnectionState.Open Then
                conexion.Close()
                exito = True
            End If
        Catch ex As SqlClient.SqlException
            MessageBox.Show("Error al desconectar al Servidor. " + ex.Message, "Sistema DSD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return exito
    End Function

    Private Function llenar_tabla(con As String)
        conexion.ConnectionString = connectionString
        Try
            If (abrir()) Then
                comando.CommandText = con
                comando.Connection = conexion
                comando.CommandTimeout = 0
                adaptador.SelectCommand = comando
            End If
        Catch ex As SqlClient.SqlException
            MessageBox.Show("Error al realizar la funcion llenar_tabla. " + ex.Message, "Sistema DSD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return adaptador
    End Function

    Private Sub ClientsLoad()

        If dataSet.Tables.Contains("cat_productos") Then dataSet.Tables("cat_productos").Clear()

        dataAdapter = llenar_tabla("SELECT TOP(10) c.id_producto, c.nombre FROM cat_productos c WHERE c.activo = 1 ORDER BY c.id_grupo_proveedor, c.id_linea")
        dataAdapter.Fill(dataSet, "cat_productos")
        cerrar()

        clientComboBox.DataSource = dataSet.Tables("cat_productos")
        'clientComboBox.DataSource = DataHelper.LoadDataTable
        clientComboBox.DisplayMember = "nombre"
        clientComboBox.ValueMember = "id_producto"


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then

            Dim query As String
            Dim hasProduct As Boolean

            query = "SELECT nombre FROM cat_productos WHERE id_producto = " & TextBox1.Text.Trim

            dataReader = consulta(query)
            If dataReader.HasRows Then
                If dataReader.Read Then
                    MsgBox(dataReader("nombre"))
                End If
            Else
                MsgBox("no se encontro producto")
            End If
            cerrar()

        End If
    End Sub
End Class
