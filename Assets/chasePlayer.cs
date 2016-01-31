using UnityEngine;
using System.Collections;

public class chasePlayer : MonoBehaviour {
    public NavMeshAgent agent;
    public Transform player;
    public float skipNav = 30;
    public float skipNavCount = 0;
    public SpriteRenderer walk1;
    public SpriteRenderer walk2;
    public SpriteRenderer death;
    public float speedToSwitchWalk = 30;
    private float timeSinceWalkSwitch;
    bool dead = false;
    public float health = 20;
    public killCount counter;

    // Use this for initialization
    void Start () {

        player = GameObject.FindWithTag("Player").transform;
        agent.SetDestination(player.position);
        counter = GameObject.FindObjectOfType<killCount>();

        death.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (skipNavCount > skipNav && !dead)
        {
            agent.SetDestination(player.position);
            skipNavCount = 0;
            //toggle walk
            if (walk1.enabled)
            {
                walk2.enabled = true;
                walk1.enabled = false;

            }
            else
            {
                walk1.enabled = true;
                walk2.enabled = false;
            }
        }
        else
        {
            skipNavCount++;
        }


        if (dead)
        {
            agent.enabled = false;
            walk1.enabled = false;
            walk2.enabled = false;
            death.enabled = true;
        }


    }

    void ApplyDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            dead = true;
            this.GetComponent<Collider>().isTrigger = true;
            
            counter.addKill();
        }
    }
}
