using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FreakySnake.Core;
using FreakySnake.Helpers;
using UnityEngine;

namespace FreakySnake.Control
{
	public class SnakeController : SingletonMonobehaviour<SnakeController>
	{
		[Header("Snake Config")] 
		[SerializeField] private int originalBodySize = 10;
		[SerializeField] private float bodyDistance = 1.8f;
		[SerializeField] private float movingSpeed = 12f;
		[SerializeField] private float rotatingSpeed = 300f;
		[SerializeField] private float limitRotatingAngle = 30f;

		[Header("Snake References")] 
		[SerializeField] private BodyPartController bodyPartControl;
		[SerializeField] private Joystick movementJoystick;
		[SerializeField] private CountUpSystem aliveTimer;
		
		private readonly List<BodyPartController> _listActiveBodyPartControl = new List<BodyPartController>();
		private RaycastHit _hit;
		private float _currentMovingSpeed;

		private async void Start()
		{
			_listActiveBodyPartControl.Add(bodyPartControl);

			for (int i = 0; i < originalBodySize - 1; i++)
			{
				AddBodyPart();
			}

			await IncreaseMovingSpeedOvertime();
			aliveTimer.BeginTimer();
		}

		private void Update()
		{
			MoveBodyParts();
		}
		
		 private void MoveBodyParts()
		 {
			 if (movementJoystick == null) return;
			 
			 _currentMovingSpeed = movingSpeed;


			 if (movementJoystick.Vertical > 0) _currentMovingSpeed *= 2;
			 
			 MoveHead(_currentMovingSpeed);

			 if (movementJoystick.Horizontal != 0) 
				 RotateBodyPart(_listActiveBodyPartControl[0].transform, Vector3.up);
			 
			 UpdateBodyParts();
		 }
		 
		private void RotateBodyPart(Transform bodyPartTransform, Vector3 rotationAxis)
		{
			var rotationAmount = rotationAxis * (rotatingSpeed * Time.deltaTime * movementJoystick.Horizontal) / movementJoystick.dragSpeed;
			bodyPartTransform.Rotate(rotationAmount);
			
			//limit the rotation angle of the Snake 
			var y = bodyPartTransform.eulerAngles.y;
			y = (y > 180f) ? (y - 360f) : y;
			
			if (y >= limitRotatingAngle)
			{
				var eulerAngles = bodyPartTransform.eulerAngles;
				eulerAngles = new Vector3(eulerAngles.x, limitRotatingAngle, eulerAngles.z);
				bodyPartTransform.eulerAngles = eulerAngles;
			}
			else if (y <= 0f - limitRotatingAngle)
			{
				var eulerAngles = bodyPartTransform.eulerAngles;
				eulerAngles = new Vector3(eulerAngles.x, 0f - limitRotatingAngle, eulerAngles.z);
				bodyPartTransform.eulerAngles = eulerAngles;
			}
		}
		
		private void UpdateBodyParts()
		{
			for (int i = 1; i < _listActiveBodyPartControl.Count; i++)
				UpdateBodyPartRotationAndPosition(_listActiveBodyPartControl[i], _listActiveBodyPartControl[i - 1]);
		}
		
		private void UpdateBodyPartRotationAndPosition(BodyPartController currentBodyPart, BodyPartController previousBodyPart)
		{
			var distance = Vector3.Distance(currentBodyPart.transform.position, previousBodyPart.transform.position);
			
			var position = previousBodyPart.transform.position;
			position.y = _listActiveBodyPartControl[0].transform.position.y;
			
			var lerpAmount = Time.deltaTime * distance / bodyDistance * _currentMovingSpeed;
			if (lerpAmount > 0.5f)
			{
				lerpAmount = 0.5f;
			}
			
			currentBodyPart.transform.position = Vector3.Slerp(currentBodyPart.transform.position, position, lerpAmount);
			currentBodyPart.transform.rotation = Quaternion.Slerp(currentBodyPart.transform.rotation, previousBodyPart.transform.rotation, lerpAmount);
		}
		
	
		private void MoveHead(float currentSpeed)
		{
			_listActiveBodyPartControl[0].transform
				.Translate(_listActiveBodyPartControl[0].transform.forward * (currentSpeed * Time.smoothDeltaTime),
					Space.World);
		}
		
		private void LateUpdate()
		{
			CameraController.Instance.FollowSnake();
		}

		private async UniTask IncreaseMovingSpeedOvertime()
		{
			var passedTime = 0f;
			var originalSpeed = 0f;
			var finalSpeed = movingSpeed;
			var increasingTime = 2f;
			
			while (passedTime < increasingTime)
			{
				passedTime += Time.deltaTime;
				var interpolation = passedTime / increasingTime;
				_currentMovingSpeed = Mathf.Lerp(originalSpeed, finalSpeed, interpolation);
				await UniTask.Yield();
			}
		}
		
		public void AddBodyPart()
		{
			var position = _listActiveBodyPartControl[^1].transform.position;
			var rotation = _listActiveBodyPartControl[^1].transform.rotation;
			var bodyPart = BodyPartsManager.Instance.GetBodyPart();
			
			bodyPart.transform.position = position;
			bodyPart.transform.rotation = rotation;
			bodyPart.gameObject.SetActive(true);
			_listActiveBodyPartControl.Add(bodyPart);
		}
	}	
}


