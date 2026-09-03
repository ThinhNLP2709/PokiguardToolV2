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
	public abstract class PointerManipulator : MouseManipulator // TypeDefIndex: 4295
	{
		// Fields
		private int m_CurrentPointerId; // 0x20
	
		// Constructors
		protected PointerManipulator(); // 0x00000001824DC390-0x00000001824DC3A0
	
		// Methods
		protected bool CanStartManipulation(IPointerEvent e); // 0x00000001824DC1E0-0x00000001824DC330
		protected bool CanStopManipulation(IPointerEvent e); // 0x00000001824DC330-0x00000001824DC390
	}
}
