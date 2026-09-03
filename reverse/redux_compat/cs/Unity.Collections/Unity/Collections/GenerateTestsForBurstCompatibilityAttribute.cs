/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
	public class GenerateTestsForBurstCompatibilityAttribute : Attribute // TypeDefIndex: 11545
	{
		// Fields
		[CompilerGenerated]
		private Type[] _GenericTypeArguments_k__BackingField; // 0x10
		public string RequiredUnityDefine; // 0x18
		public BurstCompatibleCompileTarget CompileTarget; // 0x20
	
		// Properties
		public Type[] GenericTypeArguments { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
	
		// Nested types
		public enum BurstCompatibleCompileTarget // TypeDefIndex: 11546
		{
			Player = 0,
			Editor = 1,
			PlayerAndEditor = 2
		}
	
		// Constructors
		public GenerateTestsForBurstCompatibilityAttribute(); // 0x00000001802F4070-0x00000001802F4080
	}
}
