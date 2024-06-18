using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmilerScript : MonoBehaviour
{
    //private bool JugadorDentro = false;
    public GameObject smiler;

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que entra en el collider es el jugador
        if (other.CompareTag("Player"))
        {
            //JugadorDentro = true;
            smiler.gameObject.SetActive(true);
            StartCoroutine(MoverSmiler(smiler, 5f));
            
        }
    }
    IEnumerator MoverSmiler(GameObject obj, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            obj.transform.Translate(Vector3.forward * 7f * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        smiler.gameObject.SetActive(false);
    }
}
