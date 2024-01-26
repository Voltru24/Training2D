using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSliderSmooth : HealthBar
{
    [SerializeField] private float _speed = 1;

    private Slider _slider;
    private Coroutine _workSmoothShowHealth;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public override void ShowHealth(float health, float healthMax)
    {
        if (_workSmoothShowHealth != null)
        {
            StopCoroutine(_workSmoothShowHealth);
        }

        _workSmoothShowHealth = StartCoroutine(SmoothShowHealth(health, healthMax));
    }

    private IEnumerator SmoothShowHealth(float health, float healthMax)
    {
        float lerp = Mathf.Lerp(_slider.minValue, _slider.maxValue, health / healthMax);

        while (_slider.value != lerp)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, lerp, _speed * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
