using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public OptionsManager optionsManager;

    private bool idle, talking, asking;

    void Start() {
        idle = true;
        talking = asking = false;
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool collided = Physics.Raycast(ray, out hit);

        if (Input.GetMouseButtonDown(0)) {
            if (idle) {
                if (collided && !(talking || asking)) {
                    if (hit.transform.name == "Talk") {
                        optionsManager.Talk();
                        setIdle(false);
                        talking = true;
                    } else if (hit.transform.name == "Ask") {
                        optionsManager.Ask();
                        setIdle(false);
                        asking = true;
                    } else if (hit.transform.name == "Girl") {
                        Debug.Log("Girl");
                    }
                } else if (collided && (talking || asking)) {
                    if (hit.transform.name.Contains("Option")) {
                        int chosenOption = int.Parse(hit.transform.name.Split(' ')[1]);
                        optionsManager.Choose(chosenOption - 1, asking);
                        setIdle(false);
                        talking = asking = false;
                    }
                }
            }
        }
    }

    public void setIdle(bool state) {
        Debug.Log("Setting idle to: " + state);
        idle = state;
    }

    public void endGame() {
        Debug.Log("Game Over!");
    }
}
