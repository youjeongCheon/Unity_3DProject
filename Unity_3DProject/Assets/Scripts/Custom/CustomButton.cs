using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class CustomButton : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private GameObject robot;

    public void Select()
    {
        GameObject custom=  Instantiate(prefab,robot.transform);
        custom.transform.parent = robot.transform;
        CustomManager.Instance.ChangeSeleted(custom);

    }
}
