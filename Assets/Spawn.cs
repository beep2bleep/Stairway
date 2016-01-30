using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;
    public float timeToSpawn;
    public float timeSinceLastSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > timeToSpawn)
            GameObject.Instantiate(toSpawn, transform.position, transform.rotation);
    }
}
