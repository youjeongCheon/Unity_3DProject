using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Transform goal;
    private int curWayIndex = 0;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        goal = NavMeshManager.Instance.GetGoalPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer== LayerMask.NameToLayer("WayPoint"))
        {
            if(curWayIndex>= NavMeshManager.Instance.wayPoints.Count-1)
            {
                // Goal Àü Point¿¡ µµÂø
                agent.destination = goal.position;
            }
            else
            {
                SetNextPoint();
            }
        }
        if(other.gameObject.layer == LayerMask.NameToLayer("GoalPoint"))
        {
            OnArriveEndPoint();
        }
    }

    private void OnArriveEndPoint()
    {
        
    }

    private void SetNextPoint()
    {
        curWayIndex++;
        agent.destination = NavMeshManager.Instance.wayPoints[curWayIndex].position;
    }
}
