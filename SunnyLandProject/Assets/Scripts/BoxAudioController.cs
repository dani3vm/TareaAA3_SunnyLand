using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    AudioSource[] sonidosBox;
    float initialPitch = 1.0f;
    bool isMoving = false;
    bool boxFalling = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sonidosBox = GetComponents<AudioSource>();

    }
    void FixedUpdate() 
    {
        if (isMoving == false && rb.velocity.magnitude > 1) {
            sonidosBox[1].Play();
            isMoving = true;
        } else if (isMoving == true && rb.velocity.magnitude < 1) {
            sonidosBox[1].Stop();
            isMoving = false;
        }
    }
    void OnCollisionEnter2D();

    // Update is called once per frame
    void Update()
    {
        
    }

}

