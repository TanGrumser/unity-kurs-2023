using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float acceleration = 0.5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float jumpStrength = 5f;

    private Rigidbody2D rb;
    private Animator animator;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private GameObject gameOverText;

    [SerializeField] private int maxJumps = 2;
    private int jumps = 0;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update() {
        float inputDirection = Input.GetAxis("Horizontal");

        if (inputDirection < 0) {
            sr.flipX = true;
        } else if (inputDirection > 0) {
            sr.flipX = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        //transform.position += Vector3.right * inputDirection * speed * Time.deltaTime;
        rb.AddForce(Vector2.right * inputDirection * acceleration, ForceMode2D.Force);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
            float xVelocity = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
            rb.velocity = new Vector2(xVelocity, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

    }

    private void Jump() {
        if (jumps <= 0) {
            return;
        }

        rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        jumps--;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        jumps = maxJumps;
    }
}
