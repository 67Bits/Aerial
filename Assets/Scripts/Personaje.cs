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


    public void OnTriggerEnter(Collider other)
    {
        if (nivelControl.vida > 0)
        {
            if (other.gameObject.layer == 6)
            {
                GameObject particula = Instantiate(particula_diamante1);
                particula.transform.position = other.transform.position;
                Destroy(other.gameObject);
                //other.gameObject.SetActive(false);

                nivelControl.cargarPuntos(1);
            }
            if (other.gameObject.layer == 7)
            {
                //GameObject particula = Instantiate(particula_diamante1);
                //particula.transform.position = other.transform.position;
                other.gameObject.SetActive(false);

                nivelControl.hacerDaño(1);
                //nivelControl.puntos_nivel++;
                shake.GenerateImpulse();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            shake.GenerateImpulse();
        }
    }
}
