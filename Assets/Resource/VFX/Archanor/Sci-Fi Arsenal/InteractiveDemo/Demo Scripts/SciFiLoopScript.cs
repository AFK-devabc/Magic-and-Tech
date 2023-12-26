using UnityEngine;
using System.Collections;

namespace SciFiArsenal
{
	public class SciFiLoopScript : MonoBehaviour
	{

		public GameObject chosenEffect;
		public float loopTimeLimit = 2.0f;

		void Start ()
		{
			PlayEffect();
		}


		public void PlayEffect()
		{
			StartCoroutine("EffectLoop");
		}
	

		IEnumerator EffectLoop()
		{
			GameObject effectPlayer = (GameObject) Instantiate(chosenEffect, transform.position, transform.rotation);
			effectPlayer.transform.localScale = new Vector3 (10f, 10f, 10f);

			yield return new WaitForSeconds(loopTimeLimit);

			Destroy (effectPlayer);
			PlayEffect();
		}
	}
}