using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public OptionsManager optionsManager;

    private bool idle;
    private bool talking;

    void Start() {
        idle = true;
        talking = false;
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool collided = Physics.Raycast(ray, out hit);

        if (Input.GetMouseButtonDown(0)) {
            if (idle) {
                if (collided && !talking) {
                    if (hit.transform.name == "Talk") {
                        Debug.Log("Talk");
                        optionsManager.Talk();
                        //setIdle(false);
                        talking = true;
                    } else if (hit.transform.name == "Ask") {
                        Debug.Log("Ask");
                        optionsManager.Ask();
                        //setIdle(false);
                        talking = true;
                    } else if (hit.transform.name == "Girl") {
                        Debug.Log("Girl");
                    }
                } else if (collided && talking) {
                    if (hit.transform.name.Contains("Option")) {
                        int chosenOption = int.Parse(hit.transform.name.Split(' ')[1]);
                        
                        Debug.Log("Chose option: " + chosenOption);
                        Debug.Log(optionsManager.getOption(chosenOption - 1));

                        optionsManager.Choose(chosenOption - 1);
                        setIdle(false);
                    }
                }
            }
        }
    }

    public void setIdle(bool state) {
        idle = state;
    }

    public void endGame() {
        Debug.Log("Game Over!");
    }
}
