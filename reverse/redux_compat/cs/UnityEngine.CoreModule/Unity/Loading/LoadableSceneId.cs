/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Loading
{
	[Serializable]
	[NativeHeader("Runtime/Export/SceneManager/LoadableSceneId.h")]
	[RequiredByNativeCode]
	public struct LoadableSceneId : IEquatable<Unity.Loading.LoadableSceneId> // TypeDefIndex: 7391
	{
		// Fields
		internal GUID m_SceneGUID; // 0x00
		private LoadableSceneIdFlags m_Flags; // 0x10
	
		// Methods
		[ExcludeFromDocs]
		public override string ToString(); // 0x00000001821902A0-0x00000001821902B0
		[ExcludeFromDocs]
		public override int GetHashCode(); // 0x0000000182190290-0x00000001821902A0
		[ExcludeFromDocs]
		public override bool Equals(object other); // 0x00000001821901C0-0x0000000182190260
		[ExcludeFromDocs]
		public bool Equals(LoadableSceneId other); // 0x0000000182190260-0x0000000182190290
	}
}
