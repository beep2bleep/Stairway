using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;
    public Transform player;
    public float timeToSpawn;
    public float timeSinceLastSpawn;
    public float dontSpawnDistance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > timeToSpawn)
        {
            var distance = Vector3.Distance(transform.position, player.position);
            if (distance > dontSpawnDistance)
            {
                GameObject.Instantiate(toSpawn, transform.position, transform.rotation);
            }
            timeSinceLastSpawn = 0;
        }
    }
}
