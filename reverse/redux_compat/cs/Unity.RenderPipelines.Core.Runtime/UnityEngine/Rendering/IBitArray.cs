/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public interface IBitArray // TypeDefIndex: 5731
	{
		// Properties
		uint capacity { get; }
		bool allFalse { get; }
		bool allTrue { get; }
		bool this[uint index] { get => default; set {} }
		string humanizedData { get; }
	
		// Methods
		IBitArray BitAnd(IBitArray other);
		IBitArray BitOr(IBitArray other);
		IBitArray BitNot();
	}
}
