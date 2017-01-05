using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
	public UIGameOverScreen gameOverScreen;

	// Use this for initialization
	void Start () {
		GameManager.Instance.Messenger.AddListener ("MatchEnded", OnMatchEnded);
	}

	void OnRestartMatchClick() {
		HideGameOverScreen ();
		GameManager.Instance.RestartGame ();
	}

	void OnMatchEnded(Message message) {
		WrestlingMatch match = message.data as WrestlingMatch;
		ShowGameOverScreen(match);
	}

	public void ShowGameOverScreen(WrestlingMatch match) {
		gameOverScreen.gameObject.SetActive (true);
		gameOverScreen.ShowMatchResults (match);
	}

	public void HideGameOverScreen() {
		gameOverScreen.gameObject.SetActive (false);
		GameManager.Instance.RestartGame ();
	}
}
