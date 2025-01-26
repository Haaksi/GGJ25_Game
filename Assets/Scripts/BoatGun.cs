using UnityEngine;

public class BoatGun : MonoBehaviour
{
    public Camera cam;
    public GameObject ballPrefab;
    public Transform shootPoint;
    public float fireRate;
    public float ballSpeed;
    
    private Vector3 mousePos;
    private bool canFire;
    private float timer;
    private float zRot;

    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtMouse();
        FireBall();
    }

    void LookAtMouse()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        zRot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, Mathf.Clamp(zRot, 45, 135));
    }

    void FireBall()
    {
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            GameObject ball = Instantiate(ballPrefab, shootPoint.position, Quaternion.Euler(0, 0, zRot + 90));
            ball.GetComponent<Rigidbody2D>().AddForce(transform.right * ballSpeed, ForceMode2D.Impulse);
        }
    }
}
