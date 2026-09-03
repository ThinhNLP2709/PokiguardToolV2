/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core.Raw;

// Image 10: Microsoft.Web.WebView2.Core.dll - Assembly: Microsoft.Web.WebView2.Core, Version=1.0.4191.47, Culture=neutral, PublicKeyToken=2a8ab48044d2601e - Types 10441-11179

namespace Microsoft.Web.WebView2.Core
{
	public class CoreWebView2Environment // TypeDefIndex: 10542
	{
		// Fields
		internal object _rawNative; // 0x10
		internal ICoreWebView2Environment _nativeICoreWebView2EnvironmentValue; // 0x18
		private EventRegistrationToken _NewBrowserVersionAvailableToken; // 0x20
		private EventHandler<object> privateNewBrowserVersionAvailable; // 0x28
		internal ICoreWebView2Environment10 _nativeICoreWebView2Environment10Value; // 0x30
		internal ICoreWebView2Environment11 _nativeICoreWebView2Environment11Value; // 0x38
		internal ICoreWebView2Environment12 _nativeICoreWebView2Environment12Value; // 0x40
		internal ICoreWebView2Environment13 _nativeICoreWebView2Environment13Value; // 0x48
		internal ICoreWebView2Environment14 _nativeICoreWebView2Environment14Value; // 0x50
		internal ICoreWebView2Environment15 _nativeICoreWebView2Environment15Value; // 0x58
		internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2Value; // 0x60
		internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3Value; // 0x68
		internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5Value; // 0x70
		private EventRegistrationToken _BrowserProcessExitedToken; // 0x78
		private EventHandler<CoreWebView2BrowserProcessExitedEventArgs> privateBrowserProcessExited; // 0x80
		internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6Value; // 0x88
		internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7Value; // 0x90
		internal ICoreWebView2Environment8 _nativeICoreWebView2Environment8Value; // 0x98
		private EventRegistrationToken _ProcessInfosChangedToken; // 0xA0
		private EventHandler<object> privateProcessInfosChanged; // 0xA8
		internal ICoreWebView2Environment9 _nativeICoreWebView2Environment9Value; // 0xB0
		private const char DirectorySeparatorChar = '\'; // Metadata: 0x006A14F0
		private const char AltDirectorySeparatorChar = '/'; // Metadata: 0x006A14F2
		private const char VolumeSeparatorChar = ':'; // Metadata: 0x006A14F4
		private static bool webView2LoaderLoaded; // 0x00
		private static string loaderDllFolderPath; // 0x08
	
		// Properties
		internal ICoreWebView2Environment _nativeICoreWebView2Environment { get; set; } // 0x00000001813A0900-0x00000001813A0A10 0x00000001802FAF70-0x00000001802FAF80
		public string BrowserVersionString { get; } // 0x000000018139F6D0-0x000000018139F830 
		internal ICoreWebView2Environment10 _nativeICoreWebView2Environment10 { get; set; } // 0x000000018139FAF0-0x000000018139FC00 0x0000000180378110-0x0000000180378120
		internal ICoreWebView2Environment11 _nativeICoreWebView2Environment11 { get; set; } // 0x000000018139FC00-0x000000018139FD10 0x000000018033E850-0x000000018033E860
		public string FailureReportFolderPath { get; } // 0x000000018139F830-0x000000018139F990 
		internal ICoreWebView2Environment12 _nativeICoreWebView2Environment12 { get; set; } // 0x000000018139FD10-0x000000018139FE20 0x0000000180378120-0x0000000180378130
		internal ICoreWebView2Environment13 _nativeICoreWebView2Environment13 { get; set; } // 0x000000018139FE20-0x000000018139FF30 0x00000001803780C0-0x00000001803780D0
		internal ICoreWebView2Environment14 _nativeICoreWebView2Environment14 { get; set; } // 0x000000018139FF30-0x00000001813A0040 0x00000001806CCE80-0x00000001806CCE90
		internal ICoreWebView2Environment15 _nativeICoreWebView2Environment15 { get; set; } // 0x00000001813A0040-0x00000001813A0150 0x00000001802F4050-0x00000001802F4060
		internal ICoreWebView2Environment2 _nativeICoreWebView2Environment2 { get; set; } // 0x00000001813A0150-0x00000001813A0260 0x00000001803780F0-0x0000000180378100
		internal ICoreWebView2Environment3 _nativeICoreWebView2Environment3 { get; set; } // 0x00000001813A0260-0x00000001813A0370 0x0000000180316A40-0x0000000180316A50
		internal ICoreWebView2Environment5 _nativeICoreWebView2Environment5 { get; set; } // 0x00000001813A0370-0x00000001813A0480 0x0000000180434A10-0x0000000180434A20
		internal ICoreWebView2Environment6 _nativeICoreWebView2Environment6 { get; set; } // 0x00000001813A0480-0x00000001813A05A0 0x0000000180664140-0x0000000180664160
		internal ICoreWebView2Environment7 _nativeICoreWebView2Environment7 { get; set; } // 0x00000001813A05A0-0x00000001813A06C0 0x0000000180664160-0x0000000180664180
		public string UserDataFolder { get; } // 0x000000018139F990-0x000000018139FAF0 
		internal ICoreWebView2Environment8 _nativeICoreWebView2Environment8 { get; set; } // 0x00000001813A06C0-0x00000001813A07E0 0x00000001806CCE20-0x00000001806CCE40
		internal ICoreWebView2Environment9 _nativeICoreWebView2Environment9 { get; set; } // 0x00000001813A07E0-0x00000001813A0900 0x00000001806C0C00-0x00000001806C0C20
	
