using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    Animator m_animator;
    public GameObject m_creditos, m_menu;

    void Start()
    {
        back();
        m_animator = GetComponent<Animator>();
        m_animator.SetBool("Activar",false);
    }

    public void iniciar()
    {
        m_menu.SetActive(false);
        m_animator.SetBool("Activar",true);
    }

    public void cambiarEscena()
    {
        m_animator.SetBool("Activar", false);
        SceneManager.LoadScene(1);
    }

    public void verCreditos()
    {
        m_creditos.SetActive(true);
        m_menu.SetActive(false);
    }

    public void back()
    {
        m_creditos.SetActive(false);
        m_menu.SetActive(true);
    }

    public void salir()
    {
        Application.Quit();
    }
}
