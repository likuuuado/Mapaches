using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health target;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.maxValue = target.maxHealth;
    }

    void Update()
    {
        slider.value = target.CurrentHealth;
    }
}