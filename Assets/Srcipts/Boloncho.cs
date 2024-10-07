using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boloncho : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direccion = new Vector3 (0, 1, 0);
    [SerializeField]float velocidad;
    [SerializeField] float velocidadMovimiento;
    private float h, v;
    int vida = 100;
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
            rb.AddForce(direccion * velocidad, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(h, 0, v).normalized * velocidadMovimiento, ForceMode.Force);
    }

    void Vida()
    {
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coleccionable"))
        {
            vida -= 10;
            Destroy(other.gameObject);           
            Debug.Log(vida);
        }
    }

}
