using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomState { Selet, Move, Rotate, Scale} 

public class Toolbar : MonoBehaviour
{
    public void Selet()
    {
        CustomManager.Instance.customState= CustomState.Selet;
        ArrowDeactive();
        ScaleDeactive();
    }

    public void Move()
    {
        CustomManager.Instance.customState = CustomState.Move;
        ArrowActive();
        ScaleDeactive();
    }

    public void Rotate()
    {
        CustomManager.Instance.customState = CustomState.Rotate;
        ArrowDeactive();
        ScaleDeactive();
    }

    public void Scale()
    {
        CustomManager.Instance.customState = CustomState.Scale;
        ArrowDeactive();
        ScaleActive();
    }

    public void Delete()
    {
        Destroy(CustomManager.Instance.curSelected);

    }

    private void ArrowActive()
    {
        MoveArrow[] moveArrows;
        moveArrows = CustomManager.Instance.curSelected.GetComponentsInChildren<MoveArrow>(true);
        foreach(MoveArrow moveArrow in moveArrows)
        {
            moveArrow.gameObject.SetActive(true);
        }
    }

    private void ArrowDeactive()
    {
        MoveArrow[] moveArrows;
        moveArrows = CustomManager.Instance.curSelected.GetComponentsInChildren<MoveArrow>(true);
        foreach (MoveArrow moveArrow in moveArrows)
        {
            moveArrow.gameObject.SetActive(false);
        }
    }

    private void ScaleActive()
    {
        ScaleArrow[] ScaleArrows;
        ScaleArrows = CustomManager.Instance.curSelected.GetComponentsInChildren<ScaleArrow>(true);
        foreach (ScaleArrow scaleArrow in ScaleArrows)
        {
            scaleArrow.gameObject.SetActive(true);
        }
    }

    private void ScaleDeactive()
    {
        ScaleArrow[] ScaleArrows;
        ScaleArrows = CustomManager.Instance.curSelected.GetComponentsInChildren<ScaleArrow>(true);
        foreach (ScaleArrow scaleArrow in ScaleArrows)
        {
            scaleArrow.gameObject.SetActive(false);
        }
    }
}
