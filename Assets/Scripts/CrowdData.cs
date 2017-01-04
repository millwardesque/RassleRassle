using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crowd", menuName = "Game Data/Crowd")]
public class CrowdData : ScriptableObject {
    public string crowdLocation;
    public int idealMatchLength = 20;
    public float interestDecay = 0f;
    public float minExcitementThreshold = 10f;
}
