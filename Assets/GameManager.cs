using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance of the GameManager class

    public bool isPlaying;

    [SerializeField]
    private float gameTime;

    //[SerializeField]
    //private float maxTime;

    [SerializeField]
    private TMP_Text gameTimeText;

    [SerializeField]
    private UpdateUI uiScript;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isPlaying = true;

        gameTime = 120;
        // maxTime = 90;
        UpdateGameTimeText();


    }

    // Update is called once per frame
    void Update()
    {
        // while (isPlaying == true)
        if (isPlaying) 
        { 
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                isPlaying = false;

            }


            if (isPlaying == false)
            {
                gameTime = 0;
            }

            UpdateGameTimeText();
        }

        //while (gameTime > 0)
        //{
        //    gameTime -= Time.deltaTime;
        //}
        //if (gameTime <= 0)
        //{
        //    isPlaying = false;
        //}

    }

    void UpdateGameTimeText()
    {
        int min = (int)gameTime / 60;
        int sec = (int)gameTime % 60;
        gameTimeText.text = min.ToString("00") + ":" + sec.ToString("00"); // + "/" + maxTime.ToString();
    }

    public void PlayerDied()
    {
        AudioListener.pause = true;
        isPlaying = false;
        Time.timeScale = 0;
    }

    public void TimeIsUp()
    {
        gameTime = 0;
        isPlaying = false;
        Time.timeScale = 0;
        AudioListener.pause = true;
        uiScript.OpenGameOver();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void AddTime(float time)
    {
        gameTime += time;
    }
}
