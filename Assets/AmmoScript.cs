using UnityEngine;
using System;
using System.Collections.Generic;

public class AmmoScript : MonoBehaviour
{
    [SerializeField]
    private int amountAmmo = 5;

    private int amountLife = 5;

    private int amountTime = 25;


    public enum pickupSelection
    {
        Life,
        ammo,
        time
    }

    public pickupSelection currentSelection;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int value = UnityEngine.Random.Range(0, 10);
        if (value > 7.5)
        {
            currentSelection = pickupSelection.time;
            GetComponent<MeshRenderer>().material.color = Color.aquamarine;
        }
        else if (value < 5)
        {
            currentSelection = pickupSelection.Life;
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            currentSelection = pickupSelection.ammo;
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 45, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (currentSelection)
            {
                case pickupSelection.Life:
                    other.GetComponent<PlayerHealth>().TakeDamage(-amountLife);
                    break;
                case pickupSelection.ammo:
                    other.transform.GetChild(0).GetComponent<PlayerShoot>().AddBullets(amountAmmo);
                    break;
                case pickupSelection.time:
                    GameManager.Instance.AddTime(amountTime);
                    break;
            }

            Destroy(this.gameObject);

        }
    }
}
