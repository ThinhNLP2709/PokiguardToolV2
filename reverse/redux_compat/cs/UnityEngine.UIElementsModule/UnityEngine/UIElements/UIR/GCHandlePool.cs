/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class GCHandlePool : IDisposable // TypeDefIndex: 5010
	{
		// Fields
		private List<GCHandle> m_Handles; // 0x10
		private int m_UsedHandlesCount; // 0x18
		private readonly int k_AllocBatchSize; // 0x1C
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x20
	
		// Properties
		internal bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		public GCHandlePool(int capacity = 256 /* Metadata: 0x006609B3 */, int allocBatchSize = 64 /* Metadata: 0x006609B5 */); // 0x00000001823F8DB0-0x00000001823F8E50
	
		// Methods
		public GCHandle Get(object target); // 0x00000001823F8B30-0x00000001823F8D00
		public IntPtr GetIntPtr(object target); // 0x00000001823F8B00-0x00000001823F8B30
		public void ReturnAll(); // 0x00000001823F8D00-0x00000001823F8DB0
		public void Dispose(); // 0x00000001823F8980-0x00000001823F89E0
		private void Dispose(bool disposing); // 0x00000001823F89E0-0x00000001823F8B00
	}
}
