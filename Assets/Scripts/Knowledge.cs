using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knowledge {

    private Hashtable knowledge;

    private HashSet<string> Hobbies;
    private HashSet<string> Attributes;
    private HashSet<string> Media;
    private HashSet<string> Future;
    private HashSet<string> Accomplishments;
    private HashSet<string> Vacations;

    private HashSet<string> allHobbies;
    private HashSet<string> allAttributes;
    private HashSet<string> allMedia;
    private HashSet<string> allFuture;
    private HashSet<string> allAccomplishments;
    private HashSet<string> allVacations;

    private HashSet<string> knownHobbies;
    private HashSet<string> knownAttributes;
    private HashSet<string> knownMedia;
    private HashSet<string> knownFuture;
    private HashSet<string> knownAccomplishments;
    private HashSet<string> knownVacations;

    private string girlName = null;

    public Knowledge(string girlName) {
        Hobbies = new HashSet<string> {"music", "fake"};
        Attributes = new HashSet<string> {"night", "fake"};
        Media = new HashSet<string> {"Drive", "fake"};
        Future = new HashSet<string> {"fake"};
        Accomplishments = new HashSet<string> {"fake"};
        Vacations = new HashSet<string> {"all over the world", "fake"};


        allHobbies = new HashSet<string>(Hobbies);
        allAttributes = new HashSet<string>(Attributes);
        allMedia = new HashSet<string>(Media);
        allFuture = new HashSet<string>(Future);
        allAccomplishments = new HashSet<string>(Accomplishments);
        allVacations = new HashSet<string>(Vacations);

        knownHobbies = new HashSet<string>();
        knownAttributes = new HashSet<string>();
        knownMedia = new HashSet<string>();
        knownFuture = new HashSet<string>();
        knownAccomplishments = new HashSet<string>();
        knownVacations = new HashSet<string>();

        this.girlName = girlName;
    }

    public List<string> generateTalkingPoints() {
        if (noKnowledge()) {
            return null;
        }

        List<string> options = new List<string>();

        string correctOption = generateTalkingPoint(girlName, findKnowledge());

        options.Add(correctOption);

        List<string> fakeKnowledge = findRandomKnowledge();
        List<string> fakeOptions = new List<string>();

        for (int i = 0; i < fakeKnowledge.Count; ++i) {
            fakeOptions.Add(generateTalkingPoint(girlName, fakeKnowledge[i]));
        }

        fakeOptions = fakeOptions.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < 5; ++i) {
            options.Add(fakeOptions[0]);
            fakeOptions.RemoveAt(0);
        }

        return options;
    }

    private string generateTalkingPoint(string name, string k) {
        string point = girlName + ", ";

        if (Hobbies.Contains(k))
            point += $"you said you like {k}?";
        else if (Attributes.Contains(k))
            point += $"you said you'd consider yourself a {k} person?";
        else if (Media.Contains(k))
            point += $"I've not heard of {k}, what's so interesting about it?";
        else if (Future.Contains(k))
            point += "";
        else if (Accomplishments.Contains(k))
            point += "";
        else if (Vacations.Contains(k))
            point += $"you said you've been to {k}? How was that?";

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

        return rk;
    }

    public void gainKnowledge(string k) {
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
        }
    }

    private bool noKnowledge() {
        if (knownHobbies.Count != 0) return false;
        if (knownAttributes.Count != 0) return false;
        if (knownMedia.Count != 0) return false;
        if (knownFuture.Count != 0) return false;
        if (knownAccomplishments.Count != 0) return false;
        if (knownVacations.Count != 0) return false;

        return true;
    }
}
