Public Class Form1
    Inherits Form

    Private lblNama, lblTTL, lblAlamat, lblKampus As Label
    Private txtNama, txtTTL, txtAlamat, txtKampus As TextBox
    Private btnTampil As Button

    Public Sub New()
        Me.Text = "Form Biodata Raka"
        Me.Size = New Size(400, 300)
        Me.StartPosition = FormStartPosition.CenterScreen

        lblNama = New Label() With {.Text = "NAMA", .Location = New Point(20, 20), .AutoSize = True}
        txtNama = New TextBox() With {.Location = New Point(120, 18), .Width = 200}

        lblTTL = New Label() With {.Text = "TTL", .Location = New Point(20, 60), .AutoSize = True}
        txtTTL = New TextBox() With {.Location = New Point(120, 58), .Width = 200}

        lblAlamat = New Label() With {.Text = "ALAMAT", .Location = New Point(20, 100), .AutoSize = True}
        txtAlamat = New TextBox() With {.Location = New Point(120, 98), .Width = 200}

        lblKampus = New Label() With {.Text = "KAMPUS", .Location = New Point(20, 140), .AutoSize = True}
        txtKampus = New TextBox() With {.Location = New Point(120, 138), .Width = 200}

        btnTampil = New Button() With {
            .Text = "TAMPILKAN",
            .Location = New Point(120, 180),
            .Width = 100
        }
        AddHandler btnTampil.Click, AddressOf btnTampil_Click

        Me.Controls.AddRange({lblNama, txtNama, lblTTL, txtTTL, lblAlamat, txtAlamat,
                              lblKampus, txtKampus, btnTampil})
    End Sub

    Private Sub btnTampil_Click(sender As Object, e As EventArgs)
        Dim nama As String = txtNama.Text
        Dim ttl As String = txtTTL.Text
        Dim alamat As String = txtAlamat.Text
        Dim kampus As String = txtKampus.Text

        Dim hasil As String = "BIODATA RAKA" & vbCrLf &
                              "NAMA    : " & nama & vbCrLf &
                              "TTL     : " & ttl & vbCrLf &
                              "AlAMAT  : " & alamat & vbCrLf &
                              "KAMPUS  : " & kampus

        MessageBox.Show(hasil, "Biodata")
    End Sub
End Class
