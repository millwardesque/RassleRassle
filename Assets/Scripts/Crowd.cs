using UnityEngine;
using System.Collections;

public class Crowd : MonoBehaviour {
    float m_crowdInterest = 0f;
    public float CrowdInterest
    {
        get { return m_crowdInterest; }
        set
        {
            float oldInterest = m_crowdInterest;
            m_crowdInterest = value; ;
            GameManager.Instance.Messenger.SendMessage(this, "OnCrowdInterestChange", (object)m_crowdInterest);

            if (IsExcited() && !WouldBeExcited(oldInterest)) {
                GameManager.Instance.Messenger.SendMessage(this, "OnCrowdExcitedChange", "Yes");
            }
        }
    }

    public string crowdLocation;
    public int idealMatchLength;
    public float interestDecay = 0f;
    public float minExcitementThreshold = 5f;

    public bool IsExcited() {
        return WouldBeExcited(m_crowdInterest);
    }

    public bool WouldBeExcited(float interest) {
        return interest >= minExcitementThreshold;
    }

    public void ResetCrowd() {
        m_crowdInterest = 0f;
    }

    public void InitializeData(CrowdData data) {
        idealMatchLength = data.idealMatchLength;
        interestDecay = data.interestDecay;
        minExcitementThreshold = data.minExcitementThreshold;
        crowdLocation = data.crowdLocation;

		CrowdInterest = 0f;
    }
}

