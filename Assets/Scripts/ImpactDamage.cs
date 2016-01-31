using UnityEngine;
using System.Collections;

public class ImpactDamage : MonoBehaviour
{
    private bool _hit = false;
    public float Damage = 20;
    public float Radius = 1;
    public GameObject parent;

    //Character _player;

    public AudioClip oneHitSound;

    // Use this for initialization
    void Start()
    {
        //_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

        //if (_oneHitSound == null)
        //{
        //    _oneHitSound = Resources.Load<AudioClip>("Sounds/onDashHit");
        //}

        //this.EnsureComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!_hit && Vector3.Distance(transform.position, this.transform.position) <= Radius)
        //{
        //    _hit = true;
        //    GetComponent<AudioSource>().PlayOneShot(oneHitSound);
        //}


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Enemy" || col.gameObject.name == "Enemy(Clone)"|| col.gameObject.name == "Enemy2" || col.gameObject.name == "Enemy2(Clone)"|| col.gameObject.name == "Enemy3" || col.gameObject.name == "Enemy3(Clone)")
        {
            //Destroy(col.gameObject);
            GetComponent<AudioSource>().PlayOneShot(oneHitSound);
            //Do damange
            col.gameObject.SendMessage("ApplyDamage", 8.0f);
            Destroy(parent);

        }
    }
}