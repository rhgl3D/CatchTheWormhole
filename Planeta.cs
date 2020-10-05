using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planeta : MonoBehaviour
{
    public GameObject m_jugador, m_mensaje;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == m_jugador)
        {
            m_mensaje.GetComponent<Animator>().SetTrigger("Activar");
        }
         
    }
}
