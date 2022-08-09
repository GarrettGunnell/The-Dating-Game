using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GoodQuestion", menuName = "ScriptableObjects/GoodQuestion")]
public class GoodQuestion:QuestionData
{
    [Serializable]
    public class AnswerData
    {
        [SerializeField] public string sentence;
        [SerializeField] public Knowledge knowledge;

        public string Sentence => sentence;
        public Knowledge Knowlegde => knowledge;
    }

    [Serializable]
    public class Knowledge
    {
        [SerializeField] public string correct;
        [SerializeField] public string incorrectKnowledge;
        [SerializeField] public string talkReponse;

        public string TalkResponse => talkReponse;
        public string Correct => correct;
        public string IncorrectKnowledge => incorrectKnowledge;
    }


    [SerializeField] public AnswerData[] answer;

}
