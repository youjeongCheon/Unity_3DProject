using UnityEngine;



public class Toolbar : MonoBehaviour
{
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
        Destroy(CustomManager.Instance.curSelected);

    }

    public void Create()
    {
        MoveDeactive();
        ScaleDeactive();
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
