using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazInicio : MonoBehaviour
{

    Animator m_inicio;
    float tiempo;
    public float limiteDeTiempo = 3f;

    void Start()
    {
        m_inicio = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo > limiteDeTiempo)
            m_inicio.SetTrigger("Activar");
    }
}
