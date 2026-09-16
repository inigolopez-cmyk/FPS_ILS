using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateUI : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;

    public GameObject gameOverPanel;
    //public GameObject victoryPanel;

    [SerializeField]
    private AudioSource gameOverAudio;

    //[SerializeField]
    //private AudioSource victoryAudio;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Points: " + score.ToString();
    }



    public void OpenGameOver()
    {
        gameOverAudio.ignoreListenerPause = true;
        gameOverAudio.Play();
        gameOverPanel.SetActive(true);
    }

    //public void OpenVictory()
    //{
    //    victoryAudio.ignoreListenerPause = true;
    //    victoryAudio.Play();
    //    victoryPanel.SetActive(true);
    //}

    public void RestartGame()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
