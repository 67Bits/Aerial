using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NivelControl : MonoBehaviour
{
    [HideInInspector]
    public JuegoControl juegoControl;


    [HideInInspector]
    public int puntos_nivel = 0;
    [HideInInspector]
    public int vida = 1;
    // estado 1 : Juego no ha empezado; estado 2: Juego inicio; estado 3: llego a la meta; 
    [HideInInspector]
    public int estado = 1;
         
    [Header("Anexos Personaje")]
    public Animator animacion_personaje;
    public GameObject personaje_objeto;

    [HideInInspector]
    public float largoactual_nivel = 0;

    [Header("Anexos textura tela")]
    public SkinnedMeshRenderer tela1, tela2;
    public Material m1, m2, m3, m4, m5;

    //[HideInInspector]
    //public List<GameObject> objetos_desaparecidos;

    [Header("Otros Anexos")]
    public GameObject plataforma;

    [Header("Anexos Efectos")]
    public GameObject particulavictoria1, particulavictoria2;

    [Header("Anexos interfaz")]
    public TextMeshProUGUI txt_puntos;
    public TextMeshProUGUI txt_nivel;
    public TextMeshProUGUI txt_nivel_inicio;
    public TextMeshProUGUI txt_diamantes;
    public GameObject canvasPrincipal, canvasPerdida, canvasInicio, canvasVictoria;
    public Slider sliderProgreso;
    public void cargarPuntos(int numeroPuntos)
    {
        puntos_nivel += numeroPuntos;
        txt_puntos.text = puntos_nivel.ToString();
    }

    //public void aparecerobjetos()
    //{
    //    for (int i = 0; i < objetos_desaparecidos.Count; i++)
    //    {
    //        objetos_desaparecidos[i].SetActive(true);
    //    }
    //    objetos_desaparecidos = new List<GameObject>();
    //}

    public void hacerDaño(int numeroDaño)
    {
        vida -= numeroDaño;
        if (vida <= 0)
        {
            canvasPerdida.SetActive(true);
            canvasPrincipal.SetActive(false);
            animacion_personaje.SetTrigger("muerte");
            estado = 1;
        }
        if (vida >= 5)
        {
            vida = 5;
        }
        actualizarTelas();

    }
    public void actualizarTelas()
    {
        if (vida == 1)
        {
            tela1.material = m5;
            tela2.material = m5;
        }
        else if (vida == 2)
        {
            tela1.material = m4;
            tela2.material = m4;
        }
        else if (vida == 3)
        {
            tela1.material = m3;
            tela2.material = m3;
        }
        else if (vida == 4)
        {
            tela1.material = m2;
            tela2.material = m2;
        }
        else if (vida == 5)
        {
            tela1.material = m1;
            tela2.material = m1;
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
        juegoControl = GameObject.FindGameObjectWithTag("juegoControl").GetComponent<JuegoControl>();

        estado = 1;
        vida = 5;
        txt_puntos.text = puntos_nivel.ToString();
        txt_nivel.text = "Level " + (juegoControl.nivel_real).ToString();
        txt_nivel_inicio.text = "Level " + (juegoControl.nivel_real).ToString();

        Invoke("actualizarInfoNivel", 0.1f);
        actualizarTelas();
    }
    public void actualizarInfoNivel()
    {
        largoactual_nivel = juegoControl.niveles[juegoControl.nivel - 1].distancia_a_meta;
        txt_nivel.text = "Level " + (juegoControl.nivel_real).ToString();
        txt_nivel_inicio.text = "Level " + (juegoControl.nivel_real).ToString();
    }

    public void agregarDiamantesTotales()
    {
        juegoControl.diamantes_totales += puntos_nivel;
        PlayerPrefs.SetInt("diamantes", juegoControl.diamantes_totales);
    }

    public void FixedUpdate()
    {
        sliderProgreso.value = (-plataforma.transform.position.z * 100) / largoactual_nivel;
    }
}
