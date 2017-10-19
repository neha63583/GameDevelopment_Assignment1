using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * File name: GhostController.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
/**This class is to control the movements of the enemy i.e., Ghost**/

public class GhostController : MonoBehaviour {

	public AudioSource ghostCollideSound;


	[SerializeField]
	private float ghostMinYSpeed = 0f;     // up/down speed of the ghost

	[SerializeField]
	private float ghostMaxYSpeed = 0f;         

	[SerializeField]
	private float ghostMinXSpeed = 1f;     // left/right speed of the ghost 

	[SerializeField]
	private float ghostMaxXSpeed = 5f;


	private Transform ghostTransform;
	private Vector2 ghostCurrentSpeed;
	private Vector2 ghostCurrentPosition;

	void Start () 
	{
		ghostCollideSound = gameObject.GetComponent<AudioSource> ();
		ghostTransform = gameObject.GetComponent<Transform> ();
		ResetGhost();                   //reset the position of the ghost
	}
	

	void Update () 
	{
		ghostCurrentPosition = ghostTransform.position;
		ghostCurrentPosition -= ghostCurrentSpeed;
		ghostTransform.position = ghostCurrentPosition;

		if (ghostCurrentPosition.x <= -940) 
		{
			ResetGhost ();
		}
	}

	public void ResetGhost()
	{
		float ghostXSpeed = Random.Range(ghostMinXSpeed, ghostMaxXSpeed);
		float ghostYSpeed = Random.Range (ghostMinYSpeed, ghostMaxYSpeed);

		ghostCurrentSpeed = new Vector2 (ghostXSpeed, ghostYSpeed);
		float ghostXBounds = Random.Range (-610, 610);
		float ghostYBounds = Random.Range (-330, 330);
		ghostTransform.position = new Vector2 (ghostXBounds + 940, ghostYBounds);

	}
}
