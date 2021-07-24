using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Pared : MonoBehaviour
{
    public MMFeedbacks ShineFeedback/*, particleFeedback*/;
    public GameObject silueta;
    [HideInInspector] public bool dissapear = false;

    private void Update()
    {
        if (dissapear)
        {
            print("fade");
            ShineFeedback?.PlayFeedbacks();
            //particleFeedback?.PlayFeedbacks();
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        print("dade");
        dissapear = false;
        yield return new WaitForSeconds(0.4f);
        gameObject.SetActive(false);
    }
}
