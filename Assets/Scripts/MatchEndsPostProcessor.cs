using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Match Ends Post-Processor", menuName ="Game Data/Match Ends Post-Processor")]
public class MatchEndsPostProcessor : MovePostProcessor
{
	public bool performerWins = true;

	public override void PostProcess (WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move) {
		if (performerWins) {
			match.Winner = performer;
			match.Loser = opponent;
		} else {
			match.Winner = opponent;
			match.Loser = performer;
		}

		GameManager.Instance.Messenger.SendMessage (this, "MatchEnded", match);
	}
}