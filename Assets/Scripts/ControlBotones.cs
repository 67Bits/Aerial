using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlBotones : MonoBehaviour
{

    public void reiniciar()
    {
        SceneManager.LoadScene("Prototipo");
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
