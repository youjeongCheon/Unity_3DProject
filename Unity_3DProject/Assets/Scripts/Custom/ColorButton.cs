using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField]
    private Material color;
    [SerializeField]
    private Color colorImage;
    [SerializeField]
    private Image curColorImage;


    public void paintClick()
    {
        CustomManager.Instance.selectedMaterial = color;
        curColorImage.color = colorImage;
    }
}
