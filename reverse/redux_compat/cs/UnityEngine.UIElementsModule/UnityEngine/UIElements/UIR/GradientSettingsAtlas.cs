/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class GradientSettingsAtlas : IDisposable // TypeDefIndex: 5074
	{
		// Fields
		private static readonly ProfilerMarker s_MarkerWrite; // 0x00
		private static readonly ProfilerMarker s_MarkerCommit; // 0x08
		private readonly int m_Length; // 0x10
		private readonly int m_ElemWidth; // 0x14
		private BestFitAllocator m_Allocator; // 0x18
		private Texture2D m_Atlas; // 0x20
		private RawTexture m_RawAtlas; // 0x28
		[NoAutoStaticsCleanup]
		private static int s_TextureCounter; // 0x10
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x38
		[CompilerGenerated]
		private bool _MustCommit_k__BackingField; // 0x39
	
		// Properties
		internal int length { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public Texture2D atlas { get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool MustCommit { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
	
		// Nested types
		private struct RawTexture // TypeDefIndex: 5075
		{
			// Fields
			public Color32[] rgba; // 0x00
			public int width; // 0x08
			public int height; // 0x0C
	
			// Methods
			public void WriteRawInt2Packed(int v0, int v1, int destX, int destY); // 0x000000018241CBC0-0x000000018241CC60
			public void WriteRawFloat4Packed(float f0, float f1, float f2, float f3, int destX, int destY); // 0x000000018241CB20-0x000000018241CBC0
		}
	
		// Constructors
		public GradientSettingsAtlas(int length = 4096 /* Metadata: 0x00660A84 */); // 0x0000000182414BB0-0x0000000182414C90
		static GradientSettingsAtlas(); // 0x0000000182414B00-0x0000000182414BB0
	
		// Methods
		public void Dispose(); // 0x00000001824141D0-0x0000000182414240
		protected virtual void Dispose(bool disposing); // 0x0000000182414240-0x00000001824142B0
		public void Reset(); // 0x0000000182414480-0x0000000182414540
		public Alloc Add(int count); // 0x0000000182413E40-0x0000000182413F20
		public void Remove(Alloc alloc); // 0x0000000182414430-0x0000000182414480
		public void Write(Alloc alloc, GradientSettings[] settings, GradientRemap remap); // 0x0000000182414540-0x0000000182414B00
		public void Commit(); // 0x0000000182413F20-0x00000001824141D0
		private void PrepareAtlas(); // 0x00000001824142B0-0x0000000182414430
	}
}
