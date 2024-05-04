using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent nmAgent;
    public GameObject player;
    public bool enemyMove;
    public bool findPlayer;
    [Header("opciones")]
    public bool lockTarget=false;
    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(findPlayer && lockTarget) { 
        nmAgent.destination = player.transform.position;
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (lockTarget)
            {
                findPlayer = true;
                enemyMove = true;
            }
            else
            {
                nmAgent.destination = player.transform.position;
                nmAgent.isStopped = false;
                enemyMove = true;
            }
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !lockTarget)
        {
            nmAgent.isStopped = true;
            enemyMove = false;
        }
    }

}
