using UnityEngine;
using System.Collections;

public abstract class MovePrerequisite : ScriptableObject
{
	public abstract bool IsValid (WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move);
}
