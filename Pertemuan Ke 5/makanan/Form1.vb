Public Class Form1
    Dim cmbMakanan As ComboBox
    Dim cmbMinuman As ComboBox
    Dim txtPorsiMakanan As TextBox
    Dim txtPorsiMinuman As TextBox
    Dim chkMinuman As CheckBox
    Dim btnHitung As Button
    Dim lblHargaMakanan As Label
    Dim lblHargaMinuman As Label
    Dim lblTotal As Label

    Dim hargaMakanan As Integer
    Dim hargaMinuman As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "RESO RAKA ANUGERAH PRATAMA"
        Me.Size = New Size(400, 350)

        Dim lblMakanan As New Label With {.Text = "Pilih Makanan:", .Location = New Point(20, 20)}
        Me.Controls.Add(lblMakanan)

        cmbMakanan = New ComboBox With {
            .Location = New Point(150, 20),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbMakanan.Items.AddRange(New String() {"Nasi Uduk", "Bakso", "Mie Goreng"})
        AddHandler cmbMakanan.SelectedIndexChanged, AddressOf cmbMakanan_SelectedIndexChanged
        Me.Controls.Add(cmbMakanan)

        lblHargaMakanan = New Label With {
            .Text = "Rp. 0",
            .Location = New Point(150, 50)
        }
        Me.Controls.Add(lblHargaMakanan)

        Dim lblPorsiMakan As New Label With {.Text = "Porsi Makanan:", .Location = New Point(20, 80)}
        Me.Controls.Add(lblPorsiMakan)
        txtPorsiMakanan = New TextBox With {.Location = New Point(150, 80)}
        Me.Controls.Add(txtPorsiMakanan)

        chkMinuman = New CheckBox With {
            .Text = "+ Tambah Minuman",
            .Location = New Point(20, 120)
        }
        AddHandler chkMinuman.CheckedChanged, AddressOf chkMinuman_CheckedChanged
        Me.Controls.Add(chkMinuman)

        Dim lblMinuman As New Label With {.Text = "Pilih Minuman:", .Location = New Point(20, 150)}
        Me.Controls.Add(lblMinuman)
        cmbMinuman = New ComboBox With {
            .Location = New Point(150, 150),
            .DropDownStyle = ComboBoxStyle.DropDownList,
            .Enabled = False
        }
        cmbMinuman.Items.AddRange(New String() {"Es Jeruk", "Teh Manis", "Air Mineral"})
        AddHandler cmbMinuman.SelectedIndexChanged, AddressOf cmbMinuman_SelectedIndexChanged
        Me.Controls.Add(cmbMinuman)

        lblHargaMinuman = New Label With {
            .Text = "Rp. 0",
            .Location = New Point(150, 180)
        }
        Me.Controls.Add(lblHargaMinuman)

        Dim lblPorsiMinum As New Label With {.Text = "Porsi Minuman:", .Location = New Point(20, 210)}
        Me.Controls.Add(lblPorsiMinum)
        txtPorsiMinuman = New TextBox With {
            .Location = New Point(150, 210),
            .Enabled = False
        }
        Me.Controls.Add(txtPorsiMinuman)

        btnHitung = New Button With {
            .Text = "Hitung Total",
            .Location = New Point(20, 250)
        }
        AddHandler btnHitung.Click, AddressOf btnHitung_Click
        Me.Controls.Add(btnHitung)

        lblTotal = New Label With {
            .Text = "Total: Rp. 0",
            .Font = New Font("Arial", 10, FontStyle.Bold),
            .ForeColor = Color.Green,
            .Location = New Point(150, 250),
            .AutoSize = True
        }
        Me.Controls.Add(lblTotal)

        cmbMakanan.SelectedIndex = 0
        cmbMinuman.SelectedIndex = 0
    End Sub

    Private Sub cmbMakanan_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case cmbMakanan.Text
            Case "Nasi Uduk"
                hargaMakanan = 5000
            Case "Bakso"
                hargaMakanan = 15000
            Case "Mie Goreng"
                hargaMakanan = 8000
        End Select
        lblHargaMakanan.Text = "Rp. " & hargaMakanan.ToString("N0")
    End Sub

    Private Sub cmbMinuman_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case cmbMinuman.Text
            Case "Es Jeruk"
                hargaMinuman = 3000
            Case "Teh Manis"
                hargaMinuman = 2500
            Case "Air Mineral"
                hargaMinuman = 2000
        End Select
        lblHargaMinuman.Text = "Rp. " & hargaMinuman.ToString("N0")
    End Sub

    Private Sub chkMinuman_CheckedChanged(sender As Object, e As EventArgs)
        cmbMinuman.Enabled = chkMinuman.Checked
        txtPorsiMinuman.Enabled = chkMinuman.Checked
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs)
        Dim porsiMakan As Integer = Val(txtPorsiMakanan.Text)
        Dim porsiMinum As Integer = Val(txtPorsiMinuman.Text)
        Dim total As Integer = hargaMakanan * porsiMakan

        If chkMinuman.Checked Then
            total += hargaMinuman * porsiMinum
        End If

        lblTotal.Text = "Total: Rp. " & total.ToString("N0")
    End Sub
End Class
