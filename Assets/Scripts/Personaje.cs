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

    public void OnTriggerEnter(Collider other)
    {

        if (nivelControl.vida > 0)
        {
            // Diamantes
            if (other.gameObject.layer == 9)
            {
                GameObject particula = Instantiate(particula_diamante1);
                particula.transform.position = other.transform.position;
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);

                nivelControl.cargarPuntos(1);
                animacion_personaje.SetInteger("diamante",Random.Range(1,3));
                Invoke("desactivarAnimacionDiamantes", 0.2f);
            }
            // Tijeras
            else if (other.gameObject.layer == 10)
            {
                //GameObject particula = Instantiate(particula_diamante1);
                //particula.transform.position = other.transform.position;
                other.gameObject.SetActive(false);

                nivelControl.hacerDaño(1);
                //nivelControl.puntos_nivel++;
                shake.GenerateImpulse();
            }
            // LLegada
            else if (other.gameObject.layer == 12)
            {
                nivelControl.estado = 3;
                nivelControl.canvasPrincipal.SetActive(false);
                nivelControl.canvasVictoria.SetActive(true);

                nivelControl.agregarDiamantesTotales();
                nivelControl.txt_diamantes.text = "Level Diamonds: " + (nivelControl.puntos_nivel).ToString() + "\nAll Diamonds: " + (nivelControl.juegoControl.diamantes_totales).ToString();

                // TO DO: Colocar animación victoria
            }
        }
    }

    public void desactivarAnimacionDiamantes()
    {
        animacion_personaje.SetInteger("diamante",0);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            shake.GenerateImpulse();
        }
    }
}
