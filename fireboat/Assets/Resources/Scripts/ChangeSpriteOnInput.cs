using UnityEngine;
using System.Collections;

public class ChangeSpriteOnInput : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;

    public AudioClip arrowCombo;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		if (spriteRenderer.sprite == null)
			spriteRenderer.sprite = sprite1;
	
	}
	
	public void ChangeSprite(int type)
	{
        ParticleSystem[] ps = GetComponentsInChildren<ParticleSystem>();
        switch (type)
        {
            case 1:
                if (ps[2].isPlaying)
                {
                    ps[2].Stop();
                    ps[4].Play();
                    ps[5].Play();
                    UpdateScore.ScoreUpdate(1, 1);
                    UpdateScore.ScoreUpdate(2, 1);
                    SoundManager.instance.PlayCombo(arrowCombo);
                }
                else
                    ps[0].Play();
                break;
            case 2:
                if (ps[0].isPlaying)
                {
                    ps[0].Stop();
                    ps[4].Play();
                    ps[5].Play();
                    UpdateScore.ScoreUpdate(2, 1);
                    UpdateScore.ScoreUpdate(1, 1);
                    SoundManager.instance.PlayCombo(arrowCombo);
                }
                else
                    ps[2].Play();
                break;
            case 3:
                ps[0].Play();
                break;    
        }
    }
}
