using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionSexy : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] Vector3 rotacionSensual;
    [SerializeField] Vector3 MovimientoSensual;
    [SerializeField] float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotacionSensual * velocidad * Time.deltaTime, Space.World);

        timer = timer + 1 * Time.deltaTime;

        if (timer <= 1)
        {
            transform.Translate(MovimientoSensual * velocidad * Time.deltaTime, Space.World);

        }
        else
        {
            MovimientoSensual = MovimientoSensual * -1;
            timer = 0;
            
        }
    }
}
