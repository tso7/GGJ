using UnityEngine;
using System.Collections;

public class RandomFloatGenerator : MonoBehaviour 
{

	public float min = 3.0f;
	public float max = 6.0f;
	public float result;
	public float timer = 10f;
	private int x = 0;
	private int y = 2;
	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
		timer -= 0.05f;
		if (timer < 0) 
		{
			RandomFloat ();
			bool res = fiftyfifty ();
			Debug.Log (res);
			timer = 10f;
		}
	}

	public void RandomFloat()
	{
		result = UnityEngine.Random.Range (min, max);
	}

	public bool fiftyfifty()
	{
		int num = UnityEngine.Random.Range (x,y);
		if (num == 0)
			return false;
		else
			return true;
	}
}
