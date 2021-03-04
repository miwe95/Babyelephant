// SOURCE: https://www.youtube.com/watch?v=ZVh4nH8Mayg&feature=youtu.be

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextWriting : MonoBehaviour
{

private static TextWriting inst;
private List<TextWritingSingle> twsList;

private void Awake()
{
  inst = this;
  twsList = new List<TextWritingSingle>();
}

  public static TextWritingSingle AddWritingStatic(Text uiText, string textWrite, float timeForChar, bool invChar, bool removeWriterBevoreAdd, Action onComplete)
  {
    if (removeWriterBevoreAdd)
    {
      inst.RemoveWriter(uiText);
    }
    return inst.AddWriting(uiText, textWrite, timeForChar, invChar, onComplete);
  }
  
  
  private TextWritingSingle AddWriting(Text uiText, string textWrite, float timeForChar, bool invChar, Action onComplete)
  {
    TextWritingSingle tws = new TextWritingSingle(uiText, textWrite, timeForChar, invChar, onComplete);
    twsList.Add(tws);
    return tws;
  }
  
  public static void RemoveWriter_Static(Text uiText)
  {
    inst.RemoveWriter(uiText);
  }
  
  private void RemoveWriter(Text uiText)
  {
    for (int i = 0; i < twsList.Count; i++)
    {
      if (twsList[i].getUIText() == uiText)
      {
        twsList.RemoveAt(i);
        i--;
      }
    }
  }
  
  private void Update()
  {
    for (int i = 0; i < twsList.Count; i++)
    {
      bool destroyInstance = twsList[i].Update();
      
      if (destroyInstance)
      {
        twsList.RemoveAt(i);
        i--;
      }
        
    }
   
  }
  
  // A SINGLE TEXT WRITER:
  public class TextWritingSingle
  {
  
  private float timeForChar;
  private string textWrite;
  private Text uiText;
  private float time;
  private int charidx;
  private bool invChar;
  private Action onComplete;
  
    public TextWritingSingle(Text uiText, string textWrite, float timeForChar, bool invChar, Action onComplete)
    {
    this.uiText = uiText;
    this.textWrite = textWrite;
    this.timeForChar = timeForChar;
    this.invChar = invChar;
    this.onComplete = onComplete;
    charidx = 0;
    }
  
  // if list is complete == true
  public bool Update()
  {
  time -= Time.deltaTime;
  
      while (time <= 0f)
      {
        time += timeForChar;
        charidx++;
        string text = textWrite.Substring(0, charidx);
        if (invChar)
        {
          text += "<color=#00000000>" + textWrite.Substring(charidx) + "</color>";
        }
        
        uiText.text = text;
        
        
        if (charidx >= textWrite.Length)
        {
          if (onComplete != null) onComplete();
          
          return true;
        }
      }
   return false;
  }
  
  public Text getUIText()
  {
    return uiText;
  }
  
  public bool IsActive()
  {
    return charidx < textWrite.Length;
  }
  
  public void WriteAndDestroy()
  {
    uiText.text = textWrite;
    charidx = textWrite.Length;
    if (onComplete != null) onComplete();
    TextWriting.RemoveWriter_Static(uiText);
  }
  
  }
  

}
