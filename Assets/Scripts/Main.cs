using UnityEngine;

namespace BUUG.Game {

	public class Main : MonoBehaviour {

		private const string AXIS_X = "Horizontal";
		private const string AXIS_Z = "Vertical";
		private const float AXIS_MULTI = 5;
		private const float BALL_FAIL_HEIGHT = -1;

		// Exposed Fields
		public Transform tiltPlatform;
		public Transform ball;

		// Private Variables
		private Vector3 eular = new Vector3();
		private Vector3 ballStartPosition;

		private void Awake() {
			ballStartPosition = ball.position;
		}

		private void Update() {
			Input_Process();
			Ball_Process();
		}

		private void Input_Process() {

			// Set the rotation
			eular.z = Input.GetAxis(AXIS_X) * AXIS_MULTI;
			eular.x = Input.GetAxis(AXIS_Z) * AXIS_MULTI;

			// Bake teh rotation into the transform
			tiltPlatform.eulerAngles = eular;
		}

		private void Ball_Process() {
			if (ball.position.y < BALL_FAIL_HEIGHT) {
				ball.position = ballStartPosition;
				Rigidbody physics = ball.GetComponent<Rigidbody>();
				physics.velocity = Vector3.zero;
				physics.angularVelocity = Vector3.zero;
			}
		}
	}
}