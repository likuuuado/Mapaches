using UnityEngine;
using UnityEngine.UI;

public class AngerBar : MonoBehaviour
{
    public Anger target;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Start()
    {
        slider.maxValue = target.maxAnger;
    }

    void Update()
    {
        slider.value = target.CurrentAnger; 
    }
}
