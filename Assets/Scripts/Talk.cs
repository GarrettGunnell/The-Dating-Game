using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {

    public KnowledgeManager m_knowledgeManager;

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.transform.name == "Talk") {
                    Debug.Log("Talk");
                    Debug.Log(m_knowledgeManager.generateTalkingPoint());
                }
            }
        }
    }
}
