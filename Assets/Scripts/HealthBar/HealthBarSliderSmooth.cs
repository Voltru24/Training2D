using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarSliderSmooth : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private Health _health;

    private Slider _slider;
    private Coroutine _workSmoothShowHealth;

    private void OnEnable()
    {
        _health.HealthChanged += ShowHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ShowHealth;
    }

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ShowHealth()
    {
        if (_workSmoothShowHealth != null)
        {
            StopCoroutine(_workSmoothShowHealth);
        }

        _workSmoothShowHealth = StartCoroutine(SmoothShowHealth(_health.Value, _health.ValueMax));
    }

    private IEnumerator SmoothShowHealth(float health, float healthMax)
    {
        float lerp = Mathf.Lerp(_slider.minValue, _slider.maxValue, health / healthMax);

        WaitForFixedUpdate wait =new WaitForFixedUpdate();

        while (_slider.value != lerp)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, lerp, _speed * Time.deltaTime);

            yield return wait;
        }
    }
}
