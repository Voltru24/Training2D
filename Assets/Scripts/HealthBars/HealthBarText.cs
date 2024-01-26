using TMPro;
using UnityEngine;
[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthBarText : HealthBar
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    public override void ShowHealth(float health, float healthMax)
    {
        _text.text = $"{health} / {healthMax}";
    }
}
