using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;
    public Girl girl;

    private Knowledge knowledge;
    private Questions questions;

    private List<string> currentOptions;

    void Start() {
        knowledge = new Knowledge();
        questions = new Questions();
        currentOptions = new List<string>();
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
        currentOptions = questions.generateQuestions();

        dialogueManager.populateOptions(currentOptions);
    }

    public void Choose(int n) {
        dialogueManager.EmptyOptions();
        string sentence = currentOptions[n];

        string response = girl.GetResponse(sentence);

        dialogueManager.Converse(sentence, response);
    }

    public string getOption(int n) {
        return currentOptions[n];
    }
}
