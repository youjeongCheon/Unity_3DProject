using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager>
{
    [SerializeField]
    public Transform startPosition;
    [SerializeField]
    public Transform MainCam;

    [SerializeField]
    private GameObject test1;
    [SerializeField]
    private GameObject test2;

    public GameObject targert;

    private Transform[] allChildren;

    public float money = 0;
    public float bestMoney=0;

    private void Start()
    {
        Time.timeScale = 0;
        SettingRobot();
    }

    private void SettingRobot()
    {

        GameObject robot = GameObject.Find("Robot");
        if(robot!=null)
        {
            targert = robot;
            robot.transform.position = startPosition.transform.position;
            robot.transform.localScale = 0.5f * robot.transform.localScale;
            allChildren = robot.GetComponentsInChildren<Transform>();
            foreach (Transform child in allChildren)
            {
                if (child.GetComponent<PartJoint>() != null)
                    child.GetComponent<PartJoint>().SetPart();
                child.gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
        
    }

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            
            SceneManager.LoadScene(2);
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {
            
            SceneManager.LoadScene(3);
        }
    }

    public void LoadCustomScene()
    {
        Destroy(GameObject.Find("Robot"));
        SceneManager.LoadScene(0);
    }

    public void SetScore()
    {
        if (bestMoney < money)
            bestMoney = money;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
