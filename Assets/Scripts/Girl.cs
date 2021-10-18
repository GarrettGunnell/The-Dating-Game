using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

    private Hashtable questionResponses;

    void Start() {
        questionResponses = new Hashtable();

        questionResponses.Add("What's your name?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("What do you like to do in your free time?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("What's a movie you really enjoyed?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("Do you have any pets?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("Have you ever been out of the country?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("Are you a morning person?", new List<string> {"Did you really forget my name?", null});
    
    }

    public List<string> GetResponse(string inquery) {
        return (List<string>)questionResponses[inquery];
    }
}
