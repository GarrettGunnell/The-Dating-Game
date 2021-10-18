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
        knowledge = new Knowledge(girl.girlName);
        questions = new Questions();
        currentOptions = new List<string>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Talk() {
        List<string> points = knowledge.generateTalkingPoints();

        if (points == null) {
            dialogueManager.noKnowledgeEnd();
            return;
        }

        currentOptions = points;
        dialogueManager.populateOptions(currentOptions);
    }

    public void Ask() {
        currentOptions = questions.generateQuestions();

        dialogueManager.populateOptions(currentOptions);
    }

    public void Choose(int n, bool asking) {
        dialogueManager.EmptyOptions();
        string sentence = currentOptions[n];

        List<string> response = girl.GetResponse(sentence);

        if (response[1] == null) {
            dialogueManager.endGame(response[0]);
            return;
        }

        knowledge.gainKnowledge(response[1]);

        //Debug.Log(response[1]);

        dialogueManager.Converse(sentence, response[0]);
    }

    public string getOption(int n) {
        return currentOptions[n];
    }
}
