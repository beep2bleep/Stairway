using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    public SpriteRenderer guitar;
    public SpriteRenderer spriteGun;
    public Slider health;
    public Slider rocking;
    public UnityEngine.UI.Text healthText;
    public UnityEngine.UI.Text rockText;

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
            healthText.text = "";
            rockText.text = "";
            lastfiretime = 0;
			var clone  = (GameObject)Instantiate(Bullet, gun.position, gun.rotation);
            clone.transform.parent = prefabHolder;
            if (lastSoundtime > timebetweenshots)
			{
				lastSoundtime = 0;
				this.audioS.PlayOneShot(Audio);
			}
            stairWay.volume = 0;
            spriteGun.enabled = true;
            health.value -= 1;
            healthText.text = "-1";
            Destroy(clone, .8f);
		}
		else if(lastfiretime > timebetweenshots && (Input.GetButton("Fire2") || Input.GetAxisRaw("LeftTrigger") != 0) == true)//(false)//Test for touchscreen input
		{
            healthText.text = "";
            rockText.text = "";
            //Alt fire (music)
            spriteGun.enabled = false;
            lastfiretime = 0;
            //var clone = Instantiate(Bullet, gun.position, gun.rotation);

            if (lastSoundtime > timebetweenshots)
            {
                lastSoundtime = 0;
                //stairWay.pitch = Random.Range(.5f,2.5f);
                if (stairWay.volume != 1) { stairWay.volume = 1; }
                guitar.enabled = true;
                health.value -= 5;
                healthText.text = "-5";
                rocking.value += 2;
                rockText.text = "+2";
            }
            //Destroy(clone, .8f);
        }
        else
        {
            if(lastfiretime > timebetweenshots)
            {
                healthText.text = "";
                rockText.text = "";
                //rocking.value -= .01f;//SNeeds seperate counter
            }
            if (!(Input.GetButton("Fire2") || Input.GetAxisRaw("LeftTrigger") != 0) == true)
            {
                stairWay.volume = 0;
                guitar.enabled = false;
                
            }
        }
        
#endif
        
		
	}
	
}
