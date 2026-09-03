/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class Page : IDisposable // TypeDefIndex: 5043
	{
		// Fields
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x10
		public DataSet vertices; // 0x18
		public DataSet indices; // 0x20
		public Page next; // 0x28
		public int framesEmpty; // 0x30
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public bool isEmpty { get; } // 0x000000018241C950-0x000000018241C9D0 
	
		// Constructors
		public Page(uint vertexMaxCount, uint indexMaxCount, uint extrasStride, bool mapped); // 0x000000018241C7F0-0x000000018241C950
	
		// Methods
		public void MarkVertexRangeDirty(uint start, uint count); // 0x000000018241C7D0-0x000000018241C7F0
		public void Dispose(); // 0x000000018241C760-0x000000018241C7D0
		protected virtual void Dispose(bool disposing); // 0x000000018241C710-0x000000018241C760
	}
}
