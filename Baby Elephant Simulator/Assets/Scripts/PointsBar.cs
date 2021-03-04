using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsBar : MonoBehaviour
{

    public Slider slider;
    
    public void setMaxPoint(int point)
    {
      slider.maxValue = point;
      slider.value = point;
    }
    
    public void setPoint(int point)
    {
      slider.value = point;
    }
}
