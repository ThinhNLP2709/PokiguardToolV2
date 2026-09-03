/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public interface ICameraHistoryReadAccess // TypeDefIndex: 5324
	{
		// Events
		event HistoryRequestDelegate OnGatherHistoryRequests {
			add; // 0x00000000-0x00000000
			remove; // 0x00000000-0x00000000
		}
	
		// Nested types
		public delegate void HistoryRequestDelegate(IPerFrameHistoryAccessTracker historyAccess); // TypeDefIndex: 5325; 0x00000001804A78A0-0x00000001804A78B0
	
		// Methods
		Type GetHistoryForRead<Type>()
			where Type : ContextItem;
	}
}
