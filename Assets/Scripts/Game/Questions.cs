using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Questions {

    private HashSet<string> allQuestions;
    private HashSet<string> askedQuestions;
    private HashSet<string> badQuestions;

    public Questions() {
        askedQuestions = new HashSet<string>();
        allQuestions = new HashSet<string>();
        badQuestions = new HashSet<string>();

        allQuestions.Add("What do you like doing with your free time?");
        allQuestions.Add("Watched any cool movies lately?");
        allQuestions.Add("Do you have any pets?");
        allQuestions.Add("Have you traveled anywhere interesting?");
        allQuestions.Add("Are you a morning person?");
        allQuestions.Add("Are you interested in outdoor activities?");
        allQuestions.Add("What's your favorite book?");
        allQuestions.Add("Have you ever met anyone famous?");
        allQuestions.Add("Do you happen to have a favorite cocktail?");
        allQuestions.Add("What's your favorite beverage?");
        allQuestions.Add("Alright, what's your favorite item on the Taco Bell menu?");
        allQuestions.Add("Do you have a dream job?");
        allQuestions.Add("Who's your favorite author?");
        allQuestions.Add("What's your favorite TV show?");
        allQuestions.Add("What's your favorite song?");
        allQuestions.Add("Who's your favorite band?");
        allQuestions.Add("What's your proudest achievement?");
        allQuestions.Add("Is there anywhere you'd really like to travel?");
        allQuestions.Add("What do you do for work?");
        allQuestions.Add("What's your toxic trait?");
        allQuestions.Add("Do you play any video games?");
        allQuestions.Add("Are you on social media a lot?");
        allQuestions.Add("Where are you from?");
        allQuestions.Add("Do you have a favorite animal?");
        allQuestions.Add("What's your biggest fear?");
        allQuestions.Add("What's the strangest place you've been?");
        allQuestions.Add("Do you like working in a team?");
        allQuestions.Add("Is there anything you want to get into?");
        allQuestions.Add("How'd you meet your best friend?");
        allQuestions.Add("What's needlessly expensive but worth the money?");
        allQuestions.Add("Would you want to be famous?");
        allQuestions.Add("Who's your favorite actor?");
        allQuestions.Add("What's your favorite food?");
        allQuestions.Add("What's an interest you're kind of embarrassed to admit?");
        allQuestions.Add("What's your favorite band name?");
        allQuestions.Add("What's the worst job you've had?");
        allQuestions.Add("What do you go to school for?");
        allQuestions.Add("Do you want to learn any other languages?");
        allQuestions.Add("Do you have a favorite poem?");
        allQuestions.Add("How often do you play sports?");
        allQuestions.Add("What's the most interesting piece of art you've seen?");
        allQuestions.Add("Do you like the rain?");

        badQuestions.Add("So, what's your name?");
        badQuestions.Add("Why are you still single?");
        badQuestions.Add("Are you seeing anyone else?");
        badQuestions.Add("Do you want to have kids?");
        badQuestions.Add("Are you an alcoholic?");
        badQuestions.Add("Why'd your last relationship end?");
        badQuestions.Add("How much money do you make?");
        badQuestions.Add("How do you feel about marriage?");
        badQuestions.Add("How old are you?");
        badQuestions.Add("How much do you weigh?");
        badQuestions.Add("How tall are you?");
        badQuestions.Add("So do you do this often?");
        badQuestions.Add("Are you afraid of commitment?");
        badQuestions.Add("Be honest, do you think I'm ugly?");
    }

    public void AddAskedQuestion(string q) {
        allQuestions.Remove(q);
        askedQuestions.Add(q);
    }

    public bool IsQuestionAsked(string q) {
        return askedQuestions.Contains(q);
    }

    public List<string> getQuestions() {
        return allQuestions.ToList();
    }

    public List<string> getAskedQuestions() {
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
