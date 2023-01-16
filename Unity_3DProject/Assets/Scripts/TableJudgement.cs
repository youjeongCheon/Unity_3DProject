using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;

    private List<NPC> NPCs = new List<NPC>();
    private List<Food> foods = new List<Food>();
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            foods.Add(other.GetComponent<Food>());
            other.GetComponent<Food>().startTime = Time.time;
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
            foods.Remove(other.GetComponent<Food>());
            other.GetComponent<Food>().startTime = 0;
        }
    }

    private void Judgement()
    {
        foreach(Food food in foods)
        {
            if (Time.time - food.startTime > 2 && !food.isSuccess)
            {
                OnSuccess?.Invoke();
                food.isSuccess = true;
            }
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
