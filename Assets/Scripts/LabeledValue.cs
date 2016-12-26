using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabeledValue : MonoBehaviour {
    public Text value;
    public string onChangeEventName;

    void Start() {
        GameManager.Instance.Messenger.AddListener(onChangeEventName, OnValueChange);
    }

	void OnValueChange(Message message) {
        if (message.data != null) {
            value.text = message.data.ToString();
        }
        else {
            value.text = "";
        }        
    }
}
