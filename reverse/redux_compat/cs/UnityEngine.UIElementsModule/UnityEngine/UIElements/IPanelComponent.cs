/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	public interface IPanelComponent // TypeDefIndex: 4241
	{
		// Properties
		GameObject gameObject { get; }
		PanelSettings panelSettings { get; set; }
		IPanelComponent parentUI { get; }
		float sortingOrder { get; }
		WorldSpaceSizeMode worldSpaceSizeMode { get; }
		Vector2 worldSpaceSize { get; }
		Position position { get; }
		PivotReferenceSize pivotReferenceSize { get; }
		Pivot pivot { get; }
		int creationIndex { get; }
		int softPointerCaptures { get; set; }
		VisualElementFocusRing focusRing { get; set; }
	
		// Methods
		void PerformValidation(bool forced);
		void PerformUpdate();
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		VisualElement GetRootVisualElement();
		IEventHandler GetRoot();
		void SetComponentEnabled(bool enabled);
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		bool GetComponentEnabled();
		Vector3 GetPanelPosition(IEventHandler pickedElement, Ray worldRay);
		IRuntimePanel GetContainerPanel();
	}
}
