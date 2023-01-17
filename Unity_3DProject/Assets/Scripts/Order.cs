using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Order : MonoBehaviour
{
    private SpriteRenderer spriteRender;

    [SerializeField]
    private List<FoodData> Orders;
    [SerializeField]
    private float appearTime = 0.5f;

    public FoodData data { private set; get; }
    
    private int rand;
    private float time = 0;

    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        RandomOrder();
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        transform.LookAt(GameManager.Instance.MainCam);
    }

    private void RandomOrder()
    {
        rand = Random.Range(0, 4);
        data = Orders[rand];
        spriteRender.sprite = data.Icon;
    }

    public void OnOrdered()
    {
        Appear();
    }
    public void OnSuccess()
    {
        Disappear();
    }
    public void OnFailed()
    {
        Disappear();
        StartCoroutine(ReappearEffect());

    }
    private void Appear()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        StartCoroutine(AppearEffect());
    }

    private void Disappear()
    {
        time = 0;
        gameObject.SetActive(false);
    }

    private IEnumerator AppearEffect()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (time <= appearTime)
            {
                transform.localScale = Vector3.one * (time / appearTime);
                time += Time.deltaTime;
            }
            else
            {
                StopCoroutine(AppearEffect());
            }
        }

    }

    private IEnumerator ReappearEffect()
    {
        yield return new WaitForSeconds(appearTime+3f);
        Appear();

    }


}
