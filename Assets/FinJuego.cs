using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FinJuego : MonoBehaviour
{
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void botonReiniciar()
    {
        SceneManager.LoadScene(1);
    }
}
