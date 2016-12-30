using UnityEngine;
using System.Collections;

public class MatchTurn
{
	WrestlingMatch m_match;
	Wrestler m_wrestler1;
	Wrestler m_wrestler2;
	WrestlingMove m_move1;
	WrestlingMove m_move2;

	public MatchTurn(WrestlingMatch match, Wrestler wrestler1, Wrestler wrestler2, WrestlingMove move1, WrestlingMove move2) {
		m_match = match;
		m_wrestler1 = wrestler1;
		m_wrestler2 = wrestler2;
		m_move1 = move1;
		m_move2 = move2;
	}

	public void ExecuteMove() {
		Crowd matchCrowd = GameManager.Instance.MatchCrowd;
		Commentary matchCommentary = GameManager.Instance.MatchCommentary;

		matchCrowd.CrowdInterest -= matchCrowd.interestDecay;

		float crowdInterestMultiplier = matchCrowd.IsExcited() ? 1.5f : 1f;
		matchCrowd.CrowdInterest += crowdInterestMultiplier * (m_move1.CrowdChange + m_move2.CrowdChange);

		if (matchCrowd.idealMatchLength < m_match.Turns.Count) {
			matchCommentary.AddMessage ("The crowd is getting restless");
			matchCrowd.CrowdInterest--;
		}
	
		m_wrestler1.CurrentStamina += m_move1.StaminaChange;
		m_wrestler2.CurrentStamina += m_move2.StaminaChange;

		if (m_move1.IsOffensive && !m_move2.IsOffensive) {
			m_match.MatchOffense--;
		} else if (!m_move1.IsOffensive && m_move2.IsOffensive) {
			m_match.MatchOffense++;
		}


		matchCommentary.AddMessage (m_wrestler1.WrestlerName + ": " + m_move1.MoveName);
		matchCommentary.AddMessage (m_wrestler2.WrestlerName + ": " + m_move2.MoveName);
	}
}

