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
        
        addTalkResponse("drawing", "Being able to draw is a great creative outlet, I particularly enjoy drawing portraits. Perhaps I could draw you!");
        addTalkResponse("YouTube", "There's so much to learn on there. My favorite YouTuber is Acerola_t, you should check him out!");
        addTalkResponse("doing nothing", "It's not very fun. I just haven't found anything I particularly enjoy, so I tend to spend a lot of my time staring at the wall in a depressive state as time marches forward.. with or without me.");
        
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
    
        addQuestionResponse("What's your favorite book?", "Probably 'Pale Fire' if I had to choose.", "Pale Fire");

        addTalkResponse("Pale Fire", "Dreadfully distinct.");

        addQuestionResponse("Are you interested in outdoor activities?", "No, I definitely prefer staying inside.", "indoors");

        addTalkResponse("indoors", "As embarrassing as it is, I used to be a little afraid of going outside.");
    
        addQuestionResponse("Have you ever met anyone famous?", "I met Hungrybox at a grocery store in Los Angeles.", "met Hungrybox");
    
        addTalkResponse("met Hungrybox", "Yeah, he was kind of a real asshole about it though.");

        addQuestionResponse("Do you happen to have a favorite cocktail?", "My favorite is probably... just vodka and water.", "vodka and water");

        addTalkResponse("vodka and water", "Well, you see, it hydrates you at the same time as getting you drunk. It's just efficient. Also, I might be an alcoholic.");

        addQuestionResponse("What's your favorite beverage?", "Nothing beats Mountain Dew Baja Blast.", "Baja Blast");

        addTalkResponse("Baja Blast", "What isn't there to like about it?");

        addQuestionResponse("Alright, what's your favorite item on the Taco Bell menu?", "For me, it's the naked chicken chalupa.", "the naked chicken chalupa");
    
        addTalkResponse("the naked chicken chalupa", "It really changed the game in terms of fried chicken.. but you have to try it yourself to really understand its depth.");
    
        addQuestionResponse("Do you have a dream job?", "I always wanted to be a therapist.", "be a therapist");
    
        addTalkResponse("be a therapist", "My friends constantly dump their problems on me, so why not do it for a living?");
    
        addQuestionResponse("Who's your favorite author?", "If I had to choose, probably Clive Barker.", "Clive Barker");

        addTalkResponse("Clive Barker", "Well, I mean, he's an incredibly influential horror writer. But I myself love his Abarat series, you should read it!");

        addQuestionResponse("What's your favorite TV show?", "Breaking Bad without a doubt.", "Breaking Bad");

        addTalkResponse("Breaking Bad", "Ever since I watched it years ago I find myself constantly reminiscing on many moments in the show.");

        addQuestionResponse("What's your favorite song?", "There's a lot of songs I'd consider my favorite, but if I had to choose, it would be Blue Honey by Lunar Vacation", "Blue Honey");

        addTalkResponse("Blue Honey", "It isn't really the song, rather, I spent a very important moment with someone while listening to it.");

        addQuestionResponse("Who's your favorite band?", "Alvvays, no competition.", "Alvvays");

        addTalkResponse("Alvvays", "Don't even get me started. Every single Alvvays song is an absolute banger, they are the pinnacle of synth pop. I could talk about them for hours, and I have.");

        addQuestionResponse("What's your proudest achievement?", "I got first place in a marathon.", "ran a marathon");

        addTalkResponse("ran a marathon", "Yeah, I run a lot in my free time for fun and exercise.");
    
        addQuestionResponse("Is there anywhere you'd really like to travel?", "I've always wanted to visit Japan.", "go to Japan");

        addTalkResponse("go to Japan", "I would love to see the cherry blossoms.");

        addQuestionResponse("What do you do for work?", "I'm a server at this restaurant.", "are a server");

        addTalkResponse("are a server", "Yes, all my coworkers are watching us right now.");

        addQuestionResponse("What's your toxic trait?", "To be honest, I care too much.", "care too much");

        addTalkResponse("care too much", "No, not actually, I was just making fun of the people that say that in response to the question.");

        addQuestionResponse("Do you play any video games?", "I've been playing this game called 'The Dating Game', it's really interesting and well made!", "The Dating Game");

        addTalkResponse("The Dating Game", "I like how it's a new experience each playthrough, it's endless entertainment.");

        addQuestionResponse("Are you on social media a lot?", "I can't help myself from mindlessly scrolling Twitter.", "Twitter");

        addTalkResponse("Twitter", "Twitter ruins my day constantly, I should stop using it... but I can't.");

        addQuestionResponse("Where are you from?", "I'm from Seattle, Washington originally but I moved here when I was young.", "are from Seattle");

        addTalkResponse("are from Seattle", "I don't remember much about it, I've visited several times and I don't think I'd like to live there again.");

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
