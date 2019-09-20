using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollo : MonoBehaviour
{
    //  Nuestro objetivo será hacer que el pollo salte y colisione con los elementos del juego.

    Rigidbody rb; //Definicion de variable RigidBody, con el RigidBody conseguiremos que el pollo tenga colisiones.
    public int fuerza = 500; // Deficion de la variable publica Fuerza (modificable en Unity), medirá la fuerza con la que salte el pollo.

    // Start is called before the first frame update
    void Start()
    { // Inicializar el proceso de Rigid Body
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()

    { // Aqui ejecutaremos la funcion de Saltar

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar(); // Invocacion de salto
        }
        
    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerza); // Con este comando haremos que el pollo salte en dirección hacia arriba (up)
        // En vez de un Vector3.up podríamos usar un Vector3 con coordenadas (0,1,0) que sería lo mismo que estamos haciendo con el up
    }
}
