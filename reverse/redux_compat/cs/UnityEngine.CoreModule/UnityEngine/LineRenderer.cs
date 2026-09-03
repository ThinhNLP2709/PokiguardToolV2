/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("LineRenderer", PersistentTypeId = 120)]
	[NativeHeader("Runtime/Graphics/LineRenderer.h")]
	[NativeHeader("Runtime/Graphics/GraphicsScriptBindings.h")]
	public sealed class LineRenderer : Renderer // TypeDefIndex: 7567
	{
		// Properties
		public float startWidth { set; } // 0x00000001821A5FF0-0x00000001821A6060
		public float endWidth { set; } // 0x00000001821A5BF0-0x00000001821A5C60
		public int numCornerVertices { set; } // 0x00000001821A5DF0-0x00000001821A5E50
		public int numCapVertices { set; } // 0x00000001821A5D50-0x00000001821A5DB0
		public bool useWorldSpace { set; } // 0x00000001821A60B0-0x00000001821A6110
		public bool loop { set; } // 0x00000001821A5CB0-0x00000001821A5D10
		public Color startColor { set; } // 0x00000001821A5F40-0x00000001821A5FA0
		public Color endColor { set; } // 0x00000001821A5B40-0x00000001821A5BA0
		[NativeProperty("PositionsCount")]
		public int positionCount { set; } // 0x00000001821A5E90-0x00000001821A5EF0
	
		// Constructors
		public LineRenderer(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		public void SetPosition(int index, Vector3 position); // 0x00000001821A5A80-0x00000001821A5AF0
		private static void set_startWidth_Injected(IntPtr _unity_self, float value); // 0x00000001821A5FA0-0x00000001821A5FF0
		private static void set_endWidth_Injected(IntPtr _unity_self, float value); // 0x00000001821A5BA0-0x00000001821A5BF0
		private static void set_numCornerVertices_Injected(IntPtr _unity_self, int value); // 0x00000001821A5DB0-0x00000001821A5DF0
		private static void set_numCapVertices_Injected(IntPtr _unity_self, int value); // 0x00000001821A5D10-0x00000001821A5D50
		private static void set_useWorldSpace_Injected(IntPtr _unity_self, bool value); // 0x00000001821A6060-0x00000001821A60B0
		private static void set_loop_Injected(IntPtr _unity_self, bool value); // 0x00000001821A5C60-0x00000001821A5CB0
		private static void set_startColor_Injected(IntPtr _unity_self, in Color value); // 0x00000001821A5EF0-0x00000001821A5F40
		private static void set_endColor_Injected(IntPtr _unity_self, in Color value); // 0x00000001821A5AF0-0x00000001821A5B40
		private static void set_positionCount_Injected(IntPtr _unity_self, int value); // 0x00000001821A5E50-0x00000001821A5E90
		private static void SetPosition_Injected(IntPtr _unity_self, int index, in Vector3 position); // 0x00000001821A5A30-0x00000001821A5A80
	}
}
