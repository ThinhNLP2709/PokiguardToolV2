/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Mono;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_AssemblyName))]
	[ComVisible(true)]
	public sealed class AssemblyName : ICloneable, ISerializable, IDeserializationCallback, _AssemblyName // TypeDefIndex: 3342
	{
		// Fields
		private string name; // 0x10
		private string codebase; // 0x18
		private int major; // 0x20
		private int minor; // 0x24
		private int build; // 0x28
		private int revision; // 0x2C
		private CultureInfo cultureinfo; // 0x30
		private AssemblyNameFlags flags; // 0x38
		private AssemblyHashAlgorithm hashalg; // 0x3C
		private StrongNameKeyPair keypair; // 0x40
		private byte[] publicKey; // 0x48
		private byte[] keyToken; // 0x50
		private AssemblyVersionCompatibility versioncompat; // 0x58
		private Version version; // 0x60
		private ProcessorArchitecture processor_architecture; // 0x68
		private AssemblyContentType contentType; // 0x6C
	
		// Properties
		public string Name { get; } // 0x0000000180377550-0x0000000180377560 
		public CultureInfo CultureInfo { get; } // 0x000000018031E110-0x000000018031E120 
		public AssemblyNameFlags Flags { get; } // 0x000000018047EDE0-0x000000018047EDF0 
		public string FullName { get; } // 0x0000000181523BF0-0x0000000181523FC0 
		public Version Version { get; set; } // 0x0000000180333260-0x0000000180333490 0x0000000181524090-0x0000000181524110
		private bool IsPublicKeyValid { get; } // 0x0000000181523FC0-0x0000000181524080 
	
		// Constructors
		public AssemblyName(); // 0x00000001815236B0-0x00000001815236D0
		public AssemblyName(string assemblyName); // 0x0000000181523440-0x00000001815236B0
		internal AssemblyName(SerializationInfo si, StreamingContext sc); // 0x00000001815236D0-0x0000000181523BF0
	
		// Methods
		private static bool ParseAssemblyName(IntPtr name, out MonoAssemblyName aname, out bool is_version_definited, out bool is_token_defined); // 0x0000000181523400-0x0000000181523410
		public override string ToString(); // 0x0000000181523410-0x0000000181523440
		public byte[] GetPublicKeyToken(); // 0x00000001815231A0-0x0000000181523290
		private byte[] InternalGetPublicKeyToken(); // 0x0000000181523290-0x0000000181523380
		private static unsafe void get_public_token(byte* token, byte* pubkey, int len); // 0x0000000181524080-0x0000000181524090
		private byte[] ComputePublicKeyToken(); // 0x0000000181522A80-0x0000000181522B20
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181522ED0-0x00000001815231A0
		public object Clone(); // 0x0000000181522990-0x0000000181522A80
		public void OnDeserialization(object sender); // 0x0000000181523380-0x0000000181523400
		private static unsafe MonoAssemblyName* GetNativeName(IntPtr assembly_ptr); // 0x0000000181522EC0-0x0000000181522ED0
		internal unsafe void FillName(MonoAssemblyName* native, string codeBase, bool addVersion, bool addPublickey, bool defaultToken, bool assemblyRef); // 0x0000000181522BF0-0x0000000181522EC0
		internal static AssemblyName Create(Assembly assembly, bool fillCodebase); // 0x0000000181522B20-0x0000000181522BF0
	}
}
