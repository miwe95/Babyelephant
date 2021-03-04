﻿// SOURCE: https://www.youtube.com/watch?v=ZVh4nH8Mayg&feature=youtu.be

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
   private Text messageT;
   private static int i = 0;
   string message;
   private AudioSource talking;
   
   private TextWriting.TextWritingSingle tws;
   
   string[] messageArray = new string[]
       {
         "As you have probably already noticed, the damned Corona Virus is currently up to mischief ...",
         "And yes, we have to do something about that ...",
         "So, our job is to free the city from this f#&$ing Virus ...",
         "It won't be easy, but ...",
         "Together we can do it!",
         "Alright?",
         "Let's go!",
       };
   
   
   private void Awake()
   {
     messageT = transform.Find("message").Find("messageT").GetComponent<Text>();
     talking = transform.Find("Voice").GetComponent<AudioSource>();
     
     transform.Find("message").GetComponent<Button_UI>().ClickFunc = () =>
     {
       if (tws != null && tws.IsActive())
       {
         tws.WriteAndDestroy();
       }
       else
       {
         if (i <= 5)
       {
         message = messageArray[i];
         StartTalkingSound();
         tws = TextWriting.AddWritingStatic(messageT, message, .05f, true, true, StopTalkingSound);
         
         i += 1;
       }
       else
       {
         float seconds = .4f;
         StartCoroutine(_wait(seconds));
         //test();
       }
       }
       
       
     };

   }
   
   private void Start()
   {
   StartTalkingSound();
     tws = TextWriting.AddWritingStatic(messageT, "Hello Folks! \n" + "Just click somewhere inside the bubble to continue …", .05f, true, true, StopTalkingSound);
   }
   
   IEnumerator _wait(float time)
   {
     message = messageArray[i];
     StartTalkingSound();
     tws = TextWriting.AddWritingStatic(messageT, message, .05f, true, true, StopTalkingSound);
     yield return new WaitForSeconds(time);
     SceneManager.LoadScene("MainMenu");
   }
   /*
   private void test()
   {
     message = messageArray[i];
     TextWriting.AddWritingStatic(messageT, message, .05f, true);
     //yield WaitForSeconds(5);
     SceneManager.LoadScene("MainMenu");
   }
   */
   
   private void StartTalkingSound()
   {
     talking.Play();
   }
   
   private void StopTalkingSound()
   {
     talking.Stop();
   }
   

}
