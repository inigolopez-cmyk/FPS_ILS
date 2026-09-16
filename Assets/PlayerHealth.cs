using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 5;

    [SerializeField]
    private Slider healthSlider;

    UpdateUI uiScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uiScript = GameObject.Find("HUD").GetComponent<UpdateUI>();
        healthSlider.value = health/10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health/10;
        if (health <= 0)
        {
            uiScript.OpenGameOver();
            GameManager.Instance.PlayerDied();
        }
    }
}
