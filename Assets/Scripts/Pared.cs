using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Pared : MonoBehaviour
{
    public MMFeedbacks ShineFeedback, shadowFeedback;
    public GameObject silueta;
    [HideInInspector] public bool dissapear = false;
    [HideInInspector] public bool playSil = false;

    private void Start()
    {
        playSil = false;
        dissapear = false;
    }
    private void Update()
    {
        if (dissapear)
        {
            print("fade");
            ShineFeedback?.PlayFeedbacks();
            StartCoroutine(Fade());
        }
        if (playSil)
        {
            print("fade sil");
            shadowFeedback?.PlayFeedbacks();
            StartCoroutine(FadeSil());
        }
    }

    IEnumerator Fade()
    {
        dissapear = false;
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }

    IEnumerator FadeSil()
    {
        playSil = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
