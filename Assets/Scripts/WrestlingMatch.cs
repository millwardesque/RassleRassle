using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WrestlingMatch
{
	private WrestlingMove m_nextMove1;
	private WrestlingMove m_nextMove2;

	Wrestler m_wrestler1;
	public Wrestler Wrestler1 {
		get { return m_wrestler1; }
	}

	Wrestler m_wrestler2;
	public Wrestler Wrestler2 {
		get { return m_wrestler2; }
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

		GameManager.Instance.MatchCrowd.ResetCrowd ();
		MatchOffense = 0f;

		GameManager.Instance.Messenger.SendMessage (this, "MatchStarted", this);
	}

	public void RunTurn(MatchTurn turn) {
		turn.ExecuteMove ();
		m_turns.Add (turn);

		m_nextMove1 = null;
		m_nextMove2 = null;
		GameManager.Instance.Messenger.SendMessage (this, "TurnEnded", this);
	}

	public void SetWrestlerMove(Wrestler wrestler, WrestlingMove move) {
		if (wrestler.WrestlerNumber == 1) {
			m_nextMove1 = move;
		} else if (wrestler.WrestlerNumber == 2) {
			m_nextMove2 = move;
		}
	}

	public void SetNextTurn() {
		if (m_nextMove1 != null && m_nextMove2 != null) {
			RunTurn (new MatchTurn (this, m_wrestler1, m_wrestler2, m_nextMove1, m_nextMove2));
		} else {
			Debug.LogWarning ("Move not set for at least one wrestler.");
		}
	}
}

