using UnityEngine;
using System.Collections;

public class startGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.timeSinceLevelLoad > 5 && (Input.GetButton("Fire1") || Input.GetAxisRaw("RightTrigger") != 0) == true)
        {

            Application.LoadLevel(1);
        }
	}
}
