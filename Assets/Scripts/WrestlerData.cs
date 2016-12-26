using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wrestler", menuName = "Game Data/Wrestler")]
public class WrestlerData : ScriptableObject {
    public string wrestlerName;

    [Range(0f, 1f)]
    public float athleticism;

    [Range(0f, 1f)]
    public float charisma;

    [Range(0f, 1f)]
    public float strength;

    [Range(0f, 1f)]
    public float technique;

    [Range(0f, 1f)]
    public float selling;

    [Range(0f, 1f)]
    public float stamina;
}
