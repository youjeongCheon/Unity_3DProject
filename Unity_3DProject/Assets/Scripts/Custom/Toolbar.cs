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
    }

    public void Move()
    {
        CustomManager.Instance.customState = CustomState.Move;
        ArrowActive();
    }

    public void Rotate()
    {
        CustomManager.Instance.customState = CustomState.Rotate;
        ArrowDeactive();
    }

    public void Scale()
    {
        CustomManager.Instance.customState = CustomState.Scale;
        ArrowDeactive();
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
}
