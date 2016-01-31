using UnityEngine;
using System.Collections;

public class ChangeSpriteOnInput : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;

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
        if (type == 2)
            ps[1].Play();
        else
            ps[0].Play();
    }
}
