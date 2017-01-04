using UnityEngine;
using System.Collections;

public abstract class MovePostProcessor : ScriptableObject
{
	public abstract void PostProcess (WrestlingMatch match, Wrestler performer, Wrestler opponent, WrestlingMove move);
}
