using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public float lifetime = 0.5f;

    private void Start() {

        Destroy(gameObject, lifetime);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 knockbackDirection = new Vector2(1f, 2f).normalized;
                rb.AddForce(knockbackDirection * 12f, ForceMode2D.Impulse);
            }

            Destroy(collision.gameObject, 1.5f);
            GameManager.Instance.AddScore(10);
        }
    }
}
