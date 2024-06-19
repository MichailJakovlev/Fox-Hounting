using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class Rabbit : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent agent;
    NavMeshPath path;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        float startPosition = agent.transform.position.x + agent.transform.position.z;
        StartCoroutine(SetRabbitPath(startPosition));
    }

    IEnumerator SetRabbitPath(float startPosition)
    {
        while (true)
        {
            var dirX = Random.Range(-10, 10);
            var dirZ = Random.Range(-10, 10);

            Vector3 direction = new Vector3(dirX, 0, dirZ);
            
            agent.SetDestination(direction + agent.transform.position);
            agent.CalculatePath(agent.transform.position, path);
            
            if(path.status != NavMeshPathStatus.PathComplete)
            {
                break;
            }

            anim.Play("Run");

            yield return null;
        } 
    }  
}

    


