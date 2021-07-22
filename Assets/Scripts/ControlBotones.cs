using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    public NivelControl nivelControl;

    private JuegoControl juegoControl;

    public void reiniciar()
    {
        SceneManager.LoadScene(juegoControl.niveles[juegoControl.nivel - 1].ref_nivel);
    }

    public void pasarNivel()
    {
        juegoControl.nivel++;
        juegoControl.nivel_real++;
       
        if (juegoControl.nivel > 5)
        {
            juegoControl.nivel = Random.Range(1, 5);
        }
        SceneManager.LoadScene(juegoControl.niveles[juegoControl.nivel-1].ref_nivel);
    }

    public void pausar()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;

        }
    }
    public void Start()
    {
        juegoControl = nivelControl.juegoControl;
    }
}
