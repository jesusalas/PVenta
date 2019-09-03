
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

    Dim connectionString As String = "server=DESKTOP-3Q5HT2L\SQLEXPRESS; user id=sa; password=jsalas_bd; database=test;"

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

        If dataSet.Tables.Contains("cat_articulos") Then dataSet.Tables("cat_articulos").Clear()

        dataAdapter = llenar_tabla("SELECT id_articulo, nombre FROM cat_articulos")
        dataAdapter.Fill(dataSet, "cat_articulos")
        cerrar()

        articleComboBox.DataSource = dataSet.Tables("cat_articulos")
        articleComboBox.DisplayMember = "nombre"
        articleComboBox.ValueMember = "id_articulo"

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'saleDetailDataGridView.Rows.Add()
        'saleDetailDataGridView.Rows(0).Cells("cantidad").Value = 1
        Dim articleId As Integer = articleComboBox.SelectedValue
        Dim articleName As String = articleComboBox.Text
        Dim price As Double = 5.0
        Dim quantity As Integer = quantityTextBox.Text.Trim
        Dim finalQuantity = quantity + GetQuantityAlreadyExists(articleId)
        Dim total As Double = finalQuantity * price

        saleDetailDataGridView.Rows.Add(articleId, articleName, finalQuantity, price, total)

    End Sub

    Private Function GetQuantityAlreadyExists(ByVal productId As Integer) As Double

        Dim quantity As Double

        For i = 0 To saleDetailDataGridView.RowCount - 1
            If saleDetailDataGridView.Rows(i).Cells("id_producto").Value = productId Then
                quantity = saleDetailDataGridView.Rows(i).Cells("cantidad").Value
                saleDetailDataGridView.Rows.RemoveAt(i)
                Exit For
            End If
        Next

        Return quantity

    End Function
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then

            Dim query As String
            Dim hasProduct As Boolean

            query = "SELECT id_cliente, nombre FROM cat_clientes WHERE id_cliente= " & TextBox1.Text.Trim

            dataReader = consulta(query)
            If dataReader.HasRows Then
                If dataReader.Read Then
                    clientNameTextBox.Text = dataReader("nombre")
                End If
            Else
                MsgBox("no se encontro producto")
            End If
            cerrar()

        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
