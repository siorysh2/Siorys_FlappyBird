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
    public float rangoY; // Valor que modificaremos para establecer el rango en el que se modifica la altura de las tuberias
    public float rangoZ;
    //---------
    private void OnCollisionEnter(Collision collision) // Incorporamos el metedo para autodestruir las tuberias y simplificar la escena.
    {
        if (collision.gameObject.name == "Limit") // Esta linea establece que las tuberias solo se destruyen al colisionar con el objeto Limit
        {
            Destroy(gameObject);  // Con esta linea conseguimos que las tuberias al colisionar se autodestruyan
        }

    }
    //--------

    void Start()
    // Con esto conseguiremos que las tuberias spawneen en diferentes alturas (y)
    {
        transform.Translate(0, Random.Range(rangoY * -1, rangoY * 1), Random.Range(rangoZ * -1, rangoZ * 1));
    }

    // Update is called once per frame

    //--------
    void Update()
    {
        if (GameManager.playing == true) // Solo ejecutara el movimiento de las tuberias si estamos jugando

            transform.Translate(Vector3.back * Time.deltaTime * speed);
            // Con esta linea conseguimos el movimiento de las tuberias de forma constante en funcion de la velociad

    }
}
