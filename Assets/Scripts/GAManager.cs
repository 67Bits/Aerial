using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GAManager : MonoBehaviour
{
    public static GAManager instance;
    JuegoControl juegoControl;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        juegoControl = GameObject.FindGameObjectWithTag("JuegoControl").GetComponent<JuegoControl>();
        GameAnalytics.Initialize();
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level" + juegoControl.nivel_real);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelComplete (int level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level " + level);
        print("Level " + level);
    }
}
