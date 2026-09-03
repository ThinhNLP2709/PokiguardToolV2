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

namespace UnityEngine.SceneManagement
{
	[Serializable]
	[NativeClass("UnitySceneHandle")]
	[NativeHeader("Runtime/SceneManager/UnitySceneHandle.h")]
	[UsedByNativeCode]
	public struct SceneHandle : IEquatable<SceneHandle>, IFormattable // TypeDefIndex: 8001
	{
		// Fields
		internal EntityId m_Value; // 0x00
	
		// Methods
		public override bool Equals(object obj); // 0x0000000182250000-0x0000000182250090
		public bool Equals(SceneHandle other); // 0x000000018224FFF0-0x0000000182250000
		public static bool operator ==(SceneHandle left, SceneHandle right); // 0x0000000181524170-0x0000000181524180
		public static bool operator !=(SceneHandle left, SceneHandle right); // 0x00000001822500C0-0x00000001822500E0
		public override int GetHashCode(); // 0x0000000182250090-0x00000001822500A0
		public override string ToString(); // 0x00000001822500B0-0x00000001822500C0
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001822500A0-0x00000001822500B0
	}
}
