using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;
    public Girl girl;

    private Knowledge knowledge;
    private Questions questions;

    private List<string> currentOptions;
    private int correctOption = 0;

    void Start() {
        knowledge = new Knowledge(girl.girlName);
        questions = new Questions();
        currentOptions = new List<string>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Talk() {
        (currentOptions, correctOption) = knowledge.generateTalkingPoints();

        if (currentOptions.Count == 0) {
            dialogueManager.noKnowledgeEnd();
            return;
        }

        Debug.Log(correctOption);

        dialogueManager.populateOptions(currentOptions);
    }

    public void Ask() {
        currentOptions = questions.generateQuestions();

        dialogueManager.populateOptions(currentOptions);
    }

    public void Choose(int n, bool asking) {
        dialogueManager.EmptyOptions();
        string sentence = currentOptions[n];

        if (asking) {
            List<string> response = girl.GetQuestionResponse(sentence);

            if (response[1] == null) {
                dialogueManager.endGame(response[0]);
                return;
            }

            knowledge.gainKnowledge(response[1]);

            dialogueManager.Converse(sentence, response[0]);
        } else {
            string response;
            if (n != correctOption)
                response = "When did I say that?";
            else
                response = girl.GetTalkResponse(sentence);

            dialogueManager.Converse(sentence, response);
        }
    }

    public string getOption(int n) {
        return currentOptions[n];
    }
}
