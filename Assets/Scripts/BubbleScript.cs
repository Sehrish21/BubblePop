using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour {

	Animator anim;
	private int frame;
	public GameObject master;
	private GameObject clone;
	private int counter;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("Frame: " + frame);
		frame++;

	}

	void OnMouseDown()
	{
		if(Input.GetMouseButton(0))
		{
			playAnimation ("bubble_burst");
			Waiting ();
			regenerateBubble ();
		}
	}

	/** OnClick event
	 */ 
	private void regenerateBubble ()
	{
		clone = Instantiate(master, GeneratedPosition(), Quaternion.identity) as GameObject;
		clone.transform.parent = transform;
		Destroy (bubble);
		bubble = go;
	}

	private void playAnimation(string animName)
	{
		anim.Play(animName,-1,0f);
	}

	IEnumerator Waiting()
	{
		Debug.Log("Waiting for bubble to be burst...");
		yield return new WaitUntil(() => frame >= 10);
		Debug.Log("Bubble was burst!");
	}

	Vector3 GeneratedPosition()
	{
		int x;
		x = Random.Range(-3,3);
		return new Vector3(x,-5,0);
	}
}
