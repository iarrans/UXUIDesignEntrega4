using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;

    public AudioSource BGMSource;
    public AudioSource SFXSource;

    public Slider BGM_Slider;
    public Slider SFX_Slider;

    public AudioClip MenuMusic;
    public List<AudioClip> SoundEffectList;
    public List<AudioClip> MusicPreviews;

    private void Awake()
    {
        AudioManager.instance = this;
    }

    public void ChangeBGMValue()
    {
        BGMSource.volume = BGM_Slider.value;
    }

    public void ChangeSFXValue()
    {
       SFXSource.volume = SFX_Slider.value;
    }

    public void ButtonSoundEffect()
    {
        SFXSource.clip = SoundEffectList[0];
        SFXSource.Play();
    }

    public void ButtonBackSoundEffect()
    {
        SFXSource.clip = SoundEffectList[1];
        SFXSource.Play();
    }
    public void PopUpSoundEffect()
    {
        SFXSource.clip = SoundEffectList[2];
        SFXSource.Play();
    }

    public void PlaySongPreview(int index)
    {
        StopAllCoroutines();
        StartCoroutine(SongPreview(index));
    }

    private IEnumerator SongPreview(int index)
    {
        BGMSource.clip = MusicPreviews[index];
        BGMSource.Play();
        yield return new WaitForSeconds(7);
        RestoreBGMusic();
;
    }

    public void RestoreBGMusic()
    {
        BGMSource.clip = MenuMusic;
        BGMSource.Play();
    }
}
