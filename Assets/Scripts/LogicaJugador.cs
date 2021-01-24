using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour
{
    public Vida vida;
    public bool Vida0 = false;
    public float movimiento = 1f;
    public float rotacion = 200f;
    private Animator animadorRender;

    public GameObject bala;
    public Transform puntoDisparo;
    public FinJuego finJuego;
    public Ganaste ganas;
    
    [Header("Referencia Sonidos")]
    public AudioClip SonDisparo;
    protected AudioSource audioSource;

    [Header("Atributos de arma")]
    public int balasEnCartucho = 10;
    public float daño = 100f;
    public float fuerzaDisparo = 1500f;
    public float ratioDisparo = 0.5f;
    public float velocidadBala = 20;
    public int destruidos = 0;
    public float tiempoDisparo = 2;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<Vida>();
        animadorRender = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        revisarVida();
        mover();
        rotar();
        getBalas();
        if (Input.GetKey(KeyCode.Space))
        {
            animadorRender.SetTrigger("Desenfunda");
            Disparar();
            getDestruidos();
        }
    }

    private void Disparar()
    {
        animadorRender.SetTrigger("Dispara");

        if (Time.time > tiempoDisparo && balasEnCartucho > 0)
        {
            GameObject newBala;
            newBala = Instantiate(bala, puntoDisparo.position, Quaternion.identity);
            newBala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * fuerzaDisparo);
            tiempoDisparo = Time.time + 1;
            audioSource.PlayOneShot(SonDisparo);
            balasEnCartucho--;
            DisparoDirecto();
            Destroy(newBala, 2);

        }
    }

    private void DisparoDirecto()
    {
        RaycastHit hit;  //Devuelve true si existe toque con alguno de los  colisionadores de la escena
        if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit))
        {
            if (hit.transform.CompareTag("Enemigo"))
            {
                Vida vida = hit.transform.GetComponent<Vida>();
                if (vida == null)
                {
                    throw new System.Exception("No se encontro el componente vida del enemigo");
                }
                else
                {
                    vida.recibirDano(daño);
                    destruidos++;
                }
            }
        }
    }

    private void rotar()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, -rotacion, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
           transform.Rotate(new Vector3(0f, rotacion, 0f) * Time.deltaTime);
        }
    }

    private void mover()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
           transform.Translate(Vector3.forward * movimiento * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
           transform.Translate(Vector3.back * movimiento * Time.deltaTime);
        }
    }

    void revisarVida()
    {
        if (Vida0) return; //si vida0 es true return
        if (vida.valor <= 0)
        {
            muere();
        }
    }

    private void muere()
    {
        Vida0 = true;
        animadorRender.SetTrigger("Muere");
        finJuego.Setup();
        Destroy(this);
    }
        
    public int getBalas()
    {
        if (balasEnCartucho == 0)
        {
            muere();
        }
        return balasEnCartucho;
    }

    public int getDestruidos()
    {
        if (destruidos == 3) {
            Destroy(this);
            ganas.Setup();
        }
        
        return destruidos;
    }

}
