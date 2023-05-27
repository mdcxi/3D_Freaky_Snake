using System;
using UnityEngine;

namespace FreakySnake
{
	[Serializable]
	public class SoundClip
	{
		[SerializeField]
		private AudioClip audioClip;

		public AudioClip AudioClip => audioClip;
	}
}
