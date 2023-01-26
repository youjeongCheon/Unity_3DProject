using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    public bool isCreated  { get; set; }

    public GameObject hand;

    private void Awake()
    {
        isCreated = true;
    }

    private void OnMouseDown()
    {
        if(CustomManager.Instance.customState== CustomState.Selet)
        {
            CustomManager.Instance.ChangeSeleted(gameObject.transform.root.gameObject);
        }
    }
}
