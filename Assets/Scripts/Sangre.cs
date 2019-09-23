using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sangre : MonoBehaviour
{
    // Con este script vamos a hacer que la escena se reinicie cuando la sangre desaparece al haber colisionado el pollo.
    // Este reload figura aquí y no en el pollo ya que si lo hiciera en este último el juego se reiniciaria y no apareceria la sangre.
        public void OnDestroy() // Metodo que indica que hacer al ser destruido el sistema de particulas.
        {
            GameManager.Reload(); // Hace referencia al GameManager que recargaba la escena.
        }


    
}
