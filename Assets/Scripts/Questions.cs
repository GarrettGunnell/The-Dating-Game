using System.Collections;
using System.Collections.Generic;

public class Questions {

    public Questions() {
        
    }

    public List<string> generateQuestions() {
        List<string> qs = new List<string>();

        qs.Add("What's your name?");
        qs.Add("What do you like to do in your free time?");
        qs.Add("What's a movie you really enjoyed?");
        qs.Add("Do you have any pets?");
        qs.Add("Have you ever been out of the country?");
        qs.Add("Are you a morning person?");

        return qs;
    }
}
