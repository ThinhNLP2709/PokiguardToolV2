/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public class SetPropertyBagBase<TSet, TElement> : PropertyBag<TSet>, ISetPropertyBag<TSet, TElement> // TypeDefIndex: 14499
		where TSet : ISet<TElement>
	{
		// Fields
		private readonly SetElementProperty m_Property;
	
		// Nested types
		private class SetElementProperty : Property<TSet, TElement>, ISetElementProperty // TypeDefIndex: 14500
		{
			// Fields
			internal TElement m_Value;
	
			// Properties
			public override string Name { get; }
			public override bool IsReadOnly { get; }
			public object ObjectKey { get; }
	
			// Constructors
			public SetElementProperty();
	
			// Methods
			public override TElement GetValue(ref ref TSet container);
			public override void SetValue(ref ref TSet container, TElement value);
		}
	
		[CompilerGenerated]
		private sealed class _GetPropertiesEnumerable_d__4 : IEnumerable<IProperty<TSet>>, IEnumerator<IProperty<TSet>> // TypeDefIndex: 14501
		{
			// Fields
			private int __1__state;
			private IProperty<TSet> __2__current;
			private int __l__initialThreadId;
			private TSet container;
			public TSet __3__container;
			public SetPropertyBagBase<TSet, TElement> __4__this;
			private IEnumerator<TElement> __7__wrap1;
	
			// Properties
			IProperty<TSet> IEnumerator<Unity.Properties.IProperty<TSet>>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _GetPropertiesEnumerable_d__4(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			private void __m__Finally1();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<IProperty<TSet>> IEnumerable<IProperty<TSet>>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		// Constructors
		public SetPropertyBagBase();
	
		// Methods
		public override PropertyCollection<TSet> GetProperties();
		public override PropertyCollection<TSet> GetProperties(ref ref TSet container);
		[IteratorStateMachine(typeof(_GetPropertiesEnumerable_d__4))]
		private IEnumerable<IProperty<TSet>> GetPropertiesEnumerable(TSet container);
		void ICollectionPropertyBagAccept<TSet>.Accept(ICollectionPropertyBagVisitor visitor, ref ref TSet container);
		void ISetPropertyBagAccept<TSet>.Accept(ISetPropertyBagVisitor visitor, ref ref TSet container);
		public bool TryGetProperty(ref ref TSet container, object key, out IProperty<TSet> property);
	}
}
