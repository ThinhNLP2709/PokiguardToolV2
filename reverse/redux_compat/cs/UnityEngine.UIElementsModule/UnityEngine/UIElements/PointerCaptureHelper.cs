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

namespace UnityEngine.UIElements
{
	public static class PointerCaptureHelper // TypeDefIndex: 4293
	{
		// Methods
		private static PointerDispatchState GetStateFor(IEventHandler handler); // 0x00000001824DB0C0-0x00000001824DB160
	
		// Extension methods
		public static bool HasPointerCapture(this IEventHandler handler, int pointerId); // 0x00000001824DB160-0x00000001824DB240
		public static void CapturePointer(this IEventHandler handler, int pointerId); // 0x00000001824DAE50-0x00000001824DB030
		public static void ReleasePointer(this IEventHandler handler, int pointerId); // 0x00000001824DB330-0x00000001824DB410
		public static IEventHandler GetCapturingElement(this IPanel panel, int pointerId); // 0x00000001824DB030-0x00000001824DB0C0
		public static void ReleasePointer(this IPanel panel, int pointerId); // 0x00000001824DB410-0x00000001824DB480
		internal static void ActivateCompatibilityMouseEvents(this IPanel panel, int pointerId); // 0x00000001824DADD0-0x00000001824DAE50
		internal static void PreventCompatibilityMouseEvents(this IPanel panel, int pointerId); // 0x00000001824DB240-0x00000001824DB2C0
		internal static bool ShouldSendCompatibilityMouseEvents(this IPanel panel, IPointerEvent evt); // 0x00000001824DB480-0x00000001824DB600
		internal static void ProcessPointerCapture(this IPanel panel, int pointerId); // 0x00000001824DB2C0-0x00000001824DB330
	}
}
