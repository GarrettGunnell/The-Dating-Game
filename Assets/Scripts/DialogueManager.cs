using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public StateManager stateManager;

    public Text guyDialogue;
    public Text girlDialogue;

    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public Text option5;
    public Text option6;

    private List<Text> optionTextBoxes = null;

    void Start() {
        optionTextBoxes = new List<Text>();
        optionTextBoxes.Add(option1);
        optionTextBoxes.Add(option2);
        optionTextBoxes.Add(option3);
        optionTextBoxes.Add(option4);
        optionTextBoxes.Add(option5);
        optionTextBoxes.Add(option6);

        guyDialogue.text = "";
        girlDialogue.text = "";
        foreach (Text box in optionTextBoxes) {
            box.text = "";
        }
    }

    void Update() {
        
    }

    public void noKnowledgeEnd() {
        StartCoroutine(TypeSentence(guyDialogue, "Um... uh..."));

        stateManager.endGame();
    }

    public void populateOptions(List<string> options) {
        for (int i = 0; i < options.Count; ++i) {
            Text box = optionTextBoxes[i];
            StartCoroutine(TypeSentence(box, options[i]));
        }
    }

    public void Converse(string guySentence, string girlSentence) {
        StartCoroutine(TypeSentence(guyDialogue, guySentence));
        StartCoroutine(TypeSentence(girlDialogue, girlSentence));
    }

    IEnumerator TypeSentence(Text box, string sentence) {
        box.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            box.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }

}
