/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ReloadAttribute : Attribute // TypeDefIndex: 5395
	{
		// Nested types
		public enum Package // TypeDefIndex: 5396
		{
			Builtin = 0,
			Root = 1,
			BuiltinExtra = 2
		}
	
		// Constructors
		public ReloadAttribute(string[] paths, Package package = Package.Root /* Metadata: 0x006614BB */); // 0x00000001802F4070-0x00000001802F4080
		public ReloadAttribute(string path, Package package = Package.Root /* Metadata: 0x006614BC */); // 0x0000000181E4BD10-0x0000000181E4BD90
		public ReloadAttribute(string pathFormat, int rangeMin, int rangeMax, Package package = Package.Root /* Metadata: 0x006614BD */); // 0x00000001802F4070-0x00000001802F4080
	}
}
