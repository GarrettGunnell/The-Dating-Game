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

    public Knowledge() {
        talkedAbout = new HashSet<string>();

        Hobbies = new HashSet<string> {"drawing", "YouTube", "doing nothing", "soccer", "rock climbing"};
        Attributes = new HashSet<string> {"an indoors", "a night", "not a team", "a morning", "an outdoors", "a manipulative", "not a social media", "a dog",
        "a team"};
        Media = new HashSet<string> {"La La Land", "Whiplash", "The Green Knight", "The Lighthouse", "Pale Fire", "vodka and water", "Baja Blast", 
        "the naked chicken chalupa", "Clive Barker", "Breaking Bad", "Blue Honey", "Alvvays", "The Dating Game", "Twitter", "cats", "your best friend",
        "sushi", "Ryan Gosling", "fried rice", "Ludwig", "TV On The Radio", "history", "Bonedog", "Ivan the Terrible and His Son Ivan", "Oyasumi Punpun",
        "Artemis Fowl", "cosmopolitans", "tea", "water", "Inio Asano", "Nisioisin", "Hannibal", "Spongebob", "The Barrel", "Dancing Queen", "Disorder",
        "turtles", "art supplies", "Jack Nicholson", "Jodie Foster", "pasta", "ramen", "Mars Argo", "Gesaffelstein", "I Monster", "chemistry", "nursing",
        "Saturn Devouring His Son", "the rain", "I Go Back To May"};
        Future = new HashSet<string> {"go to Japan", "be a therapist", "learn an instrument", "learn latin", "be an artist", "be a private investigator", "be a crime lord",
        "go to London", "learn an instrument", "learn to paint", "learn Japanese", "learn Chinese"};
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

        return point;
    }

    public string findKnowledge() {
        return knownKnowledge.ElementAt(Random.Range(0, knownKnowledge.Count));
    }

    public bool isKnown(string k) {
        return knownKnowledge.Contains(k);
    }

    private List<string> findRandomKnowledge() {
        HashSet<string> rk = new HashSet<string>();
        List<string> allKnowledge = unknownKnowledge.ToList();

        for (int i = 0; i < 10; ++i) {
            rk.Add(allKnowledge[Random.Range(0, allKnowledge.Count)]);
        }

        string[] talkedAboutArray = talkedAbout.ToArray();
        for (int i = 0; i < talkedAbout.Count; ++i) {
            rk.Add(talkedAboutArray[Random.Range(0, talkedAbout.Count)]);
        }

        List<string> randomKnowledge = rk.ToList();

        randomKnowledge = randomKnowledge.OrderBy(x => Random.value).ToList();

        return randomKnowledge;
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
}
