using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knowledge {

    private HashSet<string> talkedAbout;

    private HashSet<string> Hobbies;
    private HashSet<string> Attributes;
    private HashSet<string> Media;
    private HashSet<string> Future;
    private HashSet<string> Accomplishments;
    private HashSet<string> Vacations;
    private HashSet<string> Pets;

    private HashSet<string> allHobbies;
    private HashSet<string> allAttributes;
    private HashSet<string> allMedia;
    private HashSet<string> allFuture;
    private HashSet<string> allAccomplishments;
    private HashSet<string> allVacations;
    private HashSet<string> allPets;

    private HashSet<string> knownHobbies;
    private HashSet<string> knownAttributes;
    private HashSet<string> knownMedia;
    private HashSet<string> knownFuture;
    private HashSet<string> knownAccomplishments;
    private HashSet<string> knownVacations;
    private HashSet<string> knownPets;

    private string girlName = null;

    public Knowledge(string girlName) {
        talkedAbout = new HashSet<string>();

        Hobbies = new HashSet<string> {"drawing", "YouTube", "doing nothing"};
        Attributes = new HashSet<string> {"fake", "indoors"};
        Media = new HashSet<string> {"La La Land", "Whiplash", "The Green Knight", "The Lighthouse", "Pale Fire", "vodka and water", "Baja Blast", "the naked chicken chalupa"};
        Future = new HashSet<string> {"fake"};
        Accomplishments = new HashSet<string> {"fake", "met Hungrybox"};
        Vacations = new HashSet<string> {"Italy", "fake"};
        Pets = new HashSet<string> {"two dogs", "three dogs", "a cat"};


        allHobbies = new HashSet<string>(Hobbies);
        allAttributes = new HashSet<string>(Attributes);
        allMedia = new HashSet<string>(Media);
        allFuture = new HashSet<string>(Future);
        allAccomplishments = new HashSet<string>(Accomplishments);
        allVacations = new HashSet<string>(Vacations);
        allPets = new HashSet<string>(Pets);

        knownHobbies = new HashSet<string>();
        knownAttributes = new HashSet<string>();
        knownMedia = new HashSet<string>();
        knownFuture = new HashSet<string>();
        knownAccomplishments = new HashSet<string>();
        knownVacations = new HashSet<string>();
        knownPets = new HashSet<string>();

        this.girlName = girlName;
    }

    public (List<string>, List<string>, int) generateTalkingPoints() {
        if (noKnowledge()) {
            return (new List<string>(), new List<string>(), 0);
        }

        List<string> options = new List<string>();

        string correctKnowledge = findKnowledge();

        string correctOption = generateTalkingPoint(girlName, correctKnowledge);

        options.Add(correctOption);

        List<string> fakeKnowledge = findRandomKnowledge();

        for (int i = 0; i < 5; ++i) {
            options.Add(generateTalkingPoint(girlName, fakeKnowledge[i]));
        }

        fakeKnowledge.Insert(0, correctKnowledge);
        var joined = options.Zip(fakeKnowledge, (x, y) => new {x, y}).ToList();
        var shuffled = joined.OrderBy(x => Random.value).ToList();
        options = shuffled.Select(pair => pair.x).ToList();
        fakeKnowledge = shuffled.Select(pair => pair.y).ToList();

        return (options, fakeKnowledge, options.IndexOf(correctOption));
    }

    private string generateTalkingPoint(string name, string k) {
        string point = girlName + ", ";

        if (Hobbies.Contains(k))
            point += $"what's so fun about {k}?";
        else if (Attributes.Contains(k))
            point += $"you said you'd consider yourself a {k} person?";
        else if (Media.Contains(k))
            point += $"what do you like about {k}?";
        else if (Future.Contains(k))
            point += $"";
        else if (Accomplishments.Contains(k))
            point += $"you {k}?";
        else if (Vacations.Contains(k))
            point += $"you said you've been to {k}? How was that?";
        else if (Pets.Contains(k))
            point += $"you have {k}?";

        return point;
    }

    private string findKnowledge() {
        List<HashSet<string>> knownCategories = new List<HashSet<string>>();

        if (knownHobbies.Count != 0) knownCategories.Add(knownHobbies);
        if (knownAttributes.Count != 0) knownCategories.Add(knownAttributes);
        if (knownMedia.Count != 0) knownCategories.Add(knownMedia);
        if (knownFuture.Count != 0) knownCategories.Add(knownFuture);
        if (knownAccomplishments.Count != 0) knownCategories.Add(knownAccomplishments);
        if (knownVacations.Count != 0) knownCategories.Add(knownVacations);
        if (knownPets.Count != 0) knownCategories.Add(knownPets);


        HashSet<string> chosenCategory = knownCategories[Random.Range(0, knownCategories.Count)];

        string chosenKnowledge = chosenCategory.ElementAt(Random.Range(0, chosenCategory.Count));
        chosenCategory.Remove(chosenKnowledge);

        return chosenKnowledge;
    }

    private List<string> findRandomKnowledge() {
        List<string> rk = new List<string>();

        rk.Add(allHobbies.ElementAt(Random.Range(0, allHobbies.Count)));
        rk.Add(allAttributes.ElementAt(Random.Range(0, allAttributes.Count)));
        rk.Add(allMedia.ElementAt(Random.Range(0, allMedia.Count)));
        rk.Add(allFuture.ElementAt(Random.Range(0, allFuture.Count)));
        rk.Add(allAccomplishments.ElementAt(Random.Range(0, allAccomplishments.Count)));
        rk.Add(allVacations.ElementAt(Random.Range(0, allVacations.Count)));
        rk.Add(allPets.ElementAt(Random.Range(0, allPets.Count)));

        string[] talkedAboutArray = talkedAbout.ToArray();
        for (int i = 0; i < talkedAbout.Count; ++i) {
            rk.Add(talkedAboutArray[Random.Range(0, talkedAbout.Count)]);
        }

        rk = rk.OrderBy(x => Random.value).ToList();

        return rk.GetRange(0, 5);
    }

    public void gainKnowledge(string k) {
        Debug.Log("Gaining Knowledge: " + k);
        if (allHobbies.Contains(k)) {
            knownHobbies.Add(k);
            allHobbies.Remove(k);
        } else if (allAttributes.Contains(k)) {
            knownAttributes.Add(k);
            allAttributes.Remove(k);
        } else if (allMedia.Contains(k)) {
            knownMedia.Add(k);
            allMedia.Remove(k);
        } else if (allFuture.Contains(k)) {
            knownFuture.Add(k);
            allFuture.Remove(k);
        } else if (allAccomplishments.Contains(k)) {
            knownAccomplishments.Add(k);
            allAccomplishments.Remove(k);
        } else if (allVacations.Contains(k)) {
            knownVacations.Add(k);
            allVacations.Remove(k);
        } else if (allPets.Contains(k)) {
            knownPets.Add(k);
            allPets.Remove(k);
        }
    }

    public void addTalkedAbout(string k) {
        talkedAbout.Add(k);
    }

    public bool hasBeenTalkedAbout(string k) {
        return talkedAbout.Contains(k);
    }

    private bool noKnowledge() {
        if (knownHobbies.Count != 0) return false;
        if (knownAttributes.Count != 0) return false;
        if (knownMedia.Count != 0) return false;
        if (knownFuture.Count != 0) return false;
        if (knownAccomplishments.Count != 0) return false;
        if (knownVacations.Count != 0) return false;
        if (knownPets.Count != 0) return false;

        return true;
    }
}
