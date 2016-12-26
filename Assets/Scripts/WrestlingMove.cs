using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrestlingMove : MonoBehaviour {
    string m_name;
    public string MoveName
    {
        get { return m_name; }
        set
        {
            m_name = value;
            gameObject.name = value;
        }
    }

    float m_staminaChange;
    float m_crowdChange;
    bool m_isOffensive;

    public void InitializeData(WrestlingMoveData data) {
        MoveName = data.moveName;
        m_staminaChange = data.staminaChange;
        m_crowdChange = data.crowdChange;
    }
}
