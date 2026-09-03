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
using System.Security.Policy;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Assembly))]
	[ComVisible(true)]
	internal class RuntimeAssembly : Assembly // TypeDefIndex: 3347
	{
		// Fields
		internal IntPtr _mono_assembly; // 0x10
		private object _evidence; // 0x18
		internal ResolveEventHolder resolve_event_holder; // 0x20
		private object _minimum; // 0x28
		private object _optional; // 0x30
		private object _refuse; // 0x38
		private object _granted; // 0x40
		private object _denied; // 0x48
		internal bool fromByteArray; // 0x50
		internal string assemblyName; // 0x58
	
		// Properties
		public override string CodeBase { get; } // 0x0000000181535070-0x0000000181535080 
		public override string FullName { get; } // 0x0000000181535080-0x0000000181535090 
		internal override IntPtr MonoAssembly { get; } // 0x0000000180377550-0x0000000180377560 
		public override string Location { get; } // 0x0000000181535090-0x00000001815350B0 
	
		// Constructors
		protected RuntimeAssembly(); // 0x0000000181535000-0x0000000181535070
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181534C10-0x0000000181534CB0
		internal static RuntimeAssembly LoadWithPartialNameInternal(string partialName, Evidence securityEvidence, ref StackCrawlMark stackMark); // 0x0000000181534EF0-0x0000000181534FB0
		internal static RuntimeAssembly LoadWithPartialNameInternal(AssemblyName an, Evidence securityEvidence, ref StackCrawlMark stackMark); // 0x0000000181534E00-0x0000000181534EF0
		public override AssemblyName GetName(bool copiedName); // 0x0000000181534B50-0x0000000181534C10
		public override Type GetType(string name, bool throwOnError, bool ignoreCase); // 0x0000000181534CC0-0x0000000181534D90
		public override Module GetModule(string name); // 0x0000000181534890-0x0000000181534A00
		public override AssemblyName[] GetReferencedAssemblies(); // 0x0000000181534CB0-0x0000000181534CC0
		public override Module[] GetModules(bool getResourceModules); // 0x0000000181534A10-0x0000000181534B50
		internal static byte[] GetAotId(); // 0x0000000181534750-0x00000001815347A0
		private static string get_code_base(Assembly a, bool escaped); // 0x00000001815347A0-0x00000001815347B0
		private string get_location(); // 0x00000001815350B0-0x00000001815350C0
		internal static string get_fullname(Assembly a); // 0x0000000181535080-0x0000000181535090
		internal static bool GetAotIdInternal(byte[] aotid); // 0x0000000181449F80-0x0000000181449F90
		internal static string GetCodeBase(Assembly a, bool escaped); // 0x00000001815347A0-0x00000001815347B0
		internal IntPtr GetManifestResourceInternal(string name, out int size, out Module module); // 0x0000000181534880-0x0000000181534890
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181534D90-0x0000000181534E00
		public override object[] GetCustomAttributes(bool inherit); // 0x00000001815347B0-0x0000000181534810
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181534810-0x0000000181534880
		internal override Module[] GetModulesInternal(); // 0x0000000181534A00-0x0000000181534A10
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public override bool Equals(object o); // 0x0000000181534690-0x0000000181534750
		public override string ToString(); // 0x0000000181534FB0-0x0000000181535000
	}
}
