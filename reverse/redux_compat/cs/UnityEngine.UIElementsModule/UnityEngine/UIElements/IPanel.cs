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
	public interface IPanel : IDisposable // TypeDefIndex: 4275
	{
		// Properties
		VisualElement visualTree { get; }
		EventDispatcher dispatcher { get; }
		ContextType contextType { get; }
		FocusController focusController { get; }
		bool isDirty { get; }
		float scaledPixelsPerPoint { get; }
	}
}
