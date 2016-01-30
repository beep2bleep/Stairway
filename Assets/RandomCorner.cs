using UnityEngine;
using System.Collections;

public class RandomCorner : MonoBehaviour {

    public Transform TopRight;
    public Transform TopLeft;
    public Transform BotRight;
    public Transform BotLeft;
    public NavMeshAgent agent;
    public float skipNav = 30;
    public float skipNavCount = 0;

    private int nextNav;

    // Use this for initialization
    void Start () {
        nextNav = Random.Range(0, 3);

    }
	
	// Update is called once per frame
	void Update () {
        if (skipNavCount > skipNav)
        {
            switch(nextNav)
            {
                case 0:

                    agent.SetDestination(TopRight.position);
                    break;
                case 1:

                    agent.SetDestination(TopLeft.position);
                    break;
                case 2:

                    agent.SetDestination(BotRight.position);
                    break;
                case 3:

                    agent.SetDestination(BotLeft.position);
                    break;
            }
            skipNavCount = 0;
        }
        else
        {
            skipNavCount++;
            nextNav = Random.Range(0, 3);
        }
    }
}
