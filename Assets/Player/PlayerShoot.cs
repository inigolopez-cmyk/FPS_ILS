using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public Color hitColor; // Color of the ray when it hits an object

    [SerializeField]
    private InputAction reloadKey;

    private int bullets;
    private int maxBullets;

    [SerializeField]
    private TMP_Text bulletText;
    [SerializeField]
    private ParticleSystem shootParticles;
    [SerializeField]
    private AudioSource shootAudio;

    private void OnEnable()
    {
        reloadKey.Enable();
    }

    private void OnDisable()
    {
        reloadKey.Disable();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullets = 10;
        maxBullets = 25;
        UpdateBulletText();
    }

    // Update is called once per frame
    void Update()
    {
        if (reloadKey.triggered)
        {
            if (maxBullets > 0 && maxBullets > 6)
            {
                bullets += 6;
                maxBullets -= 6;
            }
            if(maxBullets > 0 && maxBullets < 6)
            {
                bullets += maxBullets;
                maxBullets = 0;     
            }
                UpdateBulletText();
        } 

        if (Mouse.current.leftButton.wasPressedThisFrame && bullets > 0)
        {
            RaycastHit hit;
            bullets--;
            shootAudio.Play();
            UpdateBulletText();

            //if (!shootParticles.isPlaying) // Disparo no automático, sino que se dispara una vez por click. Si el particle system está reproduciéndose, no se reproduce de nuevo hasta que termine.
            //{
            //    shootParticles.Play();
            //}

            shootParticles.Play(); // Disparo automático, se dispara cada vez que se hace click, aunque el particle system esté reproduciéndose.

            if (Physics.Raycast(transform.position, transform.forward, out hit)) //forward es la dirección en la que mira el eje z del objeto
            {
                if(hit.transform.CompareTag("Enemy")) // If the object that the ray collides with has the tag "Enemy", it will take damage.
                {
                    hit.transform.GetComponent<EnemyScript>().TakeDamage(5f); // The object that the ray collides with will take 5 damage.
                }

                Debug.DrawLine(transform.position, transform.forward * hit.distance, hitColor); // Used to find errors in the code, and to see if the ray is working correctly. A line is drawn from the object's position to the hit distance.
                // Debug.Break(); // Pauses the game in the Unity editor
            }
        }

    }

    void UpdateBulletText()
    {
        bulletText.text = bullets.ToString() + "/" + maxBullets.ToString();
    }


    public void AddBullets(int value)
    {
        maxBullets += value;
        UpdateBulletText();
    }

    private void FixedUpdate() // FÍSICAS
    {

    }

}
