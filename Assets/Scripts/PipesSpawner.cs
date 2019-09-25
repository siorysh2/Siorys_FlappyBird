using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesSpawner : MonoBehaviour
{// Con este script vamos a buscar la creacion de tuberias de forma continua (Instantiate) y contraleremos el tiempo en que empiezan a surgir y cada cuanto tiempo deberan hacerlo (InvokeRepeating)


    //Primero definimos las variables que vamos a usar
    public GameObject prefabPipe;
    public float ratio;  // El ratio indicara el numero de tuberias que saldraen funcion del valor dado

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPipe", 0, 2); 
        //Con esta linea estamos invocando el prefab de las tuberias al inicio (de inmediato = 0 segundos) y cada 2 segundos
    }

    // Update is called once per frame
    void Update()
    {
        // NUNCA CREAREMOS AQUI UN INVOKE REPEATING, colapsaria el sistema
    }

    void SpawnPipe()
    {
        if (GameManager.playing == true) // Solo se ejecuta el Instantiate  (spawn) si estamos jugando.
        {
            Instantiate(prefabPipe, transform);
            //Con esta linea estamos instanciando nuestro prefab de tuberias, el programa las ira duplicando segun el Invoke Reapeating

        }
    }
}
