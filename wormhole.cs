using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormhole : MonoBehaviour
{

    public GameObject cam, m_jugador;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_jugador)
        {
            cam.GetComponent<Animator>().SetTrigger("Activar");
        }

    }
}
