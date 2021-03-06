﻿using UnityEngine;
using System.Collections;

public class MatchTurn
{
	WrestlingMatch m_match;

	Wrestler m_performer;
	public Wrestler Performer {
		get { return m_performer; }
	}

	Wrestler m_opponent;
	public Wrestler Opponent {
		get { return m_opponent; }
	}

	WrestlingMove m_move;
	public WrestlingMove Move {
		get { return m_move; }
	}

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

		if (matchCrowd.idealMatchLength <= m_match.Turns.Count) {
			matchCommentary.AddMessage ("The crowd is getting restless");
			matchCrowd.CrowdInterest--;
		}
	
		m_performer.CurrentStamina += m_move.StaminaChange;

		if (m_move.EndingPosition != WrestlerPosition.Same && m_move.EndingPosition != WrestlerPosition.Any) {
			m_performer.Position = m_move.EndingPosition;
		}

		if (m_move.OpponentEndingPosition != WrestlerPosition.Same && m_move.OpponentEndingPosition != WrestlerPosition.Any) {
			m_opponent.Position = m_move.OpponentEndingPosition;
		}

		if (m_move.IsOffensive) {
			if (m_match.CurrentWrestler == m_match.Wrestler1) {
				m_match.MatchOffense--;
			} else {
				m_match.MatchOffense++;
			}

		}

		matchCommentary.GenerateMessage (m_match, this);

		if (m_move.PostProcessor != null) {
			m_move.PostProcessor.PostProcess(m_match, m_performer, m_opponent, m_move);
		}
	}
}

