using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlamethrowerGaugeUI : MonoBehaviour
{
    [SerializeField] private AnimationCurve ease;
    [SerializeField] private float updateDuration;
    [SerializeField] private Slider slider;

    private float prevFillRate;

    void OnEnable() =>
        FlamethrowerGauge.FuelUpdate += UpdateFuelGauge;

    private void OnDisable() =>
        FlamethrowerGauge.FuelUpdate -= UpdateFuelGauge;

    public void UpdateFuelGauge() => 
        StartCoroutine(UpdateGaugeViewCoroutine());

    IEnumerator UpdateGaugeViewCoroutine()
    {
        float elapsed = 0f;
        prevFillRate = FlamethrowerGauge.instance.fillRate;

        while (elapsed < updateDuration)
        {
            elapsed += Time.deltaTime;
            slider.value = ease.Evaluate(elapsed / updateDuration) * (FlamethrowerGauge.instance.fillRate - prevFillRate) + prevFillRate;
            yield return null;
        }
    }
}
