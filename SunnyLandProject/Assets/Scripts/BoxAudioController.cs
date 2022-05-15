using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour 
{
    Rigidbody2D rb;
    AudioSource[] sonidosBox;
    bool boxMoving = false;
    bool boxFalling = false;
    
    // Start is called before the first frame update
    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        sonidosBox = GetComponents<AudioSource>();
    }
    
    void FixedUpdate() 
    {
        if (boxMoving == false && rb.velocity.magnitude > 1 && boxFalling == false) 
        {
            sonidosBox[1].Play();
            boxMoving = true;
        } 
        else if (boxMoving == true && rb.velocity.magnitude < 1) 
        {
            sonidosBox[1].Stop();
            boxMoving = false;
        }
    }
    
    void OnCollisionExit2D(Collision2D Collision) 
    {
        boxFalling = true;
    }
   
    void OnCollisionEnter2D(Collision2D Collision) 
    {   
        if (boxFalling == true) 
        {
            sonidosBox[0].Play();
            boxFalling = false;
        } 
    }
}

