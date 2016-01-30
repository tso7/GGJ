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
	
	public void ChangeSprite()
	{
		if (spriteRenderer.sprite == sprite1)
			spriteRenderer.sprite = sprite2;
		else
			spriteRenderer.sprite = sprite1;
	}

}
