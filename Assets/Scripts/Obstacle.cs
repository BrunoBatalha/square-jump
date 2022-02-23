using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float velocity;
  

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * velocity);
    }
}
