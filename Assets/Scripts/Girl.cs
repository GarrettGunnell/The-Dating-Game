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
        addQuestionResponse("Have you traveled anywhere interesting?", "I've been to Canada!", "Canada");
        addQuestionResponse("Have you traveled anywhere interesting?", "I've been to France!", "France");

        addTalkResponse("Italy", "It was a fun trip but this one weird guy approached me asking if I knew where he could find 'Italian Plan B'. I didn't know what to say...");
        addTalkResponse("Canada", "I visited Stanley Park, it's apparently a rain forest which is interesting.");
        addTalkResponse("France", "I got to see the Notre-Dame! The pictures don't do it justice.");

        addQuestionResponse("Are you a morning person?", "No, I hate waking up early. I prefer staying up late.", "a night");
        addQuestionResponse("Are you a morning person?", "For some reason I'm incapable of sleeping in, so I'm a morning person by happenstance.", "a morning");
    
        addTalkResponse("a night", "It's nice and quiet at night, don't you think?");
        addTalkResponse("a morning", "The early bird gets the worm! Or something like that.");
    
        addQuestionResponse("What's your favorite book?", "Probably 'Pale Fire' if I had to choose.", "Pale Fire");
        addQuestionResponse("What's your favorite book?", "Does manga count? 'Oyasumi Punpun' is my favorite piece of literature.", "Oyasumi Punpun");
        addQuestionResponse("What's your favorite book?", "I haven't done much reading since middle school, my favorite back then was 'Artemis Fowl'.", "Artemis Fowl");

        addTalkResponse("Pale Fire", "'And dreadfully distinct\nAgainst the dark, a tall white fountain played.'");
        addTalkResponse("Oyasumi Punpun", "If there were a place lower than here\nit would surely be hell..");
        addTalkResponse("Artemis Fowl", "It's a shame the movie was so unforgivably terrible.");

        addQuestionResponse("Are you interested in outdoor activities?", "No, I definitely prefer staying inside.", "an indoors");
        addQuestionResponse("Are you interested in outdoor activities?", "Yes, I spend a lot of my time outside.", "an outdoors");
        addQuestionResponse("Are you interested in outdoor activities?", "I go rock climbing all the time.", "rock climbing");

        addTalkResponse("an indoors", "As embarrassing as it is, I used to be a little afraid of going outside.");
        addTalkResponse("an outdoors", "I go on hikes, walks, bike rides, everything really!");
        addTalkResponse("rock climbing", "There's all sorts of climbs from beginner to advanced! You should come with me some time.");
    
        addQuestionResponse("Have you ever met anyone famous?", "I met Hungrybox at a grocery store in Los Angeles.", "met Hungrybox");
        addQuestionResponse("Have you ever met anyone famous?", "I met Ryan Gosling at a grocery store in Los Angeles.", "met Ryan Gosling");
    
        addTalkResponse("met Hungrybox", "Yeah, he was kind of a real asshole about it though.");
        addTalkResponse("met Ryan Gosling", "Yeah, he was kind of a real asshole about it though.");

        addQuestionResponse("Do you happen to have a favorite cocktail?", "My favorite is probably... just vodka and water.", "vodka and water");
        addQuestionResponse("Do you happen to have a favorite cocktail?", "I would never pass up a cosmopolitan.", "cosmopolitans");
        addQuestionResponse("Do you happen to have a favorite cocktail?", "I don't really drink", "don't really drink");

        addTalkResponse("vodka and water", "Well, you see, it hydrates you at the same time as getting you drunk. It's just efficient. Also, I might be an alcoholic.");
        addTalkResponse("cosmopolitans", "The cranberry juice and lime really hides the gross alcohol taste.");
        addTalkResponse("don't really drink", "Both of my parents are alcoholics.. I didn't want to be like that.");

        addQuestionResponse("What's your favorite beverage?", "Nothing beats Mountain Dew Baja Blast.", "Baja Blast");
        addQuestionResponse("What's your favorite beverage?", "I love tea!", "tea");
        addQuestionResponse("What's your favorite beverage?", "I just like water.", "water");

        addTalkResponse("Baja Blast", "What isn't there to like about it?");
        addTalkResponse("tea", "I love all kinds of tea, my favorite is green tea.");
        addTalkResponse("water", "It's not amazing or anything, it's just water..");

        addQuestionResponse("Alright, what's your favorite item on the Taco Bell menu?", "For me, it's the naked chicken chalupa.", "the naked chicken chalupa");
    
        addTalkResponse("the naked chicken chalupa", "It really changed the game in terms of fried chicken.. but you have to try it yourself to really understand its depth.");
    
        addQuestionResponse("Do you have a dream job?", "I always wanted to be a therapist.", "be a therapist");
        addQuestionResponse("Do you have a dream job?", "I always wanted to be an artist.", "be an artist");
        addQuestionResponse("Do you have a dream job?", "I always wanted to be a private investigator.", "be a private investigator");
        addQuestionResponse("Do you have a dream job?", "I've always secretly wanted to be a crime lord.", "be a crime lord");
    
        addTalkResponse("be a therapist", "My friends constantly dump their problems on me, so why not do it for a living?");
        addTalkResponse("be an artist", "At this point in my life, I feel it's too late to become a great artist. That's why it's a dream!");
        addTalkResponse("be a private investigator", "Yeah, you know.. follow people around, investigate potential affairs, solve a dastardly murder.. it's all so exciting!");
        addTalkResponse("be a crime lord", "Following the rules is boring sometimes, it must be so freeing and empowering to do whatever you want.");
    
        addQuestionResponse("Who's your favorite author?", "If I had to choose, probably Clive Barker.", "Clive Barker");
        addQuestionResponse("Who's your favorite author?", "Inio Asano, without a doubt.", "Inio Asano");
        addQuestionResponse("Who's your favorite author?", "Ummmm... Nisioisin!", "Nisioisin");

        addTalkResponse("Clive Barker", "Well, I mean, he's an incredibly influential horror writer. But I myself love his Abarat series, you should read it!");
        addTalkResponse("Inio Asano", "Everyone of his works is masterful.. Oyasumi Punpun, Solanin, A Girl On The Shore, the list goes on. I strongly recommend his stuff!");
        addTalkResponse("Nisioisin", "He wrote Katanagatari, which I really recommend.");

        addQuestionResponse("What's your favorite TV show?", "Breaking Bad without a doubt.", "Breaking Bad");
        addQuestionResponse("What's your favorite TV show?", "I really enjoyed Hannibal.", "Hannibal");
        addQuestionResponse("What's your favorite TV show?", "I don't watch a lot of television, my favorite when I was a kid was Spongebob.", "Spongebob");

        addTalkResponse("Breaking Bad", "Ever since I watched it years ago I find myself constantly reminiscing on many moments in the show.");
        addTalkResponse("Hannibal", "Mads Mikkelsen is wonderful in it! The second season is especially great.");
        addTalkResponse("Spongebob", "A timeless classic, wouldn't you agree?");

        addQuestionResponse("What's your favorite song?", "There's a lot of songs I'd consider my favorite, but if I had to choose, it would be Blue Honey by Lunar Vacation", "Blue Honey");
        addQuestionResponse("What's your favorite song?", "I really like The Barrel by Aldous Harding.", "The Barrel");
        addQuestionResponse("What's your favorite song?", "I really like Disorder by Freak Slug.", "Disorder");
        addQuestionResponse("What's your favorite song?", "Is there any song that can compete with Dancing Queen by ABBA?", "Dancing Queen");

        addTalkResponse("Blue Honey", "It isn't really the song, rather, I spent a very important moment with someone while listening to it.");
        addTalkResponse("The Barrel", "The barrel, the barrel, the barrel, the barrel, the barrel, the barrel, the barrel, the barrel");
        addTalkResponse("Disorder", "It's a cover of the Joy Division song, but I feel like this version is an overall improvement.");
        addTalkResponse("Dancing Queen", "You can dance\nyou can jive\nhaving the time of your life.");

        addQuestionResponse("Who's your favorite band?", "Alvvays, no competition.", "Alvvays");

        addTalkResponse("Alvvays", "Don't even get me started. Every single Alvvays song is an absolute banger, they are the pinnacle of synth pop. I could talk about them for hours, and I have.");

        addQuestionResponse("What's your proudest achievement?", "I got first place in a marathon!", "ran a marathon");
        addQuestionResponse("What's your proudest achievement?", "I have an honors diploma.", "have an honors diploma");
        addQuestionResponse("What's your proudest achievement?", "I've made a lot of friends.", "made a lot of friends");
        addQuestionResponse("What's your proudest achievement?", "I won the science fair in the sixth grade.", "won the science fair");
        

        addTalkResponse("ran a marathon", "Yeah, I run a lot in my free time for fun and exercise.");
        addTalkResponse("have an honors diploma", "I worked very hard for it back in high school, turns out to not be very useful other than bragging about it in situations like this though!");
        addTalkResponse("made a lot of friends", "More than I could ever ask for!");
        addTalkResponse("won the science fair", "My project involved making circuits with salt, it was pretty fun!");

        addQuestionResponse("Is there anywhere you'd really like to travel?", "I've always wanted to visit Japan.", "go to Japan");
        addQuestionResponse("Is there anywhere you'd really like to travel?", "I've been interested in London.", "go to London");

        addTalkResponse("go to Japan", "I would love to see the cherry blossoms.");
        addTalkResponse("go to London", "I don't really know why, seems like a cool place, I guess?");

        addQuestionResponse("What do you do for work?", "I'm a server at this restaurant.", "are a server");

        addTalkResponse("are a server", "Yes, all my coworkers are watching us right now. You've also been on dates with other girls that work here as well, haven't you?");

        addQuestionResponse("What's your toxic trait?", "To be honest, I care too much.", "care too much");
        addQuestionResponse("What's your toxic trait?", "I can be unintentionally manipulative.", "a manipulative");
        addQuestionResponse("What's your toxic trait?", "I give up quite quickly sometimes..", "a self-defeating");
        

        addTalkResponse("care too much", "No, not actually, I was just making fun of the people that say that in response to the question.");
        addTalkResponse("a manipulative", "I learned it from my mother, I've spent a lot of time trying to unlearn it..");
        addTalkResponse("a self-defeating", "It's all too much sometimes, you know? I'd rather just do nothing.");

        addQuestionResponse("Do you play any video games?", "I've been playing this game called 'The Dating Game', it's really interesting and well made!", "The Dating Game");

        addTalkResponse("The Dating Game", "I like how it's a new experience each playthrough, it's endless entertainment.");

        addQuestionResponse("Are you on social media a lot?", "I can't help myself from mindlessly scrolling Twitter.", "Twitter");
        addQuestionResponse("Are you on social media a lot?", "I'm a little obsessed with posting pictures I take on Instagram..", "Instagram");
        addQuestionResponse("Are you on social media a lot?", "No, I tend to stay away from all of that.", "not a social media");

        addTalkResponse("Twitter", "Twitter ruins my day constantly, I should stop using it... but I can't.");
        addTalkResponse("Instagram", "There's a lot of talented people on there, it's a bit overwhelming.");
        addTalkResponse("not a social media", "I deleted all my social media accounts a few years ago!");

        addQuestionResponse("Where are you from?", "I'm from Seattle, Washington originally but I moved here when I was young.", "are from Seattle");
        addQuestionResponse("Where are you from?", "I'm from a small town in Michigan.", "are from Michigan");

        addTalkResponse("are from Seattle", "I don't remember much about it, I've visited several times and I don't think I'd like to live there again.");
        addTalkResponse("are from Michigan", "My family still lives there, so I visit quite often. Perhaps you could come with me!");

        addQuestionResponse("Do you have a favorite animal?", "I love cats!", "cats");
        addQuestionResponse("Do you have a favorite animal?", "I think turtles are neat.", "turtles");
        addQuestionResponse("Do you have a favorite animal?", "I like to think of myself as a dog person.", "a dog");

        addTalkResponse("cats", "While I was growing up my family was allergic to cats, I couldn't wait to move out and get one myself.");
        addTalkResponse("turtles", "Turtles are much faster than people think, did you know that?");
        addTalkResponse("a dog", "I've always liked dogs, I'd love to have a samoyed someday!");

        addQuestionResponse("What's your biggest fear?", "I used to have a major fear of bees.", "a fear of bees");
        addQuestionResponse("What's your biggest fear?", "Abandonment.", "a fear of abandonment");

        addTalkResponse("a fear of bees", "It used to be so bad that I couldn't go outside! I'm a little bit better now though.");
        addTalkResponse("a fear of abandonment", "I'd rather not talk about it..");

        addQuestionResponse("What's the strangest place you've been?", "There's this town in California called Weed.", "Weed");
        addQuestionResponse("What's the strangest place you've been?", "There's a place in Oregon called Post, it's literally just a post office.", "Post");

        addTalkResponse("Weed", "Yes, it's funny once.");
        addTalkResponse("Post", "I drove through it on a trip, it was rather underwhelming.");

        addQuestionResponse("Do you like working in a team?", "No, I find it hard to communicate professionally.", "not a team");
        addQuestionResponse("Do you like working in a team?", "Yes, I like seeing what those around me can come up with.", "a team");

        addTalkResponse("not a team", "It's difficult to trust others to do their part of the work. It stresses me out!");
        addTalkResponse("a team", "We can't do everything ourselves, there's just simply not enough time!");

        addQuestionResponse("Is there anything you want to get into?", "I want to learn an instrument, but I just don't have the time!", "learn an instrument");
        addQuestionResponse("Is there anything you want to get into?", "I want to learn to paint, I think.", "learn to paint");
        addQuestionResponse("Is there anything you want to get into?", "I never really learned how to cook.", "learn to cook");
            
        addTalkResponse("learn to paint", "I should really start soon, it takes such a long time to learn art.");
        addTalkResponse("learn an instrument", "I want to learn piano so I can play all my favorite classical songs, like anything from Chopin!");
        addTalkResponse("learn to cook", "I've survived off premade meals for too long, I'd like to be able to make my own.");

        addQuestionResponse("How'd you meet your best friend?", "I met them through my brother a very long time ago, when I was around 8 I think?", "your best friend");

        addTalkResponse("your best friend", "They were very funny and creative. I respected their artistic vision and wished for their success, but unfortunately they passed away earlier this year..");

        addQuestionResponse("What's needlessly expensive but worth the money?", "I think sushi is really expensive, but I still eat it all time time.", "sushi");
        addQuestionResponse("What's needlessly expensive but worth the money?", "Art supplies are so expensive..", "art supplies");

        addTalkResponse("sushi", "My favorite fish is salmon, I could eat salmon sashimi all day!");
        addTalkResponse("art supplies", "I like collecting sketchbooks, although I never really fill them out.");

        addQuestionResponse("Would you want to be famous?", "No, I value my privacy too much for that.", "don't want to be famous");
        addQuestionResponse("Would you want to be famous?", "Yeah I think it would be fun, I would love the attention.", "want to be famous");

        addTalkResponse("don't want to be famous", "Everything celebrities do gets posted all over social media, I could never handle that!");
        addTalkResponse("want to be famous", "Everything you say and do gets treated with such high esteem, that sounds nice..");

        addQuestionResponse("Who's your favorite actor?", "I love Ryan Gosling!", "Ryan Gosling");
        addQuestionResponse("Who's your favorite actor?", "I'm a huge fan of Jack Nicholson.", "Jack Nicholson");
        addQuestionResponse("Who's your favorite actor?", "I think Jodie Foster is a huge inspiration.", "Jodie Foster");

        addTalkResponse("Ryan Gosling", "I've seen all of his movies.. my favorite is probably Drive!");
        addTalkResponse("Jack Nicholson", "My favorite movie of his is Chinatown, but who doesn't love The Shining?");
        addTalkResponse("Jodie Foster", "Her performance alongside Anthony Hopkins in The Silence of the Lambs is one for the ages!");

        addQuestionResponse("What's your favorite food?", "I could spend the rest of my life eating fried rice.", "fried rice");
        addQuestionResponse("What's your favorite food?", "I eat pasta nearly every night, it's almost a problem.", "pasta");
        addQuestionResponse("What's your favorite food?", "I'm kind of poor, so all I ever eat is top ramen.", "ramen");
        

        addTalkResponse("fried rice", "I call it friend rice!");
        addTalkResponse("pasta", "So, basically, it's amazing because you have dozens of shapes, and hundreds of sauces and ways to cook them, combined " +
        "with hundreds of side dishes, sometimes the pasta is the side dish! It's easy to make, so it has a low floor but a high ceiling in terms of skill. " +
        "It's truly the food for both beginners and the most excellent of chefs.");
        addTalkResponse("ramen", "I'm getting a little tired of it, but I really love poaching eggs in my ramen.");

        addQuestionResponse("What's an interest you're kind of embarrassed to admit?", "I watch Ludwig on twitch..", "Ludwig");

        addTalkResponse("Ludwig", "I watch nearly every stream! I redeemed the twitter follow reward but he scammed me..");

        addQuestionResponse("What's your favorite band name?", "I've always really liked TV On The Radio, what a cool name!", "TV On The Radio");
        addQuestionResponse("What's your favorite band name?", "I think Mars Argo sounds cool.", "Mars Argo");
        addQuestionResponse("What's your favorite band name?", "Ummm... I Monster is a cool band name, but it's a reference.", "I Monster");
        addQuestionResponse("What's your favorite band name?", "Gesaffelstein sounds cool.", "Gesaffelstein");

        addTalkResponse("TV On The Radio", "My favorite song of theirs is Staring At The Sun.");
        addTalkResponse("Mars Argo", "It's such a shame she hasn't made any music, her songs are so great.");
        addTalkResponse("I Monster", "You should listen to their song Lust for a Vampyr, it bangs.");
        addTalkResponse("Gesaffelstein", "I've listen to his song Opr more times than I can count.");

        addQuestionResponse("What's the worst job you've had?", "I got hired at a Spirit Halloween a few days before halloween weekend.", "worked at Spirit Halloween");
        addQuestionResponse("What's the worst job you've had?", "I didn't actually work the job, but the worst interview I had was at a Dairy Queen.", "interviewed at Dairy Queen");

        addTalkResponse("worked at Spirit Halloween", "It was so busy the day before Halloween, the line was about a 2 hour wait. Several people offered me money to skip the line!");
        addTalkResponse("interviewed at Dairy Queen", "The guy interviewing me was just terrible, he insulted me several times even though I clearly had never been in an interview before..");

        addQuestionResponse("What do you go to school for?", "Right now I'm going to school for history, but it might change!", "history");
        addQuestionResponse("What do you go to school for?", "I'm currently studying chemistry, I enjoy it.", "chemistry");
        addQuestionResponse("What do you go to school for?", "I'm trying to become a nurse.", "nursing");

        addTalkResponse("history", "There's so many great stories from the past, fiction is great and all but nothing beats real experiences.");
        addTalkResponse("chemistry", "The math is tough, but I love how everything is equal in reactions, nothing is being created from nothing. It's all a conversion.");
        addTalkResponse("nursing", "I don't really like anything about it, but it's what all my friends are doing.. and my parents seem to like it.");

        addQuestionResponse("Do you want to learn any other languages?", "I'd love to learn latin.", "learn latin");
        addQuestionResponse("Do you want to learn any other languages?", "It's a little embarrassing, but I think learning Japanese would be cool.", "learn Japanese");
        addQuestionResponse("Do you want to learn any other languages?", "Chinese seems like a good idea to learn.", "learn Chinese");

        addTalkResponse("learn latin", "It's pretty nerdy but I think it'd be fun to randomly recite phrases in latin to my friends.");
        addTalkResponse("learn Japanese", "When I visit Japan I don't want to be seen as a dumb foreigner, I think the overall experience would be much better if I knew the language.");
        addTalkResponse("learn Chinese", "I have a lot of American-Chinese friends, so I bet they'd appreciate me trying to learn the language. Or not, who knows.");

        addQuestionResponse("Do you have a favorite poem?", "Yes, I really love Bonedog by Eva H.D.", "Bonedog");
        addQuestionResponse("Do you have a favorite poem?", "My favorite is 'I Go Back To May' by Sharon Olds.", "I Go Back To May");

        addTalkResponse("Bonedog", "You carry your weather with you,\nthe big blue whale,\na skeletal darkness.");
        addTalkResponse("I Go Back To May", "'Do what you are going to do, and I will tell about it.' I find the poem very relatable, given my parental relations.");

        addQuestionResponse("How often do you play sports?", "I play soccer with my friends sometimes.", "soccer");
        addQuestionResponse("How often do you play sports?", "I'm not really a sports person.", "aren't a sports person");

        addTalkResponse("aren't a sports person", "I just don't find it fun, I guess..");
        addTalkResponse("soccer", "It's just a nice way to get active and spend some time with my friends.");

        addQuestionResponse("What's the most interesting piece of art you've seen?", "My favorite painting is Ivan the Terrible and His Son Ivan.", "Ivan the Terrible and His Son Ivan");
        addQuestionResponse("What's the most interesting piece of art you've seen?", "Have you seen 'Saturn Devouring His Son'? It's certainly something.", "Saturn Devouring His Son");

        addTalkResponse("Ivan the Terrible and His Son Ivan", "Our bouts of anger often have permanent, irreversible consequences.");
        addTalkResponse("Saturn Devouring His Son", "The painting evokes are pretty interesting response.. it's horror in the most horrible sense.");

        addQuestionResponse("Do you like the rain?", "I love the rain, I can't stand clear skies.", "the rain");

        addTalkResponse("the rain", "It's very comforting, clear skies on the other hand make me nauseous.");
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
        if (!talkResponses.Contains(inquery))
            return "Uh oh, looks like Acerola forgot to code a response to this, or he made a typo. It's quite hard to test all of this by yourself you know.";
            
        return (string)talkResponses[inquery];
    }
}
