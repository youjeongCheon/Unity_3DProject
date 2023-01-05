using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 createPosition = hit.collider.transform.position + hit.normal;
              
                Quaternion createRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

                Instantiate(CustomManager.Instance.createObject, createPosition, createRotation);
            }
        }
    }


    /*private void OnMouseDown()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

        if(Physics.Raycast(ray, out hit))
        {
            Vector2 createPosition = hit.collider.transform.position + hit.normal;
            Quaternion createRotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);

            Instantiate(CustomManager.Instance.createObject, createPosition, createRotation);
        }
    }*/
}
