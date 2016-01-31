using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = new Quaternion(transform.rotation.x+.01f, transform.rotation.y + .01f, transform.rotation.z + .01f, transform.rotation.w+.01f);// transform.Rotate(new Vector3(1, 1, 1));
	}
}
