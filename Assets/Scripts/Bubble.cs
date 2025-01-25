using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float floatSpeed;

    private void Update()
    {
        FloatUp();
        if (transform.position.y > 15)
        {
            Destroy(gameObject);
        }
    }

    void FloatUp()
    {
        transform.Translate(Vector2.up * floatSpeed * Time.deltaTime);
    }
}
