using System.Collections;
using UnityEngine;

public class GeneradorMonedas : MonoBehaviour
{
    public GameObject monedaPrefab;
    public Transform[] puntosGeneracion;

    void Start()
    {
        if (puntosGeneracion.Length == 0)
        {
            Debug.LogError("No se han asignado puntos de generación.");
            return;
        }

        StartCoroutine(GenerarMonedas());
    }

    IEnumerator GenerarMonedas()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            if (puntosGeneracion.Length > 0)
            {
                Transform punto = puntosGeneracion[Random.Range(0, puntosGeneracion.Length)];
                Instantiate(monedaPrefab, punto.position, Quaternion.identity);
            }
        }
    }
}
