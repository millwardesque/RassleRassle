using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWrestlerActions : MonoBehaviour {
	public Button buttonPrefab;
	public int wrestlerNumber = 1;

	void Start() {
		GameManager.Instance.Messenger.AddListener ("TurnEnded", RefreshActionList);
		GameManager.Instance.Messenger.AddListener ("MatchStarted", RefreshActionList);
	}

	public void CreateMoveList(Wrestler wrestler, List<WrestlingMove> moves, bool makeInactive) {
		ClearMoveList ();
		moves.Sort (delegate (WrestlingMove x, WrestlingMove y) {
			if (x.MoveName == null && y.MoveName == null) return 0;
			else if (x.MoveName == null) return -1;
			else if (y.MoveName == null) return 1;
			else return x.MoveName.CompareTo(y.MoveName);
		});

		foreach (WrestlingMove move in moves) {
			Button moveButton = GameObject.Instantiate<Button> (buttonPrefab, this.transform);
			moveButton.GetComponentInChildren<Text> ().text = move.MoveName;
			moveButton.onClick.AddListener(delegate { 
				GameManager.Instance.Match.SetWrestlerMove(move);
				GameManager.Instance.Match.SetNextTurn ();
			});

			if (makeInactive) {
				moveButton.interactable = false;
			}
		}
	}

	public void ClearMoveList() {
		Button[] moves = GetComponentsInChildren<Button> ();
		foreach (Button move in moves) {
			GameObject.Destroy (move.gameObject);
		}
	}

	void RefreshActionList(Message message) {
		WrestlingMatch match = message.data as WrestlingMatch;
		bool wrestler1IsActive = (match.Turns.Count == 0 || match.CurrentWrestler == match.Wrestler2);
		if (match != null) {
			if (match.Wrestler1.WrestlerNumber == wrestlerNumber) {
				CreateMoveList (match.Wrestler1, match.Wrestler1.GetMoves(match, match.Wrestler2), !wrestler1IsActive);
			}
			else if (match.Wrestler2.WrestlerNumber == wrestlerNumber) {
				CreateMoveList (match.Wrestler2, match.Wrestler2.GetMoves(match, match.Wrestler1), wrestler1IsActive);
			}
		} else {
			Debug.LogError ("TurnEnded called with null match!");
		}
	}
}
