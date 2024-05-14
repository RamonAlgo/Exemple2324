using System.Collections;
using UnityEngine;

public class MonedaController : MonoBehaviour
{
    private float speed = 6f;
    private Vector3[] directions = new Vector3[4];
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        directions[0] = new Vector3(1, 1, 0).normalized;
        directions[1] = new Vector3(1, -1, 0).normalized;
        directions[2] = new Vector3(-1, -1, 0).normalized;
        directions[3] = new Vector3(-1, 1, 0).normalized;

        StartCoroutine(ChangeDirection());
        Destroy(gameObject, 6f);
    }

    void FixedUpdate()
    {
        rb.velocity = speed * rb.velocity.normalized;
    }

    IEnumerator ChangeDirection()
    {
        while (true)
        {
            rb.velocity = directions[Random.Range(0, directions.Length)] * speed;
            yield return new WaitForSeconds(2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Destroy(gameObject);
            GameController gameController = FindObjectOfType<GameController>();
            gameController.IncrementarContador();
            gameController.IncrementarEscuts();
        }
    }
}