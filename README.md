# 🎮 ATS Praktikum Pemrograman Gim 2D - Unity

![Unity 6](https://img.shields.io/badge/Unity-6000.3.24f1%20LTS-black?logo=unity&style=for-the-badge)
![C#](https://img.shields.io/badge/Language-C%23-239120?logo=csharp&style=for-the-badge)
![Template](https://img.shields.io/badge/Render%20Pipeline-Universal%202D%20(URP)-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Completed-success?style=for-the-badge)

Repositori ini berisi proyek praktikum **Ujian Tengah Semester (ATS) Pemrograman Gim 2D** menggunakan engine **Unity 6**.

---

## 📌 Identitas Mahasiswa & Soal

| Informasi | Detail |
| :--- | :--- |
| **NIM** | `4352511013` |
| **Digit Terakhir** | `3` (Ganjil) |
| **Tipe Soal** | **Tipe A: Kumpulkan Koin** |
| **Rumus Kecepatan Player** | $3 + \text{Digit Terakhir NIM} = 3 + 3 = \mathbf{6}$ |
| **Nama Proyek** | `ATS_4352511013` |
| **Nama Scene** | `Scn_ATS_4352511013` |

---

## 🎯 Ringkasan Gameplay (Tipe A)

Pemain mengendalikan kotak **Player (Biru)** di dalam arena yang dibatasi oleh 4 tembok pembatas. Misi pemain adalah mengumpulkan seluruh koin yang tersebar di arena untuk mengumpulkan skor.

* **Kotak Player (Biru):** Bergerak menggunakan tombol `W, A, S, D` dengan kecepatan `6`.
* **Tembok Arena:** Memiliki batas fisik padat (`Box Collider 2D` tanpa `Is Trigger`), menahan Player agar tidak keluar arena.
* **Koin (Kuning - Prefab):** Terdiri dari 3 koin dengan `Circle Collider 2D` bertipe sensor (`Is Trigger`).
* **Sistem Skor:** Setiap kali Player menyentuh koin, koin akan hilang (`Destroy`), dan skor di pojok kanan atas bertambah 10 poin (total skor maksimal 30 poin).

---

## 🕹️ Kontrol Permainan

| Tombol | Fungsi |
| :---: | :--- |
| <kbd>W</kbd> | Bergerak ke Atas |
| <kbd>S</kbd> | Bergerak ke Bawah |
| <kbd>A</kbd> | Bergerak ke Kiri |
| <kbd>D</kbd> | Bergerak ke Kanan |

---

## 🧱 Arsitektur Fisika & Komponen

| Objek | Komponen Utama | Pengaturan Collider | Sifat Fisika |
| :--- | :--- | :---: | :--- |
| **Player** | `Rigidbody2D`, `BoxCollider2D`, `PlayerController` | `Is Trigger: OFF` | Gravity Scale = 0, Freeze Rotation Z = ON |
| **Tembok (4 Sisi)** | `BoxCollider2D`, `SpriteRenderer` | `Is Trigger: OFF` | Diam kokoh (Solid obstacle) |
| **Koin** *(Prefab)* | `CircleCollider2D` | `Is Trigger: ON` | Sensor penambah skor + hancurkan koin |
| **Canvas UI** | `TextMeshProUGUI` | - | Mengelola skor dan tampilan UI teks |

---

## 📜 Daftar Script C# (`Assets`)

1. **`PlayerController.cs`**  
   Mengatur pergerakan karakter menggunakan sistem input (`Horizontal` dan `Vertical`) dengan pergerakan fisika `Rigidbody2D.MovePosition`. Mengintegrasikan deteksi `OnTriggerEnter2D` pada koin untuk penambahan skor dan memperbarui tampilan `TextMeshProUGUI`.

---

*Dikembangkan untuk penilaian praktikum ATS Pemrograman Gim 2D.*
