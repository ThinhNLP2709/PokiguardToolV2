/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Audio
{
	[IsReadOnly]
	public struct ProcessorInstance : IEquatable<UnityEngine.Audio.ProcessorInstance> // TypeDefIndex: 14937
	{
		// Fields
		internal readonly DualThreadHandle Handle; // 0x00
		internal readonly unsafe ProcessorHeader* Header; // 0x08
	
		// Nested types
		public enum UpdateSetting // TypeDefIndex: 14938
		{
			Default = 0,
			NeverUpdate = 1,
			UpdateIfDataIsAvailable = 2,
			UpdateAlways = 3
		}
	
		public struct CreationParameters // TypeDefIndex: 14939
		{
			// Fields
			[CompilerGenerated]
			private UpdateSetting _controlUpdateSetting_k__BackingField; // 0x00
			[CompilerGenerated]
			private UpdateSetting _realtimeUpdateSetting_k__BackingField; // 0x04
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		public struct Message // TypeDefIndex: 14940
		{
			// Fields
			internal long TypeHash; // 0x00
			internal unsafe void* Data; // 0x08
			internal IntPtr ManagedHandle; // 0x10
		}
	
		// Constructors
		internal unsafe ProcessorInstance(DualThreadHandle handle, ProcessorHeader* header); // 0x0000000180F377C0-0x0000000180F377D0
	
		// Methods
		public bool Equals(ProcessorInstance other); // 0x000000018216CF90-0x000000018216CFA0
		public override bool Equals(object obj); // 0x000000018216CFA0-0x000000018216D030
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
	}
}
