using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour {

    private Hashtable questionResponses;
    private Hashtable talkResponses;

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
        talkResponses = new Hashtable();

        addQuestionResponse("So, what's your name?", "Did you really forget my name?", null);
        addQuestionResponse("So, what's your name?", "Did you really just ask what my name is?", null);
        
        addQuestionResponse("What do you like doing with your free time?", "I love drawing, I just wish I was better at it.", "drawing");
        addQuestionResponse("What do you like doing with your free time?", "I spend a lot of time watching YouTube..", "YouTube");
        addQuestionResponse("What do you like doing with your free time?", "I don't really do anything at all.", "doing nothing");
        
        addTalkResponse("drawing", "Yes, I particularly enjoy drawing portraits. Perhaps I could draw you!");
        addTalkResponse("YouTube", "I spend too much time on YouTube, my favorite YouTuber is Acerola_t. You should check him out!");
        addTalkResponse("doing nothing", "No, I don't like doing nothing. I just haven't found anything I particularly enjoy, so I tend to spend a lot of my time staring at the wall in a depressive state as time marches forward.. with or without me.");
        
        addQuestionResponse("Watched any cool movies lately?", "My friend recommended me La La Land.", "La La Land");
        addQuestionResponse("Watched any cool movies lately?", "I just saw Whiplash.", "Whiplash");
        addQuestionResponse("Watched any cool movies lately?", "Yes! I recently watched The Green Knight.", "The Green Knight");
        addQuestionResponse("Watched any cool movies lately?", "I saw The Lighthouse a few days ago.", "The Lighthouse");
    
        addTalkResponse("La La Land", "I think it's tragic how often we must choose between our careers and those we love.");
        addTalkResponse("Whiplash", "Absolute perfection requires absolute sacrifice, wouldn't you agree? I quite enjoy the obsessed artist motif.");
        addTalkResponse("The Green Knight", "The ending never fails to make me cry, to see Gawain take responsibility and acknowledge his fallibility is so powerful!");
        addTalkResponse("The Lighthouse", "I love the promethean allegory, it's quite similar to the situation we're in right now.");
    
        addQuestionResponse("Do you have any pets?", "I've got two dogs.", "two dogs");
        addQuestionResponse("Do you have any pets?", "I've got three dogs.", "three dogs");
        addQuestionResponse("Do you have any pets?", "I've got a cat.", "a cat");

        addTalkResponse("two dogs", "Their names are Sigma and Phi, they're both corgis!");
        addTalkResponse("three dogs", "Yes, I have a doberman, a chocolate lab, and a beagle!");
        addTalkResponse("a cat", "His name is Oliver, he doesn't like people very much.");
    
        addQuestionResponse("Have you traveled anywhere interesting?", "I've been to Italy!", "Italy");

        addTalkResponse("Italy", "It was a fun trip but this one weird guy approached me asking if I knew where he could find 'Italian Plan B'. I didn't know what to say.");

        addQuestionResponse("Are you a morning person?", "No, I hate waking up early. I prefer staying up late.", "night");
    
        addTalkResponse("night", "It's nice and quiet at night, don't you think?");
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

    private void addTalkResponse(string knowledge, string response) {
        talkResponses.Add(knowledge, response);
    }

    public List<string> GetQuestionResponse(string inquery) {
        List<QuestionResponse> responses = (List<QuestionResponse>)questionResponses[inquery];

        QuestionResponse response = responses[Random.Range(0, responses.Count)];

        return new List<string>{response.response, response.knowledge};
    }

    public string GetTalkResponse(string inquery) {
        return (string)talkResponses[inquery];
    }
}
