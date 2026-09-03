/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.GlobalIllumination
{
	public static class LightmapperUtils // TypeDefIndex: 8220
	{
		// Methods
		public static LightMode Extract(LightmapBakeType baketype); // 0x00000001822496D0-0x00000001822496F0
		public static LinearColor ExtractIndirect(Light l); // 0x0000000182248C40-0x0000000182248CD0
		public static float ExtractInnerCone(Light l); // 0x0000000182248CD0-0x0000000182248D20
		private static Color ExtractColorTemperature(Light l); // 0x0000000182248B70-0x0000000182248C40
		private static void ApplyColorTemperature(Color cct, ref LinearColor lightColor); // 0x0000000182248970-0x0000000182248B70
		public static void Extract(Light l, ref DirectionalLight dir); // 0x0000000182249060-0x0000000182249390
		public static void Extract(Light l, ref PointLight point); // 0x0000000182249390-0x00000001822496D0
		public static void Extract(Light l, ref SpotLight spot); // 0x00000001822496F0-0x0000000182249A90
		public static void Extract(Light l, ref RectangleLight rect); // 0x0000000182248D20-0x0000000182249060
		public static void Extract(Light l, ref DiscLight disc); // 0x0000000182249A90-0x0000000182249DD0
		public static void Extract(Light l, out Cookie cookie); // 0x0000000182249DD0-0x0000000182249EF0
	}
}
