using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockJump : MonoBehaviour
{
    public float blockFly;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            PlayerController.anim.SetBool("Jump", true);
            PlayerController.anim.SetBool("Move", false);
            StartCoroutine(JumpClose());
            Vector2 flyVelocity = rb.velocity;
            flyVelocity.y = blockFly;
            rb.velocity = flyVelocity;
        }
    }

    IEnumerator JumpClose()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerController.anim.SetBool("Jump", false);
        PlayerController.anim.SetBool("Move", true);
    }
}
