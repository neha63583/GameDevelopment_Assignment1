using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name:GirlColliderr.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
/**This class is to indentify collisions with the girl**/

public class GirlCollider : MonoBehaviour {

	[SerializeField]
	CanvasController canvasController;

	[SerializeField]
	GhostController ghostController;

	private AudioSource candyScoreSound;


	void Start () 
	{
		candyScoreSound = gameObject.GetComponent<AudioSource>();
	}

	void Update () 
	{
		
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("candy")) 
		{
			Debug.Log("Collision detected with candy :)\n");
			if (candyScoreSound != null) 
			{
				candyScoreSound.Play ();
			}
			other.gameObject.GetComponent<CandyController>().ResetCandy();
			canvasController.CandyScore += 10;
		}

		else if (other.gameObject.tag.Equals ("gingerman")) 
		{
			Debug.Log("Collision detected with gingerman :)\n");
			if (candyScoreSound != null) 
			{
				candyScoreSound.Play ();
			}
			other.gameObject.GetComponent<CandyController>().ResetCandy();
			canvasController.CandyScore += 20;
		}

		else if (other.gameObject.tag.Equals ("ghost")) 
		{
			Debug.Log("Collision detected with ghost :(\n");
		    if (ghostController.ghostCollideSound != null) 
			{
				ghostController.ghostCollideSound.Play ();
			}
			//other.gameObject.GetComponent<GhostController>().ResetGhost();
			canvasController.GirlLife -= 1;
			StartCoroutine ("Blink");
		}

	}

	private IEnumerator Blink()
	{
		Color girlColor;
		Renderer rend = gameObject.GetComponent<Renderer> ();
		for (int blinkTime = 0; blinkTime < 2; blinkTime++) 
		{
			for (float f = 1f; f >= 0; f -= 0.1f) {
				girlColor = rend.material.color;
				girlColor.a = f;
				rend.material.color = girlColor;
				yield return new WaitForSeconds (0.01f);
			}
			for (float f = 0f; f <= 1; f += 0.1f) {
				girlColor = rend.material.color;
				girlColor.a = f;
				rend.material.color = girlColor;
				yield return new WaitForSeconds (0.01f);
			}
		}
	}
}
