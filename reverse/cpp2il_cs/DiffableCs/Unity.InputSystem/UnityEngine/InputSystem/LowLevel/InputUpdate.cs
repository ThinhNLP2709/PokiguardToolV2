namespace UnityEngine.InputSystem.LowLevel;

[Extension]
internal static class InputUpdate
{
	internal struct SerializedState
	{
		public InputUpdateType lastUpdateType; //Field offset: 0x0
		public UpdateStepCount playerUpdateStepCount; //Field offset: 0x4

	}

	internal struct UpdateStepCount
	{
		private bool m_WasUpdated; //Field offset: 0x0
		[CompilerGenerated]
		private uint <value>k__BackingField; //Field offset: 0x4

		public private uint value
		{
			[CompilerGenerated]
			[IsReadOnly]
			 get { } //Length: 4
			[CompilerGenerated]
			private set { } //Length: 4
		}

		[CompilerGenerated]
		[IsReadOnly]
		public uint get_value() { }

		public void OnBeforeUpdate() { }

		public void OnUpdate() { }

		[CompilerGenerated]
		private void set_value(uint value) { }

	}

	public static uint s_UpdateStepCount; //Field offset: 0x0
	public static InputUpdateType s_LatestUpdateType; //Field offset: 0x4
	public static UpdateStepCount s_PlayerUpdateStepCount; //Field offset: 0x8

	[Extension]
	public static InputUpdateType GetUpdateTypeForPlayer(InputUpdateType mask) { }

	[Extension]
	public static bool IsPlayerUpdate(InputUpdateType updateType) { }

	internal static void OnBeforeUpdate(InputUpdateType type) { }

	internal static void OnUpdate(InputUpdateType type) { }

	public static void Restore(SerializedState state) { }

	public static SerializedState Save() { }

}

