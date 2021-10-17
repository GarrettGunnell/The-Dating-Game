using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ask : MonoBehaviour {

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Ask") {
                    Debug.Log("Ask");
                }
            }
        }
    }
}
