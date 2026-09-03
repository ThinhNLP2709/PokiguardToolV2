/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine.Rendering;
using UnityEngine.Rendering.RenderGraphModule;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	internal class CompilerContextData : IDisposable // TypeDefIndex: 5987
	{
		// Fields
		public ResourcesData resources; // 0x10
		public NativeList<PassData> passData; // 0x18
		public NativeList<PassData> compactedNonCulledRasterPasses; // 0x20
		public Dictionary<int, GraphicsFence> fences; // 0x28
		public DynamicArray<Name> passNames; // 0x30
		public NativeList<PassInputData> inputData; // 0x38
		public NativeList<PassOutputData> outputData; // 0x40
		public NativeList<PassFragmentData> fragmentData; // 0x48
		public NativeList<ResourceHandle> sampledData; // 0x50
		public NativeList<ResourceHandle> createData; // 0x58
		public NativeList<ResourceHandle> destroyData; // 0x60
		public NativeList<PassRandomWriteData> randomAccessResourceData; // 0x68
		public NativeList<NativePassData> nativePassData; // 0x70
		public NativeList<SubPassDescriptor> nativeSubPassData; // 0x78
		private bool m_AreNativeListsAllocated; // 0x80
	
		// Properties
		public PassIterator Passes { get; } // 0x0000000181ED9830-0x0000000181ED9850 
		public NativePassIterator NativePasses { get; } // 0x0000000181ED9830-0x0000000181ED9850 
	
		// Nested types
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		public struct PassIterator // TypeDefIndex: 5988
		{
			// Fields
			private readonly CompilerContextData m_Ctx; // 0x00
			private int m_Index; // 0x08
	
			// Properties
			[IsReadOnly]
			public ref PassData Current { get; } // 0x0000000181F01E20-0x0000000181F01E50 
	
			// Constructors
			public PassIterator(CompilerContextData ctx); // 0x000000018112DD90-0x000000018112DDA0
	
			// Methods
			public bool MoveNext(); // 0x0000000181F01DF0-0x0000000181F01E20
			public PassIterator GetEnumerator(); // 0x000000018092E600-0x000000018092E610
		}
	
		[IsByRefLike]
		[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
		public struct NativePassIterator // TypeDefIndex: 5989
		{
			// Fields
			private readonly CompilerContextData m_Ctx; // 0x00
			private int m_Index; // 0x08
	
			// Properties
			[IsReadOnly]
			public ref NativePassData Current { get; } // 0x0000000181F00A30-0x0000000181F00A60 
	
			// Constructors
			public NativePassIterator(CompilerContextData ctx); // 0x000000018112DD90-0x000000018112DDA0
	
			// Methods
			public bool MoveNext(); // 0x0000000181F009D0-0x0000000181F00A30
			public NativePassIterator GetEnumerator(); // 0x000000018092E600-0x000000018092E610
		}
	
		// Constructors
		public CompilerContextData(); // 0x0000000181ED9730-0x0000000181ED9830
	
		// Methods
		private void AllocateNativeDataStructuresIfNeeded(int estimatedNumPasses); // 0x0000000181ED8070-0x0000000181ED82E0
		public void Initialize(RenderGraphResourceRegistry resourceRegistry, int estimatedNumPasses); // 0x0000000181ED8F40-0x0000000181ED8FD0
		public void Clear(); // 0x0000000181ED83A0-0x0000000181ED8480
		public ref ResourceUnversionedData UnversionedResourceData([IsReadOnly] in ResourceHandle h); // 0x0000000181ED9630-0x0000000181ED96F0
		public ref ResourceVersionedData VersionedResourceData([IsReadOnly] in ResourceHandle h); // 0x0000000181ED96F0-0x0000000181ED9730
		public ReadOnlySpan<ResourceReaderData> Readers([IsReadOnly] in ResourceHandle h); // 0x0000000181ED8FD0-0x0000000181ED9130
		public ref ResourceReaderData ResourceReader([IsReadOnly] in ResourceHandle h, int i); // 0x0000000181ED9130-0x0000000181ED9260
		public bool TryAddToFragmentList([IsReadOnly] in TextureAccess access, int listFirstIndex, int numItems, out string errorMessage); // 0x0000000181ED92B0-0x0000000181ED93F0
		public Name GetFullPassName(int passId); // 0x0000000181ED85C0-0x0000000181ED8600
		public string GetPassName(int passId); // 0x0000000181ED8940-0x0000000181ED8970
		public string GetResourceName([IsReadOnly] in ResourceHandle h); // 0x0000000181ED8BB0-0x0000000181ED8C80
		public string GetResourceVersionedName([IsReadOnly] in ResourceHandle h); // 0x0000000181ED8C80-0x0000000181ED8DC0
		public bool TryAddToRandomAccessResourceList([IsReadOnly] in ResourceHandle h, int randomWriteSlotIndex, bool preserveCounterValue, int listFirstIndex, int numItems, out string errorMessage); // 0x0000000181ED93F0-0x0000000181ED9630
		public void TagAllPasses(int value); // 0x0000000181ED9260-0x0000000181ED92B0
		public void CullAllPasses(bool isCulled); // 0x0000000181ED8480-0x0000000181ED84D0
		public TextureUVOrigin GetTextureUVOrigin([IsReadOnly] in TextureHandle targetHandle); // 0x0000000181ED8DC0-0x0000000181ED8F40
		internal List<PassData> GetPasses(); // 0x0000000181ED8970-0x0000000181ED8BB0
		internal List<NativePassData> GetNativePasses(); // 0x0000000181ED8600-0x0000000181ED8940
		public void Dispose(); // 0x0000000181ED84D0-0x0000000181ED85C0
		private void Cleanup(); // 0x0000000181ED82E0-0x0000000181ED83A0
	}
}
