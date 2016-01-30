using UnityEngine;
using System.Collections;

public class moveToPlayer : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(player.transform.position.x, 16, player.transform.position.z);
        transform.position = newPos;
        
	}
}
