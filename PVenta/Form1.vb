
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
        GetCurrentFolio()
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

        saleDetailDataGridView.Rows.Add(1, articleId, articleName, finalQuantity, price, total)
        FolioAssignement()
    End Sub

    Private Sub FolioAssignement()
        For i = 0 To saleDetailDataGridView.RowCount - 1
            saleDetailDataGridView.Rows(i).Cells("folio").Value = folioTextBox.Text.Trim & i + 1
        Next
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
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles clientIdTextBox.KeyPress
        If e.KeyChar = Chr(13) Then

            Dim query As String

            query = "SELECT id_cliente, nombre FROM cat_clientes WHERE id_cliente= " & clientIdTextBox.Text.Trim

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

    Private Sub GetCurrentFolio()
        dataReader = consulta("SELECT ISNULL(MAX(folio), 0) + 1 AS folio_actual FROM ventas")
        If dataReader.HasRows Then
            If dataReader.Read Then
                folioTextBox.Text = dataReader("folio_actual")
            End If
        End If
        cerrar()
    End Sub

    Public Function Abc(consulta As String)
        conexion.ConnectionString = connectionString
        Dim exito As Boolean = False
        If (abrir()) Then
            Try
                comando.CommandText = consulta
                comando.Connection = conexion
                comando.CommandTimeout = 0
                comando.ExecuteNonQuery()
                exito = True
            Catch ex As SqlClient.SqlException
                MessageBox.Show("Error al realizar la funcion ABC. " + ex.Message, "Sistema DSD", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        cerrar()
        Return exito
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim query As String
        Dim saleId As Integer

        query = "INSERT INTO ventas (id_cliente, folio, fecha) VALUES (" & clientIdTextBox.Text.Trim & ", " & folioTextBox.Text.Trim & ", GETDATE())"
        If Abc(query) Then
            dataReader = consulta("SELECT IDENT_CURRENT ('ventas') AS id")
            If dataReader.Read() Then
                saleId = dataReader("id")
                cerrar()
                If (saleId > 0) Then
                    query = QuerySaleDetailBuilder(saleId)
                    If Abc(query) Then
                        MsgBox("Venta guardada con exito")
                    End If
                End If
                cerrar()
            Else
                cerrar()
            End If
        End If

    End Sub

    Private Function QuerySaleDetailBuilder(ByVal SaleId As Integer) As String

        Dim query As String
        Dim folio As Integer
        Dim articleId As Integer
        Dim quantity As Integer
        Dim total As Double

        query = ""

        For i = 0 To saleDetailDataGridView.RowCount - 1

            With saleDetailDataGridView.Rows(i)
                folio = .Cells("folio").Value
                articleId = .Cells("id_producto").Value
                quantity = .Cells("cantidad").Value
                total = .Cells("total").Value
            End With

            query &= "INSERT INTO ventas_detalle VALUES (" & SaleId & ", " & folio & ", " & articleId & ", " & quantity & ", " & total & "); "
        Next

        Return query

    End Function

    Private Sub saleDetailDataGridView_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles saleDetailDataGridView.RowsRemoved
        FolioAssignement()
    End Sub

    Private Sub ClientIdTextBox_TextChanged(sender As Object, e As EventArgs) Handles clientIdTextBox.TextChanged
        clientNameTextBox.Text = ""
    End Sub

    Private Sub FolioTextBox_TextChanged(sender As Object, e As EventArgs) Handles folioTextBox.TextChanged
        Clear()
    End Sub

    Private Sub folioTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles folioTextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim query As String

            query = "SELECT ven.id_venta, ven.folio, ven.id_cliente, cli.nombre AS nombre_cliente, " &
                    "ven.fecha, det.folio AS folio_detalle, det.id_articulo, art.nombre AS nombre_articulo, det.cantidad, " &
                    "art.precio_unitario, det.subtotal AS total " &
                    "FROM ventas ven " &
                    "INNER JOIN ventas_detalle det ON det.id_venta = ven.id_venta " &
                    "LEFT JOIN cat_articulos art ON art.id_articulo = det.id_articulo " &
                    "LEFT JOIN cat_clientes cli ON cli.id_cliente = ven.id_cliente " &
                    "WHERE ven.folio = " & folioTextBox.Text

            Clear()
            dataReader = consulta(query)

            If dataReader.HasRows Then

                While dataReader.Read
                    clientIdTextBox.Text = dataReader("id_cliente")
                    clientNameTextBox.Text = dataReader("nombre_cliente")
                    articleComboBox.SelectedValue = dataReader("id_articulo")

                    saleDetailDataGridView.Rows.Add(dataReader("folio_detalle"),
                                                        dataReader("id_articulo"),
                                                        dataReader("nombre_articulo"),
                                                        dataReader("cantidad"),
                                                        dataReader("precio_unitario"),
                                                        dataReader("total"))

                End While

            Else
                MsgBox("No se encontro nota de venta")
            End If
            cerrar()
        End If
    End Sub

    Private Sub Clear()
        clientIdTextBox.Text = ""
        clientNameTextBox.Text = ""
        articleComboBox.SelectedIndex = 0
        quantityTextBox.Text = ""
        saleDetailDataGridView.Rows.Clear()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Clear()
        GetCurrentFolio()
        folioTextBox.Enabled = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        folioTextBox.Text = ""
        folioTextBox.Enabled = True
    End Sub
End Class
