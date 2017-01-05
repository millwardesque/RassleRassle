using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverScreen : MonoBehaviour {
	public Text title;
	public Text score;

	public void ShowMatchResults(WrestlingMatch match) {
		title.text = match.Winner.WrestlerName + " won!";
		score.text = "Score: " + GameManager.Instance.Scorer.CalculateScore (match, GameManager.Instance.MatchCrowd).ToString();
		score.text += "\nMatch Length: " + GameManager.Instance.Scorer.CalculateMatchLengthScore (match, GameManager.Instance.MatchCrowd).ToString();
		score.text += "\nCrowd Interest: " + GameManager.Instance.Scorer.CalculateCrowdInterestScore (match, GameManager.Instance.MatchCrowd).ToString();
	}
}
