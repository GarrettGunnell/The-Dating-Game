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

    public void Talk() {
        (currentOptions, displayedKnowledge, correctOption) = knowledge.generateTalkingPoints();

        if (currentOptions.Count == 0) {
            dialogueManager.endGame("Um... uh...", "...", "You had nothing to talk about.");
            return;
        }

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

                dialogueManager.endGame(sentence, response, "Duplicate question");
            } else {
                List<string> response = girl.GetQuestionResponse(sentence);

                if (response[1] == null) {
                    dialogueManager.endGame(sentence, response[0], "Bad question");
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
                
                dialogueManager.endGame(sentence, response, "Incorrect talk option");
            } else {
                response = girl.GetTalkResponse(pickedKnowledge);
                knowledge.addTalkedAbout(pickedKnowledge);

                dialogueManager.Converse(sentence, response);
            }
        }
    }

    public string getOption(int n) {
        return currentOptions[n];
    }
}
