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
	internal abstract class GpuUpdater : IDisposable // TypeDefIndex: 5063
	{
		// Fields
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x10
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Constructors
		protected GpuUpdater(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract void AdvanceFrame();
		public abstract void ProcessDataSet(DataSet dataSet);
		public abstract void CompleteUpdate();
		public void Dispose(); // 0x0000000182413DD0-0x0000000182413E40
		protected virtual void Dispose(bool disposing); // 0x0000000182413DC0-0x0000000182413DD0
	}
}
