using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomState { Selet, Move, Rotate, Scale} 

public class Toolbar : MonoBehaviour
{
    [SerializeField]
    private GameObject customCamera;

    public void Selet()
    {
         CustomManager.Instance.customState= CustomState.Selet;
    }

    public void Move()
    {
        CustomManager.Instance.customState = CustomState.Move;
    }

    public void Rotate()
    {
        CustomManager.Instance.customState = CustomState.Rotate;
    }

    public void Scale()
    {
        CustomManager.Instance.customState = CustomState.Scale;
    }

    public void Delete()
    {
        Destroy(CustomManager.Instance.curSelected);
    }
}
