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

namespace System
{
	[Serializable]
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	public sealed class AppDomainSetup // TypeDefIndex: 2448
	{
		// Fields
		private string application_base; // 0x10
		private string application_name; // 0x18
		private string cache_path; // 0x20
		private string configuration_file; // 0x28
		private string dynamic_base; // 0x30
		private string license_file; // 0x38
		private string private_bin_path; // 0x40
		private string private_bin_path_probe; // 0x48
		private string shadow_copy_directories; // 0x50
		private string shadow_copy_files; // 0x58
		private bool publisher_policy; // 0x60
		private bool path_changed; // 0x61
		private int loader_optimization; // 0x64
		private bool disallow_binding_redirects; // 0x68
		private bool disallow_code_downloads; // 0x69
		private object _activationArguments; // 0x70
		private object domain_initializer; // 0x78
		private object application_trust; // 0x80
		private string[] domain_initializer_args; // 0x88
		private bool disallow_appbase_probe; // 0x90
		private byte[] configuration_bytes; // 0x98
		private byte[] serialized_non_primitives; // 0xA0
		private string manager_assembly; // 0xA8
		private string manager_type; // 0xB0
		private string[] partial_visible_assemblies; // 0xB8
		[CompilerGenerated]
		private string _TargetFrameworkName_k__BackingField; // 0xC0
	
		// Properties
		public string ApplicationBase { get; } // 0x000000018164AB60-0x000000018164AB70 
	
		// Constructors
		public AppDomainSetup(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		private static string GetAppBase(string appBase); // 0x000000018164A720-0x000000018164AB60
	}
}
