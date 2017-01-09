using UnityEngine;
using System.Collections;

public class Commentary : MonoBehaviour
{
	public void AddMessage(string message) {
		GameManager.Instance.Messenger.SendMessage (this, "CommentaryMessage", message);
		Debug.Log ("Commentary: " + message);
	}
}

