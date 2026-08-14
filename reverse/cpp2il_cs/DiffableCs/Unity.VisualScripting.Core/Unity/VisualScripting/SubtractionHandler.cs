namespace Unity.VisualScripting;

public sealed class SubtractionHandler : BinaryOperatorHandler
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Func<Byte, Byte, Object> <>9__0_0; //Field offset: 0x8
		public static Func<Byte, SByte, Object> <>9__0_1; //Field offset: 0x10
		public static Func<Byte, Int16, Object> <>9__0_2; //Field offset: 0x18
		public static Func<Byte, UInt16, Object> <>9__0_3; //Field offset: 0x20
		public static Func<Byte, Int32, Object> <>9__0_4; //Field offset: 0x28
		public static Func<Byte, UInt32, Object> <>9__0_5; //Field offset: 0x30
		public static Func<Byte, Int64, Object> <>9__0_6; //Field offset: 0x38
		public static Func<Byte, UInt64, Object> <>9__0_7; //Field offset: 0x40
		public static Func<Byte, Single, Object> <>9__0_8; //Field offset: 0x48
		public static Func<Byte, Decimal, Object> <>9__0_9; //Field offset: 0x50
		public static Func<Byte, Double, Object> <>9__0_10; //Field offset: 0x58
		public static Func<SByte, Byte, Object> <>9__0_11; //Field offset: 0x60
		public static Func<SByte, SByte, Object> <>9__0_12; //Field offset: 0x68
		public static Func<SByte, Int16, Object> <>9__0_13; //Field offset: 0x70
		public static Func<SByte, UInt16, Object> <>9__0_14; //Field offset: 0x78
		public static Func<SByte, Int32, Object> <>9__0_15; //Field offset: 0x80
		public static Func<SByte, UInt32, Object> <>9__0_16; //Field offset: 0x88
		public static Func<SByte, Int64, Object> <>9__0_17; //Field offset: 0x90
		public static Func<SByte, Single, Object> <>9__0_18; //Field offset: 0x98
		public static Func<SByte, Decimal, Object> <>9__0_19; //Field offset: 0xA0
		public static Func<SByte, Double, Object> <>9__0_20; //Field offset: 0xA8
		public static Func<Int16, Byte, Object> <>9__0_21; //Field offset: 0xB0
		public static Func<Int16, SByte, Object> <>9__0_22; //Field offset: 0xB8
		public static Func<Int16, Int16, Object> <>9__0_23; //Field offset: 0xC0
		public static Func<Int16, UInt16, Object> <>9__0_24; //Field offset: 0xC8
		public static Func<Int16, Int32, Object> <>9__0_25; //Field offset: 0xD0
		public static Func<Int16, UInt32, Object> <>9__0_26; //Field offset: 0xD8
		public static Func<Int16, Int64, Object> <>9__0_27; //Field offset: 0xE0
		public static Func<Int16, Single, Object> <>9__0_28; //Field offset: 0xE8
		public static Func<Int16, Decimal, Object> <>9__0_29; //Field offset: 0xF0
		public static Func<Int16, Double, Object> <>9__0_30; //Field offset: 0xF8
		public static Func<UInt16, Byte, Object> <>9__0_31; //Field offset: 0x100
		public static Func<UInt16, SByte, Object> <>9__0_32; //Field offset: 0x108
		public static Func<UInt16, Int16, Object> <>9__0_33; //Field offset: 0x110
		public static Func<UInt16, UInt16, Object> <>9__0_34; //Field offset: 0x118
		public static Func<UInt16, Int32, Object> <>9__0_35; //Field offset: 0x120
		public static Func<UInt16, UInt32, Object> <>9__0_36; //Field offset: 0x128
		public static Func<UInt16, Int64, Object> <>9__0_37; //Field offset: 0x130
		public static Func<UInt16, UInt64, Object> <>9__0_38; //Field offset: 0x138
		public static Func<UInt16, Single, Object> <>9__0_39; //Field offset: 0x140
		public static Func<UInt16, Decimal, Object> <>9__0_40; //Field offset: 0x148
		public static Func<UInt16, Double, Object> <>9__0_41; //Field offset: 0x150
		public static Func<Int32, Byte, Object> <>9__0_42; //Field offset: 0x158
		public static Func<Int32, SByte, Object> <>9__0_43; //Field offset: 0x160
		public static Func<Int32, Int16, Object> <>9__0_44; //Field offset: 0x168
		public static Func<Int32, UInt16, Object> <>9__0_45; //Field offset: 0x170
		public static Func<Int32, Int32, Object> <>9__0_46; //Field offset: 0x178
		public static Func<Int32, UInt32, Object> <>9__0_47; //Field offset: 0x180
		public static Func<Int32, Int64, Object> <>9__0_48; //Field offset: 0x188
		public static Func<Int32, Single, Object> <>9__0_49; //Field offset: 0x190
		public static Func<Int32, Decimal, Object> <>9__0_50; //Field offset: 0x198
		public static Func<Int32, Double, Object> <>9__0_51; //Field offset: 0x1A0
		public static Func<UInt32, Byte, Object> <>9__0_52; //Field offset: 0x1A8
		public static Func<UInt32, SByte, Object> <>9__0_53; //Field offset: 0x1B0
		public static Func<UInt32, Int16, Object> <>9__0_54; //Field offset: 0x1B8
		public static Func<UInt32, UInt16, Object> <>9__0_55; //Field offset: 0x1C0
		public static Func<UInt32, Int32, Object> <>9__0_56; //Field offset: 0x1C8
		public static Func<UInt32, UInt32, Object> <>9__0_57; //Field offset: 0x1D0
		public static Func<UInt32, Int64, Object> <>9__0_58; //Field offset: 0x1D8
		public static Func<UInt32, UInt64, Object> <>9__0_59; //Field offset: 0x1E0
		public static Func<UInt32, Single, Object> <>9__0_60; //Field offset: 0x1E8
		public static Func<UInt32, Decimal, Object> <>9__0_61; //Field offset: 0x1F0
		public static Func<UInt32, Double, Object> <>9__0_62; //Field offset: 0x1F8
		public static Func<Int64, Byte, Object> <>9__0_63; //Field offset: 0x200
		public static Func<Int64, SByte, Object> <>9__0_64; //Field offset: 0x208
		public static Func<Int64, Int16, Object> <>9__0_65; //Field offset: 0x210
		public static Func<Int64, UInt16, Object> <>9__0_66; //Field offset: 0x218
		public static Func<Int64, Int32, Object> <>9__0_67; //Field offset: 0x220
		public static Func<Int64, UInt32, Object> <>9__0_68; //Field offset: 0x228
		public static Func<Int64, Int64, Object> <>9__0_69; //Field offset: 0x230
		public static Func<Int64, Single, Object> <>9__0_70; //Field offset: 0x238
		public static Func<Int64, Decimal, Object> <>9__0_71; //Field offset: 0x240
		public static Func<Int64, Double, Object> <>9__0_72; //Field offset: 0x248
		public static Func<UInt64, Byte, Object> <>9__0_73; //Field offset: 0x250
		public static Func<UInt64, UInt16, Object> <>9__0_74; //Field offset: 0x258
		public static Func<UInt64, UInt32, Object> <>9__0_75; //Field offset: 0x260
		public static Func<UInt64, UInt64, Object> <>9__0_76; //Field offset: 0x268
		public static Func<UInt64, Single, Object> <>9__0_77; //Field offset: 0x270
		public static Func<UInt64, Decimal, Object> <>9__0_78; //Field offset: 0x278
		public static Func<UInt64, Double, Object> <>9__0_79; //Field offset: 0x280
		public static Func<Single, Byte, Object> <>9__0_80; //Field offset: 0x288
		public static Func<Single, SByte, Object> <>9__0_81; //Field offset: 0x290
		public static Func<Single, Int16, Object> <>9__0_82; //Field offset: 0x298
		public static Func<Single, UInt16, Object> <>9__0_83; //Field offset: 0x2A0
		public static Func<Single, Int32, Object> <>9__0_84; //Field offset: 0x2A8
		public static Func<Single, UInt32, Object> <>9__0_85; //Field offset: 0x2B0
		public static Func<Single, Int64, Object> <>9__0_86; //Field offset: 0x2B8
		public static Func<Single, UInt64, Object> <>9__0_87; //Field offset: 0x2C0
		public static Func<Single, Single, Object> <>9__0_88; //Field offset: 0x2C8
		public static Func<Single, Double, Object> <>9__0_89; //Field offset: 0x2D0
		public static Func<Decimal, Byte, Object> <>9__0_90; //Field offset: 0x2D8
		public static Func<Decimal, SByte, Object> <>9__0_91; //Field offset: 0x2E0
		public static Func<Decimal, Int16, Object> <>9__0_92; //Field offset: 0x2E8
		public static Func<Decimal, UInt16, Object> <>9__0_93; //Field offset: 0x2F0
		public static Func<Decimal, Int32, Object> <>9__0_94; //Field offset: 0x2F8
		public static Func<Decimal, UInt32, Object> <>9__0_95; //Field offset: 0x300
		public static Func<Decimal, Int64, Object> <>9__0_96; //Field offset: 0x308
		public static Func<Decimal, UInt64, Object> <>9__0_97; //Field offset: 0x310
		public static Func<Decimal, Decimal, Object> <>9__0_98; //Field offset: 0x318
		public static Func<Double, Byte, Object> <>9__0_99; //Field offset: 0x320
		public static Func<Double, SByte, Object> <>9__0_100; //Field offset: 0x328
		public static Func<Double, Int16, Object> <>9__0_101; //Field offset: 0x330
		public static Func<Double, UInt16, Object> <>9__0_102; //Field offset: 0x338
		public static Func<Double, Int32, Object> <>9__0_103; //Field offset: 0x340
		public static Func<Double, UInt32, Object> <>9__0_104; //Field offset: 0x348
		public static Func<Double, Int64, Object> <>9__0_105; //Field offset: 0x350
		public static Func<Double, UInt64, Object> <>9__0_106; //Field offset: 0x358
		public static Func<Double, Single, Object> <>9__0_107; //Field offset: 0x360
		public static Func<Double, Double, Object> <>9__0_108; //Field offset: 0x368

		private static <>c() { }

		public <>c() { }

		internal object <.ctor>b__0_0(byte a, byte b) { }

		internal object <.ctor>b__0_1(byte a, sbyte b) { }

		internal object <.ctor>b__0_10(byte a, double b) { }

		internal object <.ctor>b__0_100(double a, sbyte b) { }

		internal object <.ctor>b__0_101(double a, short b) { }

		internal object <.ctor>b__0_102(double a, ushort b) { }

		internal object <.ctor>b__0_103(double a, int b) { }

		internal object <.ctor>b__0_104(double a, uint b) { }

		internal object <.ctor>b__0_105(double a, long b) { }

		internal object <.ctor>b__0_106(double a, ulong b) { }

		internal object <.ctor>b__0_107(double a, float b) { }

		internal object <.ctor>b__0_108(double a, double b) { }

		internal object <.ctor>b__0_11(sbyte a, byte b) { }

		internal object <.ctor>b__0_12(sbyte a, sbyte b) { }

		internal object <.ctor>b__0_13(sbyte a, short b) { }

		internal object <.ctor>b__0_14(sbyte a, ushort b) { }

		internal object <.ctor>b__0_15(sbyte a, int b) { }

		internal object <.ctor>b__0_16(sbyte a, uint b) { }

		internal object <.ctor>b__0_17(sbyte a, long b) { }

		internal object <.ctor>b__0_18(sbyte a, float b) { }

		internal object <.ctor>b__0_19(sbyte a, decimal b) { }

		internal object <.ctor>b__0_2(byte a, short b) { }

		internal object <.ctor>b__0_20(sbyte a, double b) { }

		internal object <.ctor>b__0_21(short a, byte b) { }

		internal object <.ctor>b__0_22(short a, sbyte b) { }

		internal object <.ctor>b__0_23(short a, short b) { }

		internal object <.ctor>b__0_24(short a, ushort b) { }

		internal object <.ctor>b__0_25(short a, int b) { }

		internal object <.ctor>b__0_26(short a, uint b) { }

		internal object <.ctor>b__0_27(short a, long b) { }

		internal object <.ctor>b__0_28(short a, float b) { }

		internal object <.ctor>b__0_29(short a, decimal b) { }

		internal object <.ctor>b__0_3(byte a, ushort b) { }

		internal object <.ctor>b__0_30(short a, double b) { }

		internal object <.ctor>b__0_31(ushort a, byte b) { }

		internal object <.ctor>b__0_32(ushort a, sbyte b) { }

		internal object <.ctor>b__0_33(ushort a, short b) { }

		internal object <.ctor>b__0_34(ushort a, ushort b) { }

		internal object <.ctor>b__0_35(ushort a, int b) { }

		internal object <.ctor>b__0_36(ushort a, uint b) { }

		internal object <.ctor>b__0_37(ushort a, long b) { }

		internal object <.ctor>b__0_38(ushort a, ulong b) { }

		internal object <.ctor>b__0_39(ushort a, float b) { }

		internal object <.ctor>b__0_4(byte a, int b) { }

		internal object <.ctor>b__0_40(ushort a, decimal b) { }

		internal object <.ctor>b__0_41(ushort a, double b) { }

		internal object <.ctor>b__0_42(int a, byte b) { }

		internal object <.ctor>b__0_43(int a, sbyte b) { }

		internal object <.ctor>b__0_44(int a, short b) { }

		internal object <.ctor>b__0_45(int a, ushort b) { }

		internal object <.ctor>b__0_46(int a, int b) { }

		internal object <.ctor>b__0_47(int a, uint b) { }

		internal object <.ctor>b__0_48(int a, long b) { }

		internal object <.ctor>b__0_49(int a, float b) { }

		internal object <.ctor>b__0_5(byte a, uint b) { }

		internal object <.ctor>b__0_50(int a, decimal b) { }

		internal object <.ctor>b__0_51(int a, double b) { }

		internal object <.ctor>b__0_52(uint a, byte b) { }

		internal object <.ctor>b__0_53(uint a, sbyte b) { }

		internal object <.ctor>b__0_54(uint a, short b) { }

		internal object <.ctor>b__0_55(uint a, ushort b) { }

		internal object <.ctor>b__0_56(uint a, int b) { }

		internal object <.ctor>b__0_57(uint a, uint b) { }

		internal object <.ctor>b__0_58(uint a, long b) { }

		internal object <.ctor>b__0_59(uint a, ulong b) { }

		internal object <.ctor>b__0_6(byte a, long b) { }

		internal object <.ctor>b__0_60(uint a, float b) { }

		internal object <.ctor>b__0_61(uint a, decimal b) { }

		internal object <.ctor>b__0_62(uint a, double b) { }

		internal object <.ctor>b__0_63(long a, byte b) { }

		internal object <.ctor>b__0_64(long a, sbyte b) { }

		internal object <.ctor>b__0_65(long a, short b) { }

		internal object <.ctor>b__0_66(long a, ushort b) { }

		internal object <.ctor>b__0_67(long a, int b) { }

		internal object <.ctor>b__0_68(long a, uint b) { }

		internal object <.ctor>b__0_69(long a, long b) { }

		internal object <.ctor>b__0_7(byte a, ulong b) { }

		internal object <.ctor>b__0_70(long a, float b) { }

		internal object <.ctor>b__0_71(long a, decimal b) { }

		internal object <.ctor>b__0_72(long a, double b) { }

		internal object <.ctor>b__0_73(ulong a, byte b) { }

		internal object <.ctor>b__0_74(ulong a, ushort b) { }

		internal object <.ctor>b__0_75(ulong a, uint b) { }

		internal object <.ctor>b__0_76(ulong a, ulong b) { }

		internal object <.ctor>b__0_77(ulong a, float b) { }

		internal object <.ctor>b__0_78(ulong a, decimal b) { }

		internal object <.ctor>b__0_79(ulong a, double b) { }

		internal object <.ctor>b__0_8(byte a, float b) { }

		internal object <.ctor>b__0_80(float a, byte b) { }

		internal object <.ctor>b__0_81(float a, sbyte b) { }

		internal object <.ctor>b__0_82(float a, short b) { }

		internal object <.ctor>b__0_83(float a, ushort b) { }

		internal object <.ctor>b__0_84(float a, int b) { }

		internal object <.ctor>b__0_85(float a, uint b) { }

		internal object <.ctor>b__0_86(float a, long b) { }

		internal object <.ctor>b__0_87(float a, ulong b) { }

		internal object <.ctor>b__0_88(float a, float b) { }

		internal object <.ctor>b__0_89(float a, double b) { }

		internal object <.ctor>b__0_9(byte a, decimal b) { }

		internal object <.ctor>b__0_90(decimal a, byte b) { }

		internal object <.ctor>b__0_91(decimal a, sbyte b) { }

		internal object <.ctor>b__0_92(decimal a, short b) { }

		internal object <.ctor>b__0_93(decimal a, ushort b) { }

		internal object <.ctor>b__0_94(decimal a, int b) { }

		internal object <.ctor>b__0_95(decimal a, uint b) { }

		internal object <.ctor>b__0_96(decimal a, long b) { }

		internal object <.ctor>b__0_97(decimal a, ulong b) { }

		internal object <.ctor>b__0_98(decimal a, decimal b) { }

		internal object <.ctor>b__0_99(double a, byte b) { }

	}


	public SubtractionHandler() { }

}

