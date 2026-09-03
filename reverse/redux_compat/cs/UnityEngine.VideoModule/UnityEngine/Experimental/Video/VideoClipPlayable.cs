/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Playables;
using UnityEngine.Scripting;

// Image 78: UnityEngine.VideoModule.dll - Assembly: UnityEngine.VideoModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15895-15912

namespace UnityEngine.Experimental.Video
{
	[NativeHeader("Modules/Video/Public/VideoClip.h")]
	[NativeHeader("Modules/Video/Public/ScriptBindings/VideoClipPlayable.bindings.h")]
	[NativeHeader("Modules/Video/Public/Director/VideoClipPlayable.h")]
	[NativeHeader("Runtime/Director/Core/HPlayable.h")]
	[RequiredByNativeCode]
	[StaticAccessor("VideoClipPlayableBindings", StaticAccessorType.DoubleColon)]
	public struct VideoClipPlayable : IEquatable<UnityEngine.Experimental.Video.VideoClipPlayable> // TypeDefIndex: 15898
	{
		// Fields
		private PlayableHandle m_Handle; // 0x00
	
		// Methods
		public PlayableHandle GetHandle(); // 0x000000018092E600-0x000000018092E610
		public bool Equals(VideoClipPlayable other); // 0x0000000182155840-0x0000000182155870
	}
}
