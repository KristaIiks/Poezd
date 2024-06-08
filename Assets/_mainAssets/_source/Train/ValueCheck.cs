using UnityEngine.XR.Content.Interaction;

public abstract class ValueCheck
{
	public static bool CheckValue(XRKnob _leveler)
	{
		if(_leveler.value >= .9f)
		{
			return true;
		}
		return false;
	}
}