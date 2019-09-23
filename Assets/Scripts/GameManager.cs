using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Con este metodo cargamos la libreria para gestionar la escena

public class GameManager : MonoBehaviour
{
    public static void Reload() // Metodo publico para hacer la recarga de la escena
    {
        SceneManager.LoadScene(0); // Recarga de la Scena 0 del juego, en este caso solo tenemos una escena.
    }
}
