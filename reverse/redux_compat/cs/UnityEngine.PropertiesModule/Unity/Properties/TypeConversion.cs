/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	public static class TypeConversion // TypeDefIndex: 14523
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static ConversionRegistry s_GlobalConverters; // 0x00
	
		// Nested types
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal struct Unsafe // TypeDefIndex: 14524
		{
			// Methods
			public static void LazyRegister(Type source, Type destination, Func<Delegate> getConverterDelegate); // 0x00000001822E5290-0x00000001822E53C0
		}
	
		private static class PrimitiveConverters // TypeDefIndex: 14525
		{
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 14526
			{
				// Fields
				public static readonly __c __9; // 0x00
				public static TypeConverter<string, Guid> __9__0_0; // 0x08
	
				// Constructors
				static __c(); // 0x00000001822E5140-0x00000001822E51B0
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal Guid _Register_b__0_0(ref string g); // 0x00000001822E4F80-0x00000001822E4FB0
			}
	
			// Methods
			public static void Register(); // 0x00000001822DB170-0x00000001822DB380
		}
	
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static class PrimitivesConverters // TypeDefIndex: 14527
		{
			// Methods
			public static bool TryConvertPrimitiveOrString<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
			private static TDestination DoConvert<TDestination>(ref bool source);
			private static TDestination DoConvert<TDestination>(ref byte source);
			private static TDestination DoConvert<TDestination>(ref char source);
			private static TDestination DoConvert<TDestination>(ref double source);
			private static TDestination DoConvert<TDestination>(ref short source);
			private static TDestination DoConvert<TDestination>(ref int source);
			private static TDestination DoConvert<TDestination>(ref long source);
			private static TDestination DoConvert<TDestination>(ref sbyte source);
			private static TDestination DoConvert<TDestination>(ref float source);
			private static TDestination DoConvert<TDestination>(ref string source);
			private static TDestination DoConvert<TDestination>(ref ushort source);
			private static TDestination DoConvert<TDestination>(ref uint source);
			private static TDestination DoConvert<TDestination>(ref ulong source);
		}
	
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 14528
		{
			// Fields
			public static Action _0___Setup; // 0x00
			public static Action _1___Clear; // 0x08
		}
	
		// Methods
		private static void Setup(); // 0x00000001822E2A30-0x00000001822E2BD0
		private static void Clear(); // 0x00000001822E2990-0x00000001822E29F0
		public static bool TryConvert<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static bool TryConvert<TSource, TDestination>([IsReadOnly] in ConversionRegistry registry, ref ref TSource source, out ref TDestination destination);
		private static bool TryConvertNullable<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
		private static bool TryConvertEnum<TSource, TDestination>(ref ref TSource source, out ref TDestination destination);
		private static bool TryConvertToUnityEngineObject<TSource, TDestination>(TSource source, out ref TDestination destination);
		private static bool IsNumericType(Type t); // 0x00000001822E29F0-0x00000001822E2A30
		[CompilerGenerated]
		internal static void Unity_Properties_TypeConversion_Setup_RegisterLifecycleMethod(); // 0x00000001822E2D20-0x00000001822E2E70
		[CompilerGenerated]
		internal static void Unity_Properties_TypeConversion_Clear_RegisterLifecycleMethod(); // 0x00000001822E2BD0-0x00000001822E2D20
	}
}
