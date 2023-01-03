using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomManager : SingleTon<CustomManager>
{
    private List<GameObject> listobject = new List<GameObject>();

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
            Outlinable preOutlinable = preSelected.GetComponentInChildren<Outlinable>();
            preOutlinable.DrawingMode = 0;
        }
        Outlinable curOutlinable = curSelected.GetComponentInChildren<Outlinable>();
        curOutlinable.DrawingMode = OutlinableDrawingMode.Normal;
    }

    public void AddListobject(GameObject gameObject)
    {
        listobject.Add(gameObject);
    }

    public void DeleteListobject(GameObject gameObject)
    {
        listobject.Remove(gameObject);
        Destroy(gameObject);
    }
   

}
