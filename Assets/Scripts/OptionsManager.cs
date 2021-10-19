using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;
    public Girl girl;

    private Knowledge knowledge;
    private Questions questions;

    private List<string> currentOptions;
    private List<string> displayedKnowledge = null;
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
        (currentOptions, displayedKnowledge, correctOption) = knowledge.generateTalkingPoints();

        if (currentOptions.Count == 0) {
            dialogueManager.noKnowledgeEnd();
            return;
        }

        //Debug.Log(correctOption);

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
            if (questions.IsQuestionAsked(sentence)) {
                string response = "You already asked me that...";

                dialogueManager.Converse(sentence, response);
            } else {
                List<string> response = girl.GetQuestionResponse(sentence);

                if (response[1] == null) {
                    dialogueManager.endGame(response[0]);
                    return;
                }

                knowledge.gainKnowledge(response[1]);
                questions.AddAskedQuestion(sentence);

                dialogueManager.Converse(sentence, response[0]);
            }
        } else {
            string response;
            string pickedKnowledge = displayedKnowledge[n];
            if (n != correctOption) {

                if (knowledge.hasBeenTalkedAbout(pickedKnowledge))
                    response = "We already talked about that...";
                else
                    response = "When did I say that?";
            } else {
                response = girl.GetTalkResponse(pickedKnowledge);
                knowledge.addTalkedAbout(pickedKnowledge);
            }

            dialogueManager.Converse(sentence, response);
        }
    }

    public string getOption(int n) {
        return currentOptions[n];
    }
}
