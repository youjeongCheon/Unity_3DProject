using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    public bool isCreated  { get; set; }
    GameObject curSeleted;

    private void Awake()
    {
        isCreated = true;
    }

    private void OnMouseDown()
    {
        switch (CustomManager.Instance.customState)
        {
            case CustomState.Selet:
                CustomManager.Instance.ChangeSeleted(gameObject.transform.root.gameObject);
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
