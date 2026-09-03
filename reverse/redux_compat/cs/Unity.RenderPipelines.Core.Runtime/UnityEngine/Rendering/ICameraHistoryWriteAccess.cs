/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public interface ICameraHistoryWriteAccess // TypeDefIndex: 5323
	{
		// Methods
		bool IsAccessRequested<Type>()
			where Type : ContextItem;
		Type GetHistoryForWrite<Type>()
			where Type : ContextItem, new();
		bool IsWritten<Type>()
			where Type : ContextItem;
	}
}
