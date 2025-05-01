Public Class Form1
    Dim txtNamaBarang, txtJumlah, txtHarga, txtBayar, txtTotal, txtKembali As TextBox
    Dim btHitung, btBaru, btKeluar As Button

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Penjualan Barang"
        Me.Size = New Size(420, 400)
        Me.StartPosition = FormStartPosition.CenterScreen

        Dim labelNames = {"Nama Barang", "Jumlah", "Harga", "Bayar", "Total", "Kembali"}
        Dim textBoxes = New List(Of TextBox)
        Dim y As Integer = 20

        For i = 0 To labelNames.Length - 1
            Dim lbl = New Label With {.Text = labelNames(i), .Location = New Point(20, y), .AutoSize = True}
            Dim txt = New TextBox With {.Location = New Point(150, y - 2), .Width = 220}
            If labelNames(i) = "Total" Or labelNames(i) = "Kembali" Then txt.ReadOnly = True
            textBoxes.Add(txt)
            Me.Controls.AddRange({lbl, txt})
            y += 40
        Next

        txtNamaBarang = textBoxes(0)
        txtJumlah = textBoxes(1)
        txtHarga = textBoxes(2)
        txtBayar = textBoxes(3)
        txtTotal = textBoxes(4)
        txtKembali = textBoxes(5)

        btHitung = New Button With {.Text = "Hitung", .Location = New Point(20, y), .Width = 100}
        btBaru = New Button With {.Text = "Baru", .Location = New Point(140, y), .Width = 100}
        btKeluar = New Button With {.Text = "Keluar", .Location = New Point(260, y), .Width = 100}

        AddHandler btHitung.Click, AddressOf btHitung_Click
        AddHandler btBaru.Click, AddressOf btBaru_Click
        AddHandler btKeluar.Click, AddressOf btKeluar_Click

        Me.Controls.AddRange({btHitung, btBaru, btKeluar})
    End Sub

    Private Sub btHitung_Click(sender As Object, e As EventArgs)
        Dim jumlah = Val(txtJumlah.Text)
        Dim harga = Val(txtHarga.Text)
        Dim bayar = Val(txtBayar.Text)
        Dim total = jumlah * harga
        Dim kembali = bayar - total
        txtTotal.Text = total.ToString("N0")
        txtKembali.Text = kembali.ToString("N0")
    End Sub

    Private Sub btBaru_Click(sender As Object, e As EventArgs)
        txtNamaBarang.Clear()
        txtJumlah.Clear()
        txtHarga.Clear()
        txtBayar.Clear()
        txtTotal.Clear()
        txtKembali.Clear()
        txtNamaBarang.Focus()
    End Sub

    Private Sub btKeluar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class
