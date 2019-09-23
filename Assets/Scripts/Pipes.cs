using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour

    // Con este Scrip estableceremos el movimiento de las Tuberias.
{ //--------
    // Start is called before the first frame update

    public float speed;
    // Creamos la variable Speed (modificable en Unity) para establecer la velocidad de movimiento de las tuberias
    //--------
    private void OnCollisionEnter(Collision collision) // Incorporamos el metedo para autodestruir las tuberias y simplificar la escena.
    {
        if (collision.gameObject.name == "Limit") // Esta linea establece que las tuberias solo se destruyen al colisionar con el objeto Limit
        {
            Destroy(gameObject);  // Con esta linea conseguimos que las tuberias al colisionar se autodestruyan
        }

    }
    //--------

    void Start()
    {
        
    }

    // Update is called once per frame

    //--------
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * speed);
        // Con esta linea conseguimos el movimiento de las tuberias de forma constante en funcion de la velociad

    }
}
