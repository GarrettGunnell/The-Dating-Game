using UnityEngine;

public class Portrait : MonoBehaviour {

    private float x, y;
    private Vector3 pos;
    
    private void Start() {
        pos = transform.position;
    }

    private void Update() {
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
            transform.position = pos - direction;
        }
    }
}
