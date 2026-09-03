/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Internal
{
	internal class AutoCompletePathVisitor : ITypeVisitor, IPropertyVisitor, IPropertyBagVisitor, IListPropertyVisitor // TypeDefIndex: 5285
	{
		// Fields
		private VisitContext m_VisitContext; // 0x10
		[CompilerGenerated]
		private int _maxDepth_k__BackingField; // 0x18
	
		// Properties
		public int maxDepth { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
	
		// Nested types
		private class VisitContext // TypeDefIndex: 5286
		{
			// Fields
			[CompilerGenerated]
			private List<PropertyPathInfo> _propertyPathInfos_k__BackingField; // 0x10
			[CompilerGenerated]
			private readonly HashSet<Type> _types_k__BackingField; // 0x18
			[CompilerGenerated]
			private PropertyPath _current_k__BackingField; // 0x20
			[CompilerGenerated]
			private int _currentDepth_k__BackingField; // 0xB0
	
			// Properties
			public List<PropertyPathInfo> propertyPathInfos { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
			public HashSet<Type> types { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			public PropertyPath current { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018246DED0-0x000000018246DF30 0x000000018246DF30-0x000000018246DF90
			public int currentDepth { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018158ACB0-0x000000018158ACC0 0x0000000181727410-0x0000000181727420
	
			// Constructors
			public VisitContext(); // 0x000000018246DE50-0x000000018246DED0
		}
	
		private struct InspectedTypeScope<TContainer> : IDisposable // TypeDefIndex: 5287
		{
			// Fields
			private VisitContext m_VisitContext;
	
			// Constructors
			public InspectedTypeScope(VisitContext context);
	
			// Methods
			public void Dispose();
		}
	
		private struct VisitedPropertyScope : IDisposable // TypeDefIndex: 5288
		{
			// Fields
			private VisitContext m_VisitContext; // 0x00
	
			// Constructors
			public VisitedPropertyScope(VisitContext context, IProperty property); // 0x000000018246E470-0x000000018246EBA0
			public VisitedPropertyScope(VisitContext context, int index, Type type); // 0x000000018246E120-0x000000018246E470
	
			// Methods
			public void Dispose(); // 0x000000018246DF90-0x000000018246E120
		}
	
		// Constructors
		public AutoCompletePathVisitor(); // 0x0000000182463F80-0x0000000182464050
	
		// Methods
		private bool HasReachedEnd(Type containerType); // 0x0000000182463AB0-0x0000000182463B30
		public void Reset(); // 0x0000000182463B30-0x0000000182463BE0
		void ITypeVisitor.Visit<TContainer>();
		void IPropertyBagVisitor.Visit<TContainer>(IPropertyBag<TContainer> properties, ref ref TContainer container);
		void IPropertyVisitor.Visit<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container);
		void IListPropertyVisitor.Visit<TContainer, TList, TElement>(Property<TContainer, TList> property, ref ref TContainer container, ref ref TList list)
			where TList : IList<TElement>;
		private void VisitPropertyType(Type type); // 0x0000000182463BE0-0x0000000182463F80
	}
}
