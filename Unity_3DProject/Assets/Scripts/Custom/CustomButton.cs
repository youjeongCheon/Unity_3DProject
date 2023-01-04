using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomButton : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    public void Click()
    {
        CustomManager.Instance.createObject = prefab;
        CustomManager.Instance.customState = CustomState.Create;
        
        if(CustomManager.Instance.curSelected==null)
        {
            CustomManager.Instance.CreateObject();
            CustomManager.Instance.customState = CustomState.Selet;
        }
        else
        {
            Toolbar toolbar = FindObjectOfType<Toolbar>();
            toolbar.Create();

        }
    }
}
