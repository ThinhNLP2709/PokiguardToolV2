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

namespace System.Runtime.InteropServices
{
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ComVisible(true)]
	public sealed class MarshalAsAttribute : Attribute // TypeDefIndex: 3158
	{
		// Fields
		public string MarshalCookie; // 0x10
		[ComVisible(true)]
		public string MarshalType; // 0x18
		[ComVisible(true)]
		public Type MarshalTypeRef; // 0x20
		public Type SafeArrayUserDefinedSubType; // 0x28
		private UnmanagedType utype; // 0x30
		public UnmanagedType ArraySubType; // 0x34
		public VarEnum SafeArraySubType; // 0x38
		public int SizeConst; // 0x3C
		public int IidParameterIndex; // 0x40
		public short SizeParamIndex; // 0x44
	
		// Properties
		public UnmanagedType Value { get; } // 0x000000018033D100-0x000000018033D110 
	
		// Constructors
		public MarshalAsAttribute(UnmanagedType unmanagedType); // 0x000000018150DDA0-0x000000018150DDD0
	
		// Methods
		internal MarshalAsAttribute Copy(); // 0x000000018150DD40-0x000000018150DDA0
	}
}
