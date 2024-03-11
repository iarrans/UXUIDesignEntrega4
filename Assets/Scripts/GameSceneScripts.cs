using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneScripts : MonoBehaviour
{
    public float tiempoRestante;
    public float tiempoTranscurrido;
    public TextMeshProUGUI textoTiempo;

    // Start is called before the first frame update
    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        //if (DirectorNoteSpawner.instance.areNotesLoaded) {       
        tiempoRestante -= Time.deltaTime; //para saber cuánto tiempo queda de la canción
        tiempoTranscurrido += Time.deltaTime; //para llevar la cuenta de la canción, para poder spawnear la nota a tiempo
        //}

        //parseo del tiempo a formato contador
        int minutos = Mathf.Max(Mathf.FloorToInt(tiempoRestante / 60), 0);     //Extraemos los minutos
        int segundos = Mathf.Max(Mathf.FloorToInt(tiempoRestante % 60), 0);    //Extraemos los segundos
        if (segundos >= 10) textoTiempo.text = minutos + ":" + segundos;                    //Si los segundos son mayores o iguales que 10, concatenamos y construimos el texto
        else textoTiempo.text = minutos + ":" + "0" + segundos;                             //Si los segundos son menors que 10, añadimos un 0 a nuestros segundos, concatenamos

        if (tiempoRestante <=0) //Cuando acaba la canción, se considera que el nivel ha terminado.
        {
            
            StartCoroutine(FinNivel());
        }
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        AudioManager.instance.BGMSource.Pause();
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        AudioManager.instance.BGMSource.Play();
    }

    private IEnumerator FinNivel()
    {
        textoTiempo.text = "Fin";
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ResultsScreen");
    }
}
