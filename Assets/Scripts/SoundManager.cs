using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Audio players components.
	public AudioSource soundPlayer;

    [SerializeField] private AudioClip[] soundEffect;

    public static SoundManager Instance = null;

    private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

    // Play a single clip through the sound effects source.
	public void Play(string clip)
	{
		if(clip == "Jump")
            soundPlayer.PlayOneShot(soundEffect[2]);
        else if(clip == "Coin")
            soundPlayer.PlayOneShot(soundEffect[0]);
        else if(clip == "Power")
            soundPlayer.PlayOneShot(soundEffect[1]);
        else if(clip == "Select")
            soundPlayer.PlayOneShot(soundEffect[3]);
	}
}
