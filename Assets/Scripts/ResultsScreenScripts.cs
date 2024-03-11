using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsScreenScripts : MonoBehaviour
{
    public TextMeshProUGUI totalPoints;
    public TextMeshProUGUI newHighscore;
    public TextMeshProUGUI NewRange;
    public TextMeshProUGUI NewGlobalPos;

    public GameObject MenuButton;
    public GameObject ReplayButton;
    public GameObject Martian;

    private void Start()
    {
        StartCoroutine(ResultsSequence());
    }

    // Update is called once per frame
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public IEnumerator ResultsSequence()
    {
        AudioManager.instance.SFXSource.clip = AudioManager.instance.SoundEffectList[2];
        totalPoints.gameObject.SetActive(true);
        totalPoints.text = "Total points:";
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.SFXSource.Play();
        totalPoints.text = "Total points:\n651274";
        yield return new WaitForSeconds(0.5f);
        AudioManager.instance.SFXSource.Play();
        newHighscore.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        AudioManager.instance.SFXSource.Play();
        NewRange.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        AudioManager.instance.SFXSource.Play();
        NewGlobalPos.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        MenuButton.SetActive(true);
        ReplayButton.SetActive(true);
        Martian.SetActive(true);
    }
}
