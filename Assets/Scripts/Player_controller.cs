using UnityEngine;

public class Player_controller : MonoBehaviour {

    [SerializeField] private LayerMask platformsLayerMask; /* Added new layer in Unity - platforms. Layer connected to player and platforms*/
    public float speed = 20f;
    public static Rigidbody2D rb;
    public static bool FaceRight = true;
    public static float notDead = 1; /* the way to stop moving player after dead. Become 0 when dead */
    private BoxCollider2D bc2d; /* element of BoxCast (virtual duplicate of player). Need to compare player position instead the ground */

    void Start () {
        rb = GetComponent <Rigidbody2D> ();
        bc2d = transform.GetComponent<BoxCollider2D>();
    }
	
	void Update () {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime * notDead);

        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 8000 * notDead);
            rb.AddTorque(moveX * -700 * notDead);
        }

        if (moveX > 0 && !FaceRight)
            flip();
        else if (moveX < 0 && FaceRight)
            flip();
    }

    /* Check is the player stay on the ground, by adding BoxCast the same size and position as player with 1 point down */
    private bool isGrounded()
    {
        RaycastHit2D rch2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        return rch2d.collider != null;
    }

    void flip ()
    {
        FaceRight = !FaceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
