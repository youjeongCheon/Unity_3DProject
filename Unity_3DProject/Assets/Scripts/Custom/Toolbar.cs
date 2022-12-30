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
        CameraActive();
         CustomManager.Instance.customState= CustomState.Selet;
    }

    public void Move()
    {
        CamraDeactivate();
        CustomManager.Instance.customState = CustomState.Move;
    }

    public void Rotate()
    {
        CamraDeactivate();
        CustomManager.Instance.customState = CustomState.Rotate;
    }

    public void Scale()
    {
        CamraDeactivate();
        CustomManager.Instance.customState = CustomState.Scale;
    }

    public void Delete()
    {
        Destroy(CustomManager.Instance.curSelected);
    }

    private void CameraActive()
    {
        customCamera.SetActive(true);
    }

    private void CamraDeactivate()
    {
        customCamera.SetActive(false);
    }

}
