using UnityEngine;
using System.Collections;

public class moveToPlayer : MonoBehaviour {

    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position.Set(player.transform.position.x, 16, player.transform.position.z);
	}
}
