using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemove : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(collision.gameObject);
        }
    }
}
