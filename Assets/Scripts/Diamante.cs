using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Diamante : MonoBehaviour
{
    public MMFeedbacks RotateFeedback;
       
    public int pose;
    public GameObject pared_anexa = null;

    // Update is called once per frame
    void Update()
    {
        RotateFeedback?.PlayFeedbacks();
    }
}
