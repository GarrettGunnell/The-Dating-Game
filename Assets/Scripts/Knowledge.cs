using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knowledge {

    private Hashtable knowledge;

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
        allHobbies = new HashSet<string> {"music"};
        allAttributes = new HashSet<string> {"night"};
        allMedia = new HashSet<string> {"Drive"};
        allFuture = new HashSet<string>();
        allAccomplishments = new HashSet<string>();
        allVacations = new HashSet<string> {"all over the world"};

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

        string correctOption = generateTalkingPoint();
        return new List<string> {correctOption};
    }

    private string generateTalkingPoint() {
        string k = findKnowledge();

        return k;
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

        return chosenCategory.ElementAt(Random.Range(0, chosenCategory.Count));
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
