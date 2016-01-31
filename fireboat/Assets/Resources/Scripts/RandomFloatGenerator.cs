using UnityEngine;
using System.Collections;

public class RandomFloatGenerator : GenericSingleton<RandomFloatGenerator> 
{

	public float min = 2.0f;
	public float max = 3.5f;
	public float result = 3.0f;
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
		timer -= Time.deltaTime;
		if (timer < 0) 
		{
            result = UnityEngine.Random.Range(min, max);
            timer = 10f;
		}
	}

	public float RandomFloat()
	{
		return result;
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
