using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player;

        if (TryGetComponent<Player>(out player))
        {
            player.AddMoney(_value);

            Destroy(gameObject);
        }
    }
}
