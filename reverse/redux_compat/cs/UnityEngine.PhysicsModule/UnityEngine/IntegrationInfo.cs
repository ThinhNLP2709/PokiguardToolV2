/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	public struct IntegrationInfo // TypeDefIndex: 15430
	{
		// Fields
		private readonly uint m_Id; // 0x00
		private unsafe fixed /* 0x00000000-0x00000000 */ ushort m_IntegrationVersion[0]; // 0x04
		private unsafe fixed /* 0x00000000-0x00000000 */ ushort m_SdkVersion[0]; // 0x0A
		private readonly SupportedUnityFeatures m_Features; // 0x10
		private unsafe fixed /* 0x00000000-0x00000000 */ byte m_Name[0]; // 0x14
		private unsafe fixed /* 0x00000000-0x00000000 */ byte m_Desc[0]; // 0x24
		private IntegrationLimits m_Limit; // 0x100
	
		// Properties
		public uint id { [IsReadOnly] get; } // 0x0000000180732D10-0x0000000180732D20 
		public bool isFallback { get; } // 0x00000001822D5470-0x00000001822D5480 
	
		// Nested types
		[Flags]
		internal enum SupportedUnityFeatures // TypeDefIndex: 15431
		{
			None = 0,
			DynamicsSupport = 2,
			SDKVisualDebuggerSupport = 4,
			ArticulationSupport = 8,
			ImmediateModeSupport = 16,
			VehicleSupport = 32,
			CharacterControllerSupport = 64
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_Desc_e__FixedBuffer // TypeDefIndex: 15432
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_IntegrationVersion_e__FixedBuffer // TypeDefIndex: 15433
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_Name_e__FixedBuffer // TypeDefIndex: 15434
		{
			// Fields
			public byte FixedElementField; // 0x00
		}
	
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _m_SdkVersion_e__FixedBuffer // TypeDefIndex: 15435
		{
			// Fields
			public ushort FixedElementField; // 0x00
		}
	}
}
