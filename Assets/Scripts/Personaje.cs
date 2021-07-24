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

    private GameObject paredActual;

    public DiamanteADiamante diamanteADiamante;

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

                other.gameObject.SetActive(false);

                condiamante = true;
                animacion_personaje.ResetTrigger("subir");
                animacion_personaje.ResetTrigger("bajar");
                animacion_personaje.ResetTrigger("Idle");

                //animacion_personaje.SetInteger("diamante", Random.Range(1, 3));

                animacion_personaje.SetInteger("diamante", other.gameObject.GetComponent<Diamante>().pose);
                StopAllCoroutines();
                if (other.gameObject.GetComponent<Diamante>().pared_anexa == null)
                {
                    StartCoroutine("desactivarAnimacionDiamantes");
                }
                else
                {
                    paredActual = other.gameObject.GetComponent<Diamante>().pared_anexa;
                    Invoke("desaparecerPared", 1f);
                    StartCoroutine("desactivarAnimacionDiamantes2");
                }

                personajeMovimiento.bloqueado = true;
                Physics.gravity = new Vector3(0, -5, 0);
                personajeMovimiento.fuerza_movimiento = personajeMovimiento.fuerza_movimiento - 0.6f;
                //personajeMovimiento.rg_personaje.velocity = Vector3.zero;

                diamanteADiamante.comenzarMovimiento(other.transform.position, () =>
                {
                    nivelControl.cargarPuntos(1);
                });

            }
            // Tijeras
            else if (other.gameObject.layer == 10)
            {
                other.gameObject.SetActive(false);

                nivelControl.hacerDaño(1);

                shake.GenerateImpulse();
            }
            // LLegada
            else if (other.gameObject.layer == 12)
            {
                paredActual = other.gameObject;
                Invoke("desaparecerPared", 1f);
                //other.gameObject.SetActive(false);
                nivelControl.estado = 3;
                nivelControl.canvasPrincipal.SetActive(false);
                nivelControl.canvasVictoria.SetActive(true);

                nivelControl.agregarDiamantesTotales();
                nivelControl.txt_diamantes.text = "Level Diamonds: " + (nivelControl.puntos_nivel).ToString() + "\nAll Diamonds: " + (nivelControl.juegoControl.diamantes_totales).ToString();

                animacion_personaje.SetTrigger("victoria");
                nivelControl.particulavictoria1.SetActive(true);
                nivelControl.particulavictoria2.SetActive(true);
            }
            else if (other.gameObject.layer == 14)
            {
                other.gameObject.SetActive(false);

                float distancia = Mathf.Abs(transform.position.y + 0.94f - paredActual.GetComponent<Pared>().silueta.transform.position.y);
                print(distancia);
                if (distancia > 0.6)
                {
                    print("Mal ahí");
                    nivelControl.txt_celebracion.text = "Bad";
                }
                else if (distancia > 0.3)
                {
                    print("Medio ahí");
                    nivelControl.txt_celebracion.text = "Almost";
                }
                else if (distancia < 0.3)
                {
                    print("Ahí fue");
                    nivelControl.txt_celebracion.text = "Perfect";
                }
                Invoke("quitarTextoCelebracion", 1);
            }
        }
    }

    public void quitarTextoCelebracion()
    {
        nivelControl.txt_celebracion.text = "";
    }

    public void desaparecerPared()
    {
        paredActual.GetComponent<Pared>().dissapear = true;
        //paredActual.SetActive(false);

    }

    IEnumerator desactivarAnimacionDiamantes()
    {
        yield return new WaitForSeconds(0.4f);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        personajeMovimiento.fuerza_movimiento = personajeMovimiento.fuerza_movimiento + 0.6f;
        personajeMovimiento.bloqueado = false;
        condiamante = false;
        animacion_personaje.SetInteger("diamante", 0);
    }
    IEnumerator desactivarAnimacionDiamantes2()
    {
        yield return new WaitForSeconds(1.6f);
        Physics.gravity = new Vector3(0, -9.8f, 0);
        personajeMovimiento.fuerza_movimiento = personajeMovimiento.fuerza_movimiento + 0.6f;
        personajeMovimiento.bloqueado = false;
        condiamante = false;
        animacion_personaje.SetInteger("diamante", 0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 13 && !condiamante && nivelControl.vida > 0)
        {
            animacion_personaje.SetTrigger("Idle");
        }
    }


}
