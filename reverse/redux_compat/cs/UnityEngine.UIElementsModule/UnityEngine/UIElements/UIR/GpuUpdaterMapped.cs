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
	internal class GpuUpdaterMapped : GpuUpdater // TypeDefIndex: 5064
	{
		// Fields
		private CircularRangeBuffer<GfxUpdateBufferRange> m_UpdateRangesPool; // 0x18
		private int m_CurrentFrameIndex; // 0x20
		private PerFrameData[] m_FrameDataArray; // 0x28
	
		// Nested types
		private struct PerFrameData // TypeDefIndex: 5065
		{
			// Fields
			public int rangesToFree; // 0x00
		}
	
		// Constructors
		public GpuUpdaterMapped(); // 0x00000001824110C0-0x0000000182411170
	
		// Methods
		public override void ProcessDataSet(DataSet dataSet); // 0x0000000182410D10-0x0000000182410F00
		public override void CompleteUpdate(); // 0x00000001802E76C0-0x00000001802E76D0
		private void UploadDirtyRanges(DataSet dataSet); // 0x0000000182410F00-0x00000001824110C0
		public override void AdvanceFrame(); // 0x0000000182410C30-0x0000000182410CC0
		protected override void Dispose(bool disposing); // 0x0000000182410CC0-0x0000000182410D10
	}
}
