using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbar : MonoBehaviour
{
    [SerializeField]
    private GameObject createUI;
    [SerializeField]
    private GameObject paintUI;

    public void Selet()
    {
        CustomManager.Instance.customState= CustomState.Selet;
        MoveDeactive();
        ScaleDeactive();
    }

    public void Move()
    {
        CustomManager.Instance.customState = CustomState.Move;
        MoveActive();
        ScaleDeactive();
    }

    public void Rotate()
    {
        CustomManager.Instance.customState = CustomState.Rotate;
        MoveDeactive();
        ScaleDeactive();
    }

    public void Scale()
    {
        CustomManager.Instance.customState = CustomState.Scale;
        MoveDeactive();
        ScaleActive();
    }

    public void Delete()
    {
        CustomManager.Instance.DeleteListobject(CustomManager.Instance.curSelected);
    }

    public void Create()
    {
        CustomManager.Instance.customState = CustomState.Create;
        CreateMode();
        MoveDeactive();
        ScaleDeactive();
    }

    public void Paint()
    {
        CustomManager.Instance.customState = CustomState.Paint;
        PaintMode();
        MoveDeactive();
        ScaleDeactive();

    }

    private void PaintMode()
    {
        createUI.SetActive(false);
        paintUI.SetActive(true);
    }

    private void CreateMode()
    {
        createUI.SetActive(true);
        paintUI.SetActive(false);
    }

    private void MoveActive()
    {
        MoveArrow[] moveArrows;
        moveArrows = CustomManager.Instance.curSelected.GetComponentsInChildren<MoveArrow>(true);
        foreach(MoveArrow moveArrow in moveArrows)
        {
            moveArrow.gameObject.SetActive(true);
        }
    }

    private void MoveDeactive()
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
