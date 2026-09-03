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
	public abstract class Manipulator : IManipulator // TypeDefIndex: 4228
	{
		// Fields
		private VisualElement m_Target; // 0x10
	
		// Properties
		public VisualElement target { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001824B4090-0x00000001824B4100
	
		// Constructors
		protected Manipulator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected abstract void RegisterCallbacksOnTarget();
		protected abstract void UnregisterCallbacksFromTarget();
	}
}
