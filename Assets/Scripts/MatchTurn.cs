using UnityEngine;
using System.Collections;

public class MatchTurn
{
	WrestlingMatch m_match;
	Wrestler m_performer;
	Wrestler m_opponent;
	WrestlingMove m_move;

	public MatchTurn(WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move) {
		m_match = match;
		m_performer = performer;
		m_opponent = opponent;
		m_move = move;
	}

	public void ExecuteMove() {
		Crowd matchCrowd = GameManager.Instance.MatchCrowd;
		Commentary matchCommentary = GameManager.Instance.MatchCommentary;

		matchCrowd.CrowdInterest -= matchCrowd.interestDecay;

		float crowdInterestMultiplier = matchCrowd.IsExcited() ? 1.5f : 1f;
		matchCrowd.CrowdInterest += crowdInterestMultiplier * (m_move.CrowdChange);

		if (matchCrowd.idealMatchLength < m_match.Turns.Count) {
			matchCommentary.AddMessage ("The crowd is getting restless");
			matchCrowd.CrowdInterest--;
		}
	
		m_performer.CurrentStamina += m_move.StaminaChange;

		if (m_move.EndingPosition != WrestlerPosition.Same && m_move.EndingPosition != WrestlerPosition.Any) {
			m_performer.Position = m_move.EndingPosition;
		}

		if (m_move.IsOffensive) {
			m_match.MatchOffense--;
		}


		matchCommentary.AddMessage (m_performer.WrestlerName + ": " + m_move.MoveName);
	}
}

