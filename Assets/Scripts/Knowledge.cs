using System.Collections;
using System.Collections.Generic;

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

    public Knowledge() {
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
    }

    public string generateTalkingPoint() {
        if (noKnowledge()) {
            return null;
        }
        return "";
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
