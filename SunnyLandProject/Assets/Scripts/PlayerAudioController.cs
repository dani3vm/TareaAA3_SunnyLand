using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // keep track of the jumping state ... 
    bool isJumping = false;
    bool isRunning = false;
    bool isPlaying = false;
    float initialPitch = 1.0f; 

    // make sure to keep track of the movement as well !

    Rigidbody2D rb; // note the "2D" prefix 
    AudioSource[] sonidosZorro;
    
    // Start is called before the first frame update
    void Start()
    {
	rb = GetComponent<Rigidbody2D>();
	// get the references to your audio sources here !  
    sonidosZorro = GetComponents<AudioSource>();  
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate() 
    {
	// Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...
       Debug.Log(rb.velocity.magnitude);
        if (isRunning == false && rb.velocity.magnitude > 1 && !isJumping) {
            print("The Object is Moving");
            sonidosZorro[0].Play();
            isRunning = true;
        } else if (isRunning == true && rb.velocity.magnitude < 1) {
            print("The Object is not Moving");
            sonidosZorro[0].Stop();
            isRunning = false;
        }
        if (isJumping == true) {
           sonidosZorro[0].Stop();
        }
	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	
    }
    
    // trigger your landing sound here !
    public void OnLanding() 
    {
        isJumping = false;
        print("the fox has landed");
        int randomSound = Random.Range(0, 100);
        sonidosZorro[2].pitch = initialPitch;
        if (randomSound > 50) 
        {
            sonidosZorro[2].pitch = Random.Range(0.5f, 2.0f);
        }
        sonidosZorro[2].Play();
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() 
    {
        print("the fox is crouching");
        if (isJumping == false) {
            sonidosZorro[3].Play();
        }
        
    }
 
    // trigger your jumping sound here !
    public void OnJump() 
    {
        isJumping = true;
        print("the fox has jumped");
        int randomSound = Random.Range(0, 100);
        sonidosZorro[1].pitch = initialPitch;
        if (randomSound > 50) 
        {
            sonidosZorro[1].pitch = Random.Range(0.5f, 2.5f);
        }
        sonidosZorro[1].Play();
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");
        sonidosZorro[4].Play();
    }
}