		// Events
		public event EventHandler<object> NewBrowserVersionAvailable {
			add; // 0x000000018139F1A0-0x000000018139F430
			remove; // 0x00000001813A0C20-0x00000001813A0E20
		}
		public event EventHandler<CoreWebView2BrowserProcessExitedEventArgs> BrowserProcessExited {
			add; // 0x000000018139EF00-0x000000018139F1A0
			remove; // 0x00000001813A0A10-0x00000001813A0C20
		}
		public event EventHandler<object> ProcessInfosChanged {
			add; // 0x000000018139F430-0x000000018139F6D0
			remove; // 0x00000001813A0E20-0x00000001813A1040
		}
	
		// Nested types
		private enum ProcessorArchitecture : ushort // TypeDefIndex: 10543
		{
			x86 = 0,
			x64 = 9,
			ARM64 = 12,
			Unknown = 65535
		}
	
		private struct SYSTEM_INFO // TypeDefIndex: 10544
		{
			// Fields
			internal ushort wProcessorArchitecture; // 0x00
			private ushort wReserved; // 0x02
			private int dwPageSize; // 0x04
			private IntPtr lpMinimumApplicationAddress; // 0x08
			private IntPtr lpMaximumApplicationAddress; // 0x10
			private IntPtr dwActiveProcessorMask; // 0x18
			private int dwNumberOfProcessors; // 0x20
			private int dwProcessorType; // 0x24
			private int dwAllocationGranularity; // 0x28
			private short wProcessorLevel; // 0x2C
			private short wProcessorRevision; // 0x2E
		}
	
		[CompilerGenerated]
		private struct _CreateAsync_d__102 : IAsyncStateMachine // TypeDefIndex: 10545
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2Environment> __t__builder; // 0x08
			public CoreWebView2EnvironmentOptions options; // 0x20
			public string browserExecutableFolder; // 0x28
			public string userDataFolder; // 0x30
			private CoreWebView2CreateCoreWebView2EnvironmentCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001813A37F0-0x00000001813A3CD0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A3CD0-0x00000001813A3D30
		}
	
