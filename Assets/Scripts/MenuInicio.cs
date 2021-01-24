using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene("_Complete-Game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void salir()
    {
        Debug.Log("SALIR");
    }
}
