using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Movimiento : MonoBehaviour
{

    public float aceleracionCohete = 9.8f, aceleracionRotacionX = 0.382f, aceleracionRotacionZ = 0.382f;
    public GameObject coheteAvanzar, coheteReversa, coheteRotacionXUp, coheteRotacionXDown, coheteRotacionZUp, coheteRotacionZDown;
    public GameObject centroAvanzar, centroNeutro, centroReversa;
    public float velocidadAvance01 = 25f, velocidadReversa01 = -15f, velocidadAvance02 = 50f, velocidadReversa02 = -25f;
    public Slider m_slider;
    public GameObject AlertaSlider01, AlertaSlider02;
    public GameObject Alerta01, Alerta02, AlertaTotal;

    float velocidad, velocidadRotacionX, velocidadRotacionZ;
    float inX, inY;
    float rotx, rotz;
    float val_gas = 0.01f, gas_minima = 25;
    float pos;
    bool m_propulsorReversa = false, m_propulsorDelantero = false, apagar = false;
    Animator m_animator, m_animatorAlertaSlider01, m_animatorAlertaSlider02, m_animatorAlerta01, m_animatorAlerta02;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        m_animator = GetComponent<Animator>();
        m_animatorAlertaSlider01 = AlertaSlider01.GetComponent<Animator>();
        m_animatorAlertaSlider02 = AlertaSlider02.GetComponent<Animator>();
        m_animatorAlerta01 = Alerta01.GetComponent<Animator>();
        m_animatorAlerta02 = Alerta02.GetComponent<Animator>();
        coheteAvanzar.SetActive(false);
        coheteReversa.SetActive(false);
        coheteRotacionXUp.SetActive(false);
        coheteRotacionXDown.SetActive(false);
        coheteRotacionZUp.SetActive(false);
        coheteRotacionZDown.SetActive(false);
        m_slider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0f)
        {
            if (m_slider.value < 0.0618f)
            {
                apagar = true;
                ApagarMotores();
            }


            // prender propulsores y activar aceleraciones
            if (Input.GetButtonDown("Fire1") & apagar == false)
            {

                if (m_propulsorDelantero == true | apagar == true)
                {
                    m_propulsorDelantero = false;
                    coheteAvanzar.SetActive(false);
                    m_animatorAlertaSlider01.SetBool("Activar", false);
                    m_animatorAlerta01.SetBool("Activar", false);
                }
                else
                {
                    m_propulsorDelantero = true;
                    coheteAvanzar.SetActive(true);
                }
            }

            if (Input.GetButtonDown("Fire2") & apagar == false)
            {
                if (m_propulsorReversa == true | apagar == true)
                {
                    m_propulsorReversa = false;
                    coheteReversa.SetActive(false);
                    m_animatorAlertaSlider02.SetBool("Activar", false);
                    m_animatorAlerta02.SetBool("Activar", false);
                }
                else
                {
                    m_propulsorReversa = true;
                    coheteReversa.SetActive(true);
                }
            }
            /////////////////


            // rotación
            if (apagar == false)
            {
                inX = -Input.GetAxis("Vertical");
                inY = -Input.GetAxis("Horizontal");
                m_slider.value = m_slider.value - (0.2361f * ((val_gas * Mathf.Pow(Mathf.Pow(inX, 2f), 0.5f)) + (val_gas * Mathf.Pow(Mathf.Pow(inY, 2f), 0.5f))));
            }
            else
            {
                inX = 0f;
                inY = 0f;
            }

            velocidadRotacionX = velocidadRotacionX + (inX * aceleracionRotacionX * Time.deltaTime);
            rotx = (velocidadRotacionX * Time.deltaTime) + (0.5f * (aceleracionRotacionX * Mathf.Pow(Time.deltaTime, 2f)));

            velocidadRotacionZ = velocidadRotacionZ + (inY * aceleracionRotacionZ * Time.deltaTime);
            rotz = (velocidadRotacionZ * Time.deltaTime) + (0.5f * (aceleracionRotacionZ * Mathf.Pow(Time.deltaTime, 2f)));

            //// prender propulsores X
            if (inX > 0f)
            {
                coheteRotacionXUp.SetActive(false);
                coheteRotacionXDown.SetActive(true);
            }
            else if (inX < 0f)
            {
                coheteRotacionXUp.SetActive(true);
                coheteRotacionXDown.SetActive(false);
            }
            else
            {
                coheteRotacionXUp.SetActive(false);
                coheteRotacionXDown.SetActive(false);
            }

            /////prender propulsores Z
            if (inY < 0f)
            {
                coheteRotacionZUp.SetActive(false);
                coheteRotacionZDown.SetActive(true);
            }
            else if (inY > 0f)
            {
                coheteRotacionZUp.SetActive(true);
                coheteRotacionZDown.SetActive(false);
            }
            else
            {
                coheteRotacionZUp.SetActive(false);
                coheteRotacionZDown.SetActive(false);
            }





            //////////////

            // calcular ecuaciones de movimiento según los propulsores
            if (m_propulsorDelantero)
            {
                m_slider.value = m_slider.value - (0.618f * val_gas);
                if (m_slider.value < gas_minima)
                    m_animatorAlertaSlider01.SetBool("Activar", true);

                velocidad = velocidad + (aceleracionCohete * Time.deltaTime);
                pos = (velocidad * Time.deltaTime) + (0.5f * (aceleracionCohete * Mathf.Pow(Time.deltaTime, 2f)));
            }


            if (m_propulsorReversa)
            {
                m_slider.value = m_slider.value - (0.618f * val_gas);
                if (m_slider.value < gas_minima)
                    m_animatorAlertaSlider02.SetBool("Activar", true);

                velocidad = velocidad + (-aceleracionCohete * Time.deltaTime);
                pos = (velocidad * Time.deltaTime) + (0.618f * (-aceleracionCohete * Mathf.Pow(Time.deltaTime, 2f)));
            }
            ////////////////

            // señaladores en el centro del canvas
            if (velocidad > 1.618f)
            {
                centroAvanzar.SetActive(true);
                centroNeutro.SetActive(false);
                centroReversa.SetActive(false);
            }
            else if (velocidad < -1.618f)
            {
                centroAvanzar.SetActive(false);
                centroNeutro.SetActive(false);
                centroReversa.SetActive(true);
            }
            else
            {
                //    rotx = 0.0382f * rotx;
                //   roty = 0.0382f * roty;
                //    rotz = 0.0382f * rotz;
                centroAvanzar.SetActive(false);
                centroNeutro.SetActive(true);
                centroReversa.SetActive(false);
            }


            if (velocidad > velocidadAvance02)
            {
                centroAvanzar.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                if (m_propulsorDelantero)
                    m_animatorAlerta01.SetBool("Activar", true);
            }
            else if (velocidad > velocidadAvance01 & velocidad < velocidadAvance02)
                centroAvanzar.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            else if (velocidad > 1.618f & velocidad < velocidadAvance01)
                centroAvanzar.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

            if (velocidad < velocidadReversa02)
            {
                centroReversa.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
                if (m_propulsorReversa)
                    m_animatorAlerta02.SetBool("Activar", true);
            }
            else if (velocidad < velocidadReversa01 & velocidad > velocidadReversa02)
                centroReversa.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            else if (velocidad < -1.618f & velocidad > velocidadReversa01)
                centroReversa.GetComponent<Image>().color = new Color32(0, 255, 0, 255);

            if (m_slider.value > 75)
                AlertaTotal.GetComponent<Image>().color = new Color32(0, 255, 0, 255);
            else if (m_slider.value < 75 & m_slider.value > 25)
                AlertaTotal.GetComponent<Image>().color = new Color32(255, 255, 0, 255);
            else
                AlertaTotal.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
            ///////////////////


            transform.Translate(0f, 0f, pos);
            transform.Rotate(rotx, 0f, rotz);
        }
    }


    private void ApagarMotores()
    {
        m_propulsorDelantero = false;
        coheteAvanzar.SetActive(false);
        m_animatorAlertaSlider01.SetBool("Activar", false);
        m_animatorAlerta01.SetBool("Activar", false);
        m_propulsorReversa = false;
        coheteReversa.SetActive(false);
        m_animatorAlertaSlider02.SetBool("Activar", false);
        m_animatorAlerta02.SetBool("Activar", false);

        coheteRotacionXUp.SetActive(false);
        coheteRotacionXDown.SetActive(false);
        coheteRotacionZUp.SetActive(false);
        coheteRotacionZDown.SetActive(false);
    }

    public void CambiarErrorPausa()
    {

            if (m_propulsorDelantero == true | apagar == true)
            {
                m_propulsorDelantero = false;
                coheteAvanzar.SetActive(false);
            }
            else
            {
                m_propulsorDelantero = true;
                coheteAvanzar.SetActive(true);
            }
    }
}


