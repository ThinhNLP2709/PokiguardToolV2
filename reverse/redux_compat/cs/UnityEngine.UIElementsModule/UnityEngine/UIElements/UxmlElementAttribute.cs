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
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class UxmlElementAttribute : Attribute // TypeDefIndex: 4896
	{
		// Fields
		public readonly string name; // 0x10
		public string libraryPath; // 0x18
		internal readonly Type[] supportedChildTypes; // 0x20
	
		// Constructors
		public UxmlElementAttribute(); // 0x00000001823E2280-0x00000001823E22C0
		public UxmlElementAttribute(string uxmlName); // 0x00000001823E2230-0x00000001823E2280
		public UxmlElementAttribute(string uxmlName, params Type[] supportedTypes); // 0x00000001823E21E0-0x00000001823E2230
	}
}
