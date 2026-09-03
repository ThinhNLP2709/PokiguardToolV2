/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 78: UnityEngine.VideoModule.dll - Assembly: UnityEngine.VideoModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15895-15912

namespace UnityEngine.Video
{
	[NativeClass("VideoPlayer", PersistentTypeId = 328)]
	[NativeHeader("Modules/Video/Public/VideoPlayer.h")]
	[RequireComponent(typeof(Transform))]
	[RequiredByNativeCode]
	public sealed class VideoPlayer : Behaviour // TypeDefIndex: 15908
	{
		// Fields
		[CompilerGenerated]
		private EventHandler prepareCompleted; // 0x18
		[CompilerGenerated]
		private EventHandler loopPointReached; // 0x20
		[CompilerGenerated]
		private EventHandler started; // 0x28
		[CompilerGenerated]
		private EventHandler frameDropped; // 0x30
		[CompilerGenerated]
		private ErrorEventHandler errorReceived; // 0x38
		[CompilerGenerated]
		private EventHandler seekCompleted; // 0x40
		[CompilerGenerated]
		private TimeEventHandler clockResyncOccurred; // 0x48
		[CompilerGenerated]
		private FrameReadyEventHandler frameReady; // 0x50
	
		// Nested types
		public delegate void EventHandler(VideoPlayer source); // TypeDefIndex: 15909; 0x00000001804A78A0-0x00000001804A78B0
	
		public delegate void ErrorEventHandler(VideoPlayer source, string message); // TypeDefIndex: 15910; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void FrameReadyEventHandler(VideoPlayer source, long frameIdx); // TypeDefIndex: 15911; 0x0000000180A70FB0-0x0000000180A70FC0
	
		public delegate void TimeEventHandler(VideoPlayer source, double seconds); // TypeDefIndex: 15912; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Methods
		[RequiredByNativeCode]
		private static void InvokePrepareCompletedCallback_Internal(VideoPlayer source); // 0x00000001825D31E0-0x00000001825D3220
		[RequiredByNativeCode]
		private static void InvokeFrameReadyCallback_Internal(VideoPlayer source, long frameIdx); // 0x00000001825D3160-0x00000001825D31A0
		[RequiredByNativeCode]
		private static void InvokeLoopPointReachedCallback_Internal(VideoPlayer source); // 0x00000001825D31A0-0x00000001825D31E0
		[RequiredByNativeCode]
		private static void InvokeStartedCallback_Internal(VideoPlayer source); // 0x00000001825D3260-0x00000001825D32A0
		[RequiredByNativeCode]
		private static void InvokeFrameDroppedCallback_Internal(VideoPlayer source); // 0x00000001825D3120-0x00000001825D3160
		[RequiredByNativeCode]
		private static void InvokeErrorReceivedCallback_Internal(VideoPlayer source, string errorStr); // 0x00000001825D30E0-0x00000001825D3120
		[RequiredByNativeCode]
		private static void InvokeSeekCompletedCallback_Internal(VideoPlayer source); // 0x00000001825D3220-0x00000001825D3260
		[RequiredByNativeCode]
		private static void InvokeClockResyncOccurredCallback_Internal(VideoPlayer source, double seconds); // 0x00000001825D30A0-0x00000001825D30E0
	}
}
