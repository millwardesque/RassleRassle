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

	bool m_changePerformerEndingPosition;
	public bool ChangePerformerEndingPosition {
		get { return m_changePerformerEndingPosition; }
		set { m_changePerformerEndingPosition = value; }
	}

	WrestlerPosition m_performerEndingPosition;
	public WrestlerPosition PerformerEndingPosition {
		get { return m_performerEndingPosition; }
		set { m_performerEndingPosition = value; }
	}

	bool m_changeRecipientEndingPosition;
	public bool ChangeRecipientEndingPosition {
		get { return m_changeRecipientEndingPosition; }
		set { m_changeRecipientEndingPosition = value; }
	}

	WrestlerPosition m_recipientEndingPosition;
	public WrestlerPosition RecipientEndingPosition {
		get { return m_recipientEndingPosition; }
		set { m_recipientEndingPosition = value; }
	}

    public void InitializeData(WrestlingMoveData data) {
        MoveName = data.moveName;
        m_staminaChange = data.staminaChange;
        m_crowdChange = data.crowdChange;
		m_isOffensive = data.isOffensive;

		m_changePerformerEndingPosition = data.changePerformerEndingPosition;
		m_performerEndingPosition = data.performerEndingPosition;
		m_changeRecipientEndingPosition = data.changeRecipientEndingPosition;
		m_recipientEndingPosition = data.recipientEndingPosition;
    }
}
