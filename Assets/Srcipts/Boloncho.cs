using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boloncho : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direccion = new Vector3 (0, 1, 0);
    [SerializeField]float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(direccion * velocidad, ForceMode.Impulse);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(direccion * velocidad, ForceMode.Force);
        }
        
        
    }
}
