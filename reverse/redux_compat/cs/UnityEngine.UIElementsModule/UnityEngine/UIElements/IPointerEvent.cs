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
	public interface IPointerEvent // TypeDefIndex: 4104
	{
		// Properties
		int pointerId { get; }
		string pointerType { get; }
		bool isPrimary { get; }
		int button { get; }
		int pressedButtons { get; }
		Vector3 position { get; }
		Vector3 localPosition { get; }
		Vector3 deltaPosition { get; }
		float deltaTime { get; }
		int clickCount { get; }
		float pressure { get; }
		float tangentialPressure { get; }
		float altitudeAngle { get; }
		float azimuthAngle { get; }
		float twist { get; }
		Vector2 tilt { get; }
		PenStatus penStatus { get; }
		Vector2 radius { get; }
		Vector2 radiusVariance { get; }
		EventModifiers modifiers { get; }
		bool shiftKey { get; }
		bool ctrlKey { get; }
		bool commandKey { get; }
		bool altKey { get; }
	}
}
