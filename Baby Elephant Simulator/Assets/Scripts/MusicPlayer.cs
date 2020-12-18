using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer musicPlayerInstance;

    private AudioSource audioSrc;
    private float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // DontDestroyOnLoad (this);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    private void Awake()
    {
      int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
     if (numMusicPlayers != 1)
     {
         Destroy(this.gameObject);
     }
     // if more then one music player is in the scene
     //destroy ourselves
     else
     {
         DontDestroyOnLoad(gameObject);
     }
/*
       Scene currentScene = SceneManager.GetActiveScene ();
       string sceneName = currentScene.name;
       if (sceneName == "fy_PoolParty")
       {
         DontDestroyOnLoad (transform.gameObject);
       }
*/
    }

}
