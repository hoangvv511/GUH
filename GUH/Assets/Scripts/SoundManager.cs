using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {


    public AudioClip item, flag, die, jump, gravity;
    public AudioSource adisrc;
	// Use this for initialization
	void Start () {

        item = Resources.Load<AudioClip>("item");
        adisrc = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(string clip)
    {
        switch(clip)
        {
            case "item":
                adisrc.clip = item;
                adisrc.PlayOneShot(item, 1f);
                break;
        }
    }
}
