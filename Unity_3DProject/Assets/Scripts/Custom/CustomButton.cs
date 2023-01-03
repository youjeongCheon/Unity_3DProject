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
        GameObject customObject=  Instantiate(prefab);
        Custom custom = customObject.GetComponentInChildren<Custom>();
        if(CustomManager.Instance.curSelected!=null)
        {
            Toolbar toolbar = FindObjectOfType<Toolbar>();
            toolbar.Selet();
        }
        CustomManager.Instance.ChangeSeleted(customObject);
        CustomManager.Instance.AddListobject(customObject);
        

    }
}
