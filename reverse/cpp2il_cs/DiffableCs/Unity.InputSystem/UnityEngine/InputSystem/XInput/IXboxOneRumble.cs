namespace UnityEngine.InputSystem.XInput;

public interface IXboxOneRumble : IDualMotorRumble, IHaptics
{

	public void SetMotorSpeeds(float lowFrequency, float highFrequency, float leftTrigger, float rightTrigger) { }

}

