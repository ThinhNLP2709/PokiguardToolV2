/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Pool;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	[HelpURL("UIE-VisualTree-landing")]
	public class VisualTreeAsset : ScriptableObject // TypeDefIndex: 4911
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal const string NoRegisteredUxmlElementErrorMessage = "Element \'{0}\' is missing a UxmlElementAttribute. Please ensure that you have the correct namespace imported."; // Metadata: 0x00660818
		internal const string NoRegisteredUxmlElementErrorMessageLabel = "Unknown type: \'{0}\'"; // Metadata: 0x00660886
		internal const string TemplateAliasExistsError = "VisualTreeAsset: could not register a template alias for asset `{0}`, alias is already defined for asset \'{1}\'"; // Metadata: 0x0066089A
		internal const string RootElementName = "UXML"; // Metadata: 0x0066090A
		[SerializeField]
		private bool m_ImportedWithErrors; // 0x18
		[SerializeField]
		private bool m_HasEditorElements; // 0x19
		[SerializeField]
		private bool m_HasUpdatedUrls; // 0x1A
		[SerializeField]
		private bool m_ImportedWithWarnings; // 0x1B
		[SerializeField]
		private bool m_ImportedWithObsoleteAttributeNames; // 0x1C
		private static readonly Dictionary<string, VisualElement> s_TemporarySlotInsertionPoints; // 0x00
		private static readonly List<int> s_VeaIdsPath; // 0x08
		[SerializeField]
		private List<UsingEntry> m_Usings; // 0x20
		[SerializeField]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleSheet inlineSheet; // 0x28
		[SerializeReference]
		private VisualElementAsset m_VisualTree; // 0x30
		[NonSerialized]
		private Dictionary<int, UxmlAsset> m_UsedIds; // 0x38
		[CompilerGenerated]
		private AuthoringIdConflictResolvedHandler onAuthoringIdConflictResolved; // 0x40
		[SerializeField]
		private List<AssetEntry> m_AssetEntries; // 0x48
		[SerializeField]
		private List<SlotDefinition> m_Slots; // 0x50
		[SerializeField]
		private int m_ContentContainerId; // 0x58
		[SerializeField]
		private int m_ContentHash; // 0x5C
	
		// Properties
		public bool importedWithErrors { get; internal set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		internal bool hasEditorElements { get; set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool importerWithUpdatedUrls { get; set; } // 0x0000000181780E00-0x0000000181780E10 0x0000000181780E20-0x0000000181780E30
		public bool importedWithWarnings { get; internal set; } // 0x0000000181DBEDC0-0x0000000181DBEDD0 0x0000000181DBEF90-0x0000000181DBEFA0
		internal bool importedWithObsoleteAttributeNames { get; set; } // 0x0000000180E38E30-0x0000000180E38E40 0x0000000181E92340-0x0000000181E92350
		internal List<UsingEntry> usings { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x00000001802F8630-0x00000001802F8640 
		public IEnumerable<VisualTreeAsset> templateDependencies { [IteratorStateMachine(typeof(_get_templateDependencies_d__36))] get; } // 0x00000001823EB3E0-0x00000001823EB460 
		private Dictionary<int, UxmlAsset> UsedIds { get; } // 0x00000001823EB2D0-0x00000001823EB360 
		internal VisualElementAsset visualTreeNoAlloc { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x000000018031E110-0x000000018031E120 
		internal VisualElementAsset visualTree { [VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })] get; } // 0x00000001823EB460-0x00000001823EB570 
		public IEnumerable<StyleSheet> stylesheets { [IteratorStateMachine(typeof(_get_stylesheets_d__52))] get; } // 0x00000001823EB360-0x00000001823EB3E0 
		internal List<SlotDefinition> slots { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal int contentContainerId { [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		public int contentHash { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
	
		// Events
		internal event AuthoringIdConflictResolvedHandler onAuthoringIdConflictResolved {
			add; // 0x00000001823EB230-0x00000001823EB2D0
			remove; // 0x00000001823EB570-0x00000001823EBD00
		}
	
		// Nested types
		internal delegate void AuthoringIdConflictResolvedHandler(UxmlAsset asset, int oldId, int newId); // TypeDefIndex: 4912; 0x0000000180A72B30-0x0000000180A72B50
	
		[Serializable]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal struct UsingEntry // TypeDefIndex: 4913
		{
			// Fields
			[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
			internal static readonly IComparer<UsingEntry> comparer; // 0x00
			[SerializeField]
			public string alias; // 0x00
			[SerializeField]
			public string path; // 0x08
			[SerializeField]
			public VisualTreeAsset asset; // 0x10
	
			// Constructors
			public UsingEntry(string alias, string path); // 0x00000001823E0F00-0x00000001823E0F50
			public UsingEntry(string alias, VisualTreeAsset asset); // 0x00000001823E0F50-0x00000001823E0FA0
			static UsingEntry(); // 0x00000001823E0E80-0x00000001823E0F00
		}
	
		private class UsingEntryComparer : IComparer<UsingEntry> // TypeDefIndex: 4914
		{
			// Constructors
			public UsingEntryComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public int Compare(UsingEntry x, UsingEntry y); // 0x00000001823E0E60-0x00000001823E0E80
		}
	
		[Serializable]
		internal struct SlotDefinition // TypeDefIndex: 4915
		{
			// Fields
			[SerializeField]
			public string name; // 0x00
			[SerializeField]
			public int insertionPointId; // 0x08
		}
	
		[Serializable]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal struct SlotUsageEntry // TypeDefIndex: 4916
		{
			// Fields
			[SerializeField]
			public string slotName; // 0x00
			[SerializeField]
			public int assetId; // 0x08
		}
	
		[Serializable]
		private struct AssetEntry // TypeDefIndex: 4917
		{
			// Fields
			[SerializeField]
			private string m_Path; // 0x00
			[SerializeField]
			private string m_TypeFullName; // 0x08
			[SerializeField]
			private LazyLoadReference<UnityEngine.Object> m_AssetReference; // 0x10
			[SerializeField]
			private EntityId m_EntityId; // 0x18
			private Type m_CachedType; // 0x20
	
			// Properties
			public Type type { get; } // 0x00000001823CD020-0x00000001823CD0A0 
			public string path { get; } // 0x00000001808BADD0-0x00000001808BADE0 
			public UnityEngine.Object asset { get; } // 0x00000001823CCFC0-0x00000001823CD020 
	
			// Constructors
			public AssetEntry(string path, Type type, UnityEngine.Object asset); // 0x00000001823CCEF0-0x00000001823CCFC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass81_0 // TypeDefIndex: 4918
		{
			// Fields
			public VisualElementAsset childVea; // 0x10
	
			// Constructors
			public __c__DisplayClass81_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _CloneSetupRecursively_b__0(SlotUsageEntry u); // 0x00000001823D38E0-0x00000001823D3910
		}
	
		[CompilerGenerated]
		private sealed class _DepthFirstTraversal_d__100 : IEnumerable<UxmlAsset>, IEnumerator<UxmlAsset> // TypeDefIndex: 4919
		{
			// Fields
			private int __1__state; // 0x10
			private UxmlAsset __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private UxmlAsset asset; // 0x28
			public UxmlAsset __3__asset; // 0x30
			public VisualTreeAsset __4__this; // 0x38
			private int _i_5__2; // 0x40
			private IEnumerator<UxmlAsset> __7__wrap2; // 0x48
	
			// Properties
			UxmlAsset IEnumerator<UnityEngine.UIElements.UxmlAsset>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _DepthFirstTraversal_d__100(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001823D13E0-0x00000001823D14C0
			private bool MoveNext(); // 0x00000001823D1030-0x00000001823D12F0
			private void __m__Finally1(); // 0x00000001823D14C0-0x00000001823D1510
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001823D13A0-0x00000001823D13E0
			[DebuggerHidden]
			IEnumerator<UxmlAsset> IEnumerable<UxmlAsset>.GetEnumerator(); // 0x00000001823D12F0-0x00000001823D13A0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001823D12F0-0x00000001823D13A0
		}
	
		[CompilerGenerated]
		private sealed class _DepthFirstTraversalOfType_d__99<T> : IEnumerable<T>, IEnumerator<T> // TypeDefIndex: 4920
		{
			// Fields
			private int __1__state;
			private T __2__current;
			private int __l__initialThreadId;
			public VisualTreeAsset __4__this;
			private IEnumerator<UxmlAsset> __7__wrap1;
	
			// Properties
			T IEnumerator<T>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _DepthFirstTraversalOfType_d__99(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _get_stylesheets_d__52 : IEnumerable<StyleSheet>, IEnumerator<StyleSheet> // TypeDefIndex: 4921
		{
			// Fields
			private int __1__state; // 0x10
			private StyleSheet __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public VisualTreeAsset __4__this; // 0x28
			private PooledObject<HashSet<StyleSheet>> _setHandle_5__2; // 0x30
			private HashSet<StyleSheet> _sent_5__3; // 0x40
			private PooledObject<List<UxmlAsset>> ___5__4; // 0x48
			private List<UxmlAsset> __7__wrap4; // 0x58
			private VisualElementAsset _vea_5__6; // 0x70
			private List<StyleSheet> __7__wrap6; // 0x78
			private List<string> __7__wrap7; // 0x90
	
			// Properties
			StyleSheet IEnumerator<UnityEngine.UIElements.StyleSheet>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_stylesheets_d__52(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001823D4580-0x00000001823D4B90
			private bool MoveNext(); // 0x00000001823D3C20-0x00000001823D44A0
			private void __m__Finally1(); // 0x00000001823D4B90-0x00000001823D4BE0
			private void __m__Finally2(); // 0x00000001823D4BE0-0x00000001823D4C30
			private void __m__Finally3(); // 0x00000001823D4C30-0x00000001823D4C50
			private void __m__Finally4(); // 0x00000001823D4C50-0x00000001823D4C70
			private void __m__Finally5(); // 0x00000001823D4C70-0x00000001823D4C90
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001823D4540-0x00000001823D4580
			[DebuggerHidden]
			IEnumerator<StyleSheet> IEnumerable<StyleSheet>.GetEnumerator(); // 0x00000001823D44A0-0x00000001823D4540
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001823D44A0-0x00000001823D4540
		}
	
		[CompilerGenerated]
		private sealed class _get_templateDependencies_d__36 : IEnumerable<VisualTreeAsset>, IEnumerator<VisualTreeAsset> // TypeDefIndex: 4922
		{
			// Fields
			private int __1__state; // 0x10
			private VisualTreeAsset __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public VisualTreeAsset __4__this; // 0x28
			private HashSet<VisualTreeAsset> _sent_5__2; // 0x30
			private List<UsingEntry> __7__wrap2; // 0x38
	
			// Properties
			VisualTreeAsset IEnumerator<UnityEngine.UIElements.VisualTreeAsset>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_templateDependencies_d__36(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001823D5270-0x00000001823D5320
			private bool MoveNext(); // 0x00000001823D4C90-0x00000001823D5190
			private void __m__Finally1(); // 0x00000001805E9B40-0x00000001805E9B60
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001823D5230-0x00000001823D5270
			[DebuggerHidden]
			IEnumerator<VisualTreeAsset> IEnumerable<VisualTreeAsset>.GetEnumerator(); // 0x00000001823D5190-0x00000001823D5230
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001823D5190-0x00000001823D5230
		}
	
		// Constructors
		public VisualTreeAsset(); // 0x00000001823EB120-0x00000001823EB230
		static VisualTreeAsset(); // 0x00000001823EB030-0x00000001823EB120
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal StyleSheet GetOrCreateInlineStyleSheet(); // 0x00000001823E89F0-0x00000001823E8A90
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void SetRootAsset(VisualElementAsset root); // 0x00000001823E9C70-0x00000001823E9D00
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal UxmlObjectAsset AddUxmlObject(UxmlAsset parent, string fieldUxmlName, string fullTypeName, UxmlNamespaceDefinition xmlNamespace = default); // 0x00000001823E6210-0x00000001823E6450
		private void Awake__Internal(); // 0x00000001823E6920-0x00000001823E6930
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void SetupReferences(); // 0x00000001823E9D00-0x00000001823E9EF0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool AssetEntryExists(string path, Type type); // 0x00000001823E6450-0x00000001823E65F0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void RegisterAssetEntry(string path, Type type, UnityEngine.Object asset); // 0x00000001823E9340-0x00000001823E9500
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void TransferAssetEntries(VisualTreeAsset otherVta); // 0x00000001823EA560-0x00000001823EA5F0
		internal T GetAsset<T>(string path)
			where T : UnityEngine.Object;
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal UnityEngine.Object GetAsset(string path, Type type); // 0x00000001823E8810-0x00000001823E89F0
		internal Type GetAssetType(string path); // 0x00000001823E86B0-0x00000001823E8810
		public TemplateContainer Instantiate(); // 0x00000001823E8E90-0x00000001823E90C0
		internal TemplateContainer Instantiate(out VisualElementAssetReferenceTable referenceTable); // 0x00000001823E90C0-0x00000001823E9340
		public TemplateContainer Instantiate(string bindingPath); // 0x00000001823E7860-0x00000001823E78B0
		public TemplateContainer CloneTree(); // 0x00000001823E7B40-0x00000001823E7B50
		public TemplateContainer CloneTree(string bindingPath); // 0x00000001823E7860-0x00000001823E78B0
		public void CloneTree(VisualElement target); // 0x00000001823E7510-0x00000001823E7540
		public void CloneTree(VisualElement target, out VisualElementAssetReferenceTable referenceTable); // 0x00000001823E7540-0x00000001823E7570
		public void CloneTree(VisualElement target, out int firstElementIndex, out int elementAddedCount); // 0x00000001823E78B0-0x00000001823E7B40
		internal void CloneTree(VisualElement target, out int firstElementIndex, out int elementAddedCount, out VisualElementAssetReferenceTable referenceTable); // 0x00000001823E7570-0x00000001823E7860
		internal void CloneTree(VisualElement target, CreationContext cc, VisualElementAssetReferenceTable.DocumentNode parentAuthoringNode); // 0x00000001823E7B50-0x00000001823E7E80
		private VisualElement CloneSetupRecursively(VisualElementAsset asset, CreationContext context, VisualElementAssetReferenceTable.DocumentNode parentAuthoringNode); // 0x00000001823E6B50-0x00000001823E7510
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal bool TryGetSlotInsertionPoint(int insertionPointId, out string slotName); // 0x00000001823EA5F0-0x00000001823EA6A0
		internal bool TryGetUsingEntry(string templateName, out UsingEntry entry); // 0x00000001823EA6A0-0x00000001823EA830
		private void RemoveUsingEntry(UsingEntry entry); // 0x00000001823E99B0-0x00000001823E9A20
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal VisualTreeAsset ResolveTemplate(string templateName); // 0x00000001823E9B00-0x00000001823E9C70
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal bool TemplateExists(string templateName); // 0x00000001823EA430-0x00000001823EA560
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal void RegisterTemplate(string templateName, string path); // 0x00000001823E9930-0x00000001823E99B0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void RegisterTemplate(string templateName, VisualTreeAsset asset); // 0x00000001823E98B0-0x00000001823E9930
		internal bool TryRegisterTemplate(string templateName, VisualTreeAsset asset); // 0x00000001823EA830-0x00000001823EABC0
		internal bool TryUnregisterTemplate(string templateName); // 0x00000001823EABC0-0x00000001823EAF90
		private void InsertUsingEntry(UsingEntry entry); // 0x00000001823E8DB0-0x00000001823E8E90
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal static VisualElement Create(VisualElementAsset asset, CreationContext ctx, VisualElementAssetReferenceTable.DocumentNode parentAuthoringNode = null); // 0x00000001823E7E80-0x00000001823E8030
		private static void AssignClassListFromAssetToElement(VisualElementAsset asset, VisualElement element); // 0x00000001823E65F0-0x00000001823E6610
		private static void AssignStyleSheetFromAssetToElement(VisualElementAsset asset, VisualElement element); // 0x00000001823E6610-0x00000001823E6920
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal IEnumerable<UxmlAsset> DepthFirstTraversal(); // 0x00000001823E81C0-0x00000001823E8250
		[IteratorStateMachine(typeof(_DepthFirstTraversalOfType_d__99<T>))]
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal IEnumerable<T> DepthFirstTraversalOfType<T>();
		[IteratorStateMachine(typeof(_DepthFirstTraversal_d__100))]
		internal IEnumerable<UxmlAsset> DepthFirstTraversal(UxmlAsset asset); // 0x00000001823E8250-0x00000001823E82E0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int DepthFirstTraversalIndexOf(UxmlAsset uxmlAsset); // 0x00000001823E8030-0x00000001823E81C0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
		internal int GenerateNewId(UxmlAsset vea); // 0x00000001823E82E0-0x00000001823E83B0
		internal static int GenerateNewId(UxmlAsset uxmlAsset, Dictionary<int, UxmlAsset> excludeIds); // 0x00000001823E83B0-0x00000001823E8470
		internal static int GenerateNewId(UxmlAsset uxmlAsset, int siblingIndex, Dictionary<int, UxmlAsset> excludeIds); // 0x00000001823E8470-0x00000001823E86B0
		private static int GetStableHashCode(string str); // 0x00000001823E8A90-0x00000001823E8AF0
		private bool IdExists(int id); // 0x00000001823E8D50-0x00000001823E8DB0
		internal void UnregisterId(UxmlAsset uxmlAsset); // 0x00000001823EAF90-0x00000001823EB030
		internal void RegisterId(UxmlAsset uxmlAsset, int siblingIndex = -1 /* Metadata: 0x00660816 */); // 0x00000001823E9500-0x00000001823E98B0
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElementAsset ReparentElementInDocument(VisualElementAsset vea, VisualElementAsset newParent, int index = -1 /* Metadata: 0x00660817 */); // 0x00000001823E9A20-0x00000001823E9B00
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal void Swallow(VisualElementAsset parent, VisualTreeAsset other); // 0x00000001823EA150-0x00000001823EA430
		internal static void SwallowStyleRule(VisualTreeAsset previous, VisualTreeAsset next, VisualElementAsset vea); // 0x00000001823E9EF0-0x00000001823EA150
		[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
		internal VisualElementAsset AddElementOfType(VisualElementAsset parent, string fullTypeName); // 0x00000001823E60D0-0x00000001823E6210
		private void CacheExistingIds(); // 0x00000001823E6930-0x00000001823E6B50
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static void HarmonizeIds(VisualTreeAsset vta); // 0x00000001823E8AF0-0x00000001823E8C70
		private static void HarmonizeIds(UxmlAsset uxmlAsset, int siblingIndex); // 0x00000001823E8C70-0x00000001823E8D50
	}
}
