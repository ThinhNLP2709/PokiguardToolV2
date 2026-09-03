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
	public interface ITextSelection // TypeDefIndex: 4854
	{
		// Properties
		bool isSelectable { get; set; }
		int cursorIndex { get; set; }
		bool doubleClickSelectsWord { get; set; }
		int selectIndex { get; set; }
		bool tripleClickSelectsLine { get; set; }
		bool selectAllOnFocus { get; set; }
		bool selectAllOnMouseUp { get; set; }
		Vector2 cursorPosition { get; }
		float lineHeightAtCursorPosition { get; }
		float cursorWidth { get; }
	
		// Methods
		bool HasSelection();
		void SelectNone();
	}
}
