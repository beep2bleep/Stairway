using UnityEngine;
using System.Collections;

public class MoveToStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeSinceLevelLoad > 3)
            Application.LoadLevel(0);
	}
}
