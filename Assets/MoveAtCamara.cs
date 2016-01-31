using UnityEngine;
using System.Collections;

public class MoveAtCamara : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(transform.forward * -100);
	}
}
