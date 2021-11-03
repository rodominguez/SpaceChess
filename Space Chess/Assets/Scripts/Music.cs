using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    private static Music instance;

    [SerializeField] private List<AudioClip> clips = new List<AudioClip>();
    [SerializeField] private AudioSource audioSource;

    private int index = 0;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            if (clips.Count > 0)
            {
                audioSource.clip = clips[index];
                audioSource.Play();
                IncreaseIndex();
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = clips[index];
            audioSource.Play();
            IncreaseIndex();
        }
    }

    private void IncreaseIndex()
    {
        if (index + 1 >= clips.Count)
            index = 0;
        else
            index++;
    }
}
