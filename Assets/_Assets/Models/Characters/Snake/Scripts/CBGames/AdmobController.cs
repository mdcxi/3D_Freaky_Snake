using System.Collections;
using UnityEngine;

namespace FreakySnake
{
	public class AdmobController : MonoBehaviour
	{
		private void Start()
		{
		}

		public void HideBanner()
		{
		}

		public void LoadAndShowBanner(float delay)
		{
			StartCoroutine(CRLoadAndShowBanner(delay));
		}

		private IEnumerator CRLoadAndShowBanner(float delay)
		{
			yield return new WaitForSeconds(delay);
		}

		public void RequestInterstitial()
		{
		}

		public void RequestRewardedVideo()
		{
		}

		public bool IsInterstitialReady()
		{
			return false;
		}

		public void ShowInterstitial(float delay)
		{
			StartCoroutine(CRShowInterstitial(delay));
		}

		private IEnumerator CRShowInterstitial(float delay)
		{
			yield return new WaitForSeconds(delay);
		}

		public bool IsRewardedVideoReady()
		{
			return false;
		}

		public void ShowRewardedVideo(float delay)
		{
			StartCoroutine(CRShowRewardedVideoAd(delay));
		}

		private IEnumerator CRShowRewardedVideoAd(float delay)
		{
			yield return new WaitForSecondsRealtime(delay);
		}
	}
}
