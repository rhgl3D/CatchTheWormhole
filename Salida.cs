using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    public void Salir()
    {
        SceneManager.LoadScene(2);
    }
}
