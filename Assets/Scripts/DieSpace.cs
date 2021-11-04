using UnityEngine;
using System.Collections;

public class DieSpace : MonoBehaviour {

    public GameObject respawn;
    private Color32 tempBackGroundColor; /* To renew background after player respawn */

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player_controller.notDead = 0;
            tempBackGroundColor = Camera.main.backgroundColor;
            Camera.main.backgroundColor = Color.red;
            Player_controller.rb.freezeRotation = true;
            StartCoroutine(waiter(other));
        }
    }
    
    IEnumerator waiter(Collider2D other)
    {
        yield return new WaitForSeconds(1);

        other.transform.rotation = Quaternion.Euler(0, 0, 0); /* rotate player to start position */

        /* turn Face to start position */
        if (Player_controller.FaceRight != true)
        {
            other.transform.localScale = new Vector3(other.transform.localScale.x * -1, other.transform.localScale.y, other.transform.localScale.z);
            Player_controller.FaceRight = !Player_controller.FaceRight;
        }

        Player_controller.notDead = 1;
        other.transform.position = respawn.transform.position;
        Player_controller.rb.freezeRotation = false;
        Camera.main.backgroundColor = tempBackGroundColor;
    }
}
