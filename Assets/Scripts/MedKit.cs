using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _value = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.AddHealth(_value);

            Destroy(gameObject);
        }
    }
}
