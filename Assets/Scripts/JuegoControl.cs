using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoControl : MonoBehaviour
{

    //Instancia del objeto
    [HideInInspector]
    public static JuegoControl administrador;


    [HideInInspector]
    public float velocidad_escenario = 4;

    [HideInInspector]
    public int diamantes_totales;

    [HideInInspector]
    public List<Nivel> niveles;

    [HideInInspector]
    public int nivel = 1;
    [HideInInspector]
    public int nivel_real = 1;

    [Header("Largo de niveles")]
    public float largo1, largo2, largo3, largo4, largo5;

    public void Awake()
    {
        if (administrador == null)
        {
            administrador = this;
            DontDestroyOnLoad(administrador);
        }
        else { Destroy(gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        nivel = 1;
        nivel_real = 1;
        // Persistencia
        if (PlayerPrefs.HasKey("diamantes"))
        {
            diamantes_totales = PlayerPrefs.GetInt("diamantes");
        }
        else
        {
            diamantes_totales = 0;
        }

        // Base
        crearNiveles();
    }


    public void crearNiveles()
    {
        niveles = new List<Nivel>();
        Nivel aCrear = new Nivel(1, largo1, "Prototipo1");
        niveles.Add(aCrear);
        aCrear = new Nivel(2, largo2, "Prototipo2");
        niveles.Add(aCrear);
        aCrear = new Nivel(3, largo3, "Prototipo3");
        niveles.Add(aCrear);
        aCrear = new Nivel(4, largo4, "Prototipo4");
        niveles.Add(aCrear);
        aCrear = new Nivel(5, largo5, "Prototipo5");
        niveles.Add(aCrear);
    }
}
