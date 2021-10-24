using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
    
    public static Texture2D mouseCursor, hoverCursor;
    
    void Start() {
        mouseCursor = Resources.Load("Cursor") as Texture2D;
        hoverCursor = Resources.Load("clickCursor") as Texture2D;
        Cursor.SetCursor(mouseCursor, new Vector2(0, 0), CursorMode.Auto);
    }

    public static void changeCursor(bool hover) {
        Cursor.SetCursor(hover ? hoverCursor : mouseCursor, hover ? new Vector2(0.5f, 0.5f) : new Vector2(0, 0), CursorMode.Auto);
    }
}
