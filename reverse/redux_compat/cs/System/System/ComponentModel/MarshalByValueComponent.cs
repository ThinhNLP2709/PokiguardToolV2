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

namespace System.ComponentModel
{
	[DesignerCategory("Component")]
	[TypeConverter(typeof(ComponentConverter))]
	public class MarshalByValueComponent : IComponent, IServiceProvider // TypeDefIndex: 8868
	{
		// Fields
		private static readonly object s_eventDisposed; // 0x00
		private ISite _site; // 0x10
		private EventHandlerList _events; // 0x18
	
		// Properties
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ISite Site { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public MarshalByValueComponent(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static MarshalByValueComponent(); // 0x0000000181BABFB0-0x0000000181BAC020
	
		// Methods
		~MarshalByValueComponent(); // 0x0000000181BABDE0-0x0000000181BABE60
		public void Dispose(); // 0x0000000181BABB80-0x0000000181BABBF0
		protected virtual void Dispose(bool disposing); // 0x0000000181BABBF0-0x0000000181BABDE0
		public virtual object GetService(Type service); // 0x0000000181BABE60-0x0000000181BABEC0
		public override string ToString(); // 0x0000000181BABEC0-0x0000000181BABFB0
	}
}
