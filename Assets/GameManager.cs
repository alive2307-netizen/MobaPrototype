using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject winPanel;   
    public GameObject losePanel;  

    void Awake()
    {
        Instance = this;
    }

    public void WinGame()
    {
        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void LoseGame()
    {
        if (losePanel != null) losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}