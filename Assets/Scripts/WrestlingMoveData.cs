using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName ="Game Data/Move")]
public class WrestlingMoveData : ScriptableObject {
    public string moveName;

    public float staminaChange;
    public float crowdChange;
    public bool isOffensive;

	public bool changePerformerEndingPosition;
	public WrestlerPosition performerEndingPosition;

	public bool changeRecipientEndingPosition;
	public WrestlerPosition recipientEndingPosition;
}
