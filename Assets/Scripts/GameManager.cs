using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    float m_crowdInterest = 0f;
    public float CrowdInterest
    {
        get { return m_crowdInterest; }
        set
        {
            float oldInterest = m_crowdInterest;
            m_crowdInterest = value; ;
            Messenger.SendMessage(this, "OnCrowdInterestChange", (object)m_crowdInterest);

            if (m_crowdInterest > 5f && oldInterest <= 5f) {
                Messenger.SendMessage(this, "OnCrowdExcitedChange", "Yes");
            }
        }
    }

    float m_matchOffense = 0f;
    public float MatchOffense
    {
        get { return m_matchOffense; }
        set
        {
            m_matchOffense = value; ;
            Messenger.SendMessage(this, "OnOffenseChange", (object)m_matchOffense);
        }
    }

    Wrestler m_wrestler1;
    Wrestler m_wrestler2;

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
        } else {
            Destroy(this.gameObject);
        }
    }

    private void Start() {
        m_wrestler1 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
        m_wrestler1.InitializeData(wrestler1);

        m_wrestler2 = GameObject.Instantiate<Wrestler>(wrestlerPrefab);
        m_wrestler2.InitializeData(wrestler2);

        CrowdInterest = 0f;
        MatchOffense = 0f;
        m_wrestler1.StartMatch(1);
        m_wrestler2.StartMatch(2);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            CrowdInterest += 1.0f;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)) {
            CrowdInterest -= 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            MatchOffense += 1.0f;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            MatchOffense -= 1.0f;
        }
    }
}
