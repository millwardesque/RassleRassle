using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WrestlerPosition {
	Any,
	Same,
	Standing,
	RunningOnRopes,
	OnMat,
	InTurnbuckle,
	OnTurnbuckle,
	Pinning,
	Grappling,
};

public class Wrestler : MonoBehaviour {
    int m_wrestlerNumber;	// Wrestler's 'number' in the current match.
	public int WrestlerNumber {
		get { return m_wrestlerNumber; }
	}

    float m_athleticism;
    float m_charisma;
    float m_strength;
    float m_technique;
    float m_selling;
    float m_stamina;

	WrestlerPosition m_position = WrestlerPosition.Standing;
	public WrestlerPosition Position {
		get { return m_position; }
		set {
			m_position = value;
			GameManager.Instance.Messenger.SendMessage(this, "OnWrestler" + m_wrestlerNumber + "PositionChange", m_position);
		}
	}

	string m_name;
	public string WrestlerName
	{
		get { return m_name; }
		set
		{
			m_name = value;
			gameObject.name = value;
			GameManager.Instance.Messenger.SendMessage(this, "OnWrestler" + m_wrestlerNumber + "NameChange", m_name);
		}
	}

    float m_currentStamina = 0f;
    public float CurrentStamina
    {
        get { return m_currentStamina; }
        set
        {
            m_currentStamina = value;
            GameManager.Instance.Messenger.SendMessage(this, "OnWrestler" + m_wrestlerNumber + "StaminaChange", m_currentStamina);
        }
    }

	List<WrestlingMove> m_moves;
	public List<WrestlingMove> Moves {
		get { return m_moves; }
	}

	void Awake() {
		m_moves = new List<WrestlingMove> ();
	}

    public void InitializeData(WrestlerData data) {
        WrestlerName = data.wrestlerName;
        m_athleticism = data.athleticism;
        m_charisma = data.charisma;
        m_strength = data.strength;
        m_technique = data.technique;
        m_selling = data.selling;
        m_stamina = data.stamina;

		m_moves.Clear ();
		foreach (WrestlingMoveData move in data.moves) {
			WrestlingMove newMove = new WrestlingMove();
			newMove.InitializeData (move);
			m_moves.Add (newMove);
		}
		if (m_moves.Count == 0) {
			WrestlingMoveData[] allMoves = Resources.LoadAll<WrestlingMoveData> ("Moves");
			foreach (WrestlingMoveData move in allMoves) {
				WrestlingMove newMove = new WrestlingMove();
				newMove.InitializeData (move);
				m_moves.Add (newMove);
			}
		}

		m_position = WrestlerPosition.Standing;
    }

    public void StartMatch(int wrestlerNumber) {
        m_wrestlerNumber = wrestlerNumber;

        CurrentStamina = 100f;
		WrestlerName = WrestlerName;	// Used to trigger a UI refresh.
		Position = WrestlerPosition.Standing;
    }

	public List<WrestlingMove> GetMoves(WrestlingMatch match, Wrestler opponent) {
		List<WrestlingMove> moves = new List<WrestlingMove> ();

		foreach (WrestlingMove move in m_moves) {
			if (move.PrerequisiteEvaluators == null || move.PrerequisiteEvaluators.Length == 0) {
				Debug.LogError (string.Format ("Move {0} has no prerequisite evaluators", move.MoveName));
				continue;
			}

			bool isValid = true;
			foreach (MovePrerequisite prereq in move.PrerequisiteEvaluators) {
				if (!prereq.IsValid(match, this, opponent, move)) {
					isValid = false;
					break;
				}
			}

			// Ignore reversal moves.
			if (move.IsReversalOnly) {
				isValid = false;
			}

			if (isValid) {
				moves.Add (move);
			}
		}

		// Load reversals.
		MatchTurn lastTurn = match.GetOpponentLastTurn(this);
		if (lastTurn != null && lastTurn.Move.ReversalOptions != null) {
			foreach (WrestlingMove move in lastTurn.Move.ReversalOptions) {
				moves.Add (move);
			}
		}

		return moves;
	}
}
