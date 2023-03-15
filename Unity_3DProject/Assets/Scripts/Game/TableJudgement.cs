using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;
    public UnityEvent OnFailed;

    /*private List<NPC> NPCs = new List<NPC>();

    public List<FoodData> FoodOrders  { private set; get; }
    public List<Order> Orders { private set; get; }*/

    public Dictionary<NPC, FoodData> Orders { private set; get; }

    [SerializeField]
    private ParticleSystem comffeti;

    private void Awake()
    {
        /*FoodOrders = new List<FoodData>();
        Orders = new List<Order>();*/
        Orders = new Dictionary<NPC, FoodData>();
    }

    public void NPCseat(NPC npc)
    {
        /*NPCs.Add(npc);
        Orders.Add(npc.order);
        FoodOrders.Add(npc.order.data);*/
        Orders.Add(npc, npc.order.data);
    }

    public void NPCstand(NPC npc)
    {
        // NPCs.Remove(npc);
    }

    public void OrderComplete(NPC npc)
    {
        /*Orders.Remove(npc.order);
        FoodOrders.Remove(npc.order.data);*/
        npc.OnSuccess();
        Orders.Remove(npc);
    }

    public void ConffetiPlay()
    {
        comffeti.Play();
    }

    public void NPCsad()
    {
        if (Orders.Count == 0)
            return;
        foreach (NPC npc in Orders.Keys)
            npc.OnFailed();
        
    }
}
