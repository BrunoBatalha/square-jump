using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private float groundVelocity;

    void Update()
    {
        MovementGround();
    }


    private void MovementGround()
    {
        transform.Translate(Vector2.left * groundVelocity * Time.deltaTime);
    }
}
