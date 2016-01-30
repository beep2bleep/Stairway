using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class killCount : MonoBehaviour {

    public Rigidbody myBody;
    public Text debugtext;
    public int kills;
    int startFontSize;
    // Use this for initialization
    void Start () {
        startFontSize = debugtext.fontSize;
	}
	
	// Update is called once per frame
	void Update ()
    {
        debugtext.text = kills.ToString();
        if (kills % 10 == 1)
        {
            debugtext.fontSize = startFontSize + Mathf.FloorToInt(kills / 1000);
        }
    }

    public void addKill()
    {
        kills++;
        
    }

}
