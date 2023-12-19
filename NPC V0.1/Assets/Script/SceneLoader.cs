using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Nama scene yang ingin dimuat
    public string CREDITGAME;

    public void LoadNextScene()
    {
        // Memuat scene berdasarkan nama scene yang ditentukan
        SceneManager.LoadScene(CREDITGAME);
    }
}
