Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Private lblNama, lblNIM, lblJK, lblProdi As Label
    Private txtNama, txtNIM As TextBox
    Private rbLaki, rbPerempuan As RadioButton
    Private cmbProdi As ComboBox
    Private btnTambah As Button
    Private lvData As ListView

    Structure Mahasiswa
        Dim Nama As String
        Dim NIM As String
        Dim JenisKelamin As String
        Dim Prodi As String
    End Structure

    Dim daftarMahasiswa(99) As Mahasiswa
    Dim index As Integer = 0

    Public Sub New()
        Me.Text = "FORM MAHASISWA FIKOM UBK"
        Me.Size = New Size(550, 500)
        Me.StartPosition = FormStartPosition.CenterScreen

        lblNama = New Label() With {.Text = "Nama", .Location = New Point(20, 20), .AutoSize = True}
        txtNama = New TextBox() With {.Location = New Point(150, 18), .Width = 300}

        lblNIM = New Label() With {.Text = "NIM", .Location = New Point(20, 60), .AutoSize = True}
        txtNIM = New TextBox() With {.Location = New Point(150, 58), .Width = 300}

        lblJK = New Label() With {.Text = "Jenis Kelamin", .Location = New Point(20, 100), .AutoSize = True}
        rbLaki = New RadioButton() With {.Text = "Laki-laki", .Location = New Point(150, 98)}
        rbPerempuan = New RadioButton() With {.Text = "Perempuan", .Location = New Point(280, 98)}


        lblProdi = New Label() With {.Text = "Prodi", .Location = New Point(20, 140), .AutoSize = True}
        cmbProdi = New ComboBox() With {.Location = New Point(150, 138), .Width = 300, .DropDownStyle = ComboBoxStyle.DropDownList}
        cmbProdi.Items.AddRange(New String() {"Sistem Informasi", "Sistem Komputer"})
        cmbProdi.SelectedIndex = 0

        btnTambah = New Button() With {
            .Text = "Tambah",
            .Location = New Point(150, 180),
            .Width = 100
        }
        AddHandler btnTambah.Click, AddressOf btnTambah_Click

        lvData = New ListView() With {
            .Location = New Point(20, 230),
            .Size = New Size(500, 200),
            .View = View.Details,
            .FullRowSelect = True
        }
        lvData.Columns.Add("No", 40)
        lvData.Columns.Add("Nama", 120)
        lvData.Columns.Add("NIM", 100)
        lvData.Columns.Add("Gender", 100)
        lvData.Columns.Add("Prodi", 120)

        Me.Controls.AddRange({
            lblNama, txtNama, lblNIM, txtNIM, lblJK, rbLaki, rbPerempuan,
            lblProdi, cmbProdi, btnTambah, lvData
        })
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs)
        If index >= daftarMahasiswa.Length Then
            MessageBox.Show("Data penuh!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim jk As String = If(rbLaki.Checked, "Laki-laki", If(rbPerempuan.Checked, "Perempuan", ""))

        If txtNama.Text = "" Or txtNIM.Text = "" Or jk = "" Then
            MessageBox.Show("Harap lengkapi semua data!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        daftarMahasiswa(index).Nama = txtNama.Text
        daftarMahasiswa(index).NIM = txtNIM.Text
        daftarMahasiswa(index).JenisKelamin = jk
        daftarMahasiswa(index).Prodi = cmbProdi.SelectedItem.ToString()

        Dim item As New ListViewItem((index + 1).ToString())
        item.SubItems.Add(daftarMahasiswa(index).Nama)
        item.SubItems.Add(daftarMahasiswa(index).NIM)
        item.SubItems.Add(daftarMahasiswa(index).JenisKelamin)
        item.SubItems.Add(daftarMahasiswa(index).Prodi)
        lvData.Items.Add(item)

        txtNama.Clear()
        txtNIM.Clear()
        rbLaki.Checked = False
        rbPerempuan.Checked = False
        cmbProdi.SelectedIndex = 0
        txtNama.Focus()

        index += 1
    End Sub
End Class
