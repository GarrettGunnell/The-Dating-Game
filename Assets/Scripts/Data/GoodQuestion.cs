using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GoodQuestion", menuName = "ScriptableObjects/GoodQuestion")]
public class GoodQuestion:QuestionData
{
    [Serializable]
    public class AnswerData
    {
        [SerializeField] private string sentence;
        [SerializeField] private Knowledge knowledge;

        public string Sentence => sentence;
        public Knowledge Knowlegde => knowledge;
    }

    [Serializable]
    public class Knowledge
    {
        [SerializeField] private string correct;
        [SerializeField] private string incorrectKnowledge;
        [SerializeField] private string talkReponse;
        [SerializeField] private string question;

        public string TalkResponse => talkReponse;
        public string Correct => correct;
        public string IncorrectKnowledge => incorrectKnowledge;
        public string Question => question;
    }


    [SerializeField] private AnswerData[] answer;
    public AnswerData[] Answer =>answer;

}
