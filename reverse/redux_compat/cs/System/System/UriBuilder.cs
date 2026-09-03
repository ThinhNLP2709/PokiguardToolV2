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

namespace System
{
	public class UriBuilder // TypeDefIndex: 8655
	{
		// Fields
		private bool _changed; // 0x10
		private string _fragment; // 0x18
		private string _host; // 0x20
		private string _password; // 0x28
		private string _path; // 0x30
		private int _port; // 0x38
		private string _query; // 0x40
		private string _scheme; // 0x48
		private string _schemeDelimiter; // 0x50
		private Uri _uri; // 0x58
		private string _username; // 0x60
	
		// Properties
		public string Path { set; } // 0x0000000181B568E0-0x0000000181B56990
		public Uri Uri { get; } // 0x0000000181B56830-0x0000000181B568E0 
	
		// Constructors
		public UriBuilder(Uri uri); // 0x0000000181B56660-0x0000000181B56830
	
		// Methods
		private void Init(Uri uri); // 0x0000000181B55DE0-0x0000000181B55FC0
		public override bool Equals(object rparam); // 0x0000000181B55D30-0x0000000181B55DA0
		public override int GetHashCode(); // 0x0000000181B55DA0-0x0000000181B55DE0
		private void SetFieldsFromUri(Uri uri); // 0x0000000181B55FC0-0x0000000181B56180
		public override string ToString(); // 0x0000000181B56180-0x0000000181B56660
	}
}
