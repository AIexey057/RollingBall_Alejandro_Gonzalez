using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoNaranja : MonoBehaviour
{
    float timer = 0f;
    [SerializeField] Vector3 MovimientoMandarina;
    [SerializeField] float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + 1 * Time.deltaTime;
       
        if (timer <= 5)
        {
            transform.Translate(MovimientoMandarina * velocidad * Time.deltaTime);

        }
        else
        {
            MovimientoMandarina = MovimientoMandarina * -1;
            timer = 0;
            Debug.Log("Hola");
        }
        
        
    }
}
