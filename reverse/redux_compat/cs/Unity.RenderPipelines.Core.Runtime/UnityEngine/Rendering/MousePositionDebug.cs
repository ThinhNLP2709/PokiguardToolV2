/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class MousePositionDebug // TypeDefIndex: 5513
	{
		// Fields
		private static MousePositionDebug s_Instance; // 0x00
	
		// Properties
		public static MousePositionDebug instance { get; } // 0x0000000181E53F80-0x0000000181E54010 
	
		// Constructors
		public MousePositionDebug(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Build(); // 0x00000001802E76C0-0x00000001802E76D0
		public void Cleanup(); // 0x00000001802E76C0-0x00000001802E76D0
		public Vector2 GetMousePosition(float ScreenHeight, bool sceneView); // 0x0000000181E53ED0-0x0000000181E53F80
		private Vector2 GetInputMousePosition(); // 0x0000000181E53E10-0x0000000181E53EB0
		public Vector2 GetMouseClickPosition(float ScreenHeight); // 0x0000000181E53EB0-0x0000000181E53ED0
	}
}
