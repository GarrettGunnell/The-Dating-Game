using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knowledge {
    private HashSet<string> Hobbies;
    private HashSet<string> Attributes;
    private HashSet<string> Media;
    private HashSet<string> Future;
    private HashSet<string> Accomplishments;
    private HashSet<string> Vacations;
    private HashSet<string> Pets;

    private HashSet<string> unknownKnowledge;
    private HashSet<string> knownKnowledge;
    private HashSet<string> talkedAbout;

    private Hashtable incorrectKnowledge;
    private Hashtable knowledgeResponse;

    public Knowledge() {
        talkedAbout = new HashSet<string>();

        knownKnowledge = new HashSet<string>();

        incorrectKnowledge = new Hashtable();

        incorrectKnowledge.Add("drawing", "painting");
        incorrectKnowledge.Add("YouTube", "Vimeo");
        incorrectKnowledge.Add("do", "do everything");
        incorrectKnowledge.Add("La La Land", "La La Planet");
        incorrectKnowledge.Add("The Green Knight", "The Red Knight");
        incorrectKnowledge.Add("Whiplash", "Whiptrash");
        incorrectKnowledge.Add("The Lighthouse", "The Witch");
        incorrectKnowledge.Add("two dogs", "a dog");
        incorrectKnowledge.Add("three dogs", "three cats");
        incorrectKnowledge.Add("a cat", "two cats");
        incorrectKnowledge.Add("Italy", "Spain");
        incorrectKnowledge.Add("Canada", "Portugal");
        incorrectKnowledge.Add("France", "Germany");
        incorrectKnowledge.Add("a night", "a morning");
        incorrectKnowledge.Add("a morning", "a night");
        incorrectKnowledge.Add("Pale Fire", "Gale Fire");
        incorrectKnowledge.Add("Oyasumi Punpun", "Ohayo Punpun");
        incorrectKnowledge.Add("Artemis Fowl", "Artemis Foul");
        incorrectKnowledge.Add("an indoors", "an outdoors");
        incorrectKnowledge.Add("an outdoors", "an indoors");
        incorrectKnowledge.Add("rock climbing", "hiking");
        incorrectKnowledge.Add("met Hungrybox", "met Mango");
        incorrectKnowledge.Add("met Ryan Gosling", "met Robert Pattinson");
        incorrectKnowledge.Add("vodka and water", "vodka and soda");
        incorrectKnowledge.Add("cosmopolitans", "pina coladas");
        incorrectKnowledge.Add("don't really drink", "drink a lot");
        incorrectKnowledge.Add("Baja Blast", "Baja Flash");
        incorrectKnowledge.Add("tea", "water");
        incorrectKnowledge.Add("water", "tea");
        incorrectKnowledge.Add("the naked chicken chalupa", "nacho fries");
        incorrectKnowledge.Add("be a therapist", "be a psychologist");
        incorrectKnowledge.Add("be an artist", "be a painter");
        incorrectKnowledge.Add("be a private investigator", "be a police officer");
        incorrectKnowledge.Add("be a crime lord", "be a mob boss");
        incorrectKnowledge.Add("Clive Barker", "Clive Woofer");
        incorrectKnowledge.Add("Inio Asano", "Tatsuki Fujimoto");
        incorrectKnowledge.Add("Nisioisin", "nisioisiN");
        incorrectKnowledge.Add("Breaking Bad", "Better Call Saul");
        incorrectKnowledge.Add("Hannibal", "Cannibal");
        incorrectKnowledge.Add("Spongebob", "Avatar");
        incorrectKnowledge.Add("Blue Honey", "Blue Valentine");
        incorrectKnowledge.Add("The Barrel", "Blue Honey");
        incorrectKnowledge.Add("Disorder", "The Barrel");
        incorrectKnowledge.Add("Dancing Queen", "Mamma Mia");
        incorrectKnowledge.Add("Alvvays", "Always");
        incorrectKnowledge.Add("ran a marathon", "ran a 100 meter dash");
        incorrectKnowledge.Add("have an honors diploma", "have a degree");
        incorrectKnowledge.Add("made a lot of friends", "made a few friends");
        incorrectKnowledge.Add("won the science fair", "won the spelling bee");
        incorrectKnowledge.Add("Japan", "China");
        incorrectKnowledge.Add("London", "Paris");
        incorrectKnowledge.Add("are a server", "are a bartender");
        incorrectKnowledge.Add("care too much", "don't care that much");
        incorrectKnowledge.Add("a manipulative", "a cunning");
        incorrectKnowledge.Add("a self-defeating", "a self-admiring");
        incorrectKnowledge.Add("The Dating Game", "The Hating Game");
        incorrectKnowledge.Add("Twitter", "Facebook");
        incorrectKnowledge.Add("Instagram", "Twitter");
        incorrectKnowledge.Add("not a social media", "a social media");
        incorrectKnowledge.Add("are from Seattle", "are from Portland");
        incorrectKnowledge.Add("are from Michigan", "are from New Hampshire");
        incorrectKnowledge.Add("cats", "dogs");
        incorrectKnowledge.Add("turtles", "penguins");
        incorrectKnowledge.Add("a dog", "a cat");
        incorrectKnowledge.Add("a fear of bees", "a fear of beetles");
        incorrectKnowledge.Add("a fear of abandonment", "a fear of loneliness");
        incorrectKnowledge.Add("Weed", "Hash");
        incorrectKnowledge.Add("Post", "Toast");
        incorrectKnowledge.Add("not a team", "a team");
        incorrectKnowledge.Add("a team", "not a team");
        incorrectKnowledge.Add("learn to paint", "learn to draw");
        incorrectKnowledge.Add("learn an instrument", "learn to compose");
        incorrectKnowledge.Add("learn to cook", "learn to write");
        incorrectKnowledge.Add("your best friend", "your worst friend");
        incorrectKnowledge.Add("sushi", "noodles");
        incorrectKnowledge.Add("art supplies", "textbooks");
        incorrectKnowledge.Add("don't want to be famous", "want to be famous");
        incorrectKnowledge.Add("want to be famous", "don't want to be famous");
        incorrectKnowledge.Add("Ryan Gosling", "Ryan Reynolds");
        incorrectKnowledge.Add("Jack Nicholson", "Jack Crawford");
        incorrectKnowledge.Add("Jodie Foster", "Anthony Hopkins");
        incorrectKnowledge.Add("fried rice", "white rice");
        incorrectKnowledge.Add("pasta", "donda");
        incorrectKnowledge.Add("ramen", "noodles");
        incorrectKnowledge.Add("Ludwig", "Ludwin");
        incorrectKnowledge.Add("TV On The Radio", "Radio On The TV");
        incorrectKnowledge.Add("Mars Argo", "Saturns Argo");
        incorrectKnowledge.Add("I Monster", "He, Monster");
        incorrectKnowledge.Add("Gesaffelstein", "Frankenstein");
        incorrectKnowledge.Add("worked at Spirit Halloween", "worked at Phantom Halloween");
        incorrectKnowledge.Add("interviewed at Dairy Queen", "interviewed at Diary Queen");
        incorrectKnowledge.Add("history", "english");
        incorrectKnowledge.Add("chemistry", "biology");
        incorrectKnowledge.Add("nursing", "medicine");
        incorrectKnowledge.Add("learn latin", "learn italian");
        incorrectKnowledge.Add("learn Japanese", "learn Korean");
        incorrectKnowledge.Add("learn Chinese", "learn Japanese");
        incorrectKnowledge.Add("Bonedog", "Bonecat");
        incorrectKnowledge.Add("I Go Back To May", "I Go Back To June");
        incorrectKnowledge.Add("aren't a sports person", "are a sports person");
        incorrectKnowledge.Add("soccer", "football");
        incorrectKnowledge.Add("Ivan the Terrible and His Son Ivan", "Ivan the Terrible and His Dad Ivan");
        incorrectKnowledge.Add("Saturn Devouring His Son", "Jupiter Devouring His Son");
        incorrectKnowledge.Add("the rain", "the sun");

        knowledgeResponse = new Hashtable();

        knowledgeResponse.Add("drawing", "you like drawing in your free time?");
        knowledgeResponse.Add("YouTube", "you watch YouTube in your free time?");
        knowledgeResponse.Add("do nothing", "You do nothing with your free time?");
        knowledgeResponse.Add("La La Land", "You watched La La Land?");
        knowledgeResponse.Add("Whiplash", "You watched Whiplash?");
        knowledgeResponse.Add("The Green Knight", "You saw The Green Knight?");
        knowledgeResponse.Add("The Lighthouse", "You watched The Lighthouse?");
        knowledgeResponse.Add("two dogs", "You have two dogs?");
        knowledgeResponse.Add("three dogs", "You have three dogs?");
        knowledgeResponse.Add("a cat", "You have a cat?");
        knowledgeResponse.Add("Italy", "You went to Italy?");
        knowledgeResponse.Add("Canada", "You went to Canada?");
        knowledgeResponse.Add("France", "You went to France?");
        knowledgeResponse.Add("a night", "You are a night person?");
        knowledgeResponse.Add("a morning", "You are a morning person?");
        knowledgeResponse.Add("Pale Fire", "Pale Fire is your favorite book?");
        knowledgeResponse.Add("Oyasumi Punpun", "You read Oyasumi Punpun?");
        knowledgeResponse.Add("Artemis Fowl", "Your favorite book is Artemis Fowl?");
        knowledgeResponse.Add("an indoors", "You are an indoors person?");
        knowledgeResponse.Add("an outdoors", "You are an outdoors person?");
        knowledgeResponse.Add("rock climbing", "You like going rock climbing?");
        knowledgeResponse.Add("met Hungrybox", "You met Hungrybox?");
        knowledgeResponse.Add("met Ryan Gosling", "You met Ryan Gosling?");
        knowledgeResponse.Add("vodka and water", "Your favorite drink is vodka and water?");
        knowledgeResponse.Add("cosmopolitans", "You like cosmopolitans?");
        knowledgeResponse.Add("don't really drink", "You don't really drink?");
        knowledgeResponse.Add("Baja Blast", "Your favorite beverage is Baja Blast?");
        knowledgeResponse.Add("tea", "Your favorite beverage is tea?");
        knowledgeResponse.Add("water", "Your favorite beverage is water?");
        knowledgeResponse.Add("the naked chicken chalupa", "You like the naked chicken chalupa?");
        knowledgeResponse.Add("be a therapist", "You want to be a therapist?");
        knowledgeResponse.Add("be an artist", "You want to be an artist?");
        knowledgeResponse.Add("be a private investigator", "You want to be a private investigator?");
        knowledgeResponse.Add("be a crime lord", "You want to be a crime lord?");
        knowledgeResponse.Add("Clive Barker", "Your favorite author is Clive Barker?");
        knowledgeResponse.Add("Inio Asano", "Your favorite author is Inio Asano?");
        knowledgeResponse.Add("Nisioisin", "Your favorite author is Nisioisin?");
        knowledgeResponse.Add("Breaking Bad", "Your favorite TV show is Breaking Bad?");
        knowledgeResponse.Add("Hannibal", "Your favorite TV show is Hannibal?");
        knowledgeResponse.Add("Spongebob", "Your favorite TV show is Spongebob?");
        knowledgeResponse.Add("Blue Honey", "Your favorite song is Blue Honey?");
        knowledgeResponse.Add("The Barrel", "Your favorite song is The Barrel?");
        knowledgeResponse.Add("Disorder", "Your favorite song is Disorder?");
        knowledgeResponse.Add("Dancing Queen", "Dancing Queen is your favorite song?");
        knowledgeResponse.Add("Alvvays", "Your favorite band is Alvvays?");
        knowledgeResponse.Add("ran a marathon", "You ran a marathon?");
        knowledgeResponse.Add("have an honors diploma", "You have an honors diploma?");
        knowledgeResponse.Add("made a lot of friends", "You made a lot of friends?");
        knowledgeResponse.Add("won the science fair", "You won the science fair?");
        knowledgeResponse.Add("Japan", "You want to visit Japan?");
        knowledgeResponse.Add("London", "You want to visit London?");
        knowledgeResponse.Add("are a server", "You are a server here?");
        knowledgeResponse.Add("care too much", "You care too much?");
        knowledgeResponse.Add("a manipulative", "You think you're a manipulative person?");
        knowledgeResponse.Add("a self-defeating", "You consider yourself a self-defeating person?");
        knowledgeResponse.Add("The Dating Game", "You play The Dating Game?");
        knowledgeResponse.Add("Twitter", "You spend a lot of time on Twitter?");
        knowledgeResponse.Add("Instagram", "You spend a lot of time on Instagram?");
        knowledgeResponse.Add("not a social media", "You are not a social media person?");
        knowledgeResponse.Add("are from Seattle", "You are from Seattle?");
        knowledgeResponse.Add("are from Michigan", "You are from Michigan?");
        knowledgeResponse.Add("cats", "Your favorite animal is cats?");
        knowledgeResponse.Add("turtles", "Your favorite animal is turtles?");
        knowledgeResponse.Add("a dog", "You're a dog person?");
        knowledgeResponse.Add("a fear of bees", "You have a fear of bees?");
        knowledgeResponse.Add("a fear of abandonment", "You have a fear of abandonment?");
        knowledgeResponse.Add("Weed", "You've been to Weed?");
        knowledgeResponse.Add("Post", "You've been to Post?");
        knowledgeResponse.Add("not a team", "You are not a team person?");
        knowledgeResponse.Add("a team", "You are a team person?");
        knowledgeResponse.Add("learn to paint", "You want to learn to paint?");
        knowledgeResponse.Add("learn an instrument", "You want to learn an instrument?");
        knowledgeResponse.Add("learn to cook", "You want to learn to cook?");
        knowledgeResponse.Add("your best friend", "What do you like about your best friend?");
        knowledgeResponse.Add("sushi", "sushi is expensive?");
        knowledgeResponse.Add("art supplies", "art supplies are expensive?");
        knowledgeResponse.Add("don't want to be famous", "You don't want to be famous?");
        knowledgeResponse.Add("want to be famous", "You want to be famous?");
        knowledgeResponse.Add("Ryan Gosling", "Your favorite actor is Ryan Gosling?");
        knowledgeResponse.Add("Jack Nicholson", "Your favorite actor is Jack Nicholson?");
        knowledgeResponse.Add("Jodie Foster", "Your favorite actor is Jodie Foster?");
        knowledgeResponse.Add("fried rice", "Your favorite food is fried rice?");
        knowledgeResponse.Add("pasta", "Your favorite food is pasta?");
        knowledgeResponse.Add("ramen", "Your favorite food is ramen?");
        knowledgeResponse.Add("Ludwig", "You watch Ludwig on Twitch?");
        knowledgeResponse.Add("TV On The Radio", "Your favorite band name is TV On The Radio?");
        knowledgeResponse.Add("Mars Argo", "Mars Argo is your favorite band name?");
        knowledgeResponse.Add("I Monster", "Your favorite band name is I Monster?");
        knowledgeResponse.Add("Gesaffelstein", "Your favorite band name is Gesaffelstein?");
        knowledgeResponse.Add("worked at Spirit Halloween", "You worked at Spirit Halloween?");
        knowledgeResponse.Add("interviewed at Dairy Queen", "You interviewed at Dairy Queen?");
        knowledgeResponse.Add("history", "You are going to school for history?");
        knowledgeResponse.Add("chemistry", "You are going to school for chemistry?");
        knowledgeResponse.Add("nursing", "You are going to school for nursing?");
        knowledgeResponse.Add("learn latin", "You want to learn latin?");
        knowledgeResponse.Add("learn Japanese", "You want to learn Japanese?");
        knowledgeResponse.Add("learn Chinese", "You want to learn Chinese?");
        knowledgeResponse.Add("Bonedog", "Your favorite poem is Bonedog?");
        knowledgeResponse.Add("I Go Back To May", "Your favorite poem is I Go Back To May?");
        knowledgeResponse.Add("aren't a sports person", "You aren't a sports person?");
        knowledgeResponse.Add("soccer", "You play soccer?");
        knowledgeResponse.Add("Ivan the Terrible and His Son Ivan", "Your favorite painting is Ivan the Terrible and His Son Ivan?");
        knowledgeResponse.Add("Saturn Devouring His Son", "Your favorite painting is Saturn Devouring His Son?");
        knowledgeResponse.Add("the rain", "What do you like about the rain?");
    }

    public string generateTalkingPoint(string k) {
        return (string)knowledgeResponse[k];
    }

    public string generateIncorrectTalkingPoint() {
        if (knownKnowledge.Count == 0) {
            return null;
        }

        string k = findKnowledge();
        if (!incorrectKnowledge.ContainsKey(k))
            return $"Uh oh! Stinky! There's a bug here! (This answer is wrong) (Debug: {k})";
        
        string incorrectK = (string)incorrectKnowledge[k];
        
        if (!knowledgeResponse.ContainsKey(k))
            return $"Uh oh! Stinky! There's a bug here! (This answer is wrong) (Debug: {incorrectK})";

        string correctResponse = (string)knowledgeResponse[k];

        return correctResponse.Replace(k, incorrectK);
    }

    public string findKnowledge() {
        return knownKnowledge.ElementAt(Random.Range(0, knownKnowledge.Count));
    }

    public bool isKnown(string k) {
        return knownKnowledge.Contains(k);
    }

    public void gainKnowledge(string k) {
        knownKnowledge.Add(k);
        unknownKnowledge.Remove(k);
    }

    public void addTalkedAbout(string k) {
        talkedAbout.Add(k);
        knownKnowledge.Remove(k);
    }

    public bool hasBeenTalkedAbout(string k) {
        return talkedAbout.Contains(k);
    }

    public List<string> getTalkedAbout() {
        return talkedAbout.ToList();
    }

    public int knowledgeCount() {
        return knownKnowledge.Count();
    }
}
