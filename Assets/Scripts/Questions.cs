using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Questions {

    private HashSet<string> allQuestions;
    private HashSet<string> askedQuestions;

    public Questions() {
        askedQuestions = new HashSet<string>();
        allQuestions = new HashSet<string>();

        //allQuestions.Add("So, what's your name?");
        //allQuestions.Add("What do you like doing with your free time?");
        //allQuestions.Add("Watched any cool movies lately?");
        //allQuestions.Add("Do you have any pets?");
        //allQuestions.Add("Have you traveled anywhere interesting?");
        //allQuestions.Add("Are you a morning person?");
        //allQuestions.Add("Are you interested in outdoor activities?");
        //allQuestions.Add("What's your favorite book?");
        //allQuestions.Add("Have you ever met anyone famous?");
        //allQuestions.Add("Do you happen to have a favorite cocktail?");
        //allQuestions.Add("What's your favorite beverage?");
        //allQuestions.Add("Alright, what's your favorite item on the Taco Bell menu?");
        //allQuestions.Add("Do you have a dream job?");
        //allQuestions.Add("Who's your favorite author?");
        //allQuestions.Add("What's your favorite TV show?");
        //allQuestions.Add("What's your favorite song?");
        //allQuestions.Add("Who's your favorite band?");
        //allQuestions.Add("What's your proudest achievement?");

        allQuestions.Add("Is there anywhere you'd really like to travel?");
        allQuestions.Add("What do you do for work?");
        allQuestions.Add("What's your toxic trait?");
        allQuestions.Add("Do you play any video games?");
        allQuestions.Add("Are you on social media a lot?");
        allQuestions.Add("Where are you from?");
    }

    public void AddAskedQuestion(string q) {
        allQuestions.Remove(q);
        askedQuestions.Add(q);
    }

    public bool IsQuestionAsked(string q) {
        return askedQuestions.Contains(q);
    }

    public List<string> generateQuestions() {
        List<string> qs = new List<string>();
        List<string> unaskedQuestionsList = allQuestions.ToList().OrderBy(x => Random.value).ToList();
        List<string> askedQuestionsList = askedQuestions.ToList().OrderBy(x => Random.value).ToList();

        if (askedQuestions.Count < 6) {
            int numRealQuestions = 6 - askedQuestions.Count;
            qs = unaskedQuestionsList.GetRange(0, numRealQuestions);
            for (int i = 0; i < askedQuestions.Count; ++i) {
                qs.Add(askedQuestionsList[i]);
            }
        } else {
            qs = askedQuestionsList.GetRange(0, 5);
            qs.Add(unaskedQuestionsList[0]);
        }

        return qs.OrderBy(x => Random.value).ToList();
    }
}
