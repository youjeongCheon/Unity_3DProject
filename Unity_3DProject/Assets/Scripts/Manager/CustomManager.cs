using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomManager : SingleTon<CustomManager>
{
    private List<Custom> customs = new List<Custom>();

    public GameObject curSelected;
    public GameObject preSelected;

    public CustomState customState;



    public void ChangeSeleted(GameObject gameObject)
    {
        if (curSelected != gameObject)
        {
            preSelected = curSelected;
            curSelected = gameObject;
        }
        if(preSelected!=null)
        {
            Outlinable preOutlinable = preSelected.GetComponent<Outlinable>();
            preOutlinable.DrawingMode = 0;
        }
        Outlinable curOutlinable = curSelected.GetComponent<Outlinable>();
        curOutlinable.DrawingMode = OutlinableDrawingMode.Normal;
    }

    public void AddCustom(Custom custom)
    {
        customs.Add(custom);
    }

    public void DeleteCustom(Custom custom)
    {
        customs.Remove(custom);
        Destroy(custom.gameObject);
    }
   

}
