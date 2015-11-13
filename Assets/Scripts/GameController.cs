using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{


	public Text ScoreText;
	public Text RestartText;
	public Text GameOverText;

	private bool _gameOver;
	private bool _restart;
	private int _score;

	// Use this for initialization
	void Start()
	{
		_score = 0;
		_gameOver = false;
		_restart = false;
		RestartText.text = "";
		GameOverText.text = "";
		UpdateScore();
	}

	// Update is called once per frame
	void Update()
	{
		if (_gameOver)
		{
			RestartText.text = "Press 'R' for Restart";
			_restart = true;
		}

		if (_restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}


	}

	void UpdateScore()
	{
		ScoreText.text = "Score: " + _score;
	}

	public void AddScore(int newScoreValue)
	{
		_score += newScoreValue;
		UpdateScore();
	}

	public void GameOver()
	{
		GameOverText.text = "Game Over";
		_gameOver = true;
	}

}
