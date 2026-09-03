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

namespace UnityEngine.UIElements.Internal
{
	internal class TypePathVisitor : ITypeVisitor, IPropertyBagVisitor, IPropertyVisitor // TypeDefIndex: 5289
	{
		// Fields
		[CompilerGenerated]
		private PropertyPath _Path_k__BackingField; // 0x10
		[CompilerGenerated]
		private Type _resolvedType_k__BackingField; // 0xA0
		[CompilerGenerated]
		private VisitReturnCode _ReturnCode_k__BackingField; // 0xA8
		private Type m_LastType; // 0xB0
		private int m_PathIndex; // 0xB8
	
		// Properties
		public PropertyPath Path { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001811078C0-0x0000000181107920 0x000000018246D7C0-0x000000018246D820
		private Type resolvedType { [CompilerGenerated] set; } // 0x00000001806CCE40-0x00000001806CCE60
		public VisitReturnCode ReturnCode { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x00000001806671D0-0x00000001806671E0 0x0000000181EE3C80-0x0000000181EE3C90
	
		// Constructors
		public TypePathVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Reset(); // 0x000000018246D730-0x000000018246D7C0
		void IPropertyBagVisitor.Visit<TContainer>(IPropertyBag<TContainer> properties, ref ref TContainer container);
		void IPropertyVisitor.Visit<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container);
		void ITypeVisitor.Visit<TContainer>();
		private bool IsLastPartReached(); // 0x000000018246D690-0x000000018246D730
		private static Type GetElementType(Type type); // 0x000000018246D510-0x000000018246D690
	}
}
