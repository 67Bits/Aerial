using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorElementos : MonoBehaviour
{
    // Prefabs del diamane y enemigo 1
    public GameObject diamante_prefab, enemigo1_prefab;
    // contenedores de enemigos y dimanates
    public GameObject contenedor_dimantes, contenedor_enemigos;

    [SerializeField]
    private float punto_inferor, punto_superior;

    private float distancia_entre_lineas_tiempo = 2;
    private float distancia_minima_entre_elementos = 2;

    private int nivel;

    // Start is called before the first frame update
    void Start()
    {
        // Segun el nivel se ajustan los rangos de probabilidad de generacion 
        // Segun el nivel se ajustan los espacios entre lineas y elementos
        nivel = 1;
        StartCoroutine("generarfila");
    }

    // Genera filas de elementos verticales cada determinado tiempo
    IEnumerator generarfila()
    {
        yield return new WaitForSeconds(distancia_entre_lineas_tiempo);

        float punto_creacion = Random.Range(punto_inferor, punto_inferor + 2);

        // Se crean elementos hasta alcanzar el punto superior
        // segun los rangos de probabilidad se crean los diamantes, enemigos y vacio
        // Varia la dificultad dependientos los rangos de generación
        while (punto_creacion < punto_superior)
        {
            // Probabilidad de crear 
            int probabilidad = Random.Range(0, 10);

            if (probabilidad > 4 && probabilidad < 6)
            {
                if (contenedor_dimantes.transform.childCount < 8)
                {
                    GameObject instaciado = Instantiate(diamante_prefab);
                    instaciado.transform.parent = contenedor_dimantes.transform;
                    instaciado.transform.position = new Vector3(0, punto_creacion, 12);
                }
                else
                {
                    bool termino = false;
                    for (int i = 0; i < contenedor_dimantes.transform.childCount && !termino; i++)
                    {
                        if (!contenedor_dimantes.transform.GetChild(i).gameObject.activeSelf)
                        {
                            contenedor_dimantes.transform.GetChild(i).gameObject.SetActive(true);
                            termino = true;
                            contenedor_dimantes.transform.GetChild(i).gameObject.SetActive(true);
                            contenedor_dimantes.transform.GetChild(i).GetComponent<Diamante>().StartCoroutine("eliminar");
                            contenedor_dimantes.transform.GetChild(i).transform.position = new Vector3(0, punto_creacion, 12);
                        }
                    }
                }

            }
            else if (probabilidad > 6)
            {

                if (contenedor_enemigos.transform.childCount < 8)
                {
                    GameObject instaciado = Instantiate(enemigo1_prefab);
                    instaciado.transform.parent = contenedor_enemigos.transform;
                    instaciado.transform.position = new Vector3(0, punto_creacion, 12);
                }
                else
                {
                    bool termino = false;
                    for (int i = 0; i < contenedor_enemigos.transform.childCount && !termino; i++)
                    {
                        if (!contenedor_enemigos.transform.GetChild(i).gameObject.activeSelf)
                        {
                            contenedor_enemigos.transform.GetChild(i).gameObject.SetActive(true);
                            termino = true;
                            contenedor_enemigos.transform.GetChild(i).GetComponent<Enemigo>().StartCoroutine("eliminar");
                            contenedor_enemigos.transform.GetChild(i).transform.position = new Vector3(0, punto_creacion, 12);
                        }
                    }
                }
            }
            punto_creacion += distancia_minima_entre_elementos + Random.Range(0, 2);
        }
        StartCoroutine("generarfila");
    }



    // Update is called once per frame
    void Update()
    {

    }
}
