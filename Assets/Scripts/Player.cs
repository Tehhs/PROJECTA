using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Health")]
    public float playerHealth = 100.0f;

    public float maxTime;

    private float timeInterval = 1.0f;
    private float timeInAir;
    private float timeLeftGround;

    public float GroundedOffset = -0.14f;
 
    public float GroundedRadius = 0.5f;
    public LayerMask GroundLayers;



    private bool GroundedCheck()
    {
	// set sphere position, with offset
	Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
	bool Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);

    return Grounded;
    }


    private void takeFallDamage() 
    {
        float timeInAir = Time.time - timeLeftGround;
        Debug.Log("Time in air:" + timeInAir);
        if (timeInAir >= timeInterval) 
        {
            playerHealth -= 10;
             Debug.Log("Bitch");
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = GroundedCheck();
        if (isGrounded) 
        {
            timeLeftGround = Time.time;
    
        } 

        takeFallDamage();
        Debug.Log("Helth" + playerHealth);



        
    }
}
