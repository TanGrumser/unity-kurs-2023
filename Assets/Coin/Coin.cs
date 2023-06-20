using UnityEngine;
using UnityEngine.SceneManagement;

public class Coin : MonoBehaviour {
    
    [SerializeField] private GameObject coinPrefab;

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("Player")) {
            GameManager.instance.IncrementScore();
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
