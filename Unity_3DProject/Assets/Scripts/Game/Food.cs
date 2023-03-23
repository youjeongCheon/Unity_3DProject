using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Food : MonoBehaviour
{
    public FoodData food;
   
    private bool isStay = false;
    private bool isGround = false;
    private TableJudgement table;
    private Coroutine spawnCorutine;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Floor")&&!isGround)
        {
            isGround = true;
            GameManager.Instance.money -= 1000;
            UIManager.Instance.SetMoney();
            StartCoroutine(DestroyFood());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Table"))
        {
            table = other.GetComponent<TableJudgement>();
            spawnCorutine = StartCoroutine(FoodJudgement());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (table == null)
            return;
        else if(other.gameObject == table.gameObject)
        {
            isStay = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (table == null)
            return;
        else if(other.gameObject == table.gameObject)
        {
            isStay = false;
            StopCoroutine(spawnCorutine);
        }
    }

    private IEnumerator FoodJudgement()
    {
        yield return new WaitForSeconds(2.0f);

       if(isStay && table.FoodOrders.Contains(food))
       {
            NPC npc = table.NPCs[table.FoodOrders.IndexOf(food)];
            table.OrderComplete(npc);
            GameManager.Instance.money += food.Cost;
            UIManager.Instance.SetMoney();
            StartCoroutine(DestroyFood());
            table.OnSuccess?.Invoke();
       }
       else
       {
            table.OnFailed?.Invoke();
            StartCoroutine(DestroyFood());
       }
    }

    private IEnumerator DestroyFood()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
