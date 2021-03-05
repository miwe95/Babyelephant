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
         "As you have probably already noticed, the damned corona virus is currently doing its mischief ...",
         "Our job is to free the city from the virus ...",
         "So, here are some useful tips and instructions that will help us with that ...",
         "Corona deniers are everywhere in the city who protest and we have to fight them and get points ...",
         "You will see the points bar (star) in the lower right corner of the screen ...",
         "There is also a health bar (heart) in the lower right corner of the screen, which represents my state of health ...",
         "Please use the arrow keys to navigate me through the level ...",
         "To jump, just press the space key ...",
         "I am also able to shoot. To do this, simply press e on your keyboard ...",
         "To kick the enemies please just press the q key ...",
         "And finally, there are some very useful poper-ups everywhere in the level ...",
         "Like the star that makes me jump super high and the ruby wich starts my rage mode...",
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
         if (i <= 12)
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
