using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;

    private List<NPC> NPCs = new List<NPC>();
    private List<FoodChecker> foods = new List<FoodChecker>();
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            foods.Add(other.GetComponent<FoodChecker>());
            other.GetComponent<FoodChecker>().startTime = Time.time;
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
            foods.Remove(other.GetComponent<FoodChecker>());
            other.GetComponent<FoodChecker>().startTime = 0;
        }
    }

    private void Judgement()
    {
        foreach(FoodChecker food in foods)
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
