using UnityEngine;

public class WetherSystem : MonoBehaviour
{
	[SerializeField] private Light _directionalLight;
	[SerializeField] private GameObject _snow;
	[SerializeField] private GameObject _rain;
	
	public void ChangeWeather(WeatherType _type)
	{
		switch (_type)
		{
			case WeatherType.Sun:
				RenderSettings.skybox.SetFloat("Exprosure", 1f);
				_directionalLight.intensity = 2f;
				RenderSettings.fog = false;
				_snow.SetActive(false);
				_rain.SetActive(false);
				break;
			case WeatherType.Snow:
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = false;
				_snow.SetActive(true);
				_rain.SetActive(false);
				break;
			case WeatherType.Rain:
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = false;
				_snow.SetActive(false);
				_rain.SetActive(true);
				break;
			case WeatherType.Fog:
				RenderSettings.skybox.SetFloat("Exprosure", .6f);
				_directionalLight.intensity = 1f;
				RenderSettings.fog = true;
				_snow.SetActive(false);
				_rain.SetActive(false);
				break;
		}
	}
}

[System.Serializable]
public enum WeatherType
{
	Sun,
	Rain,
	Snow,
	Fog
}