using System.Collections;
using UnityEngine;

public class Flake : BaseMainMenuButton
{
    protected override IEnumerator Act()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Application.Quit();
    }
}
