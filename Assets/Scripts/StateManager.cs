using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

    public OptionsManager optionsManager;

    void Start() {
        
    }

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Talk") {
                    Debug.Log("Talk");
                    optionsManager.Talk();
                }

                if (hit.transform.name == "Ask") {
                    Debug.Log("Ask");
                }

                if (hit.transform.name == "Girl") {
                    Debug.Log("Girl");
                }
            }
        }
    }
}
