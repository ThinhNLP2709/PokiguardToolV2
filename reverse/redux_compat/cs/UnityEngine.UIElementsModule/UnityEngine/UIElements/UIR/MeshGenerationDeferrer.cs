/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Jobs;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class MeshGenerationDeferrer : IDisposable // TypeDefIndex: 5089
	{
		// Fields
		private Queue<CallbackInfo> m_Fork; // 0x10
		private Queue<CallbackInfo> m_WorkThenFork; // 0x18
		private Queue<CallbackInfo> m_Work; // 0x20
		private Queue<CallbackInfo> m_JobDependentFork; // 0x28
		private Queue<CallbackInfo> m_JobDependentWorkThenFork; // 0x30
		private Queue<CallbackInfo> m_JobDependentWork; // 0x38
		private Queue<JobHandle> m_Dependencies; // 0x40
		private JobMerger m_DependencyMerger; // 0x48
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x50
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377920-0x0000000180377930 0x00000001803780E0-0x00000001803780F0
	
		// Nested types
		private struct CallbackInfo // TypeDefIndex: 5090
		{
			// Fields
			public MeshGenerationCallback callback; // 0x00
			public object userData; // 0x08
		}
	
		// Constructors
		public MeshGenerationDeferrer(); // 0x00000001824161A0-0x00000001824163B0
	
		// Methods
		public void AddMeshGenerationJob(JobHandle jobHandle); // 0x0000000182415B30-0x0000000182415B90
		public void AddMeshGenerationCallback(MeshGenerationCallback callback, object userData, MeshGenerationCallbackType callbackType, bool isJobDependent); // 0x0000000182415970-0x0000000182415B30
		public void ProcessDeferredWork(MeshGenerationContext meshGenerationContext); // 0x0000000182415D70-0x00000001824161A0
		private static void Invoke(CallbackInfo ci, MeshGenerationContext mgc); // 0x0000000182415C60-0x0000000182415D70
		public void Dispose(); // 0x0000000182415B90-0x0000000182415C10
		protected void Dispose(bool disposing); // 0x0000000182415C10-0x0000000182415C60
	}
}
