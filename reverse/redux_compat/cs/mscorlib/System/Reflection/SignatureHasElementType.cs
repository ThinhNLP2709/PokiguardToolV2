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
	internal abstract class SignatureHasElementType : SignatureType // TypeDefIndex: 3322
	{
		// Fields
		private readonly SignatureType _elementType; // 0x18
	
		// Properties
		public sealed override bool IsGenericTypeDefinition { get; } // 0x00000001802E7840-0x00000001802E7850 
		public abstract bool IsSZArray { get; }
		public abstract bool IsVariableBoundArray { get; }
		public sealed override bool IsConstructedGenericType { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsGenericParameter { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool IsGenericMethodParameter { get; } // 0x00000001802E7840-0x00000001802E7850 
		public sealed override bool ContainsGenericParameters { get; } // 0x000000018153C490-0x000000018153C4C0 
		internal sealed override SignatureType ElementType { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public sealed override Type[] GenericTypeArguments { get; } // 0x000000018153C510-0x000000018153C580 
		public sealed override int GenericParameterPosition { get; } // 0x000000018153C4C0-0x000000018153C510 
		public sealed override string Name { get; } // 0x000000018153C580-0x000000018153C5F0 
		public sealed override string Namespace { get; } // 0x0000000181480EF0-0x0000000181480F20 
		protected abstract string Suffix { get; }
	
		// Constructors
		protected SignatureHasElementType(SignatureType elementType); // 0x000000018153BD60-0x000000018153BDB0
	
		// Methods
		protected sealed override bool HasElementTypeImpl(); // 0x00000001802E7990-0x00000001802E79A0
		protected abstract bool IsArrayImpl();
		protected abstract bool IsByRefImpl();
		protected abstract bool IsPointerImpl();
		public abstract int GetArrayRank();
		public sealed override Type GetGenericTypeDefinition(); // 0x000000018153C3D0-0x000000018153C420
		public sealed override Type[] GetGenericArguments(); // 0x000000018153C360-0x000000018153C3D0
		public sealed override string ToString(); // 0x000000018153C420-0x000000018153C490
	}
}
