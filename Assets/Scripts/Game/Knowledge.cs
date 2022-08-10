using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Knowledge
{
    private HashSet<string> knownKnowledge;
    private HashSet<string> talkedAbout;

    private Hashtable incorrectKnowledge;
    private Hashtable knowledgeResponse;

    public Knowledge(List<GoodQuestion.Knowledge> data)
    {
        talkedAbout = new HashSet<string>();
        knownKnowledge = new HashSet<string>();

        incorrectKnowledge = new Hashtable();
        knowledgeResponse = new Hashtable();

        foreach (var k in data)
        {
            incorrectKnowledge.Add(k.Correct, k.IncorrectKnowledge);
            knowledgeResponse.Add(k.Correct, k.Question);
        }
    }

    public string generateTalkingPoint(string k)
    {
        return (string)knowledgeResponse[k];
    }

    public string generateIncorrectTalkingPoint()
    {
        if (knownKnowledge.Count == 0)
        {
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

    public string findKnowledge()
    {
        return knownKnowledge.ElementAt(Random.Range(0, knownKnowledge.Count));
    }

    public bool isKnown(string k)
    {
        return knownKnowledge.Contains(k);
    }

    public void gainKnowledge(string k)
    {
        knownKnowledge.Add(k);
    }

    public void addTalkedAbout(string k)
    {
        talkedAbout.Add(k);
        knownKnowledge.Remove(k);
    }

    public bool hasBeenTalkedAbout(string k)
    {
        return talkedAbout.Contains(k);
    }

    public List<string> getTalkedAbout()
    {
        return talkedAbout.ToList();
    }

    public int knowledgeCount()
    {
        return knownKnowledge.Count();
    }
}