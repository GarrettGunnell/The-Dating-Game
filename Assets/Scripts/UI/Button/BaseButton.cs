using System.Collections;
using UnityEngine;

public abstract class BaseButton: MonoBehaviour
{
    [SerializeField] protected Texture2D defaultTex, hoverTex;
    protected Material material;

    protected virtual void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    protected virtual void OnMouseOver()
    {
        material.SetTexture("_MainTex", hoverTex);
        UI.ChangeCursor(true);
    }

    protected virtual void OnMouseExit()
    {
        material.SetTexture("_MainTex", defaultTex);
        UI.ChangeCursor(false);
    }
}

public abstract class BaseMainMenuButton: BaseButton
{
    [SerializeField] protected  AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource.Stop();
    }

    protected void OnMouseDown()
    {
        audioSource.Play();
        StartCoroutine(Act());
    }

    protected abstract IEnumerator Act();
}

public abstract class BaseGameButton : BaseButton
{
    [SerializeField] protected Texture2D disabledTex;
    private bool isEnabled = false;

    protected override void Start()
    {
        base.Start();
        SetDisabled();
    }

    protected override void OnMouseOver()
    {
        if (isEnabled)
        {
            base.OnMouseOver();
        }
    }

    protected override void OnMouseExit()
    {
        if (isEnabled)
        {
            base.OnMouseExit();
        }
    }


    public void SetDisabled()
    {
        ChangeState(false, disabledTex);
    }

    public void SetEnabled()
    {
        ChangeState(true, defaultTex);
    }


    private void ChangeState(bool isActive, Texture2D texture)
    {
        isEnabled = isActive;
        material.SetTexture("_MainTex", texture);
    }
}

