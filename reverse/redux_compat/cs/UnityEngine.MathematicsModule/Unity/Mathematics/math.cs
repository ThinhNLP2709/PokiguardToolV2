/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

// Image 42: UnityEngine.MathematicsModule.dll - Assembly: UnityEngine.MathematicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15208-15250

namespace Unity.Mathematics
{
	[Il2CppEagerStaticClassConstruction]
	public static class math // TypeDefIndex: 15211
	{
		// Nested types
		public enum RotationOrder : byte // TypeDefIndex: 15212
		{
			XYZ = 0,
			XZY = 1,
			YXZ = 2,
			YZX = 3,
			ZXY = 4,
			Default = 4,
			ZYX = 5
		}
	
		public enum ShuffleComponent : byte // TypeDefIndex: 15213
		{
			LeftX = 0,
			LeftY = 1,
			LeftZ = 2,
			LeftW = 3,
			RightX = 4,
			RightY = 5,
			RightZ = 6,
			RightW = 7
		}
	
		internal struct LongDoubleUnion // TypeDefIndex: 15214
		{
			// Fields
			public long longValue; // 0x00
			public double doubleValue; // 0x00
		}
	
		// Methods
		public static uint hash(bool2 v); // 0x00000001822BBBC0-0x00000001822BBC30
		public static uint hash(bool3 v); // 0x00000001822B3850-0x00000001822B38A0
		public static uint hash(bool4 v); // 0x00000001822BBC80-0x00000001822BBCE0
		public static uint hash(double2 v); // 0x00000001822B3D50-0x00000001822B3DE0
		public static uint hash(double4 v); // 0x00000001822BB940-0x00000001822BB9D0
		public static float2 float2(float x, float y); // 0x00000001822BB4D0-0x00000001822BB4E0
		public static uint hash(float2 v); // 0x00000001822BBCE0-0x00000001822BBD40
		public static float2x2 float2x2(float2 c0, float2 c1); // 0x00000001822BB4E0-0x00000001822BB4F0
		public static float determinant(float2x2 m); // 0x00000001822BB2A0-0x00000001822BB2C0
		public static uint hash(float2x2 v); // 0x00000001822BBA30-0x00000001822BBB00
		public static float3 float3(float x, float y, float z); // 0x00000001822BB550-0x00000001822BB570
		public static float3 float3(float x, float2 yz); // 0x00000001822BB520-0x00000001822BB550
		public static float3 float3(float2 xy, float z); // 0x00000001822BB4F0-0x00000001822BB520
		public static uint hash(float3 v); // 0x00000001822B4FA0-0x00000001822B4FF0
		public static float3x3 float3x3(float3 c0, float3 c1, float3 c2); // 0x00000001822BB570-0x00000001822BB5B0
		public static float3x3 float3x3(float m00, float m01, float m02, float m10, float m11, float m12, float m20, float m21, float m22); // 0x00000001822BB5B0-0x00000001822BB620
		public static float3x3 transpose(float3x3 v); // 0x00000001822BF220-0x00000001822BF2D0
		public static float3x3 inverse(float3x3 m); // 0x00000001822BDC10-0x00000001822BDE30
		public static float determinant(float3x3 m); // 0x00000001822BB1F0-0x00000001822BB2A0
		public static uint hash(float3x3 v); // 0x00000001822BBB00-0x00000001822BBBC0
		public static float4 float4(float x, float y, float z, float w); // 0x00000001822BB660-0x00000001822BB680
		public static float4 float4(float2 xy, float z, float w); // 0x00000001822BB680-0x00000001822BB6B0
		public static float4 float4(float2 xy, float2 zw); // 0x00000001822BB6B0-0x00000001822BB6F0
		public static float4 float4(float3 xyz, float w); // 0x00000001822BB6F0-0x00000001822BB720
		public static float4 float4(float v); // 0x00000001822B7EC0-0x00000001822B7ED0
		public static uint hash(float4 v); // 0x00000001822B7850-0x00000001822B78A0
		public static float4 shuffle(float4 left, float4 right, ShuffleComponent x, ShuffleComponent y, ShuffleComponent z, ShuffleComponent w); // 0x00000001822BEF10-0x00000001822BF040
		internal static float select_shuffle_component(float4 a, float4 b, ShuffleComponent component); // 0x00000001822B2B80-0x00000001822B34E0
		public static uint hash(float4x3 v); // 0x00000001822B28B0-0x00000001822B29E0
		public static float4x4 float4x4(float4 c0, float4 c1, float4 c2, float4 c3); // 0x00000001822BB720-0x00000001822BB750
		public static float3 transform(float4x4 a, float3 b); // 0x0000000180D8D420-0x0000000180D8D540
		public static float4x4 inverse(float4x4 m); // 0x00000001822BBF40-0x00000001822BDC10
		public static uint hash(float4x4 v); // 0x00000001822B29E0-0x00000001822B2B80
		public static int2 int2(int x, int y); // 0x00000001822BBF30-0x00000001822BBF40
		public static uint hash(int2 v); // 0x00000001822BB8F0-0x00000001822BB940
		public static uint hash(int3 v); // 0x00000001822BA360-0x00000001822BA3B0
		public static uint hash(int4 v); // 0x00000001822BA5B0-0x00000001822BA5F0
		public static uint2 asuint(int2 x); // 0x0000000180370C60-0x0000000180370C70
		public static uint3 asuint(int3 x); // 0x0000000181D8BE70-0x0000000181D8BE90
		public static uint4 asuint(int4 x); // 0x000000018092E600-0x000000018092E610
		public static uint asuint(float x); // 0x000000018155DBB0-0x000000018155DBC0
		public static uint2 asuint(float2 x); // 0x00000001822BACC0-0x00000001822BACD0
		public static uint3 asuint(float3 x); // 0x0000000181D8BE70-0x0000000181D8BE90
		public static uint4 asuint(float4 x); // 0x000000018092E600-0x000000018092E610
		public static ulong asulong(double x); // 0x000000018155D7D0-0x000000018155D7E0
		public static float asfloat(uint x); // 0x000000018155DBA0-0x000000018155DBB0
		public static float3 asfloat(uint3 x); // 0x0000000181D8BE70-0x0000000181D8BE90
		public static float4 asfloat(uint4 x); // 0x000000018092E600-0x000000018092E610
		public static double asdouble(ulong x); // 0x00000001822BACB0-0x00000001822BACC0
		public static bool isinf(double x); // 0x00000001822BDE30-0x00000001822BDE60
		public static bool4 isnan(float4 x); // 0x00000001822BDE60-0x00000001822BDEC0
		public static int min(int x, int y); // 0x0000000180313B00-0x0000000180313B10
		public static uint min(uint x, uint y); // 0x00000001822BE4E0-0x00000001822BE4F0
		public static long min(long x, long y); // 0x00000001822BE4F0-0x00000001822BE500
		public static float min(float x, float y); // 0x00000001822BE500-0x00000001822BE520
		public static float2 min(float2 x, float2 y); // 0x00000001822BE3D0-0x00000001822BE430
		public static float3 min(float3 x, float3 y); // 0x00000001822BE460-0x00000001822BE4E0
		public static float4 min(float4 x, float4 y); // 0x00000001822BE520-0x00000001822BE5C0
		public static double min(double x, double y); // 0x00000001822BE430-0x00000001822BE460
		public static double2 min(double2 x, double2 y); // 0x00000001822BE5C0-0x00000001822BE630
		public static int max(int x, int y); // 0x00000001821ECD90-0x00000001821ECDA0
		public static int2 max(int2 x, int2 y); // 0x00000001822BE2D0-0x00000001822BE300
		public static uint max(uint x, uint y); // 0x00000001822BE390-0x00000001822BE3A0
		public static long max(long x, long y); // 0x00000001822BE320-0x00000001822BE330
		public static ulong max(ulong x, ulong y); // 0x00000001822BE1A0-0x00000001822BE1B0
		public static float max(float x, float y); // 0x00000001822BE300-0x00000001822BE320
		public static float2 max(float2 x, float2 y); // 0x00000001822BE330-0x00000001822BE390
		public static float3 max(float3 x, float3 y); // 0x00000001822BE250-0x00000001822BE2D0
		public static float4 max(float4 x, float4 y); // 0x00000001822BE1B0-0x00000001822BE250
		public static double max(double x, double y); // 0x00000001822BE3A0-0x00000001822BE3D0
		public static float lerp(float start, float end, float t); // 0x00000001821ECC10-0x00000001821ECC20
		public static float3 lerp(float3 start, float3 end, float t); // 0x00000001822BE000-0x00000001822BE070
		public static int clamp(int valueToClamp, int lowerBound, int upperBound); // 0x00000001822BB010-0x00000001822BB030
		public static uint clamp(uint valueToClamp, uint lowerBound, uint upperBound); // 0x00000001822BB030-0x00000001822BB050
		public static float clamp(float valueToClamp, float lowerBound, float upperBound); // 0x0000000181C30A00-0x0000000181C30A30
		public static float4 clamp(float4 valueToClamp, float4 lowerBound, float4 upperBound); // 0x00000001822BAED0-0x00000001822BB010
		public static double clamp(double valueToClamp, double lowerBound, double upperBound); // 0x00000001822BAE80-0x00000001822BAED0
		public static float saturate(float x); // 0x00000001822BEDD0-0x00000001822BEE10
		public static int abs(int x); // 0x00000001822BAAA0-0x00000001822BAAB0
		public static float abs(float x); // 0x00000001822BAA90-0x00000001822BAAA0
		public static float3 abs(float3 x); // 0x00000001822BAB20-0x00000001822BAB70
		public static float4 abs(float4 x); // 0x00000001822BAAD0-0x00000001822BAB20
		public static double abs(double x); // 0x00000001822BAAB0-0x00000001822BAAD0
		public static float dot(float2 x, float2 y); // 0x00000001821FC860-0x00000001821FC890
		public static float dot(float3 x, float3 y); // 0x00000001821DF6D0-0x00000001821DF700
		public static float dot(float4 x, float4 y); // 0x00000001821F68F0-0x00000001821F6930
		public static double dot(double2 x, double2 y); // 0x00000001822BB450-0x00000001822BB470
		public static float atan(float x); // 0x00000001822BAD40-0x00000001822BADA0
		public static float2 atan(float2 x); // 0x0000000181FDB3B0-0x0000000181FDB490
		public static float atan2(float y, float x); // 0x00000001822BACD0-0x00000001822BAD40
		public static float cos(float x); // 0x00000001822BB050-0x00000001822BB0B0
		public static float3 cos(float3 x); // 0x0000000181F6B0E0-0x0000000181F6B250
		public static float acos(float x); // 0x00000001822BAB70-0x00000001822BABD0
		public static float sin(float x); // 0x00000001822BF040-0x00000001822BF0A0
		public static float3 sin(float3 x); // 0x0000000181F6B250-0x0000000181F6B7E0
		public static float floor(float x); // 0x00000001822BB7A0-0x00000001822BB800
		public static double floor(double x); // 0x00000001822BB750-0x00000001822BB7A0
		public static float ceil(float x); // 0x00000001822BADA0-0x00000001822BAE00
		public static float rcp(float x); // 0x00000001822BEC70-0x00000001822BEC80
		public static float2 rcp(float2 x); // 0x00000001822BEC40-0x00000001822BEC70
		public static float pow(float x, float y); // 0x00000001822BEBC0-0x00000001822BEC30
		public static float log2(float x); // 0x00000001822BE0D0-0x00000001822BE140
		public static double log2(double x); // 0x00000001822BE070-0x00000001822BE0D0
		public static float sqrt(float x); // 0x00000001822BF130-0x00000001822BF1B0
		public static double sqrt(double x); // 0x00000001822BF1B0-0x00000001822BF220
		public static float rsqrt(float x); // 0x00000001822BEDB0-0x00000001822BEDD0
		public static float2 normalize(float2 x); // 0x0000000181C40600-0x0000000181C40650
		public static float3 normalize(float3 x); // 0x00000001822BEA90-0x00000001822BEB20
		public static float2 normalizesafe(float2 x, float2 defaultvalue = default); // 0x00000001822BEB20-0x00000001822BEBC0
		public static float length(float2 x); // 0x00000001822BDEC0-0x00000001822BDEF0
		public static float length(float3 x); // 0x0000000181C405C0-0x0000000181C40600
		public static float length(float4 x); // 0x00000001822BDEF0-0x00000001822BDF50
		public static double length(double2 x); // 0x0000000181C30AD0-0x0000000181C30B60
		public static float lengthsq(float x); // 0x0000000181FF3D80-0x0000000181FF3D90
		public static float lengthsq(float2 x); // 0x00000001822BDFE0-0x00000001822BE000
		public static float lengthsq(float3 x); // 0x00000001822BDF50-0x00000001822BDF90
		public static float lengthsq(float4 x); // 0x00000001822BDF90-0x00000001822BDFE0
		public static float distance(float2 x, float2 y); // 0x0000000181C30A30-0x0000000181C30AD0
		public static float distance(float3 x, float3 y); // 0x00000001822BB350-0x00000001822BB3A0
		public static double distance(double2 x, double2 y); // 0x00000001822BB2C0-0x00000001822BB350
		public static float distancesq(float3 x, float3 y); // 0x00000001822BB400-0x00000001822BB450
		public static float distancesq(float4 x, float4 y); // 0x00000001822BB3A0-0x00000001822BB400
		public static float3 cross(float3 x, float3 y); // 0x00000001822BB150-0x00000001822BB1C0
		public static bool any(bool2 x); // 0x00000001822BABF0-0x00000001822BAC00
		public static bool any(bool3 x); // 0x00000001822BAC40-0x00000001822BAC60
		public static bool any(bool4 x); // 0x00000001822BAC60-0x00000001822BAC80
		public static bool any(float2 x); // 0x00000001822BAC80-0x00000001822BACB0
		public static bool any(float4 x); // 0x00000001822BAC00-0x00000001822BAC40
		public static bool all(int2 x); // 0x00000001822BABD0-0x00000001822BABF0
		public static uint select(uint falseValue, uint trueValue, bool test); // 0x00000001822BEF00-0x00000001822BEF10
		public static uint2 select(uint2 falseValue, uint2 trueValue, bool2 test); // 0x00000001822BEEC0-0x00000001822BEEF0
		public static uint3 select(uint3 falseValue, uint3 trueValue, bool3 test); // 0x00000001822BEE80-0x00000001822BEEC0
		public static uint4 select(uint4 falseValue, uint4 trueValue, bool4 test); // 0x00000001822BEE10-0x00000001822BEE80
		public static float2 select(float2 falseValue, float2 trueValue, bool test); // 0x00000001822BEEF0-0x00000001822BEF00
		public static void sincos(float3 x, out float3 s, out float3 c); // 0x00000001822BF0A0-0x00000001822BF130
		public static int countbits(uint x); // 0x00000001822BB110-0x00000001822BB150
		public static int countbits(ulong x); // 0x00000001822BB0B0-0x00000001822BB110
		public static int countbits(long x); // 0x00000001822BB0B0-0x00000001822BB110
		public static int lzcnt(int x); // 0x00000001812655C0-0x0000000181265610
		public static int lzcnt(uint x); // 0x00000001812655C0-0x0000000181265610
		public static int lzcnt(ulong x); // 0x00000001822BE140-0x00000001822BE1A0
		public static int tzcnt(int x); // 0x0000000180890320-0x0000000180890370
		public static int tzcnt(uint x); // 0x0000000180890320-0x0000000180890370
		public static int tzcnt(long x); // 0x0000000181C15E90-0x0000000181C15F00
		public static int tzcnt(ulong x); // 0x0000000181C15E90-0x0000000181C15F00
		public static uint rol(uint x, int n); // 0x00000001815FB690-0x00000001815FB6B0
		public static int ceilpow2(int x); // 0x0000000180C18E80-0x0000000180C18EB0
		public static int2 ceilpow2(int2 x); // 0x0000000181FC13E0-0x0000000181FC1570
		public static uint ceilpow2(uint x); // 0x00000001822BAE00-0x00000001822BAE30
		public static long ceilpow2(long x); // 0x00000001822BAE30-0x00000001822BAE80
		public static int ceillog2(int x); // 0x0000000181C8CC00-0x0000000181C8CC40
		public static int floorlog2(int x); // 0x0000000181C8CC40-0x0000000181C8CC90
		public static float radians(float x); // 0x00000001822BEC30-0x00000001822BEC40
		public static uint csum(uint2 x); // 0x00000001822BB1E0-0x00000001822BB1F0
		public static uint csum(uint3 x); // 0x00000001822BB1C0-0x00000001822BB1D0
		public static uint csum(uint4 x); // 0x0000000180732D00-0x0000000180732D10
		public static float csum(float3 x); // 0x00000001822BB1D0-0x00000001822BB1E0
		public static float square(float x); // 0x0000000181FF3D80-0x0000000181FF3D90
		public static float f16tof32(uint x); // 0x00000001822BB470-0x00000001822BB4D0
		private static unsafe uint hash_with_unaligned_loads(void* pBuffer, int numBytes, uint seed); // 0x00000001822BBD90-0x00000001822BBF30
		public static unsafe uint hash(void* pBuffer, int numBytes, uint seed = 0 /* Metadata: 0x006A9EE1 */); // 0x00000001822BBA20-0x00000001822BBA30
		internal static float4 movelh(float4 a, float4 b); // 0x00000001822BE740-0x00000001822BE850
		internal static float4 movehl(float4 a, float4 b); // 0x00000001822BE630-0x00000001822BE740
		internal static uint fold_to_uint(double x); // 0x00000001822BB840-0x00000001822BB860
		internal static uint2 fold_to_uint(double2 x); // 0x00000001822BB800-0x00000001822BB840
		internal static uint4 fold_to_uint(double4 x); // 0x00000001822BB860-0x00000001822BB8F0
		public static float3x3 float3x3(quaternion rotation); // 0x00000001822BB620-0x00000001822BB660
		public static float3 mul(float3x3 a, float3 b); // 0x00000001822BE850-0x00000001822BE930
		public static float3x3 mul(float3x3 a, float3x3 b); // 0x0000000181E1D470-0x0000000181E1D710
		public static float4 mul(float4x4 a, float4 b); // 0x0000000180D8D110-0x0000000180D8D420
		public static float4x4 mul(float4x4 a, float4x4 b); // 0x0000000180D8CAC0-0x0000000180D8D110
		public static quaternion quaternion(float4 value); // 0x000000018092E600-0x000000018092E610
		public static quaternion mul(quaternion a, quaternion b); // 0x00000001822BE930-0x00000001822BEA90
		public static float3 rotate(quaternion q, float3 v); // 0x00000001822BEC80-0x00000001822BEDB0
		public static uint hash(quaternion q); // 0x00000001822B7850-0x00000001822B78A0
		public static uint2 uint2(uint x, uint y); // 0x00000001822BBF30-0x00000001822BBF40
		public static uint hash(uint2 v); // 0x00000001822BBD40-0x00000001822BBD90
		public static uint3 uint3(uint x, uint y, uint z); // 0x00000001822BF2D0-0x00000001822BF2E0
		public static uint hash(uint3 v); // 0x00000001822BBC30-0x00000001822BBC80
		public static uint4 uint4(uint x, uint y, uint z, uint w); // 0x00000001822BF2E0-0x00000001822BF300
		public static uint hash(uint4 v); // 0x00000001822BB9D0-0x00000001822BBA20
	}
}
