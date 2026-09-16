using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 10;

    UpdateUI uiScript;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiScript = GameObject.Find("HUD").GetComponent<UpdateUI>();
        uiScript.AddHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            uiScript.OpenGameOver();
            GameManager.Instance.PlayerDied();
        }
    }
}
