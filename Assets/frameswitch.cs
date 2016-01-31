using UnityEngine;
using System.Collections;

public class frameswitch : MonoBehaviour {
    public MeshFilter filter;
    public Mesh frame1;
    public Mesh frame2;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Random.Range(0,2)==0)
        {
            filter.mesh = frame1;
        }
        else
        {
            filter.mesh = frame2;
        }
	}
}
