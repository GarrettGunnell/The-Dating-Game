using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OptionsManager : MonoBehaviour {

    public DialogueManager dialogueManager;
    public Girl girl;

    private Knowledge knowledge;
    private Questions questions;

    private List<Option> currentOptions;

    public struct Option {
        public string option;
        public string knowledge;

        public Option(string o, string k) {
            option = o;
            knowledge = k;
        }
    };

    void Start() {
        knowledge = new Knowledge();
        questions = new Questions();
        currentOptions = new List<Option>();
    }

    public void Talk(int actionNumber) {
        List<Option> options = new List<Option>();

        List<string> qs = new List<string>(questions.getQuestions());
        List<string> askedQs = new List<string>(questions.getAskedQuestions());
        List<string> talkedAbout = new List<string>(knowledge.getTalkedAbout());
        List<string> badQs = new List<string>(questions.getBadQuestions());

        qs = qs.OrderBy(x => Random.value).ToList();
        askedQs = askedQs.OrderBy(x => Random.value).ToList();
        talkedAbout = talkedAbout.OrderBy(x => Random.value).ToList();
        badQs = badQs.OrderBy(x => Random.value).ToList();

        if (actionNumber == 1) {
            string q = qs[Random.Range(0, qs.Count)];
            options.Add(new Option(q, null));
        } else if (actionNumber == 2) {
            string k = knowledge.findKnowledge();
            string r = knowledge.generateTalkingPoint(k);
            string ik = knowledge.generateIncorrectTalkingPoint();

            options.Add(new Option(r, k));
            options.Add(new Option(ik, null));
        } else if (actionNumber < 8) {
            if (Random.value < 0.85f || knowledge.knowledgeCount() == 0) {
                string q = qs[Random.Range(0, qs.Count)];
                options.Add(new Option(q, null));
            } else {
                string k = knowledge.findKnowledge();
                string r = knowledge.generateTalkingPoint(k);

                options.Add(new Option(r, k));
            }

            for (int i = 0; i < actionNumber - 1; ++i) {
                if (Random.value < 0.5f) {
                    if (talkedAbout.Count > 0) {
                        options.Add(new Option(knowledge.generateTalkingPoint(talkedAbout[0]), talkedAbout[0]));
                        talkedAbout.RemoveAt(0);
                    } else {
                        options.Add(new Option(askedQs[0], null));
                        askedQs.RemoveAt(0);
                    }
                } else {
                    if (askedQs.Count > 0) {
                        options.Add(new Option(askedQs[0], null));
                        askedQs.RemoveAt(0);
                    } else {
                        options.Add(new Option(knowledge.generateTalkingPoint(talkedAbout[0]), talkedAbout[0]));
                        talkedAbout.RemoveAt(0);
                    }
                }
            }
        } else {
            //Correct Option
            if (knowledge.knowledgeCount() == 0) {
                string q = qs[Random.Range(0, qs.Count)];
                options.Add(new Option(q, null));
            } else {
                float correctChance = Mathf.Lerp(1.0f, 0.6f, (actionNumber - 8) / 16.0f);
                if (actionNumber > 24)
                    correctChance = 0.2f;

                Debug.Log(correctChance);
                if (Random.value < correctChance) {
                    string q = qs[Random.Range(0, qs.Count)];
                    options.Add(new Option(q, null));
                } else {
                    string k = knowledge.findKnowledge();
                    string r = knowledge.generateTalkingPoint(k);

                    options.Add(new Option(r, k));
                }
            }

            //Incorrect
            while (options.Count < 8) {
                float r = Random.value;

                if (r < 0.25f) {
                    bool add = true;
                    string incorrectPoint = knowledge.generateIncorrectTalkingPoint();
                    
                    if (incorrectPoint != null) {
                        foreach (Option op in options) {
                            if (op.option == incorrectPoint) {
                                add = false;
                                break;
                            }
                        }
                        if (add)
                            options.Add(new Option(incorrectPoint, null));
                    }
                } else if (r < 0.6f) {
                    if (talkedAbout.Count > 0) {
                        options.Add(new Option(knowledge.generateTalkingPoint(talkedAbout[0]), talkedAbout[0]));
                        talkedAbout.RemoveAt(0);
                    }
                } else if (r < 0.85f) {
                    if (askedQs.Count > 0) {
                        options.Add(new Option(askedQs[0], null));
                        askedQs.RemoveAt(0);
                    }
                } else {
                    if (badQs.Count > 0) {
                        options.Add(new Option(badQs[0], null));
                        badQs.RemoveAt(0);
                    }
                }
            }

        }

        options = options.OrderBy(x => Random.value).ToList();

        currentOptions = options;
        dialogueManager.PopulateOptions(options);
    }

    public void Choose(int n) {
        dialogueManager.EmptyOptions();
        Option choice = currentOptions[n];

        if (questions.IsQuestion(choice.option)) {
            string sentence = choice.option;

            if (questions.IsQuestionAsked(sentence)) {
                dialogueManager.EndGame(sentence, "You already asked me that...", "Duplicate question");
                return;
            }

            if (questions.IsBadQuestion(sentence)) {
                dialogueManager.EndGame(sentence, "Why would you ask me that?", "Bad question");
                return;
            }

            List<string> response = girl.GetQuestionResponse(sentence);

            knowledge.gainKnowledge(response[1]);
            questions.AddAskedQuestion(sentence);

            dialogueManager.Converse(sentence, response[0]);
        } else {
            string sentence = choice.option;
            string k = choice.knowledge;

            if (knowledge.isKnown(k)) {
                string response = girl.GetTalkResponse(k);
                knowledge.addTalkedAbout(k);

                dialogueManager.Converse(sentence, response);
            } else {
                if (knowledge.hasBeenTalkedAbout(k)) {
                    dialogueManager.EndGame(sentence, "We already talked about that...", "Talked about the same thing twice.");
                } else {
                    dialogueManager.EndGame(sentence, "When did I say that?", "She never said that bro");
                }
            }
        }
    }

    public void Leave() {
        dialogueManager.Leave();
    }

    public void Win() {
        dialogueManager.Win();
    }
}
