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

namespace UnityEngine.UI
{
	public interface ICanvasElement // TypeDefIndex: 13014
	{
		// Properties
		Transform transform { get; }
	
		// Methods
		void Rebuild(CanvasUpdate executing);
		void LayoutComplete();
		void GraphicUpdateComplete();
		bool IsDestroyed();
	}
}
