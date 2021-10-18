using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

    private Hashtable questionResponses;

    public string girlName = "Molly";

    void Start() {
        questionResponses = new Hashtable();

        questionResponses.Add("What's your name?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("What do you like to do in your free time?", new List<string> {"I like making music, perhaps you've heard of my band.", "music"});
        questionResponses.Add("What's a movie you really enjoyed?", new List<string> {"My favorite movie is Drive.", "Drive"});
        questionResponses.Add("Do you have any pets?", new List<string> {"Yes I have a pet bird!", "bird"});
        questionResponses.Add("Have you ever been out of the country?", new List<string> {"I've toured all over the world!", "all over the world"});
        questionResponses.Add("Are you a morning person?", new List<string> {"No I prefer the solitude of night time.", "night"});
    
    }

    public List<string> GetQuestionResponse(string inquery) {
        return (List<string>)questionResponses[inquery];
    }

    public string GetTalkResponse(string inquery) {
        return "Fake talk response";
    }
}
