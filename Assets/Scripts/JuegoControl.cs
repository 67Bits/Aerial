using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoControl : MonoBehaviour
{
    
    public int diamantes_totales;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("diamantes"))
        {
            diamantes_totales = PlayerPrefs.GetInt("diamantes");
        }
        else
        { 
            diamantes_totales = 0;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
