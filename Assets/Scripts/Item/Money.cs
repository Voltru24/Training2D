using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();

        if (player != null)
        {
            player.AddMoney(_value);

            Destroy(gameObject);
        }
    }
}
