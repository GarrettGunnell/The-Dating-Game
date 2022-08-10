using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

    public OptionsManager optionsManager;

    private bool idle, talking;

    private int actionNumber = 0;

    private AudioSource audioSource;

    private void Start() {
        idle = false;
        talking = false;
        
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void Update() {
        if (actionNumber >= 36 && idle && !talking) {
            idle = false;
            optionsManager.Win();
        } else {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            bool collided = Physics.Raycast(ray, out hit);

            if (Input.GetMouseButtonDown(0)) {
                if (idle) {
                    if (collided && !talking) {
                        if (hit.transform.name == "Talk") {
                            audioSource.Play();
                            SetIdle(false);
                            talking = true;
                            actionNumber++;
                            optionsManager.Talk(actionNumber);
                        } else if (hit.transform.name == "Leave") {
                            audioSource.Play();
                            SetIdle(false);
                            optionsManager.Leave();
                        }
                    } else if (collided && talking) {
                        if (hit.transform.name.Contains("Option")) {
                            audioSource.Play();

                            int chosenOption = int.Parse(hit.transform.name.Split(' ')[1]);
                            optionsManager.Choose(chosenOption - 1);
                            SetIdle(false);
                            talking = false;
                        }
                    }
                }
            }
        }
    }

    public void SetIdle(bool state) {
        //Debug.Log("Setting idle to: " + state);
        idle = state;
    }

    public void EndGame(bool victory, string reason) {
        SceneManager.LoadScene(victory ? "Victory" : "GameOver");
    }
}
