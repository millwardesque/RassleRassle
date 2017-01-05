using UnityEngine;
using System.Collections;

public class MatchScorer : MonoBehaviour
{
	public float matchLengthScoreMultiplier = 1f;
	public float crowdInterestMultiplier = 1f;

	public int CalculateScore(WrestlingMatch match, Crowd crowd) {
		return Mathf.RoundToInt(CalculateMatchLengthScore(match, crowd) + CalculateCrowdInterestScore(match, crowd));
	}

	public int CalculateMatchLengthScore(WrestlingMatch match, Crowd crowd) {
		float matchLengthDelta = Mathf.Abs((float)crowd.idealMatchLength - (float)match.Turns.Count) / (float)crowd.idealMatchLength;

		float matchLengthScore = matchLengthScoreMultiplier * Mathf.Clamp01(1f - matchLengthDelta);
		return Mathf.RoundToInt (matchLengthScore);
	}

	public int CalculateCrowdInterestScore(WrestlingMatch match, Crowd crowd) {
		float crowdInterestScore = crowdInterestMultiplier * crowd.CrowdInterest;
		return Mathf.RoundToInt (crowdInterestScore);
	}
}
