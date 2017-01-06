using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum WrestlingMoveCategory {
	None,
	Offensive,
	Defensive,
	Transitional,
	Pinning
};

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

	WrestlingMoveCategory m_category = WrestlingMoveCategory.None;
	public WrestlingMoveCategory Category {
		get { return m_category; }
		set { m_category = value; }
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

	MovePostProcessor m_postProcessor;
	public MovePostProcessor PostProcessor {
		get { return m_postProcessor; }
		set { m_postProcessor = value; }
	}

	bool m_isReversalOnly;
	public bool IsReversalOnly {
		get { return m_isReversalOnly; }
		set { m_isReversalOnly = value; }
	}

	WrestlingMove[] m_reversalOptions;
	public WrestlingMove[] ReversalOptions {
		get { return m_reversalOptions; }
	}

    public void InitializeData(WrestlingMoveData data) {
        MoveName = data.moveName;
        m_staminaChange = data.staminaChange;
        m_crowdChange = data.crowdChange;
		m_isOffensive = data.isOffensive;

		Category = data.category;
		m_startingPosition = data.startingPosition;
		m_opponentStartingPosition = data.opponentStartingPosition;
		m_endingPosition = data.endingPosition;
		m_opponentEndingPosition = data.opponentEndingPosition;
		m_prerequisiteEvaluators = data.prerequisiteEvaluators;
		m_postProcessor = data.postProcessor;

		IsReversalOnly = data.isReversalOnly;
		if (data.reversalOptions != null && data.reversalOptions.Length > 0) {
			m_reversalOptions = new WrestlingMove[data.reversalOptions.Length];
			for (int i = 0; i < data.reversalOptions.Length; ++i) {
				m_reversalOptions [i] = new WrestlingMove ();
				m_reversalOptions [i].InitializeData(data.reversalOptions [i]);
			}
		}
    }
}
