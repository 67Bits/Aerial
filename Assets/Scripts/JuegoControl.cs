using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoControl : MonoBehaviour
{

    //Instancia del objeto
    public static JuegoControl administrador;


    [HideInInspector]
    public float velocidad_escenario = 4;

    public int diamantes_totales;

    [HideInInspector]
    public List<Nivel> niveles;

    public int nivel = 1;
    public int nivel_real = 1;

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
        Nivel aCrear = new Nivel(1, 94.36f, "Prototipo1");
        niveles.Add(aCrear);
        aCrear = new Nivel(2, 94.36f, "Prototipo2");
        niveles.Add(aCrear);
        aCrear = new Nivel(3, 94.36f, "Prototipo3");
        niveles.Add(aCrear);
        aCrear = new Nivel(4, 94.36f, "Prototipo4");
        niveles.Add(aCrear);
        aCrear = new Nivel(5, 94.36f, "Prototipo5");
        niveles.Add(aCrear);
    }
}
