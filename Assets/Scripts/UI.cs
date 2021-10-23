using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {

    public static Texture2D mouseCursor, hoverCursor;

    public Option[] optionBoxes = new Option[8];
    public Talk talkButton;
    public Leave leaveButton;

    void Start() {
        mouseCursor = Resources.Load("Cursor") as Texture2D;
        hoverCursor = Resources.Load("clickCursor") as Texture2D;
        Cursor.SetCursor(mouseCursor, new Vector2(0, 0), CursorMode.Auto);
    }

    void Update() {

    }

    public static void changeCursor(bool hover) {
        Cursor.SetCursor(hover ? hoverCursor : mouseCursor, hover ? new Vector2(0.5f, 0.5f) : new Vector2(0, 0), CursorMode.Auto);
    }

    public void enableBoxes(int count) {
        for (int i = 0; i < count; ++i) {
            optionBoxes[i].SetEnabled();
        }
    }

    public void disableBoxes(int count) {
        for (int i = 0; i < count; ++i) {
            optionBoxes[i].SetDisabled();
        }
        changeCursor(false);
    }

    public void enableTalk() {
        talkButton.SetEnabled();
    }

    public void disableTalk() {
        talkButton.SetDisabled();
        changeCursor(false);
    }

    public void enableLeave() {
        leaveButton.SetEnabled();
    }

    public void disableLeave() {
        leaveButton.SetDisabled();
        changeCursor(false);
    }
}
