using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public StateManager stateManager;

    public Text guyDialogue;

    void Start() {
        
    }

    void Update() {
        
    }

    public void noKnowledgeEnd() {
        guyDialogue.text = "Um... uh...";

        stateManager.endGame();
    }
}
