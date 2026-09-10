/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ChatImagePicker // TypeDefIndex: 439
{
	// Fields
	public const int DEFAULT_MAX_SIDE = 1280; // Metadata: 0x0068B28E
	private const int JPEG_QUALITY = 82; // Metadata: 0x0068B290
	private const long MAX_SOURCE_BYTES = 33554432; // Metadata: 0x0068B292
	private const int OFN_FILEMUSTEXIST = 4096; // Metadata: 0x0068B29A
	private const int OFN_PATHMUSTEXIST = 2048; // Metadata: 0x0068B29C
	private const int OFN_NOCHANGEDIR = 8; // Metadata: 0x0068B29E
	private const int OFN_EXPLORER = 524288; // Metadata: 0x0068B29F

	// Nested types
	private struct OpenFileName // TypeDefIndex: 440
	{
		// Fields
		public int structSize; // 0x00
		public IntPtr hwndOwner; // 0x08
		public IntPtr hInstance; // 0x10
		public string filter; // 0x18
		public string customFilter; // 0x20
		public int maxCustFilter; // 0x28
		public int filterIndex; // 0x2C
		public string file; // 0x30
		public int maxFile; // 0x38
		public string fileTitle; // 0x40
		public int maxFileTitle; // 0x48
		public string initialDir; // 0x50
		public string title; // 0x58
		public int flags; // 0x60
		public short fileOffset; // 0x64
		public short fileExtension; // 0x66
		public string defExt; // 0x68
		public IntPtr custData; // 0x70
		public IntPtr hook; // 0x78
		public string templateName; // 0x80
		public IntPtr reservedPtr; // 0x88
		public int reservedInt; // 0x90
		public int flagsEx; // 0x94
	}

	// Methods
	public static void PickJpeg(int maxSide, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x000000018036FBB0-0x000000018036FC20
	private static void EncodeFromFile(string path, int maxSide, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x000000018036EE90-0x000000018036F110
	private static void EncodeTexture(Texture2D src, int maxSide, bool destroySource, Action<byte[], int, int> onPicked, Action<string> onFail); // 0x000000018036F110-0x000000018036F540
	private static Texture2D Downscale(Texture2D src, int nw, int nh); // 0x000000018036EBC0-0x000000018036EE90
	private static extern bool GetOpenFileNameW([In, Out] OpenFileName ofn); // 0x000000018036F540-0x000000018036F930
	private static string OpenFileDialogWin(); // 0x000000018036F930-0x000000018036FBB0
}

