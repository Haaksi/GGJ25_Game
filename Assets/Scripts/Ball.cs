using UnityEngine;

public class Ball : MonoBehaviour
{
    public float lifeTime;
    private float timer;
    private Manakeri manakeriScript;

    private void Start()
    {
        manakeriScript = FindObjectOfType<Manakeri>();
    }

    private void Update()
    {
        DeleteBall();
    }

    void DeleteBall()
    {
        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bubbles"))
        {
            //AddPoints();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void AddPoints()
    {
        //manakeriScript.currScore += 10;
    }
}
