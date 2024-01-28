using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health;

        if (TryGetComponent<Health>(out health))
        {
            health.AddHealth(_value);

            Destroy(gameObject);
        }
    }
}
