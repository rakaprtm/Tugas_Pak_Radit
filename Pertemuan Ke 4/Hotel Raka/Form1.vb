Public Class Form1
    ' Komponen UI
    Dim cmbJenisKamar As ComboBox
    Dim txtHarga As TextBox
    Dim txtLama As TextBox
    Dim txtBayar As TextBox
    Dim txtBiaya As TextBox
    Dim txtKembali As TextBox
    Dim btnHitung As Button
    Dim btnReset As Button

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set ukuran form
        Me.Text = "Aplikasi Penginapan"
        Me.Size = New Size(400, 400)

        ' Label dan ComboBox Jenis Kamar
        Dim lblJenisKamar As New Label With {.Text = "Jenis Kamar", .Location = New Point(20, 20)}
        Me.Controls.Add(lblJenisKamar)
        cmbJenisKamar = New ComboBox With {
            .Location = New Point(150, 20),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        cmbJenisKamar.Items.AddRange(New String() {"VIP", "Kelas I", "Kelas II", "Kelas III"})
        AddHandler cmbJenisKamar.SelectedIndexChanged, AddressOf cmbJenisKamar_SelectedIndexChanged
        Me.Controls.Add(cmbJenisKamar)

        ' Label dan TextBox Harga
        Dim lblHarga As New Label With {.Text = "Harga per Malam", .Location = New Point(20, 60)}
        Me.Controls.Add(lblHarga)
        txtHarga = New TextBox With {.Location = New Point(150, 60), .ReadOnly = True}
        Me.Controls.Add(txtHarga)

        ' Label dan TextBox Lama Inap
        Dim lblLama As New Label With {.Text = "Lama Inap (hari)", .Location = New Point(20, 100)}
        Me.Controls.Add(lblLama)
        txtLama = New TextBox With {.Location = New Point(150, 100)}
        Me.Controls.Add(txtLama)

        ' Label dan TextBox Biaya
        Dim lblBiaya As New Label With {.Text = "Total Biaya", .Location = New Point(20, 140)}
        Me.Controls.Add(lblBiaya)
        txtBiaya = New TextBox With {.Location = New Point(150, 140), .ReadOnly = True}
        Me.Controls.Add(txtBiaya)

        ' Label dan TextBox Bayar
        Dim lblBayar As New Label With {.Text = "Jumlah Bayar", .Location = New Point(20, 180)}
        Me.Controls.Add(lblBayar)
        txtBayar = New TextBox With {.Location = New Point(150, 180)}
        Me.Controls.Add(txtBayar)

        ' Label dan TextBox Kembali
        Dim lblKembali As New Label With {.Text = "Kembalian", .Location = New Point(20, 220)}
        Me.Controls.Add(lblKembali)
        txtKembali = New TextBox With {.Location = New Point(150, 220), .ReadOnly = True}
        Me.Controls.Add(txtKembali)

        ' Tombol Hitung
        btnHitung = New Button With {.Text = "Hitung", .Location = New Point(50, 270)}
        AddHandler btnHitung.Click, AddressOf btnHitung_Click
        Me.Controls.Add(btnHitung)

        ' Tombol Reset
        btnReset = New Button With {.Text = "Reset", .Location = New Point(150, 270)}
        AddHandler btnReset.Click, AddressOf btnReset_Click
        Me.Controls.Add(btnReset)
    End Sub

    Private Sub cmbJenisKamar_SelectedIndexChanged(sender As Object, e As EventArgs)
        Select Case cmbJenisKamar.Text
            Case "VIP"
                txtHarga.Text = 750000
            Case "Kelas I"
                txtHarga.Text = 500000
            Case "Kelas II"
                txtHarga.Text = 300000
            Case "Kelas III"
                txtHarga.Text = 150000
            Case Else
                txtHarga.Text = ""
        End Select
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs)
        Dim lama, harga, bayar, total, kembali As Integer

        If Not Integer.TryParse(txtLama.Text, lama) OrElse
           Not Integer.TryParse(txtHarga.Text, harga) OrElse
           Not Integer.TryParse(txtBayar.Text, bayar) Then
            MessageBox.Show("Masukkan angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        total = lama * harga
        kembali = bayar - total

        txtBiaya.Text = total.ToString("N0")
        txtKembali.Text = kembali.ToString("N0")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        cmbJenisKamar.SelectedIndex = -1
        txtHarga.Clear()
        txtLama.Clear()
        txtBayar.Clear()
        txtBiaya.Clear()
        txtKembali.Clear()
    End Sub
End Class
