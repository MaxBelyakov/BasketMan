using UnityEngine;

public class Player_controller : MonoBehaviour {

    public float speed = 20f;
    public static Rigidbody2D rb;
    public static bool FaceRight = true;
    public static float notDead = 1; /* the way to stop moving player after dead. Become 0 when dead */

    void Start () {
        rb = GetComponent <Rigidbody2D> ();
	}
	
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime * notDead);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * 8000 * notDead);

        if (moveX > 0 && !FaceRight)
            flip();
        else if (moveX < 0 && FaceRight)
            flip();
    }

    void flip ()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
