/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 35: UnityEngine.AudioModule.dll - Assembly: UnityEngine.AudioModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14899-14953

namespace UnityEngine.Audio
{
	[NativeHeader("Modules/Audio/Public/DualThreadManager.h")]
	internal struct DualThreadHandle : IEquatable<UnityEngine.Audio.DualThreadHandle> // TypeDefIndex: 14936
	{
		// Fields
		internal uint Bits; // 0x00
	
		// Properties
		public bool WasCreated { [IsReadOnly] get; } // 0x0000000180A3EC10-0x0000000180A3EC20 
	
		// Methods
		[IsReadOnly]
		public void CheckValidOrThrow(); // 0x000000018216CC30-0x000000018216CC90
		[IsReadOnly]
		public bool Equals(DualThreadHandle other); // 0x00000001815FCAB0-0x00000001815FCAC0
		[IsReadOnly]
		public override bool Equals(object obj); // 0x000000018216CC90-0x000000018216CD10
		[IsReadOnly]
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		public static bool operator ==(DualThreadHandle left, DualThreadHandle right); // 0x0000000180A2DD00-0x0000000180A2DD10
	}
}
