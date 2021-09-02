using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Galaxy
{
    internal class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxHealth(Health hp)
        {
            slider.maxValue = hp.Max;
            slider.value = slider.maxValue;
        }
    }
}