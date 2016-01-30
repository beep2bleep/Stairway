using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    public Rigidbody myBody;
    public float speedAddition;
    public float maxSpeed;
    public float speedToSwitchWalk;
    private float timeSinceWalkSwitch;
    public SpriteRenderer walk1;
    public SpriteRenderer walk2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceWalkSwitch += Time.deltaTime;
        float speed = Vector3.Magnitude(myBody.velocity);
        if (Input.GetKey(KeyCode.A))
        {
            if (myBody.velocity.x > maxSpeed * -1)
                
            {
                myBody.AddForce(Vector3.left * speedAddition);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (myBody.velocity.x < maxSpeed)
            {
                myBody.AddForce(Vector3.right * speedAddition);
            }
            //myBody.velocity = Vector3.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (myBody.velocity.z > maxSpeed * -1)
                
            {
                myBody.AddForce(Vector3.back * speedAddition);
            }
            //myBody.velocity = Vector3.back * moveSpeed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (myBody.velocity.z < maxSpeed)
            {
                myBody.AddForce(Vector3.forward * speedAddition);
            }
            //myBody.velocity = Vector3.forward * moveSpeed;
        }
        if(speed > speedToSwitchWalk  && timeSinceWalkSwitch > .25)
        {
            //toggle walk
            if(walk1.enabled)
            {
                walk2.enabled = true;
                walk1.enabled = false;

            }
            else
            {
                walk1.enabled = true;
                walk2.enabled = false;
            }
            timeSinceWalkSwitch = 0;
        }
    }
}
