using TMPro;
using UnityEngine;

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

        gameTime = 90;
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
}
