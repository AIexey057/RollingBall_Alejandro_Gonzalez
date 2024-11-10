using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boloncho : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direccion = new Vector3 (0, 1, 0);
    [SerializeField]float velocidad;
    [SerializeField] float velocidadMovimiento;
    private float h, v;
    private int vida = 10;
    private int puntuacion;
    [SerializeField]TMP_Text textoPuntuacion;
    [SerializeField] float detectarSuelo;
    [SerializeField] LayerMask queEsSuelo;
    [SerializeField] AudioClip sonidoMoneda;
    [SerializeField] AudioManager manager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(DetectarSuelo() == true)
            {
                rb.AddForce(direccion * velocidad, ForceMode.Impulse);
            }
           
        }
        
    }
    bool DetectarSuelo()
    {
        bool resultado = Physics.Raycast(transform.position, new Vector3 (0, -1, 0), detectarSuelo, queEsSuelo);
        return resultado;
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(h, 0, v).normalized * velocidadMovimiento, ForceMode.Force);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
           
            puntuacion += 10;
            textoPuntuacion.SetText("Score: " + puntuacion);
            manager.ReproducirSonido(sonidoMoneda);
            Destroy(other.gameObject);           
            Debug.Log(vida);
        }
        else if (other.CompareTag("Trampa"))
        {
            vida -= 10;
            if (vida <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Has Muerto ");
                SceneManager.LoadScene(2);
            }
        }

        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trampa"))
        {
            vida -= 10;
            if (vida <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Has Muerto ");
                SceneManager.LoadScene(2);
            }
        }
    }

    


}
