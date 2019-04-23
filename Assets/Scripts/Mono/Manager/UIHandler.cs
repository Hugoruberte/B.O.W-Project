using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;

public class UIHandler : Singleton<UIHandler>
{
	[Header("UI Reference")]
	[SerializeField] private Text scoreValueText = null;
	[SerializeField] private Text waveValueText = null;
	[SerializeField] private Text winText = null;

	[Header("Parameters")]
	[SerializeField, Range(0f, 5f)] private float waitDelayBefore = 1f;
	[SerializeField, Range(0f, 5f)] private float waitDelayAfter = 1f;

	[Header("Score Scriptable Object")]
	[SerializeField] private ScoreData scoreData = null;

	private IEnumerator waveCoroutine = null;

	protected override void Awake()
	{
		base.Awake();

		if(scoreValueText == null) {
			Debug.LogError("ERROR : Need to reference SCORE VALUE text component");
		}
		if(waveValueText == null) {
			Debug.LogError("ERROR : Need to reference WAVE VALUE text component");
		}
		if(winText == null) {
			Debug.LogError("ERROR : Need to reference WIN text component");
		}
	}

	void Start()
	{
		this.InitializeUI();

		this.scoreData.onScoreUpdate.AddListener(this.UpdateScore);
	}

	public void UpdateScore()
	{
		scoreValueText.text = this.scoreData.score.ToString();
	}

	public void DisplayWave(int wave)
	{
		this.StartAndStopCoroutine(ref this.waveCoroutine, this.DisplayWaveCoroutine(wave));
	}

	public void DisplayWin()
	{
		this.winText.gameObject.SetActive(true);
	}



	private void InitializeUI()
	{
		this.scoreValueText.text = "0";
		this.waveValueText.transform.parent.gameObject.SetActive(false);
		this.winText.gameObject.SetActive(false);
	}

	private IEnumerator DisplayWaveCoroutine(int wave)
	{
		this.waveValueText.transform.parent.gameObject.SetActive(true);

		yield return Yielders.Wait(this.waitDelayBefore);

		this.waveValueText.text = wave.ToString();

		yield return Yielders.Wait(this.waitDelayAfter);

		this.waveValueText.transform.parent.gameObject.SetActive(false);
	}
}
