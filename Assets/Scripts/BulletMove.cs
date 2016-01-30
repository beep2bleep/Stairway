using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

    public Transform gun;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().AddForce(gun.forward * 2000);
	}

}
