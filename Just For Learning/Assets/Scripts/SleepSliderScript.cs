using UnityEngine;
using UnityEngine.UI;

public class SleepSliderScript : MonoBehaviour
{
    public SimpleHealthScript healthScript;

    public Image sliderImage;

    private void Start()
    {
        sliderImage.fillAmount = 1;

        healthScript.OnHealthChanged += OnHealthChanged;
    }


    private void OnDestroy()
    {
        healthScript.OnHealthChanged -= OnHealthChanged;

    }

    private void OnHealthChanged(float maxHealth, float changeAmount)
    {
        sliderImage.fillAmount += changeAmount / maxHealth;
    }
}
