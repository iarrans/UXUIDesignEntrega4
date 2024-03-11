using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenScripts : MonoBehaviour
{

    public Slider loadingBar;
    public GameObject StartButton;
    public Sprite PressedStartSprite;

    // Start is called before the first frame update
    private void Start()
    {
        StartButton.SetActive(false);
        StartCoroutine(LoadingBar());
    }

    private IEnumerator LoadingBar()
    {
        loadingBar.gameObject.SetActive(true);
        loadingBar.value = 0;
        while (loadingBar.value < 1)
        {
            loadingBar.value += 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        loadingBar.gameObject.SetActive(false);
        StartButton.SetActive(true);
    }

    public void LoadMainMenu()
    {
        StartCoroutine(MainMenu());
    }

    private IEnumerator MainMenu()
    {
        StartButton.GetComponent<Image>().sprite = PressedStartSprite;
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("MainMenu");
    }
}
