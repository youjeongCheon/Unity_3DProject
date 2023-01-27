using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;
using UnityEngine.SceneManagement;

public enum CustomState { Selet, Move, Rotate, Scale, Create, Paint }

public class CustomManager : SingleTon<CustomManager>
{
    public List<GameObject> listObject = new List<GameObject>();

    [SerializeField]
    private GameObject robotPrefab;

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
        listObject.Add(gameObject);
    }

    public void DeleteListobject(GameObject gameObject)
    {
        listObject.Remove(gameObject);
        Destroy(gameObject);
    }

    public void CreateObject()
    {
        GameObject gameObject = Instantiate(createObject);
        gameObject.name = createObject.name;
        ChangeSeleted(gameObject);
        AddListobject(gameObject);
    }

    public void LoadGameScene()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(2);
    }

    public void RobotIntoGame()
    {
        GameObject robot = Instantiate(robotPrefab);
        robot.name = robotPrefab.name;
        foreach (GameObject gameObject in listObject)
        {
            DontDestroyOnLoad(gameObject);
            ////////////////////////////////////////////////////////////////////
            Custom custom = gameObject.GetComponentInChildren<Custom>();
            if (custom.childHandList.Count > 0)
                AttatchHand(gameObject,robot);
            else if (!custom.isOnHand)
            {
                GameObject copyobject = Instantiate(gameObject, gameObject.transform.position, gameObject.transform.rotation);
                copyobject.name = gameObject.name;

                if (copyobject.name == "Wheel_Joint_Right")
                    copyobject.transform.parent = robot.transform.GetChild(0);
                else if (copyobject.name == "Wheel_Joint_Left")
                    copyobject.transform.parent = robot.transform.GetChild(1);
                else
                    copyobject.transform.parent = robot.transform;
            }
            ///////////////////////////////////////////////////////////////
         
           
            
        }
        DontDestroyOnLoad(robot);
    }

    private void AttatchHand(GameObject handObject, GameObject robot)
    {
        GameObject handCopy = Instantiate(handObject, handObject.transform.position, handObject.transform.rotation);
        handCopy.name = handObject.name;
        Custom custom = handCopy.GetComponentInChildren<Custom>();
        Custom originCustom = handObject.GetComponentInChildren<Custom>();
        
        foreach (GameObject childHandObject in originCustom.childHandList)
        {
            custom.childHandList.Remove(childHandObject);
            GameObject copyChild = Instantiate(childHandObject, childHandObject.transform.position, childHandObject.transform.rotation);
            copyChild.name = childHandObject.name;
            custom.childHandList.Add(copyChild);
        }
        while (custom.childHandList.Count>0)
        {
            foreach(GameObject childHandObject in custom.childHandList)
            {
                childHandObject.GetComponentInChildren<Custom>().parentHand = handCopy;
                custom.childHandList.Remove(childHandObject);
                AttatchHand(childHandObject,robot);
            }
        }
        
        if(!custom.isOnHand)
        {
            handCopy.transform.parent= robot.transform;
        }
        else
        {
            handCopy.transform.parent = handCopy.GetComponentInChildren<Custom>().parentHand.transform;

        }
    }
}
