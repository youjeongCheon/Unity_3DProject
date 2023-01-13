using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableJudgement : MonoBehaviour
{
    public UnityEvent OnSuccess;

    private float startTime = 0;
    private bool isSuccesse = false;


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
        if (Time.time - startTime > 2 && !isSuccesse)
        {
            OnSuccess?.Invoke();
            isSuccesse = true;
        }
    }

   
}
