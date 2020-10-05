using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DetenerTiempo : MonoBehaviour
{
    void Detener()
    {
        Time.timeScale = 0f;
    }
}
