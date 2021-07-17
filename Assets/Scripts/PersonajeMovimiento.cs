using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovimiento : MonoBehaviour
{
    public float fuerza_movimiento;
    [SerializeField]
    private Rigidbody rg_personaje;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("click clack");
            //rg_personaje.velocity = Vector3.up * fuerza_movimiento;
            //anim.speed = 1;
            anim.SetBool("up", true);

        }
        else if (Input.GetMouseButtonUp(0))
        {
            //anim.speed = 0;
            anim.SetBool("up", false);
        }
    }
}
