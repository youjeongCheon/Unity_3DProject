using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    [SerializeField]
    private TableJudgement table;

    public void NPCseat(NPC npc)
    {

        table.NPCseat(npc);
    }

    public void NPCstand(NPC npc)
    {
        table.NPCstand(npc);
    }
}
