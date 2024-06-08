using System.Collections;
using UnityEngine;

public class WetherSystem : MonoBehaviour
{
	[SerializeField] private Light _directionalLight;
	[SerializeField] private GameObject _snow;
	[SerializeField] private GameObject _rain;
	
	private void Awake()
	{
		StartCoroutine(RandomWeather());
	}
	
	public void ChangeWeather(string _type)
	{
		switch (_type)
		{
			case "Sun":
				RenderSettings.skybox.SetFloat("Exprosure", 1f);
				_directionalLight.intensity = 2f;
				RenderSettings.fog = false;
				_snow.SetActive(false);
				_rain.SetActive(false);
				break;
			case "Snow":
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = false;
				_snow.SetActive(true);
				_rain.SetActive(false);
				break;
			case "Rain":
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = false;
				_snow.SetActive(false);
				_rain.SetActive(true);
				break;
			case "Fog":
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = true;
				_snow.SetActive(false);
				_rain.SetActive(false);
				break;
		}
	}
	
	private IEnumerator RandomWeather()
	{
		yield return new WaitForSeconds(15f);
		
		ChangeWeather("Rain");
		
		yield return new WaitForSeconds(15f);
		
		ChangeWeather("Sun");
		
		yield return new WaitForSeconds(15f);
		
		ChangeWeather("Snow");
		
		yield return new WaitForSeconds(15f);
		
		ChangeWeather("Fog");
		
		yield return new WaitForSeconds(15f);
		
		ChangeWeather("Sun");
	}
}