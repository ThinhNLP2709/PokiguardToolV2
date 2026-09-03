/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class SupportedOnRenderPipelineAttribute : Attribute // TypeDefIndex: 8334
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly Lazy<Type[]> k_DefaultRenderPipelineAsset; // 0x00
		[CompilerGenerated]
		private readonly Type[] _renderPipelineTypes_k__BackingField; // 0x10
	
		// Properties
		public Type[] renderPipelineTypes { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		public enum SupportedMode // TypeDefIndex: 8335
		{
			Unsupported = 0,
			Supported = 1,
			SupportedByBaseClass = 2
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 8336
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Type, string> __9__6_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018226F9A0-0x000000018226FA10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal string _.ctor_b__6_0(Type t); // 0x000000018226F940-0x000000018226F9A0
			internal Type[] _.cctor_b__12_0(); // 0x000000018226F870-0x000000018226F940
		}
	
		// Constructors
		public SupportedOnRenderPipelineAttribute(Type renderPipeline); // 0x000000018226EB30-0x000000018226EBF0
		public SupportedOnRenderPipelineAttribute(params Type[] renderPipeline); // 0x000000018226E7C0-0x000000018226EB30
		static SupportedOnRenderPipelineAttribute(); // 0x000000018226E6B0-0x000000018226E7C0
	
		// Methods
		public SupportedMode GetSupportedMode(Type renderPipelineAssetType); // 0x000000018226E310-0x000000018226E440
		internal static SupportedMode GetSupportedMode(Type[] renderPipelineTypes, Type renderPipelineAssetType); // 0x000000018226E440-0x000000018226E540
		public static bool IsTypeSupportedOnRenderPipeline(Type type, Type renderPipelineAssetType); // 0x000000018226E540-0x000000018226E6B0
	}
}
