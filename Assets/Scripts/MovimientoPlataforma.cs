using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public NivelControl nivelControl;

    [SerializeField]
    private float distancia_final;
    private float velocidad_plataforma;
    private Vector3 pos_inicial;

    public JuegoControl juegoControl;

    // Start is called before the first frame update
    void Start()
    {
        juegoControl = GameObject.FindGameObjectWithTag("juegoControl").GetComponent<JuegoControl>();

        velocidad_plataforma = juegoControl.velocidad_escenario;
        pos_inicial = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (nivelControl.estado == 2)
        {
            transform.position += -transform.forward * velocidad_plataforma * Time.deltaTime;
        }
        //if (transform.position.z <= distancia_final)
        //{
        //    transform.position = pos_inicial;
        //}
    }

}
