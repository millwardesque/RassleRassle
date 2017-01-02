using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Under-Attack Prerequisite", menuName ="Game Data/Under-Attack Prerequisite")]
public class UnderAttackPrerequisite : MovePrerequisite
{
	public override bool IsValid (WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move) {
		if (match.Turns.Count == 0) {
			return false; 
		}

		WrestlingMove previousMove = match.Turns [match.Turns.Count - 1].Move;
		return previousMove.IsOffensive;
	}
}