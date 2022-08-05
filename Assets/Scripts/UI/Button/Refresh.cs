using UnityEngine;
//TODO move to same as other button structure
public class Refresh : MonoBehaviour {

    public AudioSource audioSource;
    public ColorSchemer colorSchemer;

    void Start() {
        audioSource.Stop();
    }

    void OnMouseOver() {
        UI.ChangeCursor(true);
    }

    void OnMouseExit() {
        UI.ChangeCursor(false);
    }

    void OnMouseDown() {
        audioSource.Play();
        colorSchemer.Refresh();
    }
}
