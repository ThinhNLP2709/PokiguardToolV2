/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public interface ILayoutElement // TypeDefIndex: 13076
	{
		// Properties
		float minWidth { get; }
		float maxWidth { get; }
		float preferredWidth { get; }
		float flexibleWidth { get; }
		float minHeight { get; }
		float maxHeight { get; }
		float preferredHeight { get; }
		float flexibleHeight { get; }
		int layoutPriority { get; }
	
		// Methods
		void CalculateLayoutInputHorizontal();
		void CalculateLayoutInputVertical();
	}
}
