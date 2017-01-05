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

	MatchScorer m_scorer;
	public MatchScorer Scorer {
		get { return m_scorer; }
	}

    public CrowdData crowdData;
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
			m_scorer = GetComponent<MatchScorer> ();
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
		RestartGame ();
    }

	public void RestartGame() {
		m_crowd.InitializeData(crowdData);

		Wrestler matchWrestler1 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
		matchWrestler1.InitializeData(wrestler1);

		Wrestler matchWrestler2 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
		matchWrestler2.InitializeData(wrestler2);

		m_match = new WrestlingMatch (matchWrestler1, matchWrestler2);
		m_match.StartMatch ();
	}
}
