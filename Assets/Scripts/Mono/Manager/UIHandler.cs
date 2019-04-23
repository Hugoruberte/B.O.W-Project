using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools;

public class UIHandler : Singleton<UIHandler>
{
	[Header("UI Reference")]
	[SerializeField] private Text timeValueText = null;
	[SerializeField] private Text waveValueText = null;
	[SerializeField] private Text winText = null;
	[SerializeField] private Text windValueText = null;

    [Header("Parameters")]
	[SerializeField, Range(0f, 5f)] private float waitDelayBefore = 1f;
	[SerializeField, Range(0f, 5f)] private float waitDelayAfter = 1f;

	[Header("Scriptable Object")]
	[SerializeField] private TimeData timeData = null;
	[SerializeField] private WindData windData = null;

    private IEnumerator waveCoroutine = null;

	protected override void Awake()
	{
		base.Awake();

		if(timeValueText == null) {
			Debug.LogError("ERROR : Need to reference TIME VALUE text component");
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
	}

	private void Update()
	{
		timeValueText.text = this.timeData.time.ToString("F2");
        windValueText.text = this.windData.wind.ToString("F1");

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
		this.timeValueText.text = "0";
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
