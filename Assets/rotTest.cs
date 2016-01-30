using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class rotTest : MonoBehaviour {

    public Transform myBody;
    public Text debugtext;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        debugtext.text = myBody.rotation.x.ToString() + "," +myBody.rotation.y.ToString() + ","+ myBody.rotation.z.ToString() + ",";
    }
}
