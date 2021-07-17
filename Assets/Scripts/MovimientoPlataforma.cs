using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    [SerializeField]
    private float distancia_final;
    private float velocidad_plataforma;
    private Vector3 pos_inicial;

    public JuegoControl juego_control;

    // Start is called before the first frame update
    void Start()
    {
        velocidad_plataforma = juego_control.velocidad_escenario;
        pos_inicial = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += -transform.forward * velocidad_plataforma * Time.deltaTime;
        if (transform.position.z <= distancia_final)
        {
            transform.position = pos_inicial;
        }
    }

}
