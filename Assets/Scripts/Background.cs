using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float velocityMovement;
    private new Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(); 
    }

    private void Movement()
    {
       renderer.material.mainTextureOffset = new Vector2(Time.time * velocityMovement, 0);
    }
}
