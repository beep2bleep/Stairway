using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {

    public Rigidbody myBody;
    public float speedAddition;
    public float maxSpeed;
    public float speedToSwitchWalk = 30;
    private float timeSinceWalkSwitch;
    public SpriteRenderer walk1;
    public SpriteRenderer walk2;
    public SpriteRenderer stand;
    public GameObject splat;
    public Slider health;
    private float walkTimes = 0;
    bool playingheart;
    public Image dmgSprite;
    public Transform gunTransform;
    public UnityEngine.UI.Text healthText;


    public AudioClip oneHitSound;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceWalkSwitch += Time.deltaTime;
        float speed = Vector3.Magnitude(myBody.velocity);
        if(!(Input.GetButton("Fire2") || Input.GetAxisRaw("LeftTrigger") != 0))
        {
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
            }
            //Kendra movement controls did not work
            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    if (myBody.velocity.z < maxSpeed)
            //    {
            //        // get the point "distance" units ahead the weapon:
            //        Vector3 aimPos = gunTransform.position + gunTransform.forward * 1;
            //        // convert it to screen coordinates:
            //        Vector3 chPos = Camera.main.WorldToScreenPoint(aimPos);
            //        myBody.AddForce((Vector3.Normalize(chPos) * speedAddition));
            //    }
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    if (myBody.velocity.z < maxSpeed)
            //    {
            //        // get the point "distance" units ahead the weapon:
            //        Vector3 aimPos = gunTransform.position + gunTransform.forward * 1;
            //        // convert it to screen coordinates:
            //        Vector3 chPos = Camera.main.WorldToScreenPoint(aimPos);
            //        myBody.AddForce(Vector3.Normalize(chPos) * -1 * speedAddition);
            //    }
            //    //myBody.velocity = Vector3.forward * moveSpeed;
            //}

            //if (Input.GetKey(KeyCode.LeftArrow))
            //{
            //    //turn left
            //    gunTransform.Rotate(0, 0, 1);// (new Quaternion(myBody.rotation.x, myBody.rotation.y + 1, myBody.rotation.z, myBody.rotation.w));
            //}
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    //turn right
            //    gunTransform.Rotate(0, 0, -1);////gunTransform.MoveRotation(new Quaternion(myBody.rotation.x, myBody.rotation.y - 1, myBody.rotation.z, myBody.rotation.w));
            //}
        }
        
        if(speed > speedToSwitchWalk  && timeSinceWalkSwitch > .25)
        {
            healthText.text = "";
            walkTimes++;
            stand.enabled = false;
            //toggle walk
            if (walk1.enabled)
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
        else
        {
            if (timeSinceWalkSwitch > .25)
            {
                //healthText.text = "";
                walkTimes++;
                walk1.enabled = false;
                walk2.enabled = false;
                stand.enabled = true;
                timeSinceWalkSwitch = 0;
            }
        }

        if(walkTimes%5 == 0 && health.value < 100 && !playingheart)
        {
            playingheart = true;
            var audio = GetComponent<AudioSource>();
            audio.pitch = health.value / 105;
            audio.PlayOneShot(oneHitSound);//oww noise
            Color tmp = dmgSprite.color;
            tmp.a = .25f * 1/(health.value / 105);
            //tmp.a = 255 / (health.value / 105);
            dmgSprite.color = tmp;
        }
        else
        {
            if (walkTimes % 5 != 0)
            {
                playingheart = false;
                Color tmp = dmgSprite.color;
                tmp.a = 0;
                dmgSprite.color = tmp;
            }

        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.GetComponentInParent<Transform>().gameObject);
            Instantiate(splat, transform.position, transform.rotation);
            health.value += 6;
            //healthText.text = "+6";
        }
    }

    void ApplyDamage(float amount)
    {
        health.value -= amount;
        GetComponent<AudioSource>().PlayOneShot(oneHitSound);//oww noise
    }
    


}
