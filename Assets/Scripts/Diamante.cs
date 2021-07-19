using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamante : MonoBehaviour
{
    private JuegoControl juego_control;
    private float velocidad_movimiento;

    // Start is called before the first frame update
    void Start()
    {
        juego_control = GameObject.FindGameObjectWithTag("juegoControl").GetComponent<JuegoControl>();
        velocidad_movimiento = juego_control.velocidad_escenario;

    }




        // Update is called once per frame
        void Update()
    {
        transform.position += -transform.forward * velocidad_movimiento * Time.deltaTime;
    }
}
