using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public StateManager stateManager;
    public UI uiManager;

    public Text guyDialogue;
    public Text girlDialogue;

    public Animator girlAnimator;

    public Text option1;
    public Text option2;
    public Text option3;
    public Text option4;
    public Text option5;
    public Text option6;
    public Text option7;
    public Text option8;

    public AudioClip girlSound;
    public AudioClip guySound;
    public AudioSource audioSource;

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
        optionTextBoxes.Add(option7);
        optionTextBoxes.Add(option8);

        optionBoxFinished = new List<bool>();

        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        StartCoroutine(introDialogue());
    }

    void Update() {
        if (populatingOptions) {
            if (!optionBoxFinished.Any(x => x == false)) {
                populatingOptions = false;
                stateManager.setIdle(true);
            }
        }
    }

    public void endGame(string guySentence, string girlSentence, string endReason) {
        StartCoroutine(badEnd(guySentence, girlSentence, endReason));
    }

    private IEnumerator badEnd(string guySentence, string girlSentence, string endReason) {
        yield return new WaitForSecondsRealtime(0.2f);
        guyDialogue.text = "";
        audioSource.clip = guySound;
        audioSource.Play();
        foreach (char letter in guySentence.ToCharArray()) {
            guyDialogue.text += letter;
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        audioSource.Stop();
        yield return new WaitForSecondsRealtime(1.0f);
        girlDialogue.text = "";
        girlAnimator.SetBool("upset", true);
        audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("upset", false);
        audioSource.Stop();
        yield return new WaitForSecondsRealtime(1.0f);
        stateManager.endGame(false, endReason);
    }

    public void populateOptions(List<OptionsManager.Option> options) {
        uiManager.disableTalk();
        uiManager.disableLeave();
        uiManager.enableBoxes(options.Count);
        optionBoxFinished = Enumerable.Repeat(false, options.Count).ToList();

        for (int i = 0; i < options.Count; ++i) {
            Text box = optionTextBoxes[i];
            StartCoroutine(FillOption(box, options[i].option, i));
        }

        populatingOptions = true;
    }

    public void Converse(string guySentence, string girlSentence) {
        uiManager.disableBoxes(8);
        StartCoroutine(StartConversation(guySentence, girlSentence));
    }

    private void Reset() {
        stateManager.setIdle(true);
        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();
        uiManager.enableTalk();
        uiManager.enableLeave();
        uiManager.disableBoxes(8);
        uiManager.incrementTime();
    }

    public void EmptyOptions() {
        foreach (Text box in optionTextBoxes) {
            box.text = "";
        }
    }

    private float waitTime(char letter) {
        return 0.0f;
        switch(letter) {
            case '.':
                return 0.75f;
            case ',':
                return 0.5f;
            case '!':
                return 1.0f;
            case '?':
                return 0.75f;
            case '\n':
                return 0.2f;
            default:
                return 0.05f;
        }
    }

    IEnumerator StartConversation(string guySentence, string girlSentence) {
        yield return new WaitForSecondsRealtime(0.2f);

        guyDialogue.text = "";
        audioSource.clip = guySound;
        audioSource.Play();
        foreach (char letter in guySentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            guyDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        audioSource.Stop();
        yield return new WaitForSecondsRealtime(0.5f);

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
        audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();
        yield return new WaitForSecondsRealtime(1.0f);
        Reset();
    }

    IEnumerator FillOption(Text optionBox, string optionText, int optionNum) {
        optionBox.text = "";
        float fillTime = 1.0f / optionText.Length;
        foreach (char letter in optionText.ToCharArray()) {
            optionBox.text += letter;
            yield return new WaitForSecondsRealtime(fillTime);
        }

        optionBoxFinished[optionNum] = true;
    }

    public void Leave() {
        uiManager.disableTalk();
        uiManager.disableLeave();
        StartCoroutine(LeaveConvo());
    }

    private IEnumerator LeaveConvo() {
        string yourSentence = "Alright, I think I'm going to leave.";
        string girlSentence = "Oh... okay.";

        yield return new WaitForSecondsRealtime(0.2f);
        guyDialogue.text = "";
        audioSource.clip = guySound;
        audioSource.Play();
        foreach (char letter in yourSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            guyDialogue.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }

        yield return new WaitForSecondsRealtime(1.0f);

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
            audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();
        yield return new WaitForSecondsRealtime(2.0f);
        Application.Quit();
    }

    public void Win() {
        uiManager.disableTalk();
        uiManager.disableLeave();
        StartCoroutine(WinConvo());
    }

    private IEnumerator WinConvo() {
        string girlSentence = "Well, the restaurant is about to close. We should probably get going..";

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
            audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();
        yield return new WaitForSecondsRealtime(1.0f);

        string girlSentence2 = "I had a great time! We should do this again.";

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
            audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence2.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();

        yield return new WaitForSecondsRealtime(1.0f);
        stateManager.endGame(true, "Victory!");
    }

    private IEnumerator introDialogue() {
        yield return new WaitForSecondsRealtime(1.0f);
        string girlSentence = "Hey! Thanks for coming.";

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
            audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();
        yield return new WaitForSecondsRealtime(1.0f);

        string girlSentence2 = "This place closes at 08:00, so we can talk until then.";

        girlDialogue.text = "";
        girlAnimator.SetBool("talking", true);
            audioSource.clip = girlSound;
        audioSource.Play();
        foreach (char letter in girlSentence2.ToCharArray()) {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?') {
                audioSource.Play();
                audioSource.Stop();
            } else {
                audioSource.Play();
            }
            girlDialogue.text += letter;
            yield return new WaitForSecondsRealtime(waitTime(letter));
        }

        girlAnimator.SetBool("talking", false);
        audioSource.Stop();

        yield return new WaitForSecondsRealtime(1.0f);
        stateManager.setIdle(true);
        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();
        uiManager.enableTalk();
        uiManager.enableLeave();
        uiManager.disableBoxes(8);
    }
}
