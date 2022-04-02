using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
	private Animator animator;
    private UnityEngine.AI.NavMeshAgent agent;
	public Transform[] moveSpots;
	private int randomSpot;
    private float waitTime;
    private float startWaitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
		randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
void Update()
	{
		  animator.SetBool("idle", false);	
		  animator.SetBool("move", true);
		  agent.SetDestination(moveSpots[randomSpot].position);
       	if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.05f)
		{
			if (waitTime <=0)
			{
				animator.SetBool("idle", true);	
				animator.SetBool("move", false);
				randomSpot = Random.Range(0, moveSpots.Length);
				waitTime = startWaitTime;
			}
			else
			{
				animator.SetBool("idle", true);	
				animator.SetBool("move", false);
				waitTime -= Time.deltaTime;
			}
		}
	}	
	
}
