/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class StyleValuePropertyBag<TContainer, TValue> : ContainerPropertyBag<TContainer> // TypeDefIndex: 4683
		where TContainer : IStyleValue<TValue>
	{
		// Nested types
		private class ValueProperty : Property<TContainer, TValue> // TypeDefIndex: 4684
		{
			// Fields
			[CompilerGenerated]
			private readonly string _Name_k__BackingField;
			[CompilerGenerated]
			private readonly bool _IsReadOnly_k__BackingField;
	
			// Properties
			public override string Name { [CompilerGenerated] get; }
			public override bool IsReadOnly { [CompilerGenerated] get; }
	
			// Constructors
			public ValueProperty();
	
			// Methods
			public override TValue GetValue(ref ref TContainer container);
			public override void SetValue(ref ref TContainer container, TValue value);
		}
	
		private class KeywordProperty : Property<TContainer, StyleKeyword> // TypeDefIndex: 4685
		{
			// Fields
			[CompilerGenerated]
			private readonly string _Name_k__BackingField;
			[CompilerGenerated]
			private readonly bool _IsReadOnly_k__BackingField;
	
			// Properties
			public override string Name { [CompilerGenerated] get; }
			public override bool IsReadOnly { [CompilerGenerated] get; }
	
			// Constructors
			public KeywordProperty();
	
			// Methods
			public override StyleKeyword GetValue(ref ref TContainer container);
			public override void SetValue(ref ref TContainer container, StyleKeyword value);
		}
	
		// Constructors
		public StyleValuePropertyBag();
	}
}
