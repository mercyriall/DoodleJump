using UnityEngine;

public class BrownPlatform : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerMovement>();

        if (player != null && collision.attachedRigidbody.velocity.y < 0 &&
            collision.transform.position.y - collision.bounds.size.y / 5 > transform.position.y)
        {
            animator.SetBool("Break", true);
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 0.075f);
        }
    }

    private void DeleteObject()
    {
        Destroy(this.gameObject);
    }
}
