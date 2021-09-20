using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Galaxy
{

    internal class HealthBar : MonoBehaviour
    {
        public Slider slider;
        public Gradient gradient;

        public Image image;

        public void SetMaxHealth(Health hp)
        {
            slider.maxValue = hp.Max;
            slider.value = slider.maxValue;

            image.color = gradient.Evaluate(1f);
        }

        public void SetHealth(float hp)
        {
            slider.value = hp;

            image.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}