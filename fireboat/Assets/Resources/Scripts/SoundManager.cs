using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{

	public AudioSource efxSource;
	public AudioSource musicSource;
    public AudioSource arrowLeft, arrowRight;
    public AudioSource combo;
    public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float highPitchRange = 1.05f;


	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	
	}

	public void PlaySingle(AudioClip clip)
	{
		efxSource.clip = clip;
		efxSource.Play ();
	}
    public void PlayCombo(AudioClip clip)
    {
        combo.clip = clip;
        combo.Play();
    }

    public void LeftArrowRandom(params AudioClip [] clips)
	{
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

        arrowLeft.pitch = randomPitch;
        arrowLeft.clip = clips [randomIndex];
		arrowLeft.Play();
	}

    public void RightArrowRandom(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        arrowRight.pitch = randomPitch;
        arrowRight.clip = clips[randomIndex];
        arrowRight.Play();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
