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
	[NativeHeader("Runtime/Export/Input/Cursor.bindings.h")]
	public class Cursor // TypeDefIndex: 7648
	{
		// Properties
		public static CursorLockMode lockState { get; } // 0x00000001821CBCC0-0x00000001821CBCF0 
	
		// Methods
		public static void SetCursor(Texture2D texture, Vector2 hotspot, CursorMode cursorMode); // 0x00000001821CBC60-0x00000001821CBCC0
		private static void SetCursor_Injected(IntPtr texture, in Vector2 hotspot, CursorMode cursorMode); // 0x00000001821CBC00-0x00000001821CBC60
	}
}
