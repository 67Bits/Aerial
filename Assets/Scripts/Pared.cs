using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Pared : MonoBehaviour
{
    public MMFeedbacks ShineFeedback, shadowFeedback;
    public GameObject silueta;
    public GameObject animatedWall;
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
            print("wall");
            ShineFeedback?.PlayFeedbacks();
            StartCoroutine(Fade());
        }
        if (playSil)
        {
            print("silueta");
            shadowFeedback?.PlayFeedbacks();
            ShineFeedback?.PlayFeedbacks();
            StartCoroutine(FadeSil());
        }
    }

    IEnumerator Fade()
    {
        animatedWall.GetComponent<Animator>().SetTrigger("fall");
        dissapear = false;
        yield return new WaitForSeconds(1.9f);
        gameObject.SetActive(false);
        print("le di a la pared");
    }

    IEnumerator FadeSil()
    {
        playSil = false;
        yield return new WaitForSeconds(0.8f);
        silueta.SetActive(false);
        print("silueta desactivada");
        yield return new WaitForSeconds(0.8f);
        gameObject.SetActive(false);
        print("le di a la silueta");
    }
}
