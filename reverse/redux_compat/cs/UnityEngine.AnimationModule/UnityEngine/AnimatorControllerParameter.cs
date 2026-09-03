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
	[NativeAsStruct]
	[NativeHeader("Modules/Animation/AnimatorControllerParameter.h")]
	[UsedByNativeCode]
	public class AnimatorControllerParameter // TypeDefIndex: 14738
	{
		// Fields
		internal string m_Name; // 0x10
		internal AnimatorControllerParameterType m_Type; // 0x18
		internal float m_DefaultFloat; // 0x1C
		internal int m_DefaultInt; // 0x20
		internal bool m_DefaultBool; // 0x24
	
		// Properties
		public string name { get; } // 0x0000000180377550-0x0000000180377560 
		public AnimatorControllerParameterType type { get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Constructors
		public AnimatorControllerParameter(); // 0x00000001821582C0-0x0000000182158310
	
		// Methods
		public override bool Equals(object o); // 0x0000000182158210-0x00000001821582C0
		public override int GetHashCode(); // 0x0000000181411DF0-0x0000000181411E20
	}
}
