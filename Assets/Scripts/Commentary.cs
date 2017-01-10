using UnityEngine;
using System.Collections;

public class Commentary : MonoBehaviour
{
	public void GenerateMessage(WrestlingMatch match, MatchTurn turn) {
		string commentary = turn.Move.GetRandomCommentary ();
		if (commentary == "") {
			commentary = match.CurrentWrestler.WrestlerName + ": " + turn.Move.MoveName;
		}

		commentary = commentary.Replace ("<performer>", turn.Performer.WrestlerName);
		commentary = commentary.Replace ("<opponent>", turn.Opponent.WrestlerName);

		AddMessage (commentary);
	}

	public void AddMessage(string message) {
		GameManager.Instance.Messenger.SendMessage (this, "CommentaryMessage", message);
		Debug.Log ("Commentary: " + message);
	}
}

