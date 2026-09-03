/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class JobMerger : IDisposable // TypeDefIndex: 5082
	{
		// Fields
		private static readonly MemoryLabel k_MemoryLabel; // 0x00
		private NativeArray<JobHandle> m_Jobs; // 0x10
		private int m_JobCount; // 0x20
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x24
	
		// Properties
		public int count { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018153BC50-0x000000018153BC60 0x0000000181706050-0x0000000181706060
	
		// Constructors
		public JobMerger(int capacity); // 0x00000001824158A0-0x0000000182415970
		static JobMerger(); // 0x0000000182415810-0x00000001824158A0
	
		// Methods
		public void Add(JobHandle job); // 0x0000000182415610-0x0000000182415690
		public JobHandle MergeAndReset(); // 0x0000000182415770-0x0000000182415810
		public void Dispose(); // 0x00000001824156F0-0x0000000182415770
		protected void Dispose(bool disposing); // 0x0000000182415690-0x00000001824156F0
	}
}
