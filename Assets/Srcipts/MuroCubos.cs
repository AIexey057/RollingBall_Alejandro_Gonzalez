using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MuroCubos : MonoBehaviour
{
   [SerializeField] private Rigidbody[] rbs;

    private bool iniciarCuenta = false;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
      if (iniciarCuenta == true)
        {
            timer += 1 * Time.unscaledDeltaTime;
            if(timer >= 2)
            {
                Time.timeScale = 1f;
               for(int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].useGravity = true;
                }
            }
        }  
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0.2f;
            iniciarCuenta = true;  
        }
    }
}
