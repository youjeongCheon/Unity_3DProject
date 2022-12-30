using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomManager : SingleTon<CustomManager>
{
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

   

}
