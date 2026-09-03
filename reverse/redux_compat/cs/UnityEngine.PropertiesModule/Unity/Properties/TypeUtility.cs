/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Pool;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public static class TypeUtility // TypeDefIndex: 14534
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly ConcurrentDictionary<Type, ITypeConstructor> s_TypeConstructors; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly MethodInfo s_CreateTypeConstructor; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly ConcurrentDictionary<Type, string> s_CachedResolvedName; // 0x10
		[NoAutoStaticsCleanup]
		private static readonly ObjectPool<StringBuilder> s_Builders; // 0x18
		[NoAutoStaticsCleanup]
		private static readonly object syncedPoolObject; // 0x20
	
		// Nested types
		private interface ITypeConstructor // TypeDefIndex: 14535
		{
			// Properties
			bool CanBeInstantiated { get; }
	
			// Methods
			object Instantiate();
		}
	
		private interface ITypeConstructor<T> : ITypeConstructor // TypeDefIndex: 14536
		{
			// Methods
			T Instantiate();
			void SetExplicitConstructor(Func<T> constructor);
		}
	
		private class TypeConstructor<T> : ITypeConstructor<T> // TypeDefIndex: 14537
		{
			// Fields
			private Func<T> m_ExplicitConstructor;
			private Func<T> m_ImplicitConstructor;
			private IConstructor<T> m_OverrideConstructor;
	
			// Properties
			bool ITypeConstructor.CanBeInstantiated { get; }
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 14538
			{
				// Fields
				public static Func<T> _0___CreateValueTypeInstance;
				public static Func<T> _1___CreateScriptableObjectInstance;
				public static Func<T> _2___CreateClassInstance;
			}
	
			// Constructors
			public TypeConstructor();
	
			// Methods
			private void SetImplicitConstructor();
			private static T CreateValueTypeInstance();
			private static T CreateScriptableObjectInstance();
			private static T CreateClassInstance();
			public void SetExplicitConstructor(Func<T> constructor);
			T Unity.Properties.TypeUtility.ITypeConstructor<T>.Instantiate();
			object Unity.Properties.TypeUtility.ITypeConstructor.Instantiate();
		}
	
		private class NonConstructable : ITypeConstructor // TypeDefIndex: 14539
		{
			// Properties
			bool ITypeConstructor.CanBeInstantiated { get; } // 0x00000001802E7840-0x00000001802E7850 
	
			// Constructors
			public NonConstructable(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public object Instantiate(); // 0x00000001822DB030-0x00000001822DB080
		}
	
		private struct Cache<T> // TypeDefIndex: 14540
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static ITypeConstructor<T> TypeConstructor;
		}
	
		private class TypeConstructorVisitor : ITypeVisitor // TypeDefIndex: 14541
		{
			// Fields
			public ITypeConstructor TypeConstructor; // 0x10
	
			// Constructors
			public TypeConstructorVisitor(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Visit<TContainer>();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 14542
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001822E50D0-0x00000001822E5140
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal StringBuilder _.cctor_b__11_0(); // 0x00000001822E4FB0-0x00000001822E4FE0
			internal void _.cctor_b__11_1(StringBuilder sb); // 0x00000001822E4FE0-0x00000001822E5000
			internal string _.cctor_b__11_2(); // 0x00000001815B1550-0x00000001815B1570
		}
	
		// Constructors
		static TypeUtility(); // 0x00000001822E4150-0x00000001822E45C0
	
		// Methods
		public static string GetTypeDisplayName(Type type); // 0x00000001822E3800-0x00000001822E3910
		private static string GetTypeDisplayName(Type type, IReadOnlyList<Type> args, ref int argIndex); // 0x00000001822E3910-0x00000001822E4150
		private static ITypeConstructor CreateTypeConstructor(Type type); // 0x00000001822E33B0-0x00000001822E3680
		private static ITypeConstructor<T> CreateTypeConstructor<T>();
		private static ITypeConstructor GetTypeConstructor(Type type); // 0x00000001822E3750-0x00000001822E3800
		private static ITypeConstructor<T> GetTypeConstructor<T>();
		public static bool CanBeInstantiated(Type type); // 0x00000001822E3050-0x00000001822E3150
		public static bool CanBeInstantiated<T>();
		public static void SetExplicitInstantiationMethod<T>(Func<T> constructor);
		public static T Instantiate<T>();
		public static bool TryInstantiate<T>(out ref T instance);
		public static T Instantiate<T>(Type derivedType);
		public static bool TryInstantiate<T>(Type derivedType, out ref T value);
		public static TArray InstantiateArray<TArray>(int count = 0 /* Metadata: 0x006A9718 */);
		public static bool TryInstantiateArray<TArray>(int count, out ref TArray instance);
		public static TArray InstantiateArray<TArray>(Type derivedType, int count = 0 /* Metadata: 0x006A9719 */);
		private static void CheckIsAssignableFrom(Type type, Type derivedType); // 0x00000001822E3230-0x00000001822E33B0
		private static void CheckCanBeInstantiated<T>(ITypeConstructor<T> constructor);
		private static void CheckCanBeInstantiated(ITypeConstructor constructor, Type type); // 0x00000001822E3150-0x00000001822E3230
	
		// Extension methods
		public static Type GetRootType(this Type type); // 0x00000001822E3680-0x00000001822E3750
	}
}
