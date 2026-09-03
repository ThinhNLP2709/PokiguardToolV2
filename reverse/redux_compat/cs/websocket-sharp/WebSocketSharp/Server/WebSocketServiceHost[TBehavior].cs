/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebSocketSharp;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	internal class WebSocketServiceHost<TBehavior> : WebSocketServiceHost // TypeDefIndex: 13333
		where TBehavior : WebSocketBehavior, new()
	{
		// Fields
		private Func<TBehavior> _creator;
	
		// Properties
		public override Type BehaviorType { get; }
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass4_0 // TypeDefIndex: 13334
		{
			// Fields
			public Action<TBehavior> initializer;
	
			// Constructors
			public __c__DisplayClass4_0();
	
			// Methods
			internal TBehavior _createSessionCreator_b__1();
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13335
		{
			// Fields
			public static readonly __c<TBehavior> __9;
			public static Func<TBehavior> __9__4_0;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal TBehavior _createSessionCreator_b__4_0();
		}
	
		// Constructors
		internal WebSocketServiceHost(string path, Action<TBehavior> initializer, Logger log);
	
		// Methods
		private static Func<TBehavior> createSessionCreator(Action<TBehavior> initializer);
		protected override WebSocketBehavior CreateSession();
	}
}
