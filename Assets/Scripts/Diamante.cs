using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Diamante : MonoBehaviour
{
    public MMFeedbacks RotateFeedback;

    // Update is called once per frame
    void Update()
    {
        RotateFeedback?.PlayFeedbacks();
    }
}
