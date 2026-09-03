/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	internal class AttributeHelperEngine // TypeDefIndex: 7710
	{
		// Fields
		[NoAutoStaticsCleanup]
		public static DisallowMultipleComponent[] _disallowMultipleComponentArray; // 0x00
		[NoAutoStaticsCleanup]
		public static ExecuteInEditMode[] _executeInEditModeArray; // 0x08
		[NoAutoStaticsCleanup]
		public static RequireComponent[] _requireComponentArray; // 0x10
	
		// Constructors
		static AttributeHelperEngine(); // 0x00000001821E2B90-0x00000001821E2C90
	
		// Methods
		[RequiredByNativeCode]
		private static Type GetParentTypeDisallowingMultipleInclusion(Type type); // 0x00000001821E25F0-0x00000001821E2720
		[RequiredByNativeCode]
		private static Type[] GetRequiredComponents(Type klass); // 0x00000001821E2720-0x00000001821E2B90
		private static int GetExecuteMode(Type klass); // 0x00000001821E2540-0x00000001821E25F0
		[RequiredByNativeCode]
		private static int CheckIsEditorScript(Type klass); // 0x00000001821E2330-0x00000001821E24D0
		[RequiredByNativeCode]
		private static int GetDefaultExecutionOrderFor(Type klass); // 0x00000001821E24D0-0x00000001821E2540
		private static T GetCustomAttributeOfType<T>(Type klass)
			where T : Attribute;
	}
}
