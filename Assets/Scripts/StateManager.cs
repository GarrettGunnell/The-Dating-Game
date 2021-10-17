﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public OptionsManager optionsManager;

    private bool idle;
    private bool talking;

    void Start() {
        idle = true;
        talking = true;
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
                    }

                    if (hit.transform.name == "Ask") {
                        Debug.Log("Ask");
                        optionsManager.Ask();
                    }

                    if (hit.transform.name == "Girl") {
                        Debug.Log("Girl");
                    }
                } else if (collided && talking) {
                    if (hit.transform.name.Contains("Option")) {
                        string chosenOption = hit.transform.name.Split(' ')[1];
                        Debug.Log(chosenOption);
                        //optionsManager.Talk();
                    }
                }

                
            }


        }
    }

    public void endGame() {
        Debug.Log("Game Over!");
    }
}
