/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	[RequiredByNativeCode]
	public sealed class ContextMenu : Attribute // TypeDefIndex: 7715
	{
		// Fields
		public readonly string menuItem; // 0x10
		public readonly bool validate; // 0x18
		public readonly int priority; // 0x1C
	
		// Constructors
		public ContextMenu(string itemName); // 0x00000001821E55E0-0x00000001821E5620
		public ContextMenu(string itemName, bool isValidateFunction); // 0x00000001821E5590-0x00000001821E55E0
		public ContextMenu(string itemName, bool isValidateFunction, int priority); // 0x00000001821E5530-0x00000001821E5590
	}
}
