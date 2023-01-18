using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Food Data",menuName = "Scriptable Object/Food Data",order = int.MaxValue)]
public class FoodData : ScriptableObject
{
    [SerializeField]
    private string foodName;
    [SerializeField]
    private float cost;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private GameObject prefab;

    public string FoodName { get { return foodName; } }
    public float Cost { get { return cost; } }
    public Sprite Icon { get { return icon; } }
    public GameObject Prefab { get { return prefab; } }
}
