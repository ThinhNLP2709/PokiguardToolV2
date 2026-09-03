/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Messaging
{
	[Serializable]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public class ConstructionCall : MethodCall, IConstructionCallMessage // TypeDefIndex: 2977
	{
		// Fields
		private IActivator _activator; // 0x68
		private object[] _activationAttributes; // 0x70
		private IList _contextProperties; // 0x78
		private Type _activationType; // 0x80
		private string _activationTypeName; // 0x88
		private bool _isContextOk; // 0x90
		[NonSerialized]
		private RemotingProxy _sourceProxy; // 0x98
	
		// Properties
		internal bool IsContextOk { get; set; } // 0x000000018033D630-0x000000018033D640 0x000000018033EC10-0x000000018033EC20
		public Type ActivationType { get; } // 0x00000001814D78C0-0x00000001814D7960 
		public string ActivationTypeName { get; } // 0x000000018038B8A0-0x000000018038B8B0 
		public IActivator Activator { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public object[] CallSiteActivationAttributes { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		public IList ContextProperties { get; } // 0x00000001814D7960-0x00000001814D79D0 
		public override IDictionary Properties { get; } // 0x00000001814D79D0-0x00000001814D7A10 
		internal RemotingProxy SourceProxy { get; set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
	
		// Constructors
		internal ConstructionCall(Type type); // 0x00000001814D7840-0x00000001814D78C0
		internal ConstructionCall(SerializationInfo info, StreamingContext context); // 0x00000001814D7780-0x00000001814D7840
	
		// Methods
		internal override void InitDictionary(); // 0x00000001814D7240-0x00000001814D7350
		internal void SetActivationAttributes(object[] attributes); // 0x0000000180434A10-0x0000000180434A20
		internal override void InitMethodProperty(string key, object value); // 0x00000001814D7350-0x00000001814D7780
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814D7100-0x00000001814D7240
	}
}
