/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class SetValueVisitor<TSrcValue> : PathVisitor // TypeDefIndex: 3925
	{
		// Fields
		public static readonly ObjectPool<SetValueVisitor<TSrcValue>> Pool;
		public TSrcValue Value;
		[CompilerGenerated]
		private ConverterGroup _group_k__BackingField;
	
		// Properties
		public ConverterGroup group { [CompilerGenerated] get; [CompilerGenerated] set; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3926
		{
			// Fields
			public static readonly __c<TSrcValue> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal SetValueVisitor<TSrcValue> _.cctor_b__9_0();
			internal void _.cctor_b__9_1(SetValueVisitor<TSrcValue> v);
		}
	
		// Constructors
		public SetValueVisitor();
		static SetValueVisitor();
	
		// Methods
		public override void Reset();
		protected override void VisitPath<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container, ref ref TValue value);
	}
}
