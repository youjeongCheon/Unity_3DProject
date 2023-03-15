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
    private int num = 0;

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

       if(isStay && table.Orders.ContainsValue(food))
       {
            NPC npc = table.Orders.FirstOrDefault(x => x.Value == food).Key;
            table.OrderComplete(npc);
            GameManager.Instance.money += food.Cost;
            UIManager.Instance.SetMoney();
            StartCoroutine(DestroyFood());
            table.OnSuccess?.Invoke();
       }
       else
       {
            table.OnFailded?.Invoke();
            StartCoroutine(DestroyFood());
       }
        /*int orderCount = table.FoodOrders.Count;
        foreach(Order order in table.Orders)
        {
            if(isStay && string.Equals(order.data.FoodName, foodname))
            {
                order.npc.OnSuccess();
                table.OnSuccess?.Invoke();
                table.OrderComplete(order.npc);
                GameManager.Instance.money += order.data.Cost;
                UIManager.Instance.SetMoney(GameManager.Instance.money);
                StartCoroutine(DestroyFood());
                break;
            }
            else if(isStay&&!string.Equals(order.data.FoodName, foodname))
            {
                num++;
            }
        }
        if(orderCount>0&&num==orderCount)
        {
            table.OnFailded?.Invoke();
            StartCoroutine(DestroyFood());
        }*/
    }

    private IEnumerator DestroyFood()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
