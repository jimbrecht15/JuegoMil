using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantalla : MonoBehaviour
{
    public Text textoVida;
    public Text balas;
    public Text zombies;
    private LogicaJugador jugador;
    public Vida vida;
    

    // Start is called before the first frame update
    void Start()
    {
        jugador = GetComponent<LogicaJugador>();
        vida = GetComponent<Vida>();
                
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.text = "Vida = " + vida.valor + "/100";
        balas.text = "Balas= " + jugador.getBalas() + " ";
        zombies.text = "Zombies= " + jugador.getDestruidos();

    }
}