using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Cargamos la libreria de UI para el tema puntuacion

// Variable publica, modificable para todos - peligroso -
// Variable privada, admite reglas de acceso y modificacion
// Variable static, estableceria la variable unica para todos el juego
// Variable bool, admite true o false
//************************************************************

public class Pollo : MonoBehaviour
{
    //  Nuestro objetivo será hacer que el pollo salte y colisione con los elementos del juego.

    Rigidbody rb;
    //Definicion de variable RigidBody, con el RigidBody conseguiremos que el pollo tenga colisiones.
    public int fuerza = 500;
    // Deficion de la variable publica Fuerza (modificable en Unity), medirá la fuerza con la que salte el pollo.
    //--------
    public int puntuacion = 0;
    // Declararamos la variable puntuacion como entera.
    //--------
    [SerializeField] GameObject prefabSangre;
    // Sistema de particulas de la explosion de pollo
    //La SeriealizeField nos permite modificarlo en el editor, pero no nos deja modificar el codigo. Similar a public.
    //--------
    public Text txtPuntuacion;
    //Declaramos la varible, pero tenemos que enlazar el texto que esta en el canvas con este script, por eso lo arrastraremos al hueco que se ha creado en el componente de pollo TxtPuntuacion
    //Asi creamos la referencia (hilo conductor) al txtPuntuacion para poder mostrarlo en la UI
    //--------
    AudioSource audioSource; 
    // Declaramos la variable de audioSource para poder usar el componente AudioSource de pollo en el codigo.
    [SerializeField] private AudioClip sonidoAlas; // Creamos la variable del sonido de las ala
    [SerializeField] private AudioClip sonidoPuntuacion;// Creamos la variable del sonido de la puntuacion.
    //----------
    [SerializeField] private GameObject botonReload; // Creamos la variable botonReload para hacer el GameOver y Retry
    //----------
    // Start is called before the first frame update
    void Start()
    { // Inicializar el proceso de Rigid Body
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); // Llamamos al componente AudioSource del pollo
    }

    // Update is called once per frame
    void Update()
    //--------
    { // Aqui ejecutaremos la funcion de Saltar

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
            // Invocacion de salto
        }

    }

    void Saltar()
    {
        rb.AddForce(Vector3.up * fuerza); // Con este comando haremos que el pollo salte en dirección hacia arriba (up)
                                          // En vez de un Vector3.up podríamos usar un Vector3 con coordenadas (0,1,0) que sería lo mismo que estamos haciendo con el up
        audioSource.PlayOneShot(sonidoAlas); //Ejecutamos el sonidoAlas cuando salte el pollo

    }

    //--------
    private void Morir() //Defición del metodo Morir, esto forma parte de la refactorizacion de codigo
    {
        Destroy(gameObject); // Con esto destruimos el pollo cuando choque con las tuberias

        Instantiate(prefabSangre, transform.position, transform.rotation);
        // Instanciamos la sangre y le aplicamos el transform acotado para que el sistema de particulas vaya acomppañadoo de la posicion de pollo PERO no desaparezca cuando el pollo se destruya

        GameManager.playing = false;
        // Deja de generar tuberias cuando el pollo muere

        botonReload.SetActive(true); 
        //Activa el boton de Reiniciar la escena
    }
    private void OnCollisionEnter(Collision collision) // Muerte del pollo.
    {
        Morir(); // Metodo de refactorizar el codigo (con el destornillador)

        //GameManager.Reload(); // Para poder recargar la escena cuando el pollo sea destruido -> Nos lo llevamos al script de la Sangre
    }

    //--------

    // Configuracion de la puntuacion con el Trigger que hemos metido en el prefabPipes como collider
    private void OnTriggerEnter(Collider other)
    { // Este metodo sirve para determinar que sucedera a pollo cuando entre en colision con el Trigger

        if (other.gameObject.CompareTag("Limite") == true) // Significa que si pollo choca con uno o varios objeto con el tag Limite se ejecute la accion de Morir
        {
            Morir();
        }
        else
        {               // Si pollo choca con otro objeto que no tenga el tag Limite sucederá:
            puntuacion++; // Incremento de la puntuacion
            txtPuntuacion.text = puntuacion.ToString(); //Aqui enlazamos el txtPuntuacion (lo que se muestra en pantalla) con la Puntuacion del trigger
            //To String convierte el texto a cadena de numeros

            audioSource.PlayOneShot(sonidoPuntuacion); //Sonido al pasar por el Trigger (puntuar)

        }

    }
}

