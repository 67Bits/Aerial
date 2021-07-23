using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public NivelControl nivelControl;

    public float fuerza_movimiento;
    public float velocidad_movimiento_principal;
    [SerializeField]
    public Rigidbody rg_personaje;
    [SerializeField]
    private Rigidbody rg_personaje_global;
    public Animator anim;

    // Pendientes
    RaycastHit actual_pendiente_ray;
    Vector3 piso_direccion;
    float piso_angulo;
    Vector3 pendiente_direccion_movimiento;

    [HideInInspector]
    public bool bloqueado = false;

    private bool detectarPendiente()
    {
        int layer = 1 << 11; 
        if (Physics.Raycast(transform.position, Vector3.down, out actual_pendiente_ray,2, layer))
        {
            if (actual_pendiente_ray.normal != Vector3.up)
            {
                Vector3 vector1 = Vector3.Cross(actual_pendiente_ray.normal, Vector3.down);
                piso_direccion = Vector3.Cross(vector1, actual_pendiente_ray.normal);
                piso_angulo = Vector3.Angle(actual_pendiente_ray.normal, Vector3.up);
                return true;               
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nivelControl.estado == 2)
        {
            if (Input.GetMouseButton(0))
            {
                if (!bloqueado)
                {
                    anim.SetTrigger("subir");
                    anim.ResetTrigger("Idle");
                }
                rg_personaje.velocity = Vector3.up * fuerza_movimiento;
              
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (!bloqueado)
                {
                    anim.SetTrigger("subir");
                    anim.ResetTrigger("Idle");
                }

            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (!bloqueado)
                {
                    anim.SetTrigger("bajar");
                    anim.ResetTrigger("Idle");
                }                
            }
        }
    }

    private void FixedUpdate()
    {
        if (nivelControl.estado == 2)
        {
            if (detectarPendiente())
            {
                pendiente_direccion_movimiento = Vector3.ProjectOnPlane(Vector3.forward, actual_pendiente_ray.normal);
                gameObject.transform.position += pendiente_direccion_movimiento.normalized * velocidad_movimiento_principal * Time.deltaTime;
            }
            else
            {
                gameObject.transform.position += Vector3.forward * velocidad_movimiento_principal * Time.deltaTime;
            }           
        }
    }
}
