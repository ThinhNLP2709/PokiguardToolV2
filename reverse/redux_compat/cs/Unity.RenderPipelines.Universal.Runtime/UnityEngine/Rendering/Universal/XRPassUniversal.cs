/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal class XRPassUniversal : XRPass // TypeDefIndex: 9878
	{
		// Fields
		[CompilerGenerated]
		private bool _isLateLatchEnabled_k__BackingField; // 0x808
		[CompilerGenerated]
		private bool _canMarkLateLatch_k__BackingField; // 0x809
		[CompilerGenerated]
		private bool _hasMarkedLateLatch_k__BackingField; // 0x80A
		[CompilerGenerated]
		private bool _canFoveateIntermediatePasses_k__BackingField; // 0x80B
		internal CullingResults cullingResults; // 0x810
	
		// Properties
		internal bool isLateLatchEnabled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182030E90-0x0000000182030EA0 0x0000000182030ED0-0x0000000182030EE0
		internal bool canMarkLateLatch { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182030E70-0x0000000182030E80 0x0000000182030EB0-0x0000000182030EC0
		internal bool hasMarkedLateLatch { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182030E80-0x0000000182030E90 0x0000000182030EC0-0x0000000182030ED0
		internal bool canFoveateIntermediatePasses { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182030E60-0x0000000182030E70 0x0000000182030EA0-0x0000000182030EB0
	
		// Constructors
		public XRPassUniversal(); // 0x0000000182030E50-0x0000000182030E60
	
		// Methods
		public static XRPass Create(XRPassCreateInfo createInfo); // 0x0000000182030D30-0x0000000182030DF0
		public override void Release(); // 0x0000000182030DF0-0x0000000182030E50
	}
}
