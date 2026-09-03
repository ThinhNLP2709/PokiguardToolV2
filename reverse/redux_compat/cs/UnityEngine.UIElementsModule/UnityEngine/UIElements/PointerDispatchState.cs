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
	internal class PointerDispatchState // TypeDefIndex: 4294
	{
		// Fields
		private IEventHandler[] m_PendingPointerCapture; // 0x10
		private IEventHandler[] m_PointerCapture; // 0x18
		private bool[] m_ShouldSendCompatibilityMouseEvents; // 0x20
	
		// Constructors
		public PointerDispatchState(); // 0x00000001824DC020-0x00000001824DC1E0
	
		// Methods
		internal void Reset(); // 0x00000001824DBE30-0x00000001824DBF20
		public IEventHandler GetCapturingElement(int pointerId); // 0x0000000181ACD1B0-0x0000000181ACD1E0
		public bool HasPointerCapture(IEventHandler handler, int pointerId); // 0x00000001824DB770-0x00000001824DB7A0
		public void CapturePointer(IEventHandler handler, int pointerId); // 0x00000001824DB630-0x00000001824DB770
		public void ReleasePointer(int pointerId); // 0x00000001824DBD30-0x00000001824DBDF0
		public void ReleasePointer(IEventHandler handler, int pointerId); // 0x00000001824DBDF0-0x00000001824DBE30
		public void ProcessPointerCapture(int pointerId); // 0x00000001824DB7D0-0x00000001824DBD30
		public void ActivateCompatibilityMouseEvents(int pointerId); // 0x00000001824DB600-0x00000001824DB630
		public void PreventCompatibilityMouseEvents(int pointerId); // 0x00000001824DB7A0-0x00000001824DB7D0
		public bool ShouldSendCompatibilityMouseEvents(IPointerEvent evt); // 0x00000001824DBF20-0x00000001824DC020
	}
}
