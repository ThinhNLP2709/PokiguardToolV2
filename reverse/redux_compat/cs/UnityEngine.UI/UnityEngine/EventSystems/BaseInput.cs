/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public class BaseInput : UIBehaviour // TypeDefIndex: 13195
	{
		// Properties
		public virtual string compositionString { get; } // 0x00000001825ADAE0-0x00000001825ADB20 
		public virtual IMECompositionMode imeCompositionMode { get; set; } // 0x00000001825ADB20-0x00000001825ADB60 0x00000001825ADD20-0x00000001825ADD70
		public virtual Vector2 compositionCursorPos { get; set; } // 0x00000001825ADAA0-0x00000001825ADAE0 0x00000001825ADCC0-0x00000001825ADD20
		public virtual bool mousePresent { get; } // 0x00000001825ADBC0-0x00000001825ADC00 
		public virtual Vector2 mousePosition { get; } // 0x00000001825ADB60-0x00000001825ADBC0 
		public virtual Vector2 mouseScrollDelta { get; } // 0x00000001825ADC00-0x00000001825ADC40 
		public virtual float mouseScrollDeltaPerTick { get; } // 0x0000000181E471E0-0x0000000181E471F0 
		public virtual bool touchSupported { get; } // 0x00000001825ADC80-0x00000001825ADCC0 
		public virtual int touchCount { get; } // 0x00000001825ADC40-0x00000001825ADC80 
	
		// Constructors
		public BaseInput(); // 0x00000001820502E0-0x00000001820502F0
	
		// Methods
		public virtual bool GetMouseButtonDown(int button); // 0x00000001825AD920-0x00000001825AD970
		public virtual bool GetMouseButtonUp(int button); // 0x00000001825AD970-0x00000001825AD9C0
		public virtual bool GetMouseButton(int button); // 0x00000001825AD9C0-0x00000001825ADA10
		public virtual Touch GetTouch(int index); // 0x00000001825ADA10-0x00000001825ADAA0
		public virtual float GetAxisRaw(string axisName); // 0x00000001825AD880-0x00000001825AD8D0
		public virtual bool GetButtonDown(string buttonName); // 0x00000001825AD8D0-0x00000001825AD920
	}
}
