using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;

    private List<NPC> NPCs = new List<NPC>();
    private bool isSuccess = false;
    private float startTime = 0;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            startTime = Time.time;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            Judgement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            startTime = 0;
        }
    }

    private void Judgement()
    {
        if (Time.time - startTime > 2 &&!isSuccess)
        {
            OnSuccess?.Invoke();
            isSuccess = true;
        }
    }

    public void NPCseat(NPC npc)
    {
        NPCs.Add(npc);
    }

    public void NPCstand(NPC npc)
    {
        NPCs.Remove(npc);
    }

    public void NPCclap()
    {
        if (NPCs.Count == 0)
            return;
        foreach (NPC npc in NPCs)
        {
            npc.OnSuccess();
        }
    }
}
