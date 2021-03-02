using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
  private static MusicPlayer musicPlayerInstance;

  public AudioSource audioSrc;
  private float musicVolume = 1f;

  // Start is called before the first frame update
  void Start()
  {
    // DontDestroyOnLoad (this);


    AudioSource[] audios = FindObjectsOfType<AudioSource>();
    if (audios.Length > 1)
    {
      //audioSrc = GameObject.FindGameObjectWithTag("musicplayer_runforever").GetComponent<AudioSource>();
      Destroy(audios[0]);
    }
    // if more then one music player is in the scene
    //destroy ourselves
    else
    {
      DontDestroyOnLoad(audioSrc.gameObject);
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


  // Update is called once per frame
  void Update()
  {
    audioSrc.volume = musicVolume;
  }

  public void SetVolume(float vol)
  {
    musicVolume = vol;
  }
}
