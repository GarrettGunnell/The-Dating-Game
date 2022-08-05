using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI : MonoBehaviour
{
    private const int minutePerQuestion = 5;

    private static Texture2D mouseCursor, hoverCursor;

    [SerializeField] private Option[] optionBoxes = new Option[8];
    [SerializeField] private Talk talkButton;
    [SerializeField] private Leave leaveButton;

    [SerializeField] private Text dateBox, timeBox;

    [SerializeField] private int hour = 5;
    [SerializeField] private int minute = 0;

    private string currentTime => $"{hour:D2}:{minute:D2}";

    private void Start()
    {
        ChangeCursor(false);

        DateTime randomDate = new DateTime(2022, 1, 1).AddDays(Random.Range(0, 364));
        dateBox.text = $"{randomDate.Month:D2}/{randomDate.Day:D2}";

        timeBox.text = currentTime;
    }

    public static void ChangeCursor(bool hover)
    {
        if (mouseCursor == null)
        {
            mouseCursor = Resources.Load("Cursor") as Texture2D;
            hoverCursor = Resources.Load("clickCursor") as Texture2D;
        }
        var texture = hover ? hoverCursor : mouseCursor;
        var hotspot = hover ? new Vector2(0.5f, 0.5f) : new Vector2(0, 0);
        Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
    }

    public void EnableBoxes(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            optionBoxes[i].SetEnabled();
        }
    }

    public void DisableBoxes(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            optionBoxes[i].SetDisabled();
        }
        ChangeCursor(false);
    }

    public void EnableTalk()
    {
        EnableButton(talkButton);
    }

    public void DisableTalk()
    {
        DisableButton(talkButton);
    }

    public void EnableLeave()
    {
        EnableButton(leaveButton);
    }

    public void DisableLeave()
    {
        DisableButton(leaveButton);
    }

    private void EnableButton(BaseGameButton button)
    {
        button.SetEnabled();
    }

    private void DisableButton(BaseGameButton button)
    {
        button.SetDisabled();
        ChangeCursor(false);
    }

    public void IncrementTime()
    {
        minute += minutePerQuestion;
        if (minute >= 60)
        {
            hour++;
            minute = 0;
        }
        timeBox.text = currentTime;
    }
}
