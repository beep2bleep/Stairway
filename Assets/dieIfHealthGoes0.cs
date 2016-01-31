using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dieIfHealthGoes0WinIfRockingMax : MonoBehaviour {

    public Slider health;
    public Slider rocking;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(health.value == health.minValue)
        {
            //Lose
        }
        else if(rocking.value == rocking.maxValue)
        {
            //Win
        }
	}
}