		[CompilerGenerated]
		private struct _CreateCoreWebView2CompositionControllerAsync_d__22 : IAsyncStateMachine // TypeDefIndex: 10546
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2CompositionController> __t__builder; // 0x08
			public CoreWebView2Environment __4__this; // 0x20
			public IntPtr ParentWindow; // 0x28
			public CoreWebView2ControllerOptions options; // 0x30
			private CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001813A3D30-0x00000001813A41B0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A41B0-0x00000001813A4210
		}
	
		[CompilerGenerated]
		private struct _CreateCoreWebView2CompositionControllerAsync_d__59 : IAsyncStateMachine // TypeDefIndex: 10547
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2CompositionController> __t__builder; // 0x08
			public CoreWebView2Environment __4__this; // 0x20
			public IntPtr ParentWindow; // 0x28
			private CoreWebView2CreateCoreWebView2CompositionControllerCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813A4210-0x00000001813A4670
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A4670-0x00000001813A46D0
		}
	
		[CompilerGenerated]
		private struct _CreateCoreWebView2ControllerAsync_d__15 : IAsyncStateMachine // TypeDefIndex: 10548
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2Controller> __t__builder; // 0x08
			public CoreWebView2Environment __4__this; // 0x20
			public IntPtr ParentWindow; // 0x28
			private CoreWebView2CreateCoreWebView2ControllerCompletedHandler _handler_5__2; // 0x30
			private object __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001813A46D0-0x00000001813A4B30
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A4B30-0x00000001813A4B90
		}
	
		[CompilerGenerated]
		private struct _CreateCoreWebView2ControllerAsync_d__21 : IAsyncStateMachine // TypeDefIndex: 10549
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<CoreWebView2Controller> __t__builder; // 0x08
			public CoreWebView2Environment __4__this; // 0x20
			public IntPtr ParentWindow; // 0x28
			public CoreWebView2ControllerOptions options; // 0x30
			private CoreWebView2CreateCoreWebView2ControllerCompletedHandler _handler_5__2; // 0x38
			private object __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001813A4B90-0x00000001813A5010
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A5010-0x00000001813A5070
		}
	
		[CompilerGenerated]
		private struct _GetProcessExtendedInfosAsync_d__38 : IAsyncStateMachine // TypeDefIndex: 10550
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<IReadOnlyList<CoreWebView2ProcessExtendedInfo>> __t__builder; // 0x08
			public CoreWebView2Environment __4__this; // 0x20
			private CoreWebView2GetProcessExtendedInfosCompletedHandler _handler_5__2; // 0x28
			private object __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001813A5590-0x00000001813A59E0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001813A59E0-0x00000001813A5A40
		}
	
		// Constructors
		internal CoreWebView2Environment(object rawCoreWebView2Environment); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		internal void OnNewBrowserVersionAvailable(object args); // 0x000000018136EED0-0x000000018136EEF0
		public async Task<CoreWebView2Controller> CreateCoreWebView2ControllerAsync(IntPtr ParentWindow); // 0x000000018139BE00-0x000000018139BEF0
		public CoreWebView2WebResourceResponse CreateWebResourceResponse(Stream Content, int StatusCode, string ReasonPhrase, string Headers); // 0x000000018139CE70-0x000000018139D0F0
		public async Task<CoreWebView2Controller> CreateCoreWebView2ControllerAsync(IntPtr ParentWindow, CoreWebView2ControllerOptions options); // 0x000000018139BCF0-0x000000018139BE00
		public async Task<CoreWebView2CompositionController> CreateCoreWebView2CompositionControllerAsync(IntPtr ParentWindow, CoreWebView2ControllerOptions options); // 0x000000018139BBE0-0x000000018139BCF0
		public CoreWebView2SharedBuffer CreateSharedBuffer(ulong Size); // 0x000000018139C6B0-0x000000018139C8A0
		public async Task<IReadOnlyList<CoreWebView2ProcessExtendedInfo>> GetProcessExtendedInfosAsync(); // 0x000000018139E040-0x000000018139E110
		public CoreWebView2FileSystemHandle CreateWebFileSystemFileHandle(string path, CoreWebView2FileSystemHandlePermission permission); // 0x000000018139CA50-0x000000018139CC00
		public CoreWebView2FileSystemHandle CreateWebFileSystemDirectoryHandle(string path, CoreWebView2FileSystemHandlePermission permission); // 0x000000018139C8A0-0x000000018139CA50
		public CoreWebView2FindOptions CreateFindOptions(); // 0x000000018139C390-0x000000018139C520
		public CoreWebView2WebResourceRequest CreateWebResourceRequest(string uri, string Method, Stream postData, string Headers); // 0x000000018139CC00-0x000000018139CE70
		public async Task<CoreWebView2CompositionController> CreateCoreWebView2CompositionControllerAsync(IntPtr ParentWindow); // 0x000000018139BAF0-0x000000018139BBE0
		public CoreWebView2PointerInfo CreateCoreWebView2PointerInfo(); // 0x000000018139C200-0x000000018139C390
		internal void OnBrowserProcessExited(CoreWebView2BrowserProcessExitedEventArgs args); // 0x000000018139ED60-0x000000018139ED90
		public CoreWebView2PrintSettings CreatePrintSettings(); // 0x000000018139C520-0x000000018139C6B0
		internal void OnProcessInfosChanged(object args); // 0x000000018136F1D0-0x000000018136F200
		public IReadOnlyList<CoreWebView2ProcessInfo> GetProcessInfos(); // 0x000000018139E110-0x000000018139E280
		public CoreWebView2ContextMenuItem CreateContextMenuItem(string Label, Stream iconStream, CoreWebView2ContextMenuItemKind Kind); // 0x000000018139B880-0x000000018139BAF0
		internal static extern int CreateCoreWebView2EnvironmentWithOptions(in string browserExecutableFolder, in string userDataFolder, ICoreWebView2EnvironmentOptions options, ICoreWebView2CreateCoreWebView2EnvironmentCompletedHandler environment_created_handler); // 0x000000018139C090-0x000000018139C200
		internal static extern int GetAvailableCoreWebView2BrowserVersionString(in string browserExecutableFolder, ref string versionInfo); // 0x000000018139DA40-0x000000018139DB30
		internal static extern int CompareBrowserVersions(in string version1, in string version2, ref int result); // 0x000000018139B6B0-0x000000018139B760
		internal static extern int GetAvailableCoreWebView2BrowserVersionStringWithOptions(in string browserExecutableFolder, ICoreWebView2EnvironmentOptions options, ref string versionInfo); // 0x000000018139D8F0-0x000000018139DA40
		public static async Task<CoreWebView2Environment> CreateAsync(string browserExecutableFolder = null, string userDataFolder = null, CoreWebView2EnvironmentOptions options = null); // 0x000000018139B760-0x000000018139B880
		public static string GetAvailableBrowserVersionString(string browserExecutableFolder); // 0x000000018139D770-0x000000018139D8F0
		public static string GetAvailableBrowserVersionString(string browserExecutableFolder = null, CoreWebView2EnvironmentOptions environmentOptions = null); // 0x000000018139D3D0-0x000000018139D770
		public static int CompareBrowserVersions(string version1, string version2); // 0x000000018139B5D0-0x000000018139B6B0
		public CoreWebView2ControllerOptions CreateCoreWebView2ControllerOptions(); // 0x000000018139BEF0-0x000000018139C090
		private static ProcessorArchitecture GetArchitecture(); // 0x000000018139D130-0x000000018139D1D0
		private static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo); // 0x000000018139E280-0x000000018139E300
		internal static extern IntPtr LoadLibrary(string dllToLoad); // 0x000000018139E3F0-0x000000018139E480
		private static bool IsDirectorySeparator(char c); // 0x000000018139E300-0x000000018139E320
		internal static bool IsValidDriveChar(char value); // 0x000000018139E3D0-0x000000018139E3F0
		private static bool IsDotNetFramework(); // 0x000000018139E320-0x000000018139E3D0
		private static string GetAssemblyLocationDirectory(); // 0x000000018139D300-0x000000018139D3D0
		private static string GetAssemblyCodeBaseDirectory(); // 0x000000018139D1D0-0x000000018139D300
		private static extern IntPtr GetModuleHandle(string lpModuleName); // 0x000000018139DE10-0x000000018139DEA0
		private static extern uint GetModuleFileName(in IntPtr hModule, out StringBuilder lpFilename, in int nSize); // 0x000000018139DD40-0x000000018139DE10
		private static string GetCurrentDllRuningDirectory(); // 0x000000018139DB30-0x000000018139DD40
		private static string GetProcessArchSubFolder(); // 0x000000018139DEA0-0x000000018139E040
		private static string GetAppDomainBaseDirectory(); // 0x000000018139D0F0-0x000000018139D130
		public static void SetLoaderDllFolderPath(string folderPath); // 0x000000018139ED90-0x000000018139EE40
		private static string TrimFormat(string path); // 0x000000018139EE40-0x000000018139EF00
		private static void LoadWebView2LoaderDll(); // 0x000000018139E480-0x000000018139ED60
	}
}
