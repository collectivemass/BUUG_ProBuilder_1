using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BUUG.Game {

	public class CameraFollow : MonoBehaviour {

		// Public (Editor Exposed) Variables
		public Transform whatToFollow;

		// Private (Internal) Variables
		private Transform localTransform;

		private void Awake() {
			localTransform = transform;
		}

		private void Update() {
		
			// Make the camera folow the target but only on the X and Y
			Vector3 position = localTransform.position;
			position.x = whatToFollow.position.x;
			position.z = whatToFollow.position.z;
			localTransform.position = position;
		}
	}
}