using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10f;

    private NavMeshAgent agent;

    private Transform player;

    [SerializeField]
    private GameObject knife;

    [SerializeField]
    private List<Transform> patrolPoint = new List<Transform>();

    int currentPoint = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player = GameObject.Find("Player").transform; 
        agent.stoppingDistance = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= 20)  
        {
            agent.destination = player.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, patrolPoint[currentPoint].position) >= 3)
            {
                agent.destination = patrolPoint[currentPoint].position;
            }
            else
            {
                if (currentPoint < patrolPoint.Count-1)
                {
                    currentPoint++;
                }
                else
                {
                    currentPoint = 0;
                }
            }
        }

        //if (Vector3.Distance(transform.position, player.transform.position) <= 8)
        //{
        //    agent.destination = player.position;
        //}
        //else
        //{
        //    agent.destination = patrolPoint[0].position;
        //}

        // agent.destination = new Vector3(10, 10, 10);
        // agent.destination = player.position;


        if (Vector2.Distance(transform.position, player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }

    public void TakeDamage(float value)
    {
        health -= value;

        GetComponent<MeshRenderer>().material.DOColor(Color.red, 1).From();
        GetComponent<MeshRenderer>().material.DOColor(Color.grey, 1);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
