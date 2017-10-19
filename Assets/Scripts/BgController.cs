using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: BgController.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
/**This class is to control the movements of the background**/
public class BgController : MonoBehaviour {

	[SerializeField]
	private float bgSpeed = 2f;   //speed of the background

	[SerializeField]                   //To scroll the background from left to right(horizontally),variables defined on x-axis 
	private float bgStartX = 1370f;      //From where background starts(+ve value)
	[SerializeField]
	private float bgEndX = -1370f;        //From where background ends(-ve value)

	private Transform bgTransform;      //to access position, rotation and scale
	private Vector2 bgCurrentPosition;  //current position of the background

	void Start ()           
	{
		this.bgTransform = gameObject.GetComponent<Transform> ();
		Reset ();
	}


	void Update () 
	{
		bgCurrentPosition = bgTransform.position;
		bgCurrentPosition -= new Vector2 (bgSpeed, 0);   //move background left to right
		if(bgCurrentPosition.x <= bgEndX)                
		{
			Reset ();
		}
		bgTransform.position = bgCurrentPosition;
	}

	private void Reset()          //function to reset the position of the background
	{
		bgCurrentPosition = new Vector2 (bgStartX, 0);
	}
}
	
