using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject Menu, Controls, Credits;
    public int val;
    bool condicion = false;
    Movimiento m_movimiento;

    void Start()
    {
        m_movimiento = FindObjectOfType<Movimiento>();
        Return();
        Controls.SetActive(false);
        Credits.SetActive(false);
        
    }

    void Update ()
    {
        if (condicion)
        {
            Time.timeScale = 0f;
        }

    }

    public void ActivarMenu()
    {
        m_movimiento.CambiarErrorPausa();
        condicion = true;
        Menu.SetActive(true);
        
    }

    public void Return()
    {
        Time.timeScale = 1f;
        Menu.SetActive(false);
        condicion = false;

    }

    public void ViewControls()
    {
        Menu.SetActive(false);
        Controls.SetActive(true);
    }

    public void Back01()
    {
        Menu.SetActive(true);
        Controls.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(val);
    }

    public void Back02()
    {
        Menu.SetActive(true);
        Credits.SetActive(false);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
