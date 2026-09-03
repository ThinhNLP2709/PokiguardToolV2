/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal class ResourcesData // TypeDefIndex: 6011
	{
		// Fields
		public NativeList<ResourceUnversionedData>[] unversionedData; // 0x10
		public NativeList<ResourceVersionedData>[] versionedData; // 0x18
		public NativeList<ResourceReaderData>[] readerData; // 0x20
		public DynamicArray<Name>[] resourceNames; // 0x28
	
		// Properties
		public ref ResourceVersionedData this[ResourceHandle h] { get => default; } // 0x0000000181F03050-0x0000000181F031D0 
	
		// Constructors
		public ResourcesData(); // 0x0000000181F02EA0-0x0000000181F03050
	
		// Methods
		public void Clear(); // 0x0000000181F023F0-0x0000000181F024E0
		private void AllocateAndResizeNativeListIfNeeded<T>(ref NativeList<T> nativeList, int size, NativeArrayOptions options)
			where T : struct;
		public void Initialize(RenderGraphResourceRegistry resources); // 0x0000000181F02760-0x0000000181F02EA0
		public int Index([IsReadOnly] in ResourceHandle h); // 0x0000000181F02690-0x0000000181F02760
		public int IndexReader([IsReadOnly] in ResourceHandle h, int readerID); // 0x0000000181F025B0-0x0000000181F02690
		public void Dispose(); // 0x0000000181F024E0-0x0000000181F025B0
	}
}
