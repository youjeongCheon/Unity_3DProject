using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public string foodname;
   
    private bool isStay = false;
   
    private TableJudgement table;
    private Coroutine spawnCorutine;

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
        if(other.gameObject == table.gameObject)
        {
            isStay = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == table.gameObject)
        {
            isStay = false;
            StopCoroutine(spawnCorutine);
        }
    }

    private IEnumerator FoodJudgement()
    {
        yield return new WaitForSeconds(2.0f);
        foreach(Order order in table.Orders)
        {
            if(isStay&& string.Equals( order.data.FoodName, foodname))
            {
                table.OnSuccess?.Invoke();
                GameManager.Instance.money += order.data.Cost;
                Debug.Log(GameManager.Instance.money);
            }
            else if(isStay&&!string.Equals(order.data.FoodName, foodname))
            {
                Debug.Log("����");
                table.OnFailded?.Invoke();
            }
        }

    }
}
