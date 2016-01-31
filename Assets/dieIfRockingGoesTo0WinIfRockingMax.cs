using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class dieIfRockingGoesTo0WinIfRockingMax : MonoBehaviour
{

    public Slider health;
    public Slider rocking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health.value == health.minValue)
        {
            //Lose

            Application.LoadLevel(2);
        }
        else if (rocking.value == rocking.maxValue)
        {
            //Win

            Application.LoadLevel(3);
        }
    }
}
