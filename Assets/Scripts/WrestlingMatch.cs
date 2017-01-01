using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WrestlingMatch
{
	private WrestlingMove m_nextMove;

	Wrestler m_wrestler1;
	public Wrestler Wrestler1 {
		get { return m_wrestler1; }
	}

	Wrestler m_wrestler2;
	public Wrestler Wrestler2 {
		get { return m_wrestler2; }
	}

	Wrestler m_currentWrestler;
	public Wrestler CurrentWrestler {
		get { return m_currentWrestler; }
	}

	float m_matchOffense = 0f;
	public float MatchOffense
	{
		get { return m_matchOffense; }
		set
		{
			m_matchOffense = value;

			string output = (m_matchOffense < 0f ? m_wrestler1.WrestlerName : (m_matchOffense > 0f ? m_wrestler2.WrestlerName : "Even")) + " (" + m_matchOffense + ")";
			GameManager.Instance.Messenger.SendMessage(this, "OnOffenseChange", output);
		}
	}

	List<MatchTurn> m_turns;
	public List<MatchTurn> Turns {
		get { return m_turns; }
	}

	public WrestlingMatch(Wrestler wrestler1, Wrestler wrestler2) {
		m_wrestler1 = wrestler1;
		m_wrestler2 = wrestler2;

		m_turns = new List<MatchTurn> ();
	}

	public void StartMatch() {
		m_wrestler1.StartMatch(1);
		m_wrestler2.StartMatch(2);
		m_currentWrestler = m_wrestler1;

		GameManager.Instance.MatchCrowd.ResetCrowd ();
		MatchOffense = 0f;

		GameManager.Instance.Messenger.SendMessage (this, "MatchStarted", this);
	}

	public void RunTurn(MatchTurn turn) {
		turn.ExecuteMove ();
		m_turns.Add (turn);

		GameManager.Instance.Messenger.SendMessage (this, "TurnEnded", this);

		m_nextMove = null;
		Wrestler opponent = (CurrentWrestler == m_wrestler1 ? m_wrestler2 : m_wrestler1);
		Wrestler temp = CurrentWrestler;
		m_currentWrestler = opponent;
		opponent = temp;
	}

	public void SetWrestlerMove(WrestlingMove move) {
		m_nextMove = move;
	}

	public void SetNextTurn() {
		if (m_nextMove != null) {
			Wrestler opponent;
			if (CurrentWrestler == m_wrestler1) {
				opponent = m_wrestler2;
			} else {
				opponent = m_wrestler1;
			}
			RunTurn (new MatchTurn (this, CurrentWrestler, opponent, m_nextMove));
		} else {
			Debug.LogWarning ("Move not set for active wrestler.");
		}
	}
}

