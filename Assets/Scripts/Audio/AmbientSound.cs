using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSound : ManagerSound
{
    [SerializeField] private AudioClip sound;
    [SerializeField] private float volume = 1f; 
    [SerializeField] private float timeEffectSlow = 1.4f; 
    void Start()
    {
        base.InitializeAudioSource();
        InitializeAmbientSound();
    }

    private void InitializeAmbientSound()
    {
        if(sound != null)
        {
            Debug.Log("Entra al sound");
            base.audioSource.clip = sound;
            base.audioSource.loop =  true;
            base.audioSource.volume = volume;
            PlaySound();
        }

    }

    public void setVolume(float value)
    {
        volume = value;
    }

    public float getVolume()
    {
        return volume;
    }

    public void PauseGame()
    {
        StopAllCoroutines();
        StartCoroutine(IEPauseGame());
        Debug.Log("entro a pause");
    }

    public void ResumeGame()
    {
        StopAllCoroutines();
        StartCoroutine(IEResumeGame());
    }

    public void PlaySound()
    {
        base.audioSource.Play();
    }

    IEnumerator IEPauseGame()
    {

        float startPitch = audioSource.pitch;
        float startVolume = audioSource.volume;

        float durationEffectSlow = timeEffectSlow;

        for (float t = 0; t < durationEffectSlow; t += Time.unscaledDeltaTime)
        {
            audioSource.pitch = Mathf.Lerp(startPitch, 0.5f, t / durationEffectSlow);
            audioSource.volume = Mathf.Lerp(startVolume, 0.2f, t / durationEffectSlow);
            yield return null;
        }

        audioSource.pitch = 0.5f;
        audioSource.volume = 0.2f;
        audioSource.Pause();
    }
        IEnumerator IEResumeGame()
    {
        float durationEffectSlow = timeEffectSlow;

        audioSource.UnPause();
        float startPitch = audioSource.pitch;
        float startVolume = audioSource.volume;

        for (float t = 0; t < durationEffectSlow; t += Time.unscaledDeltaTime)
        {
            audioSource.pitch = Mathf.Lerp(startPitch, 1f, t / durationEffectSlow);
            audioSource.volume = Mathf.Lerp(startVolume, 1f, t / durationEffectSlow);
            yield return null;
        }

        audioSource.pitch = 1f;
        audioSource.volume = getVolume();

    }


}
