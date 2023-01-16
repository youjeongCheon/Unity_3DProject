using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class FoodProvider : MonoBehaviour
{
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material red;
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private Transform spawnTransform;
    [SerializeField]
    private float time = 2f;
    [SerializeField]
    private LayerMask layer;

    private MeshRenderer renderer;
    private Coroutine spawnCorutine;
    private bool isSpawn = false;
    

    private Vector3 point = new Vector3(0.05f, 4, 0.05f);

    private void Awake()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, point, Quaternion.identity, layer);
        if (!isSpawn&&colliders.Length>0)
        {
            renderer.material = red;
            spawnCorutine = StartCoroutine(FoodSpawn());
            isSpawn = true;
        }
        else if(isSpawn&&colliders.Length==0)
        {
            renderer.material = green;
            StopCoroutine(spawnCorutine);
            isSpawn = false;
        }
    }
   
    private IEnumerator FoodSpawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(time);
            Instantiate(food, spawnTransform.position,Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, point * 2);
    }
}
