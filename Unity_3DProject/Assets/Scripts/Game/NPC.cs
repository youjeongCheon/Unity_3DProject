using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class NPC : MonoBehaviour
{
    public UnityEvent OnOrdered;

    private NavMeshAgent agent;
    private Animator anim;
    private Rigidbody rigid;
    private Transform goal;
    private Seat seat;
    public Order order;
    private EmoticonChanger emoticon;
    private int curWayIndex = 0;
    private int GFXcount = 10;
    private bool eatCompite = false;

    private void Awake()
    {
        SetGFX();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        emoticon = GetComponentInChildren<EmoticonChanger>();
        rigid = GetComponent<Rigidbody>();
        order = GetComponentInChildren<Order>();
        goal = NavMeshManager.Instance.GetGoalPoint();
        anim.SetBool("isWalking", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer== LayerMask.NameToLayer("WayPoint"))
        {
            if(!eatCompite && curWayIndex>= NavMeshManager.Instance.wayPoints.Count-1)
            {
                // Goal Àü PosPoint¿¡ µµÂø
                OnOrdered?.Invoke();
                
                agent.destination = goal.position;
            }
            else if(eatCompite&&curWayIndex==0)
            {
                Destroy(gameObject);
                NavMeshManager.Instance.SetGoalPoints(goal);
                NavMeshManager.Instance.NPCcount--;
            }
            else
            {
                SetNextPoint();
            }
        }
        if(other.gameObject==goal.gameObject)
        {
            if (eatCompite)
            {
                agent.destination = NavMeshManager.Instance.wayPoints[curWayIndex].position;

            }
            else
                OnArriveEndPoint();

        }
    }

    private void OnArriveEndPoint()
    {
        agent.enabled = false;
        seat = goal.GetComponentInChildren<Seat>();
        seat.NPCseat(this);
        transform.root.position = seat.transform.position;
        rigid.angularVelocity = Vector3.zero;
        if (seat.gameObject.name == "SeatF")
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.SetBool("isWalking", false);

    }

    private void GoOutside()
    {
        eatCompite = true;
        seat.NPCstand(this);
        transform.root.position = goal.transform.position;
        anim.SetBool("isWalking", true);
        agent.enabled = true;
    }

    private void SetNextPoint()
    {
        if (eatCompite)
            curWayIndex--;
        else
            curWayIndex++;

        agent.destination = NavMeshManager.Instance.wayPoints[curWayIndex].position;
    }

    private void SetGFX()
    {
        int rand = Random.Range(0, GFXcount);
        Transform GFX = transform.GetChild(0).GetChild(rand);
        GFX.gameObject.SetActive(true);
    }

    public void OnSuccess()
    {
        anim.SetBool("IsClapping",true);
        emoticon.OnSuccess();
        order.OnSuccess();
        StartCoroutine(ClapRoutine());
    }

    public void OnFailed()
    {
        emoticon.OnFailed();
        order.OnFailed();
    }

    private IEnumerator ClapRoutine()
    {
        yield return new WaitForSeconds(3);
        anim.SetBool("IsClapping", false);
        GoOutside();
    }
}
