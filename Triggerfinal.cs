using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerfinal : MonoBehaviour
{

    public GameObject m_jugador,pantallawin;

    void Start()
    {
        pantallawin.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_jugador)
        {
            pantallawin.SetActive(true);
        }

    }
}
