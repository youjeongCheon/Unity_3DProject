using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;
    public UnityEvent OnFailed;

    public List<NPC> NPCs { private set; get; }
    public List<FoodData> FoodOrders { private set; get; }


    [SerializeField]
    private ParticleSystem comffeti;

    private void Awake()
    {
        NPCs = new List<NPC>();
        FoodOrders = new List<FoodData>();
    }

    public void NPCseat(NPC npc)
    {
        NPCs.Add(npc);
        FoodOrders.Add(npc.order.data);
    }

    public void NPCstand(NPC npc)
    {
        // Do Nothing
    }

    public void OrderComplete(NPC npc)
    {
        npc.OnSuccess();
        NPCs.Remove(npc);
        FoodOrders.Remove(npc.order.data);
    }

    public void ConffetiPlay()
    {
        comffeti.Play();
    }

    public void NPCsad()
    {
        if (NPCs.Count == 0)
            return;
        foreach (NPC npc in NPCs)
            npc.OnFailed();
        
    }
}
