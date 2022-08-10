using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Questions {

    private HashSet<string> allQuestions;
    private HashSet<string> askedQuestions;
    private HashSet<string> badQuestions;

    public Questions(GoodQuestion[] good, QuestionData[] bad = null) {
        askedQuestions = new HashSet<string>();
        allQuestions = new HashSet<string>();
        badQuestions = new HashSet<string>();
        foreach (var q in good)
        {
            allQuestions.Add(q.Sentence);
        }

        foreach (var b in bad)
        {
            badQuestions.Add(b.Sentence);
        }
        

    }

    public void AddAskedQuestion(string q) {
        allQuestions.Remove(q);
        askedQuestions.Add(q);
    }

    public bool IsQuestionAsked(string q) {
        return askedQuestions.Contains(q);
    }

    public List<string> GetQuestions() {
        return allQuestions.ToList();
    }

    public List<string> GetAskedQuestions() {
        return askedQuestions.ToList();
    }

    public bool IsQuestion(string q) {
        return allQuestions.Contains(q) || askedQuestions.Contains(q) || badQuestions.Contains(q);
    }

    public bool IsBadQuestion(string q) {
        return badQuestions.Contains(q);
    }

    public List<string> getBadQuestions() {
        return badQuestions.ToList();
    }
}
