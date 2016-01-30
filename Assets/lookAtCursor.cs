using UnityEngine;
using System.Collections;

public class lookAtCursor : MonoBehaviour {
    public Camera myCam;
    public GameObject debug;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Ray vRay = myCam.ScreenPointToRay(Input.mousePosition);
        //RaycastHit vHit;
        //Debug.DrawRay(Input.mousePosition, Input.mousePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.blue);
        //if (Physics.Raycast(vRay, out vHit, 1000))
        //{
        //    this.transform.LookAt(vHit.transform);
        //}
        
        

        //transform.LookAt(myCam.ScreenToWorldPoint(Input.mousePosition));

        var camPos = myCam.ScreenToWorldPoint(Input.mousePosition);
        camPos.Set(camPos.x, -8.25f, camPos.z);
        transform.LookAt(camPos);


        //Transform toSet = transform;
        //toSet.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ////toSet.rotation = new Quaternion(this.transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        //transform.rotation = toSet.rotation;
        ////this.transform.rotation = //new Transform( .Set(0, transform.rotation.y, transform.rotation.z, transform.rotation.z);// = 0;
    }
}
