using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
    [SerializeField]
    private Vector3 moveAxis;

    private void OnMouseDrag()
    {
        if (CustomManager.Instance.customState == CustomState.Move)
        {
           
        }


    }
}
