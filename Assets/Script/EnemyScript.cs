using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "MainCharachter")
        {
            PlayerController.Instance.dead();
        }
    }
}
