using UnityEngine;
using TMPro; // Wajib di-import karena kita pakai UI TextMeshPro untuk skor

public class PlayerController : MonoBehaviour
{
    [Header("Pengaturan Player")]
    // Kecepatan player diatur di sini (sesuai rumus NIM: 3 + digit terakhir)
    public float kecepatan = 6f;

    [Header("Pengaturan UI & Skor")]
    public int score = 0;
    // Slot buat masukin objek teks skor dari Hierarchy ke Inspector
    public TextMeshProUGUI scoreText;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        // Ambil komponen Rigidbody2D yang terpasang di objek Player
        rb = GetComponent<Rigidbody2D>();

        // Biar kotak player gak langsung meluncur jatuh gara-gara gravitasi Unity
        if (rb != null)
        {
            rb.gravityScale = 0f;
        }

        // Tampilkan angka skor 0 saat game baru dinyalakan
        UpdateScoreUI();
    }

    void Update()
    {
        // Membaca pencetan tombol dari keyboard (bisa pakai WASD atau Panah)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Menggerakkan player pakai fisika Rigidbody2D biar tabrakan temboknya stabil
        if (rb != null)
        {
            // .normalized dipasang biar pas jalan diagonal (serong) jalannya gak terlalu kencang
            rb.MovePosition(rb.position + movement.normalized * kecepatan * Time.fixedDeltaTime);
        }
    }

    // Fungsi otomatis yang kepanggil pas player nabrak objek ber-trigger (Koin)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah objek yang ditabrak namanya punya kata "Coin" (misal: Coin, Coin (1), Coin (2), dll)
        if (other.gameObject.name.Contains("Coin") || other.CompareTag("Coin"))
        {
            score += 10; // Tambah 10 poin tiap berhasil ngambil 1 koin
            UpdateScoreUI(); // Perbarui tulisan skor yang ada di layar
            Destroy(other.gameObject); // Hilangkan koin dari layar/scene

            Debug.Log("Koin berhasil diambil! Skor saat ini: " + score);
        }
    }

    // Fungsi khusus buat update tampilan teks skor di UI Canvas
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score = " + score;
        }
    }
}