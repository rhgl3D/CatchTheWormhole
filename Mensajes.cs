using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mensajes : MonoBehaviour
{
    public GameObject m_leygravitacion;

    void Start()
    {
        m_leygravitacion.SetActive(false);
    }
    
    public void MasInformacion()
    {
        m_leygravitacion.SetActive(true);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }
}
