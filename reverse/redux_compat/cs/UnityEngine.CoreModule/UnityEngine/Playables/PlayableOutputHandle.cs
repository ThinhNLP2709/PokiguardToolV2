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

namespace UnityEngine.Playables
{
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[NativeHeader("Runtime/Export/Director/PlayableOutputHandle.bindings.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[UsedByNativeCode]
	public struct PlayableOutputHandle : IEquatable<UnityEngine.Playables.PlayableOutputHandle> // TypeDefIndex: 8206
	{
		// Fields
		internal IntPtr m_Handle; // 0x00
		internal uint m_Version; // 0x08
		private static readonly PlayableOutputHandle m_Null; // 0x00
	
		// Properties
		public static PlayableOutputHandle Null { get; } // 0x000000018224B4B0-0x000000018224B500 
	
		// Methods
		[VisibleToOtherModules]
		internal bool IsPlayableOutputOfType<T>();
		public override int GetHashCode(); // 0x000000018224B2A0-0x000000018224B2D0
		public static bool operator ==(PlayableOutputHandle lhs, PlayableOutputHandle rhs); // 0x000000018222B110-0x000000018222B130
		public override bool Equals(object p); // 0x000000018224B3A0-0x000000018224B430
		public bool Equals(PlayableOutputHandle other); // 0x000000018222B110-0x000000018222B130
		internal static bool CompareVersion(PlayableOutputHandle lhs, PlayableOutputHandle rhs); // 0x0000000180C10DC0-0x0000000180C10DE0
		[VisibleToOtherModules]
		internal bool IsValid(); // 0x000000018224B470-0x000000018224B4B0
		[FreeFunction("PlayableOutputHandleBindings::GetPlayableOutputType", HasExplicitThis = true, ThrowsException = true)]
		internal Type GetPlayableOutputType(); // 0x000000018224B430-0x000000018224B470
	}
}
