using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DiamanteADiamante : MonoBehaviour
{

    public float velocidad;

    public Transform target;
    public GameObject diamantePrefab;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    public void comenzarMovimiento(Vector3 _inicial, Action completo)
    {
        Vector3 targetPos = cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        GameObject diamante = Instantiate(diamantePrefab, transform);

        StartCoroutine(MoverDiamante(diamante.transform, _inicial, targetPos, completo));
    }
    IEnumerator MoverDiamante(Transform obj, Vector3 posIni, Vector3 finPos, Action completo)
    {
        float time = 0;
        while (time < 1)
        {
            time += velocidad * Time.deltaTime;
            obj.position = Vector3.Lerp(posIni, finPos, time);
            obj.localScale = Vector3.Lerp(new Vector3(0.6f, 0.6f, 0.6f), new Vector3 (0.34f, 0.34f, 0.34f), time); ;

            yield return new WaitForEndOfFrame();
        }
        completo.Invoke();
        Destroy(obj.gameObject);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
