using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FavorBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    // Start is called before the first frame update
    public void SetMaxFavor(int favor){
        slider.maxValue = favor;
        slider.value = favor;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetFavor(int favor){
        slider.value = favor;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
