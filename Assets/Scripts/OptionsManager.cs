using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;

    private KnowledgeManager knowledge;

    void Start() {
        knowledge = new KnowledgeManager();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Talk() {
        Debug.Log(knowledge.generateTalkingPoint());
    }
}
