using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Personaje : MonoBehaviour
{
    public NivelControl nivelControl;
    [SerializeField]
    private GameObject particula_diamante1;

    public CinemachineImpulseSource shake;

    public Animator animacion_personaje;

    private bool condiamante = false;

    public PersonajeMovimiento personajeMovimiento;


    public void OnTriggerEnter(Collider other)
    {

        if (nivelControl.vida > 0)
        {
            // Diamantes
            if (other.gameObject.layer == 9)
            {
                nivelControl.hacerDaño(-1);
                GameObject particula = Instantiate(particula_diamante1);
                particula.transform.position = other.transform.position;
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                nivelControl.objetos_desaparecidos.Add(other.gameObject);

                nivelControl.cargarPuntos(1);
                condiamante = true;
                animacion_personaje.ResetTrigger("subir");
                animacion_personaje.ResetTrigger("bajar");
                animacion_personaje.ResetTrigger("Idle");

                animacion_personaje.SetInteger("diamante", Random.Range(1, 3));

                personajeMovimiento.bloqueado = true;
                Physics.gravity = Vector3.zero;
                personajeMovimiento.rg_personaje.velocity = Vector3.zero;
                StopAllCoroutines();
                StartCoroutine("desactivarAnimacionDiamantes");
            }
            // Tijeras
            else if (other.gameObject.layer == 10)
            {
                //GameObject particula = Instantiate(particula_diamante1);
                //particula.transform.position = other.transform.position;
                other.gameObject.SetActive(false);
                nivelControl.objetos_desaparecidos.Add(other.gameObject);

                nivelControl.hacerDaño(1);
                //nivelControl.puntos_nivel++;
                shake.GenerateImpulse();
            }
            // LLegada
            else if (other.gameObject.layer == 12)
            {
                other.gameObject.SetActive(false);
                nivelControl.estado = 3;
                nivelControl.canvasPrincipal.SetActive(false);
                nivelControl.canvasVictoria.SetActive(true);

                nivelControl.agregarDiamantesTotales();
                nivelControl.txt_diamantes.text = "Level Diamonds: " + (nivelControl.puntos_nivel).ToString() + "\nAll Diamonds: " + (nivelControl.juegoControl.diamantes_totales).ToString();

                animacion_personaje.SetTrigger("victoria");

            }
        }
    }

    IEnumerator desactivarAnimacionDiamantes()
    {
        yield return new WaitForSeconds(0.4f);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        personajeMovimiento.bloqueado = false;
        condiamante = false;
        animacion_personaje.SetInteger("diamante", 0);
    }

    //public void desactivarAnimacionDiamantes()
    //{

    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == 13 && !condiamante)
    //    {
    //        animacion_personaje.SetTrigger("Idle");
    //    }
    //}
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 13 && !condiamante && nivelControl.vida > 0)
        {
            animacion_personaje.SetTrigger("Idle");
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.layer == 13)
    //    {
    //        animacion_personaje.ResetTrigger("Idle");
    //    }
    //}
}
