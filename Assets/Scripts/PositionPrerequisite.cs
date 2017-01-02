using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Position Prerequisite", menuName ="Game Data/Position Prerequisite")]
public class PositionPrerequisite : MovePrerequisite
{
	public override bool IsValid (WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move) {
		bool wrestlerIsInRightPosition = move.StartingPosition == WrestlerPosition.Any || move.StartingPosition == WrestlerPosition.Same || move.StartingPosition == performer.Position;
		bool opponentIsInRightPosition = move.OpponentStartingPosition == WrestlerPosition.Any || move.OpponentStartingPosition == WrestlerPosition.Same || move.OpponentStartingPosition == opponent.Position;

		return wrestlerIsInRightPosition && opponentIsInRightPosition;
	}
}