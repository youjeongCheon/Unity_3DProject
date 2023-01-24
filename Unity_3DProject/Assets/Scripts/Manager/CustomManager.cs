using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
using UnityEngine.SceneManagement;

public enum CustomState { Selet, Move, Rotate, Scale, Create, Paint }

public class CustomManager : SingleTon<CustomManager>
{
    private List<GameObject> listobject = new List<GameObject>();

    [SerializeField]
    public GameObject robot;

    public GameObject createObject;
    public GameObject curSelected;
    public GameObject preSelected;

    public Material selectedMaterial;

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

    public void CreateObject()
    {
        GameObject gameObject = Instantiate(createObject);
        ChangeSeleted(gameObject);
        AddListobject(gameObject);
    }

    public void LoadGameScene()
    {
        DontDestroyOnLoad(robot);
        SceneManager.LoadScene(1);
    }
}
