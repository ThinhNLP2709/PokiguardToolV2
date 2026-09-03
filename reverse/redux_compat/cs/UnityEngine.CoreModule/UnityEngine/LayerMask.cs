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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("BitField", "struct BitField;")]
	[NativeHeader("Runtime/BaseClasses/TagManager.h")]
	[NativeHeader("Runtime/BaseClasses/BitField.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct LayerMask // TypeDefIndex: 7757
	{
		// Fields
		[NativeName("m_Bits")]
		[SerializeField]
		private int m_Mask; // 0x00
	
		// Properties
		public int value { get; } // 0x0000000180732D10-0x0000000180732D20 
	
		// Methods
		public static implicit operator int(LayerMask mask); // 0x0000000180815D70-0x0000000180815D80
		public static implicit operator LayerMask(int intVal); // 0x0000000180815D70-0x0000000180815D80
		[NativeMethod("LayerToString")]
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static string LayerToName(int layer); // 0x00000001821EBC80-0x00000001821EBD40
		[NativeMethod("StringToLayer")]
		[StaticAccessor("GetTagManager()", StaticAccessorType.Dot)]
		public static int NameToLayer(string layerName); // 0x00000001821EBD80-0x00000001821EBED0
		[NativeMethod(Name = "CurrentThreadIsMainThread", IsFreeFunction = true, IsThreadSafe = true)]
		private static bool CurrentThreadIsMainThread(); // 0x00000001821EBC10-0x00000001821EBC40
		public override string ToString(); // 0x00000001821EBED0-0x00000001821EC060
		private static void LayerToName_Injected(int layer, ); // 0x00000001821EBC40-0x00000001821EBC80
		private static int NameToLayer_Injected(ref ManagedSpanWrapper layerName); // 0x00000001821EBD40-0x00000001821EBD80
	}
}
