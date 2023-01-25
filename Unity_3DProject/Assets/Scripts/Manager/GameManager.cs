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

  
    private Transform[] allChildren;

    public float money = 0;

    private void Start()
    {
        SettingRobot();
    }

    private void SettingRobot()
    {

        GameObject robot = GameObject.Find("Robot");
        robot.transform.position = startPosition.transform.position;
        robot.transform.localScale = 0.5f * robot.transform.localScale;
        allChildren = robot.GetComponentsInChildren<Transform>();
        foreach(Transform child in allChildren)
        {
            child.gameObject.layer = LayerMask.NameToLayer("Player");
        }
    }

    public void LoadCustomScene()
    {
        Destroy(GameObject.Find("Robot"));
        SceneManager.LoadScene(0);
    }
}
