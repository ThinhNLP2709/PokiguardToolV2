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
	public abstract class Module : ICustomAttributeProvider, ISerializable, _Module // TypeDefIndex: 3310
	{
		// Fields
		public static readonly TypeFilter FilterTypeName; // 0x00
		public static readonly TypeFilter FilterTypeNameIgnoreCase; // 0x08
		private const BindingFlags DefaultLookup = BindingFlags.Default | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public; // Metadata: 0x0064ECFC
	
		// Properties
		public virtual Assembly Assembly { get; } // 0x000000018152D9E0-0x000000018152DA10 
		public virtual Guid ModuleVersionId { get; } // 0x000000018152DA10-0x000000018152DA40 
		public virtual string ScopeName { get; } // 0x000000018152DA40-0x000000018152DA70 
	
		// Constructors
		protected Module(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Module(); // 0x000000018152D900-0x000000018152D9E0
	
		// Methods
		public virtual bool IsResource(); // 0x000000018152D8B0-0x000000018152D8E0
		public virtual bool IsDefined(Type attributeType, bool inherit); // 0x000000018152D880-0x000000018152D8B0
		public virtual object[] GetCustomAttributes(bool inherit); // 0x000000018152D7E0-0x000000018152D810
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018152D7B0-0x000000018152D7E0
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018152D850-0x000000018152D880
		public override bool Equals(object o); // 0x0000000181524170-0x0000000181524180
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public static bool operator ==(Module left, Module right); // 0x0000000181524F10-0x0000000181524F40
		public override string ToString(); // 0x000000018152D8E0-0x000000018152D900
		private static bool FilterTypeNameImpl(Type cls, object filterCriteria); // 0x000000018152D660-0x000000018152D7B0
		private static bool FilterTypeNameIgnoreCaseImpl(Type cls, object filterCriteria); // 0x000000018152D4C0-0x000000018152D660
		internal virtual Guid GetModuleVersionId(); // 0x000000018152D810-0x000000018152D850
	}
}
