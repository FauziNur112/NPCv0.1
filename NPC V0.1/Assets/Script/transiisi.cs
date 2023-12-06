using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class transiisi : MonoBehaviour
{
    public Button tombolMulai;

    void Start()
    {
        // Menambahkan event untuk tombol saat diklik
        tombolMulai.onClick.AddListener(MulaiAksi);
    }

    void MulaiAksi()
    {
        // Tindakan yang akan dijalankan saat tombol ditekan
        // Memuat scene selanjutnya
        SceneManager.LoadScene("cutscene");
    }
}
