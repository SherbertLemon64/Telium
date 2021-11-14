using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarUI : MonoBehaviour
{
    [SerializeField] private AnimationCurve ease;
    [SerializeField] private float updateDuration;
    [SerializeField] private Slider slider;

    private int prevHitpoints;

    private void Update()
    {
        if (Player.Instance.Health != prevHitpoints)
        {
            StartCoroutine("UpdateHealthbar");
        }
    }

    IEnumerator UpdateHealthbar()
    {
        float elapsed = 0f;
        prevHitpoints = Player.Instance.Health;

        while (elapsed < updateDuration)
        {
            elapsed += Time.deltaTime;
            slider.value = ease.Evaluate(elapsed / updateDuration) * (Player.Instance.Health - prevHitpoints) + prevHitpoints;
            yield return null;
        }
    }
}
