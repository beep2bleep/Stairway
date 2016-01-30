using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;
    public Transform player;
    public float timeToSpawn;
    public float timeSinceLastSpawn;
    public float dontSpawnDistance;
    private Transform prefabHolder;

	// Use this for initialization
	void Start () {
        prefabHolder = GameObject.FindGameObjectWithTag("PrefabHolder").transform;
    }
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn > timeToSpawn)
        {
            var distance = Vector3.Distance(transform.position, player.position);
            if (distance > dontSpawnDistance)
            {
                GameObject newSpawn = (GameObject)Instantiate(toSpawn, transform.position, transform.rotation);
                newSpawn.transform.parent = prefabHolder;
            }
            timeSinceLastSpawn = 0;
        }
    }
}
