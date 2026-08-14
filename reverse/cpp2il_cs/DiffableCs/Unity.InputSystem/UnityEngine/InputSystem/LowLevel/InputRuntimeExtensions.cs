namespace UnityEngine.InputSystem.LowLevel;

[Extension]
internal static class InputRuntimeExtensions
{

	[Extension]
	public static long DeviceCommand(IInputRuntime runtime, int deviceId, ref TCommand command) { }

}

