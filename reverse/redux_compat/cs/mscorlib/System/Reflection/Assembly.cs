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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Assembly))]
	[ComVisible(true)]
	public class Assembly : ICustomAttributeProvider, ISerializable, _Assembly // TypeDefIndex: 3340
	{
		// Properties
		public virtual string CodeBase { get; } // 0x0000000181524950-0x0000000181524990 
		public virtual string FullName { get; } // 0x0000000181524990-0x00000001815249D0 
		internal virtual IntPtr MonoAssembly { get; } // 0x0000000181524A10-0x0000000181524A50 
		public virtual string Location { get; } // 0x00000001815249D0-0x0000000181524A10 
		[MonoTODO]
		public bool IsFullyTrusted { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Nested types
		internal class ResolveEventHolder // TypeDefIndex: 3341
		{
			// Constructors
			public ResolveEventHolder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public Assembly(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815243C0-0x0000000181524400
		public virtual bool IsDefined(Type attributeType, bool inherit); // 0x0000000181524730-0x0000000181524770
		public virtual object[] GetCustomAttributes(bool inherit); // 0x0000000181524270-0x00000001815242B0
		public virtual object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181524230-0x0000000181524270
		internal virtual Type[] GetTypes(bool exportedOnly); // 0x00000001815246E0-0x00000001815246F0
		public virtual Type[] GetTypes(); // 0x00000001815246F0-0x0000000181524710
		public virtual Type GetType(string name); // 0x0000000181524680-0x00000001815246B0
		internal Type InternalGetType(Module module, string name, bool throwOnError, bool ignoreCase); // 0x0000000181524720-0x0000000181524730
		public virtual AssemblyName GetName(bool copiedName); // 0x0000000181524380-0x00000001815243C0
		public virtual AssemblyName GetName(); // 0x00000001814CCEC0-0x00000001814CCEE0
		public override string ToString(); // 0x0000000181524940-0x0000000181524950
		public static Assembly GetAssembly(Type type); // 0x0000000181524180-0x0000000181524220
		public static Assembly Load(string assemblyString); // 0x00000001815248C0-0x00000001815248F0
		public static Assembly ReflectionOnlyLoad(string assemblyString); // 0x00000001815248F0-0x0000000181524940
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public static Assembly LoadWithPartialName(string partialName); // 0x0000000181524770-0x00000001815247D0
		private static Assembly load_with_partial_name(string name, Evidence e); // 0x0000000181524A50-0x0000000181524A60
		[Obsolete("This method has been deprecated. Please use Assembly.Load() instead. http://go.microsoft.com/fwlink/?linkid=14202")]
		public static Assembly LoadWithPartialName(string partialName, Evidence securityEvidence); // 0x0000000181524860-0x00000001815248C0
		internal static Assembly LoadWithPartialName(string partialName, Evidence securityEvidence, bool oldBehavior); // 0x00000001815247D0-0x0000000181524860
		internal virtual Module[] GetModulesInternal(); // 0x0000000181524310-0x0000000181524350
		public static Assembly GetExecutingAssembly(); // 0x00000001815242B0-0x00000001815242E0
		public static Assembly GetCallingAssembly(); // 0x0000000181524220-0x0000000181524230
		internal static IntPtr InternalGetReferencedAssemblies(Assembly module); // 0x0000000181524710-0x0000000181524720
		internal static AssemblyName[] GetReferencedAssemblies(Assembly module); // 0x0000000181524400-0x0000000181524650
		public override int GetHashCode(); // 0x0000000181474D40-0x0000000181474D50
		public override bool Equals(object o); // 0x0000000181524170-0x0000000181524180
		private static Exception CreateNIE(); // 0x0000000181524110-0x0000000181524170
		public virtual Type GetType(string name, bool throwOnError, bool ignoreCase); // 0x00000001815246B0-0x00000001815246E0
		public virtual Module GetModule(string name); // 0x00000001815242E0-0x0000000181524310
		public virtual AssemblyName[] GetReferencedAssemblies(); // 0x0000000181524650-0x0000000181524680
		public virtual Module[] GetModules(bool getResourceModules); // 0x0000000181524350-0x0000000181524380
		public static bool operator ==(Assembly left, Assembly right); // 0x0000000181524A60-0x0000000181524AC0
		public static bool operator !=(Assembly left, Assembly right); // 0x0000000181524AC0-0x0000000181524B20
	}
}
