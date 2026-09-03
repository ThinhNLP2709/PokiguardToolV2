/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	public class ParameterInfo : ICustomAttributeProvider, IObjectReference, _ParameterInfo // TypeDefIndex: 3312
	{
		// Fields
		protected ParameterAttributes AttrsImpl; // 0x10
		protected Type ClassImpl; // 0x18
		protected object DefaultValueImpl; // 0x20
		protected MemberInfo MemberImpl; // 0x28
		protected string NameImpl; // 0x30
		protected int PositionImpl; // 0x38
		private const int MetadataToken_ParamDef = 134217728; // Metadata: 0x0064ED15
	
		// Properties
		public virtual ParameterAttributes Attributes { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public virtual MemberInfo Member { get; } // 0x000000018033D240-0x000000018033D250 
		public virtual string Name { get; } // 0x000000018031E110-0x000000018031E120 
		public virtual Type ParameterType { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public virtual int Position { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		public bool IsIn { get; } // 0x0000000181533CD0-0x0000000181533CF0 
		public bool IsOptional { get; } // 0x0000000181533CF0-0x0000000181533D20 
		public bool IsOut { get; } // 0x0000000181533D20-0x0000000181533D50 
		public virtual object DefaultValue { get; } // 0x0000000181533CA0-0x0000000181533CD0 
	
		// Constructors
		protected ParameterInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual bool IsDefined(Type attributeType, bool inherit); // 0x0000000181533B90-0x0000000181533C10
		public virtual object[] GetCustomAttributes(bool inherit); // 0x00000001815336C0-0x0000000181533730
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181533730-0x0000000181533810
		public object GetRealObject(StreamingContext context); // 0x0000000181533810-0x0000000181533B90
		public override string ToString(); // 0x0000000181533C10-0x0000000181533CA0
	}
}
