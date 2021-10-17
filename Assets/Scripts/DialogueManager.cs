using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private List<bool> optionBoxFinished;

    private bool populatingOptions = false;

    void Start() {
        optionTextBoxes = new List<Text>();
        optionTextBoxes.Add(option1);
        optionTextBoxes.Add(option2);
        optionTextBoxes.Add(option3);
        optionTextBoxes.Add(option4);
        optionTextBoxes.Add(option5);
        optionTextBoxes.Add(option6);

        optionBoxFinished = new List<bool> {false, false, false, false, false, false};

        guyDialogue.text = "";
        girlDialogue.text = "";
        foreach (Text box in optionTextBoxes) {
            box.text = "";
        }
    }

    void Update() {
        if (populatingOptions) {
            if (!optionBoxFinished.Any(x => x == false)) {
                populatingOptions = false;
                stateManager.setIdle(true);
            }
        }
    }

    public void noKnowledgeEnd() {
        StartCoroutine(TypeSentence(guyDialogue, "Um... uh..."));

        stateManager.endGame();
    }

    public void populateOptions(List<string> options) {

        for (int i = 0; i < optionBoxFinished.Count; ++i) {
            optionBoxFinished[i] = false;
        }

        for (int i = 0; i < options.Count; ++i) {
            Text box = optionTextBoxes[i];
            StartCoroutine(FillOption(box, options[i], i));
        }

        populatingOptions = true;
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

    IEnumerator FillOption(Text optionBox, string optionText, int optionNum) {
        optionBox.text = "";
        foreach (char letter in optionText.ToCharArray()) {
            optionBox.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        optionBoxFinished[optionNum] = true;
    }

}
