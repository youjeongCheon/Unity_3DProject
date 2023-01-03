using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    private void OnMouseDown()
    {
        switch (CustomManager.Instance.customState)
        {
            case CustomState.Selet:
                CustomManager.Instance.ChangeSeleted(gameObject.transform.parent.gameObject);
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
