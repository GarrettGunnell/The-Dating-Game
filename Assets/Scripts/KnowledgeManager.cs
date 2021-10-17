using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnowledgeManager : MonoBehaviour {

    private Hashtable knowledge;

    void Start() {
        knowledge = new Hashtable();
        knowledge.Add("Hobbies", new List<string>());
        knowledge.Add("Attributes", new List<string>());
        knowledge.Add("Media", new List<string>());
        knowledge.Add("Future", new List<string>());
        knowledge.Add("Accomplishments", new List<string>());
        knowledge.Add("Vacations", new List<string>());
    }

    public string generateTalkingPoint() {
        if (noKnowledge()) {
            return null;
        }
        return "";
    }

    private bool noKnowledge() {
        foreach (string key in knowledge.Keys) {
            List<string> v = (List<string>)knowledge[key];

            if (v.Count != 0) return false;
        }

        return true;
    }

}
