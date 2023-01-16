using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EmotionState { Smile, Angry, Sad, None }
public class EmoticonChanger : MonoBehaviour
{
    private SpriteRenderer renderer;

    [SerializeField]
    private Sprite smileEmotion;
    [SerializeField]
    private Sprite angryEmotion;
    [SerializeField]
    private Sprite sadEmotion;
    [SerializeField]
    private float duration;
    [SerializeField]
    private float appearTime;

    private float time = 0;

    private void Awake()
    {
        renderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.LookAt(GameManager.Instance.MainCam);
    }
    public void Onsuccess()
    {
        ChangeEmotion(EmotionState.Smile);
        Appear();
    }

    private void ChangeEmotion(EmotionState emotionState)
    {
        switch(emotionState)
        {
            case EmotionState.Smile:
                renderer.sprite = smileEmotion;
                break;

            case EmotionState.Angry:
                renderer.sprite = angryEmotion;
                break;

            case EmotionState.Sad:
                renderer.sprite = sadEmotion;
                break;

            default:
                renderer.sprite = null;
                break;
        }
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
        while(true)
        {
            yield return new WaitForSeconds(0.01f);
            if(time <= appearTime)
            {
                transform.localScale = Vector3.one * (time / appearTime);
                time += Time.deltaTime;
            }
            else
            {
                StartCoroutine(Last());
                StopCoroutine(AppearEffect());
            }
        }
        
    }
    private IEnumerator Last()
    {
       
        yield return new WaitForSeconds(duration);
        Disappear();
    }
}
