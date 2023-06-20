using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private float speed = 2f;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("EnemyTrigger")) {
            speed *= -1;
            sr.flipX = !sr.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            // if the player jumps on the enemy
            if (collision.relativeVelocity.y < -0.1) {
                GameManager.instance.IncrementScore();
                Destroy(gameObject);
            } else {
                GameManager.instance.GameOver();
            }
        }
    }
}
