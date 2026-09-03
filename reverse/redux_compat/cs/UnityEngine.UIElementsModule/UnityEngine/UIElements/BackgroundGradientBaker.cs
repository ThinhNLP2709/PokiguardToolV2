/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class BackgroundGradientBaker : IDisposable // TypeDefIndex: 4305
	{
		// Fields
		private readonly Dictionary<BackgroundGradient, VectorImage> m_Cache; // 0x10
		private readonly Dictionary<VectorImage, Entry> m_Entries; // 0x18
		private readonly HashSet<VectorImage> m_PendingEviction; // 0x20
		private readonly List<VectorImage> m_PurgeScratch; // 0x28
		private bool m_Disposed; // 0x30
	
		// Nested types
		private sealed class Entry // TypeDefIndex: 4306
		{
			// Fields
			public BackgroundGradient sourceKey; // 0x10
			public int refCount; // 0x30
	
			// Constructors
			public Entry(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public BackgroundGradientBaker(); // 0x00000001824CF1E0-0x00000001824CF330
	
		// Methods
		public VectorImage Bake([IsReadOnly] in BackgroundGradient gradient); // 0x00000001824CDB50-0x00000001824CDFB0
		internal void AddUser(VectorImage vi); // 0x00000001824CDA80-0x00000001824CDB50
		internal void RemoveUser(VectorImage vi); // 0x00000001824CEEB0-0x00000001824CEF90
		internal void PurgePending(); // 0x00000001824CE8D0-0x00000001824CECE0
		public void Dispose(); // 0x00000001824CE450-0x00000001824CE670
		private static Texture2D CreateAtlas([IsReadOnly] in BackgroundGradient gradient); // 0x00000001824CE2E0-0x00000001824CE450
		private static void ComputeQuadMesh([IsReadOnly] in BackgroundGradient gradient, out VectorImageVertex[] vertices, out ushort[] indices); // 0x00000001824CDFB0-0x00000001824CE2E0
		internal static Vector2 LinearUV(Vector2 corner, float angleRadians); // 0x00000001824CE7E0-0x00000001824CE8A0
		internal static Vector2 RadialUV(Vector2 corner, Vector2 center, BackgroundGradientSize sizeMode); // 0x00000001824CECE0-0x00000001824CEEB0
		internal static void EllipseAxes(Vector2 center, BackgroundGradientSize sizeMode, out float Rx, out float Ry); // 0x00000001824CE670-0x00000001824CE7E0
		private static Color32 SampleStops([IsReadOnly] in BackgroundGradient gradient, float t); // 0x00000001824CEF90-0x00000001824CF1E0
		private static float NormalizePosition(float pos, bool isPercent); // 0x00000001824CE8A0-0x00000001824CE8D0
	}
}
