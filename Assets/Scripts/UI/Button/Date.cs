using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Date : BaseMainMenuButton
{
    protected override IEnumerator Act()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene("MainGame");
    }
}
