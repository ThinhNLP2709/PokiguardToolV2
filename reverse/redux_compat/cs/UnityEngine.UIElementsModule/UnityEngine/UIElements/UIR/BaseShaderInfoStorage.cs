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
	internal abstract class BaseShaderInfoStorage : IDisposable // TypeDefIndex: 5145
	{
		// Fields
		[NoAutoStaticsCleanup]
		protected static int s_TextureCounter; // 0x00
		internal static readonly ProfilerMarker s_MarkerCopyTexture; // 0x08
		internal static readonly ProfilerMarker s_MarkerGetTextureData; // 0x10
		internal static readonly ProfilerMarker s_MarkerUpdateTexture; // 0x18
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x10
	
		// Properties
		public abstract Texture2D texture { get; }
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Constructors
		protected BaseShaderInfoStorage(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static BaseShaderInfoStorage(); // 0x0000000182435660-0x0000000182435750
	
		// Methods
		public abstract bool AllocateRect(int width, int height, out RectInt uvs);
		public abstract void SetTexel(int x, int y, Color color);
		public abstract void UpdateTexture();
		public void Dispose(); // 0x00000001824355F0-0x0000000182435660
		protected virtual void Dispose(bool disposing); // 0x0000000182413DC0-0x0000000182413DD0
	}
}
