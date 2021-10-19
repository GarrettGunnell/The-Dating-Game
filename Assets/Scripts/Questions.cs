using System.Collections;
using System.Collections.Generic;

public class Questions {

    private HashSet<string> allQuestions;
    private HashSet<string> askedQuestions;

    public Questions() {
        askedQuestions = new HashSet<string>();
        allQuestions = new HashSet<string>();

        allQuestions.Add("So, what's your name?");
        allQuestions.Add("What do you like doing with your free time?");
        allQuestions.Add("Watched any cool movies lately?");
        allQuestions.Add("Do you have any pets?");
        allQuestions.Add("Have you traveled anywhere interesting?");
        allQuestions.Add("Are you a morning person?");
    }

    public void AddAskedQuestion(string q) {
        askedQuestions.Add(q);
    }

    public bool IsQuestionAsked(string q) {
        return askedQuestions.Contains(q);
    }

    public List<string> generateQuestions() {
        List<string> qs = new List<string>();

        qs.Add("What's your name?");
        qs.Add("What do you like to do in your free time?");
        qs.Add("What's a movie you really enjoyed?");
        qs.Add("Do you have any pets?");
        qs.Add("Have you ever been out of the country?");
        qs.Add("Are you a morning person?");

        return qs;
    }
}
