using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSound: MonoBehaviour
{
    public AudioClip dieSound;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Yomi")
        {
            audioSource.PlayOneShot(dieSound);
        }
    }
}
