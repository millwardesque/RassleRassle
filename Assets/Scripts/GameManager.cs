using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	Commentary m_commentary;
	public Commentary MatchCommentary {
		get { return m_commentary; }
	}

	Crowd m_crowd;
	public Crowd MatchCrowd {
		get { return m_crowd; }
	}

	WrestlingMatch m_match;
	public WrestlingMatch Match {
		get { return m_match; }
	}

    public WrestlerData wrestler1;
    public WrestlerData wrestler2;
    public Wrestler wrestlerPrefab;

    MessageManager m_messenger;
    public MessageManager Messenger
    {
        get { return m_messenger; }
    }

    public static GameManager Instance = null;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            m_messenger = new MessageManager();
			m_crowd = GetComponent<Crowd> ();
			m_commentary = GetComponent<Commentary> ();
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        Wrestler matchWrestler1 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
		matchWrestler1.InitializeData(wrestler1);

		Wrestler matchWrestler2 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
		matchWrestler2.InitializeData(wrestler2);

		m_match = new WrestlingMatch (matchWrestler1, matchWrestler2);
		m_match.StartMatch ();
    }

    private void Update() {
		if (Input.GetKeyDown (KeyCode.M)) {
			m_match.RunTurn (new MatchTurn (m_match, m_match.Wrestler1, m_match.Wrestler2, m_match.Wrestler1.Moves [0], m_match.Wrestler2.Moves [0]));
		}
    }

	public void OnSubmitTurn() {
		m_match.SetNextTurn ();
	}
}
