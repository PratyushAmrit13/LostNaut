using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour

{
    public Slider slider;
    public void SetMaxOxygen(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;
    }
    
   public void SetOxygen(int amount)
    {
        slider.value = amount;
    }
}
