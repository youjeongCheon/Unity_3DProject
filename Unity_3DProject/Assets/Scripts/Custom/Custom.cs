using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    public bool isCreated  { get; set; }

    public bool isOnHand = false;
    public List<GameObject> childHandList = new List<GameObject>();
    public GameObject parentHand;

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
