using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Credits : MonoBehaviour
{

    [SerializeField] private VideoPlayer vidPlayer;
    [SerializeField] private ColorSchemer colorSchemer;

    private void Update()
    {
        if (vidPlayer.frame > 0 && vidPlayer.isPlaying == false)
        {
            colorSchemer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
