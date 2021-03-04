using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeansBar : MonoBehaviour
{
    public Slider slider;
    
    public void setMaxBean(int bean)
    {
      slider.maxValue = bean;
      slider.value = bean;
    }
    
    public void setBean(int bean)
    {
      slider.value = bean;
    }
    
}
