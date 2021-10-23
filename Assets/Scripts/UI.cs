using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public Texture2D mouseCursor;

    Vector2 hotSpot = new Vector2(0, 0);
    CursorMode cursorMode = CursorMode.Auto;

    // Start is called before the first frame update
    void Start() {
        Cursor.SetCursor(mouseCursor, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
