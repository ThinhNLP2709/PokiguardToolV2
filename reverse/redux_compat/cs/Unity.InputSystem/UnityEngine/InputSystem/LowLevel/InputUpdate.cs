/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.LowLevel
{
	internal static class InputUpdate // TypeDefIndex: 6486
	{
		// Fields
		public static uint s_UpdateStepCount; // 0x00
		public static InputUpdateType s_LatestUpdateType; // 0x04
		public static UpdateStepCount s_PlayerUpdateStepCount; // 0x08
	
		// Nested types
		[Serializable]
		public struct UpdateStepCount // TypeDefIndex: 6487
		{
			// Fields
			private bool m_WasUpdated; // 0x00
			[CompilerGenerated]
			private uint _value_k__BackingField; // 0x04
	
			// Properties
			public uint value { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
	
			// Methods
			public void OnBeforeUpdate(); // 0x0000000181DEA4E0-0x0000000181DEA4F0
			public void OnUpdate(); // 0x0000000181DEA4F0-0x0000000181DEA500
		}
	
		[Serializable]
		public struct SerializedState // TypeDefIndex: 6488
		{
			// Fields
			public InputUpdateType lastUpdateType; // 0x00
			public UpdateStepCount playerUpdateStepCount; // 0x04
		}
	
		// Methods
		internal static void OnBeforeUpdate(InputUpdateType type); // 0x0000000181DE49D0-0x0000000181DE4A40
		internal static void OnUpdate(InputUpdateType type); // 0x0000000181DE4A40-0x0000000181DE4AC0
		public static SerializedState Save(); // 0x0000000181DE4B60-0x0000000181DE4BB0
		public static void Restore(SerializedState state); // 0x0000000181DE4AC0-0x0000000181DE4B60
	
		// Extension methods
		public static InputUpdateType GetUpdateTypeForPlayer(this InputUpdateType mask); // 0x0000000181DE49A0-0x0000000181DE49C0
		public static bool IsPlayerUpdate(this InputUpdateType updateType); // 0x0000000181DE49C0-0x0000000181DE49D0
	}
}
