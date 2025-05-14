using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public GameObject attackPrefab;
    public Transform attackSpawnPoint;

    public bool isGameStarted = false;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isGameStarted) return;

        
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

       
        bool jumpInputPC = Input.GetKeyDown(KeyCode.Space);

       
        bool jumpInputMobile = false;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            jumpInputMobile = true;
        }

        
        if (isGrounded && (jumpInputPC || jumpInputMobile))
        {
            PerformJumpAndAttack();
        }
    }

      private void PerformJumpAndAttack()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        GameObject attack = Instantiate(attackPrefab, attackSpawnPoint.position, Quaternion.identity);
        attack.transform.localScale = transform.localScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}
