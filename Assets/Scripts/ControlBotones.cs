using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{
    public NivelControl nivelControl;
    

    public void reiniciar()
    {
        //SceneManager.LoadScene("Prototipo");
    }

    public void pasarNivel()
    {


        nivelControl.niveles[nivelControl.nivel].SetActive(false);
        nivelControl.nivel++;
        nivelControl.niveles[nivelControl.nivel].SetActive(true);

        nivelControl.personaje_objeto.transform.position = Vector3.zero;

        nivelControl.estado = 1;
        nivelControl.canvasPrincipal.SetActive(false);
        nivelControl.canvasVictoria.SetActive(false);
        nivelControl.canvasInicio.SetActive(true);

        nivelControl.puntos_nivel = 0;
        nivelControl.txt_nivel.text = "Level " + (nivelControl.nivel+1).ToString();
        nivelControl.txt_nivel_inicio.text = "Level " + (nivelControl.nivel+1).ToString();


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
}
