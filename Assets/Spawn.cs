using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject toSpawn;

    public GameObject toSpawn2;

    public GameObject toSpawn3;
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
                int spawn = Random.RandomRange(0, 3);
                switch (spawn)
                {
                    case 0:
                        GameObject newSpawn = (GameObject)Instantiate(toSpawn, transform.position, transform.rotation);
                        newSpawn.transform.parent = prefabHolder;
                        break;
                    case 1:
                        newSpawn = (GameObject)Instantiate(toSpawn2, transform.position, transform.rotation);
                        newSpawn.transform.parent = prefabHolder;
                        break;
                    case 2:
                        newSpawn = (GameObject)Instantiate(toSpawn3, transform.position, transform.rotation);
                        newSpawn.transform.parent = prefabHolder;
                        break;
                }
            }
            timeSinceLastSpawn = 0;
        }
    }
}
