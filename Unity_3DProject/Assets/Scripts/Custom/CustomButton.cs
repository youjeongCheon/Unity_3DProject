using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomButton : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    

    public void Select()
    {
        GameObject customObject=  Instantiate(prefab);
        Custom custom = customObject.GetComponent<Custom>();
        CustomManager.Instance.ChangeSeleted(customObject);
        CustomManager.Instance.AddCustom(custom);

    }
}
