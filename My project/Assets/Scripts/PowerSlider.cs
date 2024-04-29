using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PowerSlider : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] GameObject Plumber;
    void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }
    void Start()
    {
        _slider.value = _slider.maxValue;
        Plumber.GetComponent<Plumber>().LaunchMultiplier = _slider.value;
    }
    private void HandleSliderValueChanged(float value)
    {
        Plumber.GetComponent<Plumber>().LaunchMultiplier = value;
    }
}
