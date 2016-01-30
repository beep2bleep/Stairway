using UnityEngine;
using System.Collections;

public class chasePlayer : MonoBehaviour {
    public NavMeshAgent agent;
    public Transform player;
    public float skipNav = 30;
    public float skipNavCount = 0;

    // Use this for initialization
    void Start () {
        agent.SetDestination(player.position);
    }
	
	// Update is called once per frame
	void Update () {
        
        if (skipNavCount > skipNav)
        {
            agent.SetDestination(player.position);
            skipNavCount = 0;
        }
        else
        {
            skipNavCount++;
        }
    }
}
