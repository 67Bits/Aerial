using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NivelControl : MonoBehaviour
{
    public JuegoControl juegoControl;

    public GameObject personaje_objeto;

    public int puntos_nivel = 0;
    
    public int vida = 1;
    // estado 1 : Juego no ha empezado; estado 2: Juego inicio; estado 3: llego a la meta; 
    public int estado = 1;

    public TextMeshProUGUI txt_puntos;
    public TextMeshProUGUI txt_nivel;
    public TextMeshProUGUI txt_nivel_inicio;
    public TextMeshProUGUI txt_diamantes;

    public GameObject canvasPrincipal, canvasPerdida, canvasInicio, canvasVictoria;

    public Animator animacion_personaje;


    public List<GameObject> niveles;
    public int nivel = 0;
    private float largoactual_nivel;

    public Slider sliderProgreso;

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
        estado = 2;
        canvasPrincipal.SetActive(true);
        canvasInicio.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        estado = 1;
        txt_puntos.text = puntos_nivel.ToString();
        txt_nivel.text = "Level " + (nivel + 1).ToString();
        txt_nivel_inicio.text = "Level " + (nivel + 1).ToString();

        niveles[nivel].SetActive(true);
        largoactual_nivel = niveles[nivel].GetComponent<Nivel>().distancia_a_meta;
    }

    public void agregarDiamantesTotales()
    {
        juegoControl.diamantes_totales += puntos_nivel;
        PlayerPrefs.SetInt("diamantes", juegoControl.diamantes_totales);
        print(juegoControl.diamantes_totales);
    }

    public void FixedUpdate()
    {
        sliderProgreso.value = (personaje_objeto.transform.position.z * 100) / largoactual_nivel;
    }
}
