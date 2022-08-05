using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    [Serializable]
    public class CharData
    {
        [SerializeField] private char letter;
        [SerializeField] private float typeTime;

        public char Letter => letter;
        public float TypeTime => typeTime;
    }

    protected const int numberOfBoxes = 8;
    protected const string girlTalkState = "talking";
    protected const string girlUpsetState = "upset";

    [SerializeField] private StateManager stateManager;
    [SerializeField] private UI uiManager;

    [SerializeField] private Text guyDialogue;
    [SerializeField] private Text girlDialogue;

    [SerializeField] private Animator girlAnimator;
    [SerializeField] private Text[] option;
    [SerializeField] private CharData[] lettersData;
    [SerializeField] private float defaultLetterTime = 0.05f;

    [SerializeField] private AudioClip girlSound;
    [SerializeField] private AudioClip guySound;
    [SerializeField] private AudioSource audioSource;

    private List<bool> optionBoxFinished;

    private bool populatingOptions = false;

    private void Start() {

        optionBoxFinished = new List<bool>();

        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();

        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();

        StartCoroutine(IntroDialogue());
    }

    private void Update() {
        if (populatingOptions) {
            if (!optionBoxFinished.Any(x => x == false)) {
                populatingOptions = false;
                stateManager.setIdle(true);
            }
        }
    }

    public void EndGame(string guySentence, string girlSentence, string endReason) {
        StartCoroutine(BadEnd(guySentence, girlSentence, endReason));
    }

    private IEnumerator BadEnd(string guySentence, string girlSentence, string endReason) {
        yield return new WaitForSecondsRealtime(0.2f);
        yield return SayGuy(guySentence);
        yield return new WaitForSecondsRealtime(1.0f);
        yield return SayGirl(girlSentence, true);
        yield return new WaitForSecondsRealtime(1.0f);
        stateManager.endGame(false, endReason);
    }

    public void PopulateOptions(List<OptionsManager.Option> options) {
        uiManager.DisableTalk();
        uiManager.DisableLeave();
        uiManager.EnableBoxes(options.Count);
        optionBoxFinished = Enumerable.Repeat(false, options.Count).ToList();

        for (int i = 0; i < options.Count; ++i) {
            Text box = option[i];
            StartCoroutine(FillOption(box, options[i].option, i));
        }

        populatingOptions = true;
    }

    public void Converse(string guySentence, string girlSentence) {
        uiManager.DisableBoxes(numberOfBoxes);
        StartCoroutine(StartConversation(guySentence, girlSentence));
    }

    private void Reset() {
        stateManager.setIdle(true);
        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();
        uiManager.EnableTalk();
        uiManager.EnableLeave();
        uiManager.DisableBoxes(numberOfBoxes);
        uiManager.IncrementTime();
    }

    public void EmptyOptions() {
        foreach (Text box in option) {
            box.text = "";
        }
    }

    private float WaitTime(char letter) {
        var data = lettersData.FirstOrDefault(c => c.Letter == letter);
        if(data != default)
        {
            return data.TypeTime;
        }
        return defaultLetterTime;
    }

    private IEnumerator SayGirl(string sentence, bool isUpset = false)
    {
        var state = isUpset ? girlUpsetState : girlTalkState;
        girlAnimator.SetBool(state, true);
        yield return Say(girlDialogue, girlSound, sentence.ToCharArray());
        girlAnimator.SetBool(state, false);
    }

    private IEnumerator SayGuy(string sentence)
    {
        yield return Say(guyDialogue, guySound, sentence.ToCharArray());
    }

    private IEnumerator Say(Text dialog, AudioClip clip, char[] sentence)
    {
        dialog.text = "";
        audioSource.clip = clip;
        audioSource.Play();
        foreach (char letter in sentence)
        {
            if (letter == ',' || letter == '.' || letter == '\n' || letter == '!' || letter == '?')
            {
                audioSource.Play();
                audioSource.Stop();
            }
            else
            {
                audioSource.Play();
            }
            dialog.text += letter;
            yield return new WaitForSecondsRealtime(WaitTime(letter));
        }

        audioSource.Stop();
    }

    private IEnumerator StartConversation(string guySentence, string girlSentence) {
        yield return new WaitForSecondsRealtime(0.2f);

        yield return SayGuy(guySentence);
        yield return new WaitForSecondsRealtime(0.5f);

        yield return SayGirl(girlSentence);
        yield return new WaitForSecondsRealtime(1.0f);
        Reset();
    }

    private IEnumerator FillOption(Text optionBox, string optionText, int optionNum) {
        optionBox.text = "";
        float fillTime = 1.0f / optionText.Length;
        foreach (char letter in optionText.ToCharArray()) {
            optionBox.text += letter;
            yield return new WaitForSecondsRealtime(fillTime);
        }

        optionBoxFinished[optionNum] = true;
    }

    public void Leave() {
        uiManager.DisableTalk();
        uiManager.DisableLeave();
        StartCoroutine(LeaveConvo());
    }

    private IEnumerator LeaveConvo() {
        string yourSentence = "Alright, I think I'm going to leave.";
        string girlSentence = "Oh... okay.";

        yield return new WaitForSecondsRealtime(0.2f);
        yield return SayGuy(yourSentence);

        yield return new WaitForSecondsRealtime(1.0f);

        yield return SayGirl(girlSentence);
        yield return new WaitForSecondsRealtime(2.0f);
        Application.Quit();
    }

    public void Win() {
        uiManager.DisableTalk();
        uiManager.DisableLeave();
        StartCoroutine(WinConvo());
    }

    private IEnumerator WinConvo() {
        string girlSentence = "Well, the restaurant is about to close. We should probably get going..";
        yield return SayGirl(girlSentence);
        yield return new WaitForSecondsRealtime(1.0f);

        string girlSentence2 = "I had a great time! We should do this again.";
        yield return SayGirl(girlSentence2);

        yield return new WaitForSecondsRealtime(1.0f);
        stateManager.endGame(true, "Victory!");
    }

    private IEnumerator IntroDialogue() {
        yield return new WaitForSecondsRealtime(1.0f);
        string girlSentence = "Hey! Thanks for coming.";

        yield return SayGirl(girlSentence);
        yield return new WaitForSecondsRealtime(1.0f);

        string girlSentence2 = "This place closes at 08:00, so we can talk until then.";

        yield return SayGirl(girlSentence2);
        yield return new WaitForSecondsRealtime(1.0f);

        stateManager.setIdle(true);
        guyDialogue.text = "";
        girlDialogue.text = "";
        EmptyOptions();
        uiManager.EnableTalk();
        uiManager.EnableLeave();
        uiManager.DisableBoxes(numberOfBoxes);
    }
}
