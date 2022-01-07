using UnityEngine;

public class CamMove : MonoBehaviour {

    public GameObject player;
	private float RotationPerSecond = 1;

	void Update () {
		// Camera follow the player
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);

		// Skybox rotation
		RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationPerSecond);
	}
}