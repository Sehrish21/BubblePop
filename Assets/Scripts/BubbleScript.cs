using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour {

	Animator anim;
	private int frame;
	public GameObject bubble;
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
			regenerateBubble ();
		}
	}

	private void regenerateBubble ()
	{
		anim.Play("bubble_burst",-1,0f);
		Waiting ();
		anim.Play("bubbleAnimation");
		bubble.transform.Translate (GeneratedPosition());
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
