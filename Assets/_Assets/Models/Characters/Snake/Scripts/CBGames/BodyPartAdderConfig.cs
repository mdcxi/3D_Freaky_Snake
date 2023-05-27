using System;
using UnityEngine;

namespace FreakySnake
{
	[Serializable]
	public class BodyPartAdderConfig
	{
		[SerializeField]
		private int minScoreToCreate;

		[SerializeField]
		private int minBodyPartNumber = 1;

		[SerializeField]
		private int maxBodyPartNumber = 3;

		public int MinScoreToCreate => minScoreToCreate;

		public int MinBodyPartNumber => minBodyPartNumber;

		public int MaxBodyPartNumber => maxBodyPartNumber;
	}
}
