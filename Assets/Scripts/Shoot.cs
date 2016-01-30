using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	
	public double timebetweenshots = .1;
	public double timebetweenSounds = 1;
	private double lastfiretime = 0;
	private double lastSoundtime = 0;
	public GameObject Bullet;
	public AudioClip Audio;
    public AudioClip AudioStairway;
    public AudioSource audioS;
    public AudioSource stairWay;
	//private PlayerCharacter _player;
    public bool touchShot = false;
    public Transform gun;
    private Transform prefabHolder;
    public SpriteRenderer flash;

    // Use this for initialization
    void Start()
    {
        prefabHolder = GameObject.FindGameObjectWithTag("PrefabHolder").transform;
    }

    // Update is called once per frame
    void Update()
	{  
		lastfiretime += Time.deltaTime;
		lastSoundtime += Time.deltaTime;
#if FIRETV
		if (lastfiretime > timebetweenshots && (Input.GetButton("Fire1") || Input.GetAxisRaw("RightTriggerFireTV") > 0) == true && _player.ViewOption == PlayerViewOptions.OverTheShoulder && (Input.touchCount == 0 || touchShot))
		{
			lastfiretime = 0;
			var clone  = Instantiate(Bullet,Camera.main.transform.position,Camera.main.transform.rotation);
			
			if(lastSoundtime > timebetweenshots)
			{
				lastSoundtime = 0;
				this.audioS.PlayOneShot(Audio);
			}
			Destroy(clone, .8f);
		}
		else if(false)//Test for touchscreen input
		{
			
		}
#else
		if (lastfiretime > timebetweenshots && (Input.GetButton("Fire1") || Input.GetAxisRaw("RightTrigger") != 0) == true) //&& _player.ViewOption == PlayerViewOptions.OverTheShoulder && (Input.touchCount == 0 || touchShot))
		{
			lastfiretime = 0;
			var clone  = (GameObject)Instantiate(Bullet, gun.position, gun.rotation);
            clone.transform.parent = prefabHolder;
            if (lastSoundtime > timebetweenshots)
			{
				lastSoundtime = 0;
				this.audioS.PlayOneShot(Audio);
			}
			Destroy(clone, .8f);

            flash.enabled = true;
            StartCoroutine(DisableFlash());
        }
		else if(lastfiretime > timebetweenshots && (Input.GetButton("Fire2") || Input.GetAxisRaw("LeftTrigger") != 0) == true)//(false)//Test for touchscreen input
		{
            //Alt fire (music)
            lastfiretime = 0;
            var clone = Instantiate(Bullet, gun.position, gun.rotation);

            if (lastSoundtime > timebetweenshots)
            {
                lastSoundtime = 0;
                stairWay.pitch = Random.Range(0,100);
                stairWay.Play();
            }
            Destroy(clone, .8f);
        }

#endif
        

    }
    IEnumerator DisableFlash()
    {
        yield return new WaitForFixedUpdate();
        flash.enabled = false;
    }

}
