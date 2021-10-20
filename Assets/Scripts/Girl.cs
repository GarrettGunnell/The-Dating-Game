using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

    private Hashtable questionResponses;

    public string girlName = "Molly";

    struct QuestionResponse {
        public string response;
        public string knowledge;

        public QuestionResponse(string r, string k) {
            response = r;
            knowledge = k;
        }
    };

    void Start() {
        questionResponses = new Hashtable();

        addQuestionResponse("So, what's your name?", "Did you really forget my name?", null);
        addQuestionResponse("So, what's your name?", "Did you really just ask what my name is?", null);
        
        addQuestionResponse("What do you like doing with your free time?", "I love drawing, I just wish I was better at it.", "drawing");
        addQuestionResponse("What do you like doing with your free time?", "I spend a lot of time watching YouTube..", "Youtube");
        
    
    /*
        questionResponses.Add("What's your name?", new List<string> {"Did you really forget my name?", null});
        questionResponses.Add("What do you like to do in your free time?", new List<string> {"I like making music, perhaps you've heard of my band.", "music"});
        questionResponses.Add("What's a movie you really enjoyed?", new List<string> {"My favorite movie is Drive.", "Drive"});
        questionResponses.Add("Do you have any pets?", new List<string> {"Yes I have a pet bird!", "bird"});
        questionResponses.Add("Have you ever been out of the country?", new List<string> {"I've toured all over the world!", "all over the world"});
        questionResponses.Add("Are you a morning person?", new List<string> {"No I prefer the solitude of night time.", "night"});
    */
    }

    private void addQuestionResponse(string question, string response, string knowledge) {
        QuestionResponse qr = new QuestionResponse(response, knowledge);
        
        if (!questionResponses.ContainsKey(question)) {
            questionResponses.Add(question, new List<QuestionResponse> {qr});
        } else {
            ((List<QuestionResponse>)questionResponses[question]).Add(qr);
        }
    }

    public List<string> GetQuestionResponse(string inquery) {
        List<QuestionResponse> responses = (List<QuestionResponse>)questionResponses[inquery];

        QuestionResponse response = responses[Random.Range(0, responses.Count)];

        return new List<string>{response.response, response.knowledge};
    }

    public string GetTalkResponse(string inquery) {
        return "Fake talk response";
    }
}
