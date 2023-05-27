using FreakySnake.Control;
using UnityEngine;

namespace FreakySnake.Core
{
	public class CameraController : SingletonMonobehaviour<CameraController>
	{
		[SerializeField]
		private float smoothTime = 0.1f;

		private Vector3 _velocity = Vector3.zero;

		private float _originalZDistance;

		private void Start()
		{
			//The initial distance along the Z-axis between the camera and the snake
			//e.g. 	||0| - |0|| = 0
			_originalZDistance = Mathf.Abs(Mathf.Abs(transform.position.z) - Mathf.Abs(SnakeController.Instance.transform.position.z));
		
		}

		public void FollowSnake()
		{
			var snakePosition = SnakeController.Instance.transform.position;
			var position = transform.position;
			var cameraPosition = position; 
		
			var x = (snakePosition - cameraPosition).x;
			var z = (snakePosition - cameraPosition).z - _originalZDistance;

			//Move the camera along with the snake with a new distance along the X and Z axes
			var target = cameraPosition + new Vector3(x, 0f, z); 
		
			position = Vector3.SmoothDamp(position, target, ref _velocity, smoothTime);
			transform.position = position;
		}
	}
}

