using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DieSpace : MonoBehaviour {

    public Material[] Skyboxes;  // Skyboxes array (blue and red)

    void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "Player") {

            // Freeze player movement
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            // Change skybox to red
            RenderSettings.skybox = Skyboxes[1];

            StartCoroutine(waiter());
        }
    }
    
    IEnumerator waiter() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("main");
    }
}