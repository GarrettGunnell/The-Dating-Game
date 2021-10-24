using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait : MonoBehaviour {

    float x, y;
    Vector3 pos;
    
    void Start() {
        pos = transform.position;
    }

    void Update() {
        if ( 0 < Input.mousePosition.x && Input.mousePosition.x < Screen.width && 0 < Input.mousePosition.y && Input.mousePosition.y < Screen.height) {
            float targetX = Input.mousePosition.x - Screen.width * 0.75f;
            float dx = targetX - x;
            x += dx * 0.05f;
            float targetY = Input.mousePosition.y - Screen.height / 2.0f;
            float dy = targetY - y;
            y += dy * 0.05f;

            Vector3 direction = new Vector3(x, y, 0.0f);
            direction.y *= 1 / 500.0f * 0.2f;
            direction.x *= 1 / 500.0f * 0.7f;
            this.transform.position = pos - direction;
        }
    }
}
