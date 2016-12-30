using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    public void StartMatch(int wrestlerNumber) {
        m_wrestlerNumber = wrestlerNumber;

        CurrentStamina = 100f;
        WrestlerName = WrestlerName;
    }
}
