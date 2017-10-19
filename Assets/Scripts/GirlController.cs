using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: GirlController.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
/**This class is to control the movements of the main character i.e., Halloween Girl**/

public class GirlController : MonoBehaviour {

	[SerializeField]
	private float girlSpeed = 3f;  //speed of the girl

	[SerializeField]
	private float girlBackX = 563f;    

	[SerializeField]
	private float girlFrontX = 563f;

	[SerializeField]
	private float girlUpY = 350f;

	[SerializeField]
	private float girlDownY = -350f;

	private Vector2 girlCurrentPosition;
	private Transform girlTransform;

	void Start () 
	{
		girlTransform = gameObject.GetComponent<Transform> ();
		girlCurrentPosition = girlTransform.position;
	}
	

	void Update () 
	{
		girlCurrentPosition = girlTransform.position;
		float userHorInput = Input.GetAxis("Horizontal");
		float userVerInput = Input.GetAxis ("Vertical");

		if ((userHorInput > 0) || (Input.GetKey(KeyCode.D)))   //if user press left arrow
		{
			girlCurrentPosition += new Vector2 (girlSpeed, 0);
		}

		else if ((userHorInput < 0) || (Input.GetKey(KeyCode.A)))  //if user press right arrow
		{
			girlCurrentPosition -= new Vector2 (girlSpeed, 0);
		}

		else if ((userVerInput > 0) || (Input.GetKey(KeyCode.W)))  //if user press up arrow
		{
			girlCurrentPosition += new Vector2 (0, girlSpeed);
		}

		else if ((userVerInput < 0) || (Input.GetKey(KeyCode.S)))  //if user press down arrow
		{
			girlCurrentPosition -= new Vector2 (0, girlSpeed);
		}

		CheckBoundaries ();
		girlTransform.position = girlCurrentPosition;

	}

	private void CheckBoundaries()
	{
		if (girlCurrentPosition.x < girlBackX)    //check if girl is going backwards from far point 
		{
			girlCurrentPosition.x = girlBackX;
		}

		else if (girlCurrentPosition.x > girlFrontX)  //check if girl is going forward
		{
			girlCurrentPosition.x = girlFrontX;
		}

		else if (girlCurrentPosition.y < girlDownY) //check if the girl is going far down
		{
			girlCurrentPosition.y = girlDownY;
		}

		else if (girlCurrentPosition.y > girlUpY) //check if the girl is going far up
		{
			girlCurrentPosition.y = girlUpY;
		}
	}
}
