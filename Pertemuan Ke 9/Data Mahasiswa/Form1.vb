﻿Imports System.Windows.Forms

Public Class FormNilai
    Inherits Form

    ' Komponen UI
    Private txtNama, txtAbsensi, txtUTS, txtUAS As TextBox
    Private txtBobotAbsensi, txtBobotUTS, txtBobotUAS As TextBox
    Private txtTotal, txtAngka, txtHuruf, txtAnalisa As TextBox
    Private btnHitung, btnClear, btnSimpan As Button

    Public Sub New()
        Me.Text = "Form Penilaian Mahasiswa"
        Me.Size = New Size(600, 400)
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Group Input
        Dim grpInput As New GroupBox() With {.Text = "Input", .Location = New Point(20, 20), .Size = New Size(250, 150)}
        txtNama = New TextBox() With {.Location = New Point(100, 20), .Width = 120}
        txtAbsensi = New TextBox() With {.Location = New Point(100, 50), .Width = 120}
        txtUTS = New TextBox() With {.Location = New Point(100, 80), .Width = 120}
        txtUAS = New TextBox() With {.Location = New Point(100, 110), .Width = 120}
        grpInput.Controls.AddRange({
            New Label() With {.Text = "Nama", .Location = New Point(10, 20)},
            txtNama,
            New Label() With {.Text = "Absensi", .Location = New Point(10, 50)},
            txtAbsensi,
            New Label() With {.Text = "UTS", .Location = New Point(10, 80)},
            txtUTS,
            New Label() With {.Text = "UAS", .Location = New Point(10, 110)},
            txtUAS
        })

        ' Group Output
        Dim grpOutput As New GroupBox() With {.Text = "Output", .Location = New Point(20, 180), .Size = New Size(250, 100)}
        txtAngka = New TextBox() With {.Location = New Point(130, 20), .ReadOnly = True}
        txtHuruf = New TextBox() With {.Location = New Point(130, 45), .ReadOnly = True}
        txtAnalisa = New TextBox() With {.Location = New Point(130, 70), .ReadOnly = True}
        grpOutput.Controls.AddRange({
            New Label() With {.Text = "Hasil Akhir Angka", .Location = New Point(10, 20)},
            txtAngka,
            New Label() With {.Text = "Hasil Akhir Huruf", .Location = New Point(10, 45)},
            txtHuruf,
            New Label() With {.Text = "Hasil Analisa", .Location = New Point(10, 70)},
            txtAnalisa
        })

        ' Group Bobot
        Dim grpBobot As New GroupBox() With {.Text = "Bobot", .Location = New Point(300, 20), .Size = New Size(250, 150)}
        txtBobotAbsensi = New TextBox() With {.Location = New Point(120, 20), .Width = 100, .Text = "10"}
        txtBobotUTS = New TextBox() With {.Location = New Point(120, 50), .Width = 100, .Text = "40"}
        txtBobotUAS = New TextBox() With {.Location = New Point(120, 80), .Width = 100, .Text = "50"}
        txtTotal = New TextBox() With {.Location = New Point(120, 110), .Width = 100, .ReadOnly = True, .Text = "100"}
        btnSimpan = New Button() With {.Text = "Simpan", .Location = New Point(80, 140)}
        AddHandler txtBobotAbsensi.TextChanged, AddressOf CekTotalBobot
        AddHandler txtBobotUTS.TextChanged, AddressOf CekTotalBobot
        AddHandler txtBobotUAS.TextChanged, AddressOf CekTotalBobot
        grpBobot.Controls.AddRange({
            New Label() With {.Text = "Bobot Absensi", .Location = New Point(10, 20)},
            txtBobotAbsensi,
            New Label() With {.Text = "Bobot UTS", .Location = New Point(10, 50)},
            txtBobotUTS,
            New Label() With {.Text = "Bobot UAS", .Location = New Point(10, 80)},
            txtBobotUAS,
            New Label() With {.Text = "Total Bobot", .Location = New Point(10, 110)},
            txtTotal,
            btnSimpan
        })

        ' Group Function
        Dim grpFunc As New GroupBox() With {.Text = "Function", .Location = New Point(300, 190), .Size = New Size(250, 80)}
        btnHitung = New Button() With {.Text = "Hitung", .Location = New Point(20, 30), .Enabled = True}
        btnClear = New Button() With {.Text = "Clear", .Location = New Point(130, 30)}
        AddHandler btnHitung.Click, AddressOf HitungNilai
        AddHandler btnClear.Click, AddressOf ClearForm
        grpFunc.Controls.AddRange({btnHitung, btnClear})

        ' Tambahkan semua ke form
        Me.Controls.AddRange({grpInput, grpOutput, grpBobot, grpFunc})
    End Sub

    Private Sub CekTotalBobot(sender As Object, e As EventArgs)
        Dim total As Integer = Val(txtBobotAbsensi.Text) + Val(txtBobotUTS.Text) + Val(txtBobotUAS.Text)
        txtTotal.Text = total.ToString()
        btnHitung.Enabled = (total = 100)
    End Sub

    Private Sub HitungNilai(sender As Object, e As EventArgs)
        Dim absensi = Val(txtAbsensi.Text)
        Dim uts = Val(txtUTS.Text)
        Dim uas = Val(txtUAS.Text)
        Dim bobotAbsensi = Val(txtBobotAbsensi.Text)
        Dim bobotUTS = Val(txtBobotUTS.Text)
        Dim bobotUAS = Val(txtBobotUAS.Text)

        Dim nilaiAkhir = (absensi * bobotAbsensi + uts * bobotUTS + uas * bobotUAS) / 100
        txtAngka.Text = nilaiAkhir.ToString("0")

        Dim huruf As String = ""
        Dim analisa As String = ""

        Select Case nilaiAkhir
            Case >= 85
                huruf = "A" : analisa = "Baik Sekali"
            Case >= 70
                huruf = "B" : analisa = "Baik"
            Case >= 55
                huruf = "C" : analisa = "Cukup"
            Case >= 40
                huruf = "D" : analisa = "Kurang"
            Case Else
                huruf = "E" : analisa = "Sangat Kurang"
        End Select

        txtHuruf.Text = huruf
        txtAnalisa.Text = analisa
    End Sub

    Private Sub ClearForm(sender As Object, e As EventArgs)
        txtNama.Clear()
        txtAbsensi.Clear()
        txtUTS.Clear()
        txtUAS.Clear()
        txtAngka.Clear()
        txtHuruf.Clear()
        txtAnalisa.Clear()
    End Sub
End Class
