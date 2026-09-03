/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct BatchPackedCullingViewID : IEquatable<BatchPackedCullingViewID> // TypeDefIndex: 8348
	{
		// Fields
		internal readonly ulong handle; // 0x00
	
		// Constructors
		internal BatchPackedCullingViewID(ulong viewID); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public override int GetHashCode(); // 0x000000018126B220-0x000000018126B230
		public bool Equals(BatchPackedCullingViewID other); // 0x0000000180DF5FE0-0x0000000180DF5FF0
		public override bool Equals(object obj); // 0x00000001822556C0-0x0000000182255740
		[IsReadOnly]
		public EntityId GetEntityId(); // 0x0000000180E85FD0-0x0000000180E85FE0
	}
}
