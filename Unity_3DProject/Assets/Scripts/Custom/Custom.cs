using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

[RequireComponent(typeof(Outlinable))]
public class Custom : MonoBehaviour
{
    private Outlinable outlinable;

    private void Awake()
    {
        outlinable = GetComponent<Outlinable>();
    }

    private void OnMouseDown()
    {
        switch(CustomManager.Instance.customState)
        {
            case CustomState.Selet:
                CustomManager.Instance.ChangeSeleted(this.gameObject);
                break;
            case CustomState.Move:

                break;
            case CustomState.Rotate:

                break;
            case CustomState.Scale:

                break;


        }
    }

    
}
