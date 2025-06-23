using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI; // Pastikan Anda mengimpor namespace UI

public class Score : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText; // Tambahkan TextMeshProUGUI untuk Skor
    public TextMeshProUGUI gameOverText; // Tambahkan TextMeshProUGUI untuk Game Over
    public Button playButton; // Tombol Play
    public float timeRemaining = 180f; // waktu permainan (dalam detik)
    public int score = 0; // Variabel untuk skor
    private bool isGameOver = false;
    private bool isGameStarted = false; // Variabel untuk mengecek apakah game sudah dimulai

    // Start is called before the first frame update
    void Start()
    {
        playButton.gameObject.SetActive(true); // Pastikan tombol Play aktif saat game mulai
        playButton.onClick.AddListener(StartGame); // Tambahkan listener untuk tombol Play
        UpdateTimerText();
        UpdateScoreText(); // Perbarui teks skor di awal
        gameOverText.gameObject.SetActive(false); // Sembunyikan pesan Game Over di awal
    }

    // Fungsi untuk memulai permainan
    void StartGame()
    {
        isGameStarted = true; // Menandakan game telah dimulai
        playButton.gameObject.SetActive(false); // Sembunyikan tombol Play
        timeRemaining = 180f; // Reset waktu permainan
        score = 0; // Reset skor
        UpdateScoreText(); // Perbarui skor
        UpdateTimerText(); // Perbarui timer
        gameOverText.gameObject.SetActive(false); // Sembunyikan pesan Game Over
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStarted && !isGameOver)
        {
            // Menghitung mundur waktu
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Jika waktu habis
                timeRemaining = 0;
                isGameOver = true;
                GameOver();
            }
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString() + "s";
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScoreItem")) // Cek tag objek item
        {
            score += 20; // Tambah skor untuk ScoreItem
            scoreText.text = "Score: " + score.ToString(); // Update tampilan skor
            Destroy(other.gameObject); // Hancurkan ScoreItem
        }
    }

    void GameOver()
    {
        // Tampilkan pesan Game Over
        timerText.text = "Time: 0s";
        gameOverText.text = "Game Over!"; // Set teks Game Over
        gameOverText.gameObject.SetActive(true); // Tampilkan pesan Game Over
        
        // Anda bisa menambahkan kode untuk menghentikan permainan di sini
        // Misalnya: menonaktifkan kontrol pemain atau memunculkan menu akhir
    }
}
