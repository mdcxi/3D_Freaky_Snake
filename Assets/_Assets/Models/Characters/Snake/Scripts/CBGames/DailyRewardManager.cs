using UnityEngine;

namespace FreakySnake
{
	public class DailyRewardManager : MonoBehaviour
	{
		[SerializeField]
		private DailyRewardItem[] dailyRewardItems;

		public DailyRewardItem[] DailyRewardItems => dailyRewardItems;
	}
}
