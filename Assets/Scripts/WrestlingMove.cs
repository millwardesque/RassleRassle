using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrestlingMove {
    string m_name;
    public string MoveName
    {
        get { return m_name; }
		set { m_name = value; }
    }

    float m_staminaChange;
	public float StaminaChange {
		get { return m_staminaChange; }
	}

    float m_crowdChange;
	public float CrowdChange {
		get { return m_crowdChange; }
	}

    bool m_isOffensive;
	public bool IsOffensive {
		get { return m_isOffensive; }
	}

	WrestlerPosition m_startingPosition;
	public WrestlerPosition StartingPosition {
		get { return m_startingPosition; }
		set { m_startingPosition = value; }
	}

	WrestlerPosition m_opponentStartingPosition;
	public WrestlerPosition OpponentStartingPosition {
		get { return m_opponentStartingPosition; }
		set { m_opponentStartingPosition = value; }
	}

	WrestlerPosition m_endingPosition;
	public WrestlerPosition EndingPosition {
		get { return m_endingPosition; }
		set { m_endingPosition = value; }
	}

	WrestlerPosition m_opponentEndingPosition;
	public WrestlerPosition OpponentEndingPosition {
		get { return m_opponentEndingPosition; }
		set { m_opponentEndingPosition = value; }
	}

	MovePrerequisite[] m_prerequisiteEvaluators;
	public MovePrerequisite[] PrerequisiteEvaluators {
		get { return m_prerequisiteEvaluators; }
		set { m_prerequisiteEvaluators = value; }
	}

    public void InitializeData(WrestlingMoveData data) {
        MoveName = data.moveName;
        m_staminaChange = data.staminaChange;
        m_crowdChange = data.crowdChange;
		m_isOffensive = data.isOffensive;

		m_startingPosition = data.startingPosition;
		m_opponentStartingPosition = data.opponentStartingPosition;
		m_endingPosition = data.endingPosition;
		m_opponentEndingPosition = data.opponentEndingPosition;
		m_prerequisiteEvaluators = data.prerequisiteEvaluators;
    }
}
