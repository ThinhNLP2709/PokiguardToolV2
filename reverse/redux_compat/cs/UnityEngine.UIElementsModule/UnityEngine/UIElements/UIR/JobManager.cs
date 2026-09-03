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
	internal class JobManager : IDisposable // TypeDefIndex: 5077
	{
		// Fields
		private NativePagedList<ConvertMeshJobData> m_ConvertMeshJobs; // 0x10
		private NativePagedList<ConvertMeshExtrasData> m_ConvertMeshExtras; // 0x18
		private NativePagedList<CopyMeshJobData> m_CopyMeshJobs; // 0x20
		private JobMerger m_JobMerger; // 0x28
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x30
	
		// Properties
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
	
		// Constructors
		public JobManager(); // 0x0000000182415460-0x0000000182415610
	
		// Methods
		public void Add(ref ConvertMeshJobData job); // 0x0000000182414C90-0x0000000182414CF0
		public void Add(ref CopyMeshJobData job); // 0x0000000182414CF0-0x0000000182414D50
		public unsafe ConvertMeshExtrasData* AllocConvertMeshExtras(); // 0x0000000182414D50-0x0000000182414DA0
		public void CompleteConvertMeshJobs(); // 0x0000000182414DA0-0x0000000182415040
		public void CompleteCopyMeshJobs(); // 0x0000000182415040-0x00000001824152C0
		public void Dispose(); // 0x0000000182415380-0x0000000182415460
		protected void Dispose(bool disposing); // 0x00000001824152C0-0x0000000182415380
	}
}
