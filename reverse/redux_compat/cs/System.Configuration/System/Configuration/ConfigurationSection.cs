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
	public abstract class ConfigurationSection : ConfigurationElement // TypeDefIndex: 15978
	{
		// Methods
		protected internal virtual void DeserializeSection(XmlReader reader); // 0x0000000181781C40-0x0000000181781C70
		protected internal override bool IsModified(); // 0x0000000181781C70-0x0000000181781CA0
		protected internal override void ResetModified(); // 0x0000000181781CA0-0x0000000181781CD0
		protected internal virtual string SerializeSection(ConfigurationElement parentElement, string name, ConfigurationSaveMode saveMode); // 0x0000000181781CD0-0x0000000181781D00
	}
}
