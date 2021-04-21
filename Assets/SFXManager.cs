using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : Singleton<SFXManager>
{

    public AudioClip victory;
    public AudioClip fail;
    public AudioClip victoryWindow;
    public AudioClip failWindow;
    AudioSource audioSource;
    public void playVictory()
    {
        if (victory)
        {

            audioSource.PlayOneShot(victory);
        }
    }
    public void playFail()
    {
        audioSource.PlayOneShot(fail);
    }
    public void playVictoryWindow()
    {
        audioSource.PlayOneShot(victoryWindow);
    }
    public void playFailWindow()
    {
        audioSource.PlayOneShot(failWindow);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
