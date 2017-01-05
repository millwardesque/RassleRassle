using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverScreen : MonoBehaviour {
	public Text title;

	public void ShowMatchResults(WrestlingMatch match) {
		title.text = match.Winner.WrestlerName + " won!";
	}
}
