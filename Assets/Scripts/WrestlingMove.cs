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

    public void InitializeData(WrestlingMoveData data) {
        MoveName = data.moveName;
        m_staminaChange = data.staminaChange;
        m_crowdChange = data.crowdChange;
		m_isOffensive = data.isOffensive;
    }
}
