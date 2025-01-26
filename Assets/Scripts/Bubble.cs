using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float floatSpeed;
    public float maxHeight;

    private void Update()
    {
        FloatUp();
        if (transform.position.y > maxHeight)
        {
            Destroy(gameObject);
        }
    }

    void FloatUp()
    {
        transform.Translate(floatSpeed * Time.deltaTime * Vector2.up);
    }
}
