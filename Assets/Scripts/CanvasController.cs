using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * File name: CanvasController.cs
 * Author's Name: Neha Arora
 * Student Id: 101043939
**/
public class CanvasController : MonoBehaviour {

	[SerializeField]
	Text candyScoreLabel;

	[SerializeField]
	Text girlLifeLabel;

	[SerializeField]
	Text gameOverLabel;

	[SerializeField]
	Text highScoreLabel;

	[SerializeField]
	Button playAgainBtn;

	[SerializeField]
	Text gameNameLabel;

	[SerializeField]
	Button playBtn;

	private int candyScore = 0;          //default collected candies = 0
	private int girlLife = 3;            //default lives of girl = 5

	public int CandyScore              //method to set getter and setter properties of candy score
	{
		get {return candyScore;}
		set {candyScore = value;
			candyScoreLabel.text = "Candies: " + candyScore;}
	}

	public int GirlLife              //method to set getter and setter properties of girl's life
	{
		get {return girlLife;}
		set {
			girlLife = value;
			if (girlLife <= 0) {
				gameOver ();} 
			else {
				girlLifeLabel.text = "Life: " + girlLife; }
		   }
	}
		
	void Start ()
	{
		initializeFirstPage();
	}
	

	private void gameOver()
	{
		gameOverLabel.gameObject.SetActive (true);
		highScoreLabel.gameObject.SetActive (true);
		playAgainBtn.gameObject.SetActive (true);

		girlLifeLabel.gameObject.SetActive (false);
		candyScoreLabel.gameObject.SetActive (false);
		gameNameLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		highScoreLabel.text = "High Score: " + candyScore;
	}

	private void initializeFirstPage()
	{
		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);

		girlLifeLabel.gameObject.SetActive (false);
		candyScoreLabel.gameObject.SetActive (false);

		gameNameLabel.gameObject.SetActive (true);
		playBtn.gameObject.SetActive (true);
	}

	private void initializeCanvas()
	{
		candyScore = 0;
		girlLife = 3;

		candyScoreLabel.text = "Candies: " + CandyScore;
		girlLifeLabel.text = "Life: " + GirlLife;

		gameOverLabel.gameObject.SetActive (false);
		highScoreLabel.gameObject.SetActive (false);
		playAgainBtn.gameObject.SetActive (false);

		girlLifeLabel.gameObject.SetActive (true);
		candyScoreLabel.gameObject.SetActive (true);
		gameNameLabel.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
	}

	public void PlayBtnClick()
	{
		initializeCanvas ();
	}

	public void PlayAgainBtnClick()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}


}
