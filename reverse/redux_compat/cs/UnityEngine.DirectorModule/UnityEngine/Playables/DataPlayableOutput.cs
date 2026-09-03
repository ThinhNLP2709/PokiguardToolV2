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

// Image 63: UnityEngine.DirectorModule.dll - Assembly: UnityEngine.DirectorModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15783-15793

namespace UnityEngine.Playables
{
	[NativeHeader("Runtime/Director/Core/HPlayableGraph.h")]
	[NativeHeader("Runtime/Director/Core/HPlayableOutput.h")]
	[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutput.bindings.h")]
	[NativeHeader("Modules/Director/DataPlayableOutput.h")]
	[NativeHeader("Modules/Director/ScriptBindings/DataPlayableOutputExtensions.bindings.h")]
	[RequiredByNativeCode]
	[StaticAccessor("DataPlayableOutputBindings", StaticAccessorType.DoubleColon)]
	internal struct DataPlayableOutput // TypeDefIndex: 15786
	{
		// Fields
		private PlayableOutputHandle m_Handle; // 0x00
	
		// Constructors
		internal DataPlayableOutput(PlayableOutputHandle handle); // 0x0000000182270EC0-0x0000000182270F70
	
		// Methods
		[RequiredByNativeCode]
		private static void Internal_CallOnPlayerChanged(PlayableOutputHandle handle, object previousPlayer, object currentPlayer); // 0x0000000182270CA0-0x0000000182270EC0
	}
}
