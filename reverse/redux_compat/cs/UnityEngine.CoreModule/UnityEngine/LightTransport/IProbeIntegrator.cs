/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LightTransport
{
	public interface IProbeIntegrator : IDisposable // TypeDefIndex: 8189
	{
		// Nested types
		public enum ResultType : uint // TypeDefIndex: 8190
		{
			Success = 0,
			Cancelled = 1,
			JobFailed = 2,
			OutOfMemory = 3,
			InvalidInput = 4,
			LowLevelAPIFailure = 5,
			IOFailed = 6,
			Undefined = 7
		}
	
		public struct Result // TypeDefIndex: 8191
		{
			// Fields
			public ResultType type; // 0x00
			public string message; // 0x08
	
			// Constructors
			public Result(ResultType _type, string _message); // 0x0000000180F37790-0x0000000180F377B0
	
			// Methods
			public override string ToString(); // 0x000000018224FF40-0x000000018224FFF0
		}
	}
}
