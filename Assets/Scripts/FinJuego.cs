using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinJuego : MonoBehaviour
{
    public LogicaJugador jugador;

    void Start()
    {
        jugador = GetComponent<LogicaJugador>();
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void botonReiniciar()
    {
        //Debug.Log("Text: Tocaste Boton");
        SceneManager.LoadScene("_Complete-Game");
        //jugador.reiniciarJuego();
    }
}
