using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] eDestinations;

    public float distanceToFollowPath = 2;

    private int i = 0;

    [Header("----Active Player Follow----")]
    public bool followPlayer;

    private GameObject player;

    private float distanceToPlayer;
    public float distanceToFollowPlayer = 10;


    void Start()
    {
        navMeshAgent.destination = eDestinations[0].transform.position;

        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }


    public void EnemyPath()
    {
        navMeshAgent.destination = eDestinations[i].position;

        if (Vector3.Distance(transform.position, eDestinations[i].position) <= distanceToFollowPath)
        {
            if (eDestinations[i] != eDestinations[eDestinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }
    }


    public void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }
}
