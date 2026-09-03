/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Profiling
{
	internal interface IProfilerEmitter // TypeDefIndex: 13784
	{
		// Properties
		bool IsEnabled { get; }
	
		// Methods
		void EmitFrameMetaData(Guid id, int tag, Array data);
		void InitialiseCallbacks(Action<float> onLateUpdateDelegate);
	}
}
