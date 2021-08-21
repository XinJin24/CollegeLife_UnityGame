using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Slider))]
public class SliderTimer : MonoBehaviour
{

	public float FillTime = 3.0f;
	public Slider _slider;

	void Start()
	{
		_slider = GetComponent<Slider>();
		Reset();
	}

	public void Reset()
	{
		_slider.minValue = Time.time;
		_slider.maxValue = Time.time + FillTime;
	}
	void Update()
	{
		_slider.value = Time.time;
	}
}