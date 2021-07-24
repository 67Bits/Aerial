using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Pared : MonoBehaviour
{
    public MMFeedbacks ShineFeedback;
    public GameObject silueta;
    [HideInInspector] public bool dissapear = false;

    private void Update()
    {
        if (dissapear)
        {
            ShineFeedback?.PlayFeedbacks();
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        dissapear = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
