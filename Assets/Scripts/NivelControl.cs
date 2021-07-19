using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NivelControl : MonoBehaviour
{
    public int puntos_nivel = 0;
    
    public int vida = 1;

    public TextMeshProUGUI txt_puntos;

    public GameObject canvasPrincipal, canvasPerdida, canvasInicio;

    public Animator animacion_personaje;

    public void cargarPuntos(int numeroPuntos)
    {
        puntos_nivel += numeroPuntos;
        txt_puntos.text = puntos_nivel.ToString();
    }

    public void hacerDaño(int numeroDaño)
    {
        vida -= numeroDaño;
        if (vida <= 0)
        {
            canvasPerdida.SetActive(true);
            canvasPrincipal.SetActive(false);
            animacion_personaje.SetTrigger("muerte");
        }
    }

    public void iniciar()
    {
        Time.timeScale = 1;
        canvasPrincipal.SetActive(true);
        canvasInicio.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        txt_puntos.text = puntos_nivel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
