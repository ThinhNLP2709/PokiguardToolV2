/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Pool;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public static class PropertyContainer // TypeDefIndex: 14434
	{
		// Nested types
		private class GetPropertyVisitor : PathVisitor // TypeDefIndex: 14435
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static readonly ObjectPool<GetPropertyVisitor> Pool; // 0x00
			public IProperty Property; // 0xB8
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 14436
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001822E51B0-0x00000001822E5220
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal GetPropertyVisitor _.cctor_b__5_0(); // 0x00000001822E5000-0x00000001822E5050
				internal void _.cctor_b__5_1(GetPropertyVisitor v); // 0x0000000180A67FD0-0x0000000180A68000
			}
	
			// Constructors
			public GetPropertyVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static GetPropertyVisitor(); // 0x00000001822DAA30-0x00000001822DABC0
	
			// Methods
			public override void Reset(); // 0x00000001822DA9B0-0x00000001822DAA30
			protected override void VisitPath<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container, ref ref TValue value);
		}
	
		private class GetValueVisitor<TSrcValue> : PathVisitor // TypeDefIndex: 14437
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static readonly ObjectPool<GetValueVisitor<TSrcValue>> Pool;
			public TSrcValue Value;
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 14438
			{
				// Fields
				public static readonly __c<TSrcValue> __9;
	
				// Constructors
				static __c();
				public __c();
	
				// Methods
				internal GetValueVisitor<TSrcValue> _.cctor_b__5_0();
				internal void _.cctor_b__5_1(GetValueVisitor<TSrcValue> v);
			}
	
			// Constructors
			public GetValueVisitor();
			static GetValueVisitor();
	
			// Methods
			public override void Reset();
			protected override void VisitPath<TContainer, TValue>(Property<TContainer, TValue> property, ref ref TContainer container, ref ref TValue value);
		}
	
		// Methods
		public static void Accept<TContainer>(IPropertyBagVisitor visitor, ref ref TContainer container, VisitParameters parameters = default);
		public static bool TryAccept<TContainer>(IPropertyBagVisitor visitor, ref ref TContainer container, VisitParameters parameters = default);
		public static bool TryAccept<TContainer>(IPropertyBagVisitor visitor, ref ref TContainer container, out VisitReturnCode returnCode, VisitParameters parameters = default);
		public static bool TryGetProperty<TContainer>(ref ref TContainer container, [IsReadOnly] in PropertyPath path, out IProperty property);
		public static bool TryGetProperty<TContainer>(ref ref TContainer container, [IsReadOnly] in PropertyPath path, out IProperty property, out VisitReturnCode returnCode);
		public static bool TryGetValue<TContainer, TValue>(ref ref TContainer container, string name, out ref TValue value);
		public static bool TryGetValue<TContainer, TValue>(ref ref TContainer container, [IsReadOnly] in PropertyPath path, out ref TValue value, out VisitReturnCode returnCode);
	}
}
