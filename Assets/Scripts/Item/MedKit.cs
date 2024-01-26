using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.AddHealth(_value);

            Destroy(gameObject);
        }
    }
}
