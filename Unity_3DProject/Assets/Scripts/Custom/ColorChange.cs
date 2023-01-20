using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField]
    private Material color;

    public void paintClick()
    {
        CustomManager.Instance.selectedMaterial = color;
        
    }
}
