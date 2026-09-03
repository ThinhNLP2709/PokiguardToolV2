/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal sealed class MeshModifierChainCache : IDisposable // TypeDefIndex: 5106
	{
		// Fields
		private readonly Dictionary<int, List<ChainInfo>> m_Buckets; // 0x10
		private readonly Dictionary<List<MeshModifierRegistration>, ChainInfo> m_InfoByChain; // 0x18
		private readonly List<int> m_PruneEmptyKeys; // 0x20
		private ChainInfo m_FreeChainInfoHead; // 0x28
	
		// Nested types
		private sealed class ChainInfo // TypeDefIndex: 5107
		{
			// Fields
			public List<MeshModifierRegistration> chain; // 0x10
			public int refCount; // 0x18
			public ChainInfo nextFree; // 0x20
	
			// Constructors
			public ChainInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		private sealed class RefComparer : IEqualityComparer<List<MeshModifierRegistration>> // TypeDefIndex: 5108
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static readonly RefComparer Instance; // 0x00
	
			// Constructors
			public RefComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static RefComparer(); // 0x0000000182427990-0x0000000182427A00
	
			// Methods
			public bool Equals(List<MeshModifierRegistration> x, List<MeshModifierRegistration> y); // 0x000000018171AC80-0x000000018171AC90
			public int GetHashCode(List<MeshModifierRegistration> obj); // 0x000000018171AC90-0x000000018171ACA0
		}
	
		// Constructors
		public MeshModifierChainCache(); // 0x0000000182424080-0x00000001824241D0
	
		// Methods
		public List<MeshModifierRegistration> GetShared(List<MeshModifierRegistration> content); // 0x0000000182423690-0x0000000182423A90
		public void Acquire(List<MeshModifierRegistration> chain); // 0x00000001824233D0-0x0000000182423440
		public void Release(List<MeshModifierRegistration> chain); // 0x0000000182423D70-0x0000000182423F20
		public void Prune(); // 0x0000000182423A90-0x0000000182423D00
		public void Dispose(); // 0x0000000182423640-0x0000000182423690
		private void RemoveInfo(ChainInfo info); // 0x0000000182423F20-0x0000000182424080
		private ChainInfo AcquireChainInfo(List<MeshModifierRegistration> content); // 0x00000001824232C0-0x00000001824233D0
		private void ReleaseChainInfo(ChainInfo info); // 0x0000000182423D00-0x0000000182423D70
		private static int ComputeHash(List<MeshModifierRegistration> chain); // 0x0000000182423440-0x0000000182423530
		private static bool ContentEquals(List<MeshModifierRegistration> a, List<MeshModifierRegistration> b); // 0x0000000182423530-0x0000000182423640
	}
}
