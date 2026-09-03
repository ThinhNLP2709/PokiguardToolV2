/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 49: UnityEngine.ScriptingModule.dll - Assembly: UnityEngine.ScriptingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15445-15504

namespace UnityEngine.Bindings
{
	[IsByRefLike]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	[VisibleToOtherModules]
	internal struct BlittableListWrapper // TypeDefIndex: 15491
	{
		// Fields
		private MarshalledArray arrayWrapper; // 0x00
	
		// Constructors
		public BlittableListWrapper(BlittableArrayWrapper arrayWrapper, int listSize); // 0x00000001822E65C0-0x00000001822E65E0
	
		// Methods
		internal void Unmarshal<T>(List<T> list)
			where T : struct;
	}
}
