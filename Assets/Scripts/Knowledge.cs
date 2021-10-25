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

    public Knowledge() {
        talkedAbout = new HashSet<string>();

        Hobbies = new HashSet<string> {"drawing", "YouTube", "doing nothing", "soccer", "rock climbing"};
        Attributes = new HashSet<string> {"an indoors", "a night", "not a team", "a morning", "an outdoors", "a manipulative", "not a social media", "a dog",
        "a team", "a self-defeating"};
        Media = new HashSet<string> {"La La Land", "Whiplash", "The Green Knight", "The Lighthouse", "Pale Fire", "vodka and water", "Baja Blast", 
        "the naked chicken chalupa", "Clive Barker", "Breaking Bad", "Blue Honey", "Alvvays", "The Dating Game", "Twitter", "cats", "your best friend",
        "sushi", "Ryan Gosling", "fried rice", "Ludwig", "TV On The Radio", "history", "Bonedog", "Ivan the Terrible and His Son Ivan", "Oyasumi Punpun",
        "Artemis Fowl", "cosmopolitans", "tea", "water", "Inio Asano", "Nisioisin", "Hannibal", "Spongebob", "The Barrel", "Dancing Queen", "Disorder",
        "turtles", "art supplies", "Jack Nicholson", "Jodie Foster", "pasta", "ramen", "Mars Argo", "Gesaffelstein", "I Monster", "chemistry", "nursing",
        "Saturn Devouring His Son", "the rain", "I Go Back To May", "Instagram"};
        Future = new HashSet<string> {"go to Japan", "be a therapist", "learn an instrument", "learn latin", "be an artist", "be a private investigator", "be a crime lord",
        "go to London", "learn an instrument", "learn to paint", "learn to cook", "learn Japanese", "learn Chinese"};
        Accomplishments = new HashSet<string> {"ran a marathon", "met Hungrybox", "are a server", "care too much", "are from Seattle", "don't want to be famous",
        "worked at Spirit Halloween", "met Ryan Gosling", "don't really drink", "have an honors diploma", "made a lot of friends", "won the science fair",
        "are from Michigan", "want to be famous", "interviewed at Dairy Queen", "aren't a sports person"};
        Vacations = new HashSet<string> {"Italy", "Weed", "Canada", "France", "Post"};
        Pets = new HashSet<string> {"two dogs", "three dogs", "a cat", "a fear of bees", "a fear of abandonment"};

        unknownKnowledge = new HashSet<string>(Attributes);
        unknownKnowledge.UnionWith(Media);
        unknownKnowledge.UnionWith(Future);
        unknownKnowledge.UnionWith(Accomplishments);
        unknownKnowledge.UnionWith(Vacations);
        unknownKnowledge.UnionWith(Pets);

        knownKnowledge = new HashSet<string>();

        incorrectKnowledge = new Hashtable();

        incorrectKnowledge.Add("drawing", "painting");
        incorrectKnowledge.Add("YouTube", "Vimeo");
        incorrectKnowledge.Add("doing nothing", "doing everything");
        incorrectKnowledge.Add("La La Land", "La La Planet");
        incorrectKnowledge.Add("The Green Knight", "The Red Knight");
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
        incorrectKnowledge.Add("go to Japan", "go to China");
        incorrectKnowledge.Add("go to London", "go to Paris");
        incorrectKnowledge.Add("are a server", "are a bartender");
        incorrectKnowledge.Add("care too much", "don't care that much");
        incorrectKnowledge.Add("a manipulative", "a cunning");
        incorrectKnowledge.Add("a self-defeating", "a self-admiring");
        incorrectKnowledge.Add("The Dating Game", "Macroscopic");
        incorrectKnowledge.Add("Twitter", "Facebook");
        incorrectKnowledge.Add("Instagram", "Twitter");
        incorrectKnowledge.Add("not a social media", "a social media");
        incorrectKnowledge.Add("are from Seattle", "are from Portland");
        incorrectKnowledge.Add("are from Michigan", "are from New Hampshire");
        incorrectKnowledge.Add("cats", "dogs");
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
        incorrectKnowledge.Add("Ryan Gosling", "Robert Pattinson");
        incorrectKnowledge.Add("Jack Nicholson", "Ryan Gosling");
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
        incorrectKnowledge.Add("interviewed at Diary Queen", "interviewed at Burger King");
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
    }

    public string generateTalkingPoint(string k) {
        string point = "";

        if (Hobbies.Contains(k))
            point += $"What's so fun about {k}?";
        else if (Attributes.Contains(k))
            point += $"You'd consider yourself {k} person?";
        else if (Media.Contains(k))
            point += $"What do you like about {k}?";
        else if (Future.Contains(k))
            point += $"You want to {k}?";
        else if (Accomplishments.Contains(k))
            point += $"You {k}?";
        else if (Vacations.Contains(k))
            point += $"You've been to {k}?";
        else if (Pets.Contains(k))
            point += $"You have {k}?";
        else {
            point += $"Uh oh stinky! Looks like there's a bug here. ({k})";
        }

        return point;
    }

    public string findKnowledge() {
        return knownKnowledge.ElementAt(Random.Range(0, knownKnowledge.Count));
    }

    public bool isKnown(string k) {
        return knownKnowledge.Contains(k);
    }

    public string findRandomKnowledge() {
        return unknownKnowledge.ElementAt(Random.Range(0, unknownKnowledge.Count));
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
