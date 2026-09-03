/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 32: UnityEngine.AnimationModule.dll - Assembly: UnityEngine.AnimationModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14715-14764

namespace UnityEngine
{
	[NativeHeader("Modules/Animation/HumanDescription.h")]
	[NativeType(CodegenOptions.Custom, "MonoSkeletonBone")]
	[RequiredByNativeCode]
	public struct SkeletonBone // TypeDefIndex: 14743
	{
		// Fields
		[NativeName("m_Name")]
		public string name; // 0x00
		[NativeName("m_ParentName")]
		internal string parentName; // 0x08
		[NativeName("m_Position")]
		public Vector3 position; // 0x10
		[NativeName("m_Rotation")]
		public Quaternion rotation; // 0x1C
		[NativeName("m_Scale")]
		public Vector3 scale; // 0x2C
	}
}
