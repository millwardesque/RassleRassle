using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName ="Game Data/Move")]
public class WrestlingMoveData : ScriptableObject {
    public string moveName;
	public WrestlingMoveCategory category = WrestlingMoveCategory.None;

    public float staminaChange;
    public float crowdChange;
    public bool isOffensive;

	public WrestlerPosition startingPosition = WrestlerPosition.Any;
	public WrestlerPosition opponentStartingPosition = WrestlerPosition.Any;
	public WrestlerPosition endingPosition = WrestlerPosition.Same;
	public WrestlerPosition opponentEndingPosition = WrestlerPosition.Same;

	public MovePrerequisite[] prerequisiteEvaluators;
	public MovePostProcessor postProcessor;
}
