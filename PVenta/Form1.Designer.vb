<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.clientIdTextBox = New System.Windows.Forms.TextBox()
        Me.saleDetailDataGridView = New System.Windows.Forms.DataGridView()
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.id_producto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantityTextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.articleComboBox = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.clientNameTextBox = New System.Windows.Forms.TextBox()
        Me.folioTextBox = New System.Windows.Forms.TextBox()
        Me.folioLabel = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.saleDetailDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cliente"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(494, 87)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Agregar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'clientIdTextBox
        '
        Me.clientIdTextBox.Location = New System.Drawing.Point(72, 45)
        Me.clientIdTextBox.Name = "clientIdTextBox"
        Me.clientIdTextBox.Size = New System.Drawing.Size(76, 20)
        Me.clientIdTextBox.TabIndex = 2
        '
        'saleDetailDataGridView
        '
        Me.saleDetailDataGridView.AllowUserToAddRows = False
        Me.saleDetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.saleDetailDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.folio, Me.id_producto, Me.nombre, Me.cantidad, Me.precio, Me.total})
        Me.saleDetailDataGridView.Location = New System.Drawing.Point(25, 131)
        Me.saleDetailDataGridView.Name = "saleDetailDataGridView"
        Me.saleDetailDataGridView.ReadOnly = True
        Me.saleDetailDataGridView.Size = New System.Drawing.Size(644, 150)
        Me.saleDetailDataGridView.TabIndex = 3
        '
        'folio
        '
        Me.folio.HeaderText = "folio"
        Me.folio.Name = "folio"
        Me.folio.ReadOnly = True
        '
        'id_producto
        '
        Me.id_producto.HeaderText = "id_producto"
        Me.id_producto.Name = "id_producto"
        Me.id_producto.ReadOnly = True
        Me.id_producto.Visible = False
        '
        'nombre
        '
        Me.nombre.HeaderText = "nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 200
        '
        'cantidad
        '
        Me.cantidad.HeaderText = "cantidad"
        Me.cantidad.Name = "cantidad"
        Me.cantidad.ReadOnly = True
        '
        'precio
        '
        Me.precio.HeaderText = "precio"
        Me.precio.Name = "precio"
        Me.precio.ReadOnly = True
        '
        'total
        '
        Me.total.HeaderText = "total"
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'quantityTextBox
        '
        Me.quantityTextBox.Location = New System.Drawing.Point(405, 90)
        Me.quantityTextBox.Name = "quantityTextBox"
        Me.quantityTextBox.Size = New System.Drawing.Size(83, 20)
        Me.quantityTextBox.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(350, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cantidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Articulo"
        '
        'articleComboBox
        '
        Me.articleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.articleComboBox.FormattingEnabled = True
        Me.articleComboBox.Location = New System.Drawing.Point(72, 90)
        Me.articleComboBox.Name = "articleComboBox"
        Me.articleComboBox.Size = New System.Drawing.Size(260, 21)
        Me.articleComboBox.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(106, 307)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "Guardar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(189, 307)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Buscar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'clientNameTextBox
        '
        Me.clientNameTextBox.Location = New System.Drawing.Point(154, 45)
        Me.clientNameTextBox.Name = "clientNameTextBox"
        Me.clientNameTextBox.Size = New System.Drawing.Size(334, 20)
        Me.clientNameTextBox.TabIndex = 11
        '
        'folioTextBox
        '
        Me.folioTextBox.Enabled = False
        Me.folioTextBox.Location = New System.Drawing.Point(72, 12)
        Me.folioTextBox.Name = "folioTextBox"
        Me.folioTextBox.Size = New System.Drawing.Size(76, 20)
        Me.folioTextBox.TabIndex = 13
        '
        'folioLabel
        '
        Me.folioLabel.AutoSize = True
        Me.folioLabel.Location = New System.Drawing.Point(26, 12)
        Me.folioLabel.Name = "folioLabel"
        Me.folioLabel.Size = New System.Drawing.Size(29, 13)
        Me.folioLabel.TabIndex = 12
        Me.folioLabel.Text = "Folio"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(25, 307)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 14
        Me.Button5.Text = "Nuevo"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.folioTextBox)
        Me.Controls.Add(Me.folioLabel)
        Me.Controls.Add(Me.clientNameTextBox)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.articleComboBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.quantityTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.saleDetailDataGridView)
        Me.Controls.Add(Me.clientIdTextBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.saleDetailDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents clientIdTextBox As TextBox
    Friend WithEvents saleDetailDataGridView As DataGridView
    Friend WithEvents quantityTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents articleComboBox As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents clientNameTextBox As TextBox
    Friend WithEvents folio As DataGridViewTextBoxColumn
    Friend WithEvents id_producto As DataGridViewTextBoxColumn
    Friend WithEvents nombre As DataGridViewTextBoxColumn
    Friend WithEvents cantidad As DataGridViewTextBoxColumn
    Friend WithEvents precio As DataGridViewTextBoxColumn
    Friend WithEvents total As DataGridViewTextBoxColumn
    Friend WithEvents folioTextBox As TextBox
    Friend WithEvents folioLabel As Label
    Friend WithEvents Button5 As Button
End Class
