using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) // Metodo para declarar las colisiones
    {
        if (collision.gameObject.name == "Limit") // Condicional, si colisiona con el objeto llamado LIMIT pasara:
        {
            Destroy(gameObject);  // Destruir el propio objeto.
        }

    }
}

    