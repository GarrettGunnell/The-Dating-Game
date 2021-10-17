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
                    } else if (hit.transform.name == "Ask") {
                        Debug.Log("Ask");
                        optionsManager.Ask();
                    } else if (hit.transform.name == "Girl") {
                        Debug.Log("Girl");
                    }
                } else if (collided && talking) {
                    if (hit.transform.name.Contains("Option")) {
                        string chosenOption = hit.transform.name.Split(' ')[1];
                        Debug.Log(chosenOption);
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
