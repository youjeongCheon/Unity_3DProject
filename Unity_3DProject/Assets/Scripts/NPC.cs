using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class NPC : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator anim;
    private Rigidbody rigid;
    private Transform goal;
    private Transform seat;
    private int curWayIndex = 0;
    private int GFXcount = 10;

    private void Awake()
    {
        SetGFX();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody>();
        goal = NavMeshManager.Instance.GetGoalPoint();
        anim.SetBool("isWalking", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer== LayerMask.NameToLayer("WayPoint"))
        {
            if(curWayIndex>= NavMeshManager.Instance.wayPoints.Count-1)
            {
                // Goal �� Point�� ����
                agent.destination = goal.position;
            }
            else
            {
                SetNextPoint();
            }
        }
        if(other.gameObject==goal.gameObject)
        {
            OnArriveEndPoint();
        }
    }

    private void OnArriveEndPoint()
    {
        agent.enabled = false;
        seat = goal.GetChild(0);
        transform.root.position = seat.position;
        rigid.angularVelocity = Vector3.zero;
        if (seat.gameObject.name == "SeatF")
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.SetBool("isWalking", false);

    }

    private void SetNextPoint()
    {
        curWayIndex++;
        agent.destination = NavMeshManager.Instance.wayPoints[curWayIndex].position;
    }

    private void SetGFX()
    {
        int rand = Random.Range(0, GFXcount);
        Transform GFX = transform.GetChild(0).GetChild(rand);
        GFX.gameObject.SetActive(true);
    }
}