using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSourcePrefab;
    private Transform audioTransform;

    public AudioClip hitSound;
    public AudioClip jumpSound;
    public AudioClip gateOpenSound;
    public AudioClip buttonSound;
    public AudioClip fruitSound;
    public AudioClip shootingSound;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        audioTransform = new GameObject("AudioSources").transform;
        audioTransform.SetParent(this.transform);
    }

    public void PlaySound(AudioClip clip, float volume = 1.0f)
    {
        AudioSource source = Instantiate(audioSourcePrefab, audioTransform);
        source.clip = clip;
        source.volume = volume;
        source.Play();

        // Destroy the AudioSource after it has finished playing
        Destroy(source.gameObject, clip.length);
    }
}
