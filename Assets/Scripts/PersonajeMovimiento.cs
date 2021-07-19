using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public NivelControl nivelControl;

    public float fuerza_movimiento;
    [SerializeField]
    private Rigidbody rg_personaje;
    [SerializeField]
    private Rigidbody rg_personaje_global;
    public Animator anim;

    private Vector3 planeNormal;
    private float radians;
    private float degrees;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (nivelControl.vida > 0)
        {



            if (Input.GetMouseButton(0))
            {
                rg_personaje.velocity = Vector3.up * fuerza_movimiento;
                //anim.speed = 1;
                anim.SetBool("subir", true);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                //anim.speed = 0;
                anim.SetBool("subir", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (nivelControl.vida > 0)
        {

            transform.position += transform.forward * fuerza_movimiento * Time.deltaTime; 

         
        }

    }
}
