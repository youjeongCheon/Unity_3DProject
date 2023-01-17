using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;
    public UnityEvent OnFailded;

    private List<NPC> NPCs = new List<NPC>();

    public List<FoodData> FoodOrders  { private set; get; }

    private void Awake()
    {
        FoodOrders = new List<FoodData>();
    }

    public void NPCseat(NPC npc)
    {
        NPCs.Add(npc);
        FoodOrders.Add(npc.order.data);
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

    public void NPCsad()
    {
        if (NPCs.Count == 0)
            return;
        foreach (NPC npc in NPCs)
        {
            npc.OnFailed();
        }
    }
}
