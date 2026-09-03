/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	internal sealed class SignatureConstructedGenericType : SignatureType // TypeDefIndex: 3321
	{
		// Fields
		private readonly Type _genericTypeDefinition; // 0x18
		private readonly Type[] _genericTypeArguments; // 0x20
	
		// Properties
		public sealed override bool IsGenericTypeDefinition { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsSZArray { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsVariableBoundArray { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsConstructedGenericType { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public sealed override bool IsGenericParameter { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsGenericMethodParameter { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool ContainsGenericParameters { get; } // 0x000000018153C1C0-0x000000018153C260 
		internal sealed override SignatureType ElementType { get; } // 0x00000001802E7860-0x00000001802E7870 
		public sealed override Type[] GenericTypeArguments { get; } // 0x000000018153C2B0-0x000000018153C330 
		public sealed override int GenericParameterPosition { get; } // 0x000000018153C260-0x000000018153C2B0 
		public sealed override string Name { get; } // 0x000000018153C330-0x000000018153C360 
		public sealed override string Namespace { get; } // 0x0000000181480EF0-0x0000000181480F20 
	
		// Constructors
		internal SignatureConstructedGenericType(Type genericTypeDefinition, Type[] typeArguments); // 0x000000018153BF90-0x000000018153C1C0
	
		// Methods
		protected sealed override bool HasElementTypeImpl(); // 0x00000001802E7840-0x00000001802E7850
		protected sealed override bool IsArrayImpl(); // 0x00000001802E7840-0x00000001802E7850
		protected sealed override bool IsByRefImpl(); // 0x00000001802E7840-0x00000001802E7850
		protected sealed override bool IsPointerImpl(); // 0x00000001802E7840-0x00000001802E7850
		public sealed override int GetArrayRank(); // 0x000000018153BDE0-0x000000018153BE30
		public sealed override Type GetGenericTypeDefinition(); // 0x00000001802F8EC0-0x00000001802F8ED0
		public sealed override Type[] GetGenericArguments(); // 0x000000018153BE30-0x000000018153BE50
		public sealed override string ToString(); // 0x000000018153BE50-0x000000018153BF90
	}
}
