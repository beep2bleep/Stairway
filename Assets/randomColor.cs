using UnityEngine;
using System.Collections;

public class randomColor : MonoBehaviour {

    public SpriteRenderer walk1;
    public SpriteRenderer walk2;
    public SpriteRenderer death;

    // Use this for initialization
    void Start () {
        walk1.material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        walk2.material.color = walk1.material.color;
        death.material.color = walk1.material.color;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
