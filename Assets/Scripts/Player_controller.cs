using UnityEngine;

public class Player_controller : MonoBehaviour {

    public float speed = 20f;
    private Rigidbody2D rb;
    public static bool FaceRight = true;

    void Start () {
        rb = GetComponent <Rigidbody2D> ();
	}
	
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed *Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector2.up * 8000);

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
