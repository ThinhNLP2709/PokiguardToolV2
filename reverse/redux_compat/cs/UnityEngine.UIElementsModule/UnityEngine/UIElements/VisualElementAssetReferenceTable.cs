/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public sealed class VisualElementAssetReferenceTable : IDisposable // TypeDefIndex: 4299
	{
		// Fields
		internal static readonly ObjectPool<ElementNode> s_ElementNodePool; // 0x00
		internal static readonly ObjectPool<DocumentNode> s_DocumentNodePool; // 0x08
		internal static readonly ObjectPool<VisualElementAssetReferenceTable> s_TablePool; // 0x10
		[TupleElementNames(new string[2] {"root", "path" })]
		internal readonly Dictionary<ValueTuple<ElementNode, AuthoringIdPath>, GCHandle> m_CachedReferences; // 0x10
		[CompilerGenerated]
		private DocumentNode _root_k__BackingField; // 0x18
	
		// Properties
		public DocumentNode root { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		public class ElementNode : IDisposable // TypeDefIndex: 4300
		{
			// Fields
			internal GCHandle m_VisualElementHandle; // 0x10
	
			// Properties
			public VisualElement visualElement { set; } // 0x00000001824D5EC0-0x00000001824D5F00
	
			// Constructors
			internal ElementNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			~ElementNode(); // 0x00000001824D5DB0-0x00000001824D5E30
			public void Dispose(); // 0x00000001824D5D40-0x00000001824D5DB0
			internal virtual void ReleaseToPool(); // 0x00000001824D5E30-0x00000001824D5EC0
			internal void ReleaseHandle(); // 0x00000001824D5D20-0x00000001824D5D40
			protected virtual void Dispose(bool disposing); // 0x00000001824D5D20-0x00000001824D5D40
		}
	
		public class DocumentNode : ElementNode // TypeDefIndex: 4301
		{
			// Fields
			internal readonly Dictionary<int, ElementNode> m_Children; // 0x18
	
			// Constructors
			internal DocumentNode(); // 0x00000001824D4A20-0x00000001824D4AA0
	
			// Methods
			internal ElementNode AddElement(int id, VisualElement visualElement); // 0x00000001824D4790-0x00000001824D4870
			internal override void ReleaseToPool(); // 0x00000001824D4870-0x00000001824D4A20
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4302
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824DF090-0x00000001824DF100
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ElementNode _.cctor_b__20_0(); // 0x00000001824DEA00-0x00000001824DEA50
			internal void _.cctor_b__20_1(ElementNode node); // 0x00000001824DEA50-0x00000001824DEAC0
			internal DocumentNode _.cctor_b__20_2(); // 0x00000001824DEAC0-0x00000001824DEB70
			internal void _.cctor_b__20_3(DocumentNode node); // 0x00000001824DEA50-0x00000001824DEAC0
			internal VisualElementAssetReferenceTable _.cctor_b__20_4(); // 0x00000001824DEB70-0x00000001824DEC20
			internal void _.cctor_b__20_5(VisualElementAssetReferenceTable node); // 0x00000001824DEC20-0x00000001824DECB0
		}
	
		// Constructors
		private VisualElementAssetReferenceTable(); // 0x00000001824E3880-0x00000001824E3900
		static VisualElementAssetReferenceTable(); // 0x00000001824E34B0-0x00000001824E3880
	
		// Methods
		~VisualElementAssetReferenceTable(); // 0x00000001824E3240-0x00000001824E32B0
		internal static VisualElementAssetReferenceTable Create(VisualElement rootElement); // 0x00000001824E3030-0x00000001824E3170
		public void ReleaseToPool(); // 0x00000001824E33F0-0x00000001824E34B0
		private void FreeCachedReference(); // 0x00000001824E32B0-0x00000001824E33F0
		public void Dispose(); // 0x00000001824E31C0-0x00000001824E3240
		private void Dispose(bool disposing); // 0x00000001824E3170-0x00000001824E31C0
	}
}
