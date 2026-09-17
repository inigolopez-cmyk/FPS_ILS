using UnityEngine;

public class GoalScript : MonoBehaviour
{
    GameObject player;
    UpdateUI uiScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        uiScript = GameObject.Find("HUD").GetComponent<UpdateUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            uiScript.OpenVictory();
            GameManager.Instance.PlayerWon();

        }
    }

}
