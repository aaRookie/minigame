using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource m_audioSource;

    public AudioClip m_button1;
    public AudioClip m_button2;

    private void Awake()
    {
        Instance = this;
        m_audioSource = this.GetComponent<AudioSource>();

    }

    public void PlayButton1()
    {
        m_audioSource.PlayOneShot(m_button1);
    }

    public void PlayButton2()
    {
        m_audioSource.PlayOneShot(m_button2);
    }
}
