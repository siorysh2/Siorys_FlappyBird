using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{

    Rigidbody rbPajaro; // Declaramos el rigidbody del pollo 

    // Start is called before the first frame update
    void Start()
    {
        rbPajaro = GameObject.Find("Pollo").GetComponent<Rigidbody>();
        // Busca un objeto llamado Pollo y dame el componente RigibBody para poder manipularlo.
    }

    public void Jugar()
    {
        GameManager.playing = true; // Podemos acceder a la variable playing porque es publica
        rbPajaro.isKinematic = false; // Desactiva el Kinematic para poder dar libertad al pollo (gravedad y colisiones)
    }

    public void Reiniciar()
    {
        GameManager.Reload(); //Recarga la escena llamando al script de GameManager
    }



}