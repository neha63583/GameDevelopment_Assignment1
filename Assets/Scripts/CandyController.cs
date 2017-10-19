using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: CandyController.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
/**This class is to control the movements of the candy**/
public class CandyController : MonoBehaviour {

	[SerializeField]
	private float candyMinYSpeed = 0f;     // up/down speed of the candy

	[SerializeField]
	private float candyMaxYSpeed = 0f;         

	[SerializeField]
	private float candyMinXSpeed = 3f;     // left/right speed of the candy 

	[SerializeField]
	private float candyMaxXSpeed = 6f;

	[SerializeField]
	private float candyStartY = 400f;

	[SerializeField]
	private float candyEndY = -400f;

	[SerializeField]
	private float candyStartX = -710f;

	[SerializeField]
	private float candyEndX = 710f;

	private Transform candyTransform;
	private Vector2 candyCurrentSpeed;
	private Vector2 candyCurrentPosition;

	void Start () 
	{
		candyTransform = gameObject.GetComponent<Transform> ();
		ResetCandy();                   //reset the position of the candy
	}


	void Update () 
	{
		candyCurrentPosition = candyTransform.position;
		candyCurrentPosition -= candyCurrentSpeed;
		candyTransform.position = candyCurrentPosition;

		if (candyCurrentPosition.x <= candyStartX) 
		{
			ResetCandy ();
		}
	}

	public void ResetCandy()
	{
		float candyXSpeed = Random.Range(candyMinXSpeed, candyMaxXSpeed);
		float candyYSpeed = Random.Range (candyMinYSpeed, candyMaxYSpeed);

		candyCurrentSpeed = new Vector2 (candyXSpeed, candyYSpeed);
		float candyXBounds = Random.Range (candyStartX, candyEndX);
		float candyYBounds = Random.Range (candyEndY, candyStartY);
		candyTransform.position = new Vector2 (candyXBounds + 940, candyYBounds);
	}
}
