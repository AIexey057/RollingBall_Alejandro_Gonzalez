using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    // Start is called before the first frame update
  
    public void ReproducirSonido(AudioClip clip)
    {
        sfx.PlayOneShot(clip);  
    }
}
