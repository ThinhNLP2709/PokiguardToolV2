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
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ComVisible(true)]
	[DesignerCategory("Component")]
	public class Component : MarshalByRefObject, IComponent // TypeDefIndex: 8902
	{
		// Fields
		private static readonly object EventDisposed; // 0x00
		private ISite site; // 0x18
		private EventHandlerList events; // 0x20
	
		// Properties
		protected virtual bool CanRaiseEvents { get; } // 0x00000001802E7990-0x00000001802E79A0 
		internal bool CanRaiseEventsInternal { get; } // 0x0000000181624290-0x00000001816242B0 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ISite Site { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected bool DesignMode { get; } // 0x0000000181BA47D0-0x0000000181BA4820 
	
		// Constructors
		public Component(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Component(); // 0x0000000181BA4760-0x0000000181BA47D0
	
		// Methods
		~Component(); // 0x000000018145FC70-0x000000018145FCF0
		public void Dispose(); // 0x0000000181BA4390-0x0000000181BA4400
		protected virtual void Dispose(bool disposing); // 0x0000000181BA4400-0x0000000181BA4610
		protected virtual object GetService(Type service); // 0x0000000181BA4610-0x0000000181BA4670
		public override string ToString(); // 0x0000000181BA4670-0x0000000181BA4760
	}
}
