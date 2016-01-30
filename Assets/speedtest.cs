using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class speedtest : MonoBehaviour {

    public Rigidbody myBody;
    public Text debugtext;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        debugtext.text = myBody.velocity.x.ToString() + "," +myBody.velocity.y.ToString() + ","+ myBody.velocity.z.ToString() + ",";
    }
}
