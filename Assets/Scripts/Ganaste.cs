using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganaste : MonoBehaviour
{
    void Start()
    {
       
    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void botonReiniciar()
    {
        //Debug.Log("Text: Tocaste Boton");
        SceneManager.LoadScene("_Complete-Game");
      
    }
}
