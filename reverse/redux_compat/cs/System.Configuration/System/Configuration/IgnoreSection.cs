/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 87: System.Configuration.dll - Assembly: System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a - Types 15976-15985

namespace System.Configuration
{
	public sealed class IgnoreSection : ConfigurationSection // TypeDefIndex: 15984
	{
		// Properties
		protected internal override ConfigurationPropertyCollection Properties { get; } // 0x0000000181781E20-0x0000000181781E50 
	
		// Constructors
		public IgnoreSection(); // 0x0000000181781DF0-0x0000000181781E20
	
		// Methods
		protected internal override void DeserializeSection(XmlReader xmlReader); // 0x0000000181781D00-0x0000000181781D30
		protected internal override bool IsModified(); // 0x0000000181781D30-0x0000000181781D60
		protected internal override void Reset(ConfigurationElement parentSection); // 0x0000000181781D90-0x0000000181781DC0
		protected internal override void ResetModified(); // 0x0000000181781D60-0x0000000181781D90
		protected internal override string SerializeSection(ConfigurationElement parentSection, string name, ConfigurationSaveMode saveMode); // 0x0000000181781DC0-0x0000000181781DF0
	}
}
