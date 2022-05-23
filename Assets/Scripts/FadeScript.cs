using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public AnimationCurve fadeCurve = new AnimationCurve(new Keyframe(0, 1), new Keyframe(0.6f, 0.7f, -1.8f, -1.2f), new Keyframe(1, 0));

    public float alpha = 1;
    private Texture2D texture;
    private bool done;
    public float time;

    public bool fadeOut;

    public void Reset()
    {
        done = false;
        alpha = 1;
        time = 0;
    }

    public void Reverse()
    {
        done = false;
        alpha = 0;
        time = 1;
    }

    [RuntimeInitializeOnLoadMethod]
    public void RedoFade()
    {
        if (fadeOut)
        {
            Reverse();
        }
        else
        {
            Reset();
        }
    }

    public void OnGUI()
    {
        if(texture == null) { texture = new Texture2D(1, 1);  }

        texture.SetPixel(0, 0, new Color(1, 1, 1, alpha));
        texture.Apply();

        if (fadeOut)
        {
            if (!done)
            {
                time += Time.deltaTime;
                alpha = fadeCurve.Evaluate(time);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            }


            if (alpha <= 0) { done = true; }
        }
        else
        {
            if (!done)
            {
                time -= Time.deltaTime;
                alpha = fadeCurve.Evaluate(time);
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            }
            else
            {
                GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
            }


            if (alpha >= 1) { done = true; }
        }
        
    }
}
