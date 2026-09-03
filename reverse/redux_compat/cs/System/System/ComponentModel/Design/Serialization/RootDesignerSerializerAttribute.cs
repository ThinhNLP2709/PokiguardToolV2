/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel.Design.Serialization
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
	[Obsolete("This attribute has been deprecated. Use DesignerSerializerAttribute instead.  For example, to specify a root designer for CodeDom, use DesignerSerializerAttribute(...,typeof(TypeCodeDomSerializer)).  https://go.microsoft.com/fwlink/?linkid=14202")]
	public sealed class RootDesignerSerializerAttribute : Attribute // TypeDefIndex: 8944
	{
		// Fields
		private string _typeId; // 0x10
		[CompilerGenerated]
		private readonly bool _Reloadable_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly string _SerializerTypeName_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly string _SerializerBaseTypeName_k__BackingField; // 0x28
	
		// Properties
		public string SerializerBaseTypeName { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public override object TypeId { get; } // 0x0000000181BD4390-0x0000000181BD4430 
	
		// Constructors
		public RootDesignerSerializerAttribute(string serializerTypeName, string baseSerializerTypeName, bool reloadable); // 0x0000000181BD4320-0x0000000181BD4390
	}
}
