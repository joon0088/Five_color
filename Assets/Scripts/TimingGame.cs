using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingGame : MonoBehaviour
{
    public RectTransform circleBackground;
    public RectTransform circlePlayer;
    public Button stopButton;
    public Button restartButton;

    private bool increaseCircleSize;

    [HideInInspector]
    public bool stopButtonClicked = false;

    public Button nextButton;

    private void Update()
    {

        if (stopButtonClicked == false)
        {

            if (circlePlayer.localScale.x >= 10)
            {
                if (increaseCircleSize == true)
                {
                    Debug.Log("sizeIncrese = false");
                    increaseCircleSize = false;
                }
            }
            else if (circlePlayer.localScale.x < 3)
            {
                if (increaseCircleSize == false)
                {
                    Debug.Log("sizeIncrese = false");
                    increaseCircleSize = true;
                }
            }

            ChangeCircleSize();
        }
    }



    public void ChangeCircleSize()
    {
        if (increaseCircleSize == true)
        {
            circlePlayer.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
        else if (increaseCircleSize == false)
        {
            circlePlayer.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
    }

    public void StopButtonClick()
    {
        stopButtonClicked = true;

        CheckCircleSize();
    }

    public void CheckCircleSize()
    {
        if (Mathf.Abs(circleBackground.localScale.x - circlePlayer.localScale.x) < 1)
        {
            Debug.Log("Pass!");
            // Next Stage
            nextButton.gameObject.SetActive(true);
            stopButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
        else
        {
            stopButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }

    public void RestartButtonClick()
    {
        stopButtonClicked = false;

        stopButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
    }
}
