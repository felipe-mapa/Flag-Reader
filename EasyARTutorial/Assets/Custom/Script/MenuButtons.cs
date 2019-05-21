using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour {
    public static MenuButtons instance;
    public Button startButton;
    public Button listButton;
    public Button quitButton;
    public CanvasGroup uiElement;

    private Canvas menuCanvas;

    private void Awake() {
        menuCanvas = GetComponent<Canvas>();
        startButton.onClick.AddListener(() => disableCanvas());
        listButton.onClick.AddListener(() => quitApp());
        quitButton.onClick.AddListener(() => quitApp());

        instance = this;
    }

    private void disableCanvas(){
        FadeOut();
    }

    private void quitApp() {
        Application.Quit();
    }

    public void FadeOut(){
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
        uiElement.blocksRaycasts = false;
        uiElement.interactable = false;
    }

    public void FadeIn(){
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
        uiElement.blocksRaycasts = true;
        uiElement.interactable = true;
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f){
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while(true){
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if(percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
    }
}
