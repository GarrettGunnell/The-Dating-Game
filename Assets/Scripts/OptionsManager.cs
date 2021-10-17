using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;

    private Knowledge knowledge;
    private Questions questions;

    void Start() {
        knowledge = new Knowledge();
        questions = new Questions();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Talk() {
        string t = knowledge.generateTalkingPoint();

        if (t == null)
            dialogueManager.noKnowledgeEnd();
    }

    public void Ask() {
        List<string> qs = questions.generateQuestions();

        dialogueManager.populateOptions(qs);
    }
}
