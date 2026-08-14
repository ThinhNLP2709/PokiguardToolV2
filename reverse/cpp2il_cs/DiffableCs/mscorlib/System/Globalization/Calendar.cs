namespace System.Globalization;

[ComVisible(True)]
public abstract class Calendar : ICloneable
{
	internal int m_currentEraValue; //Field offset: 0x10
	[OptionalField(VersionAdded = 2)]
	private bool m_isReadOnly; //Field offset: 0x14
	internal int twoDigitYearMax; //Field offset: 0x18

	internal override int BaseCalendarID
	{
		internal get { } //Length: 20
	}

	internal override int CurrentEraValue
	{
		internal get { } //Length: 520
	}

	public abstract Int32[] Eras
	{
		 get { } //Length: 0
	}

	internal override int ID
	{
		internal get { } //Length: 6
	}

	[ComVisible(False)]
	public override DateTime MaxSupportedDateTime
	{
		 get { } //Length: 79
	}

	[ComVisible(False)]
	public override DateTime MinSupportedDateTime
	{
		 get { } //Length: 79
	}

	public override int TwoDigitYearMax
	{
		 get { } //Length: 4
		 set { } //Length: 36
	}

	protected Calendar() { }

	[ComVisible(False)]
	public override object Clone() { }

	internal override int get_BaseCalendarID() { }

	internal override int get_CurrentEraValue() { }

	public abstract Int32[] get_Eras() { }

	internal override int get_ID() { }

	public override DateTime get_MaxSupportedDateTime() { }

	public override DateTime get_MinSupportedDateTime() { }

	public override int get_TwoDigitYearMax() { }

	public abstract int GetDayOfMonth(DateTime time) { }

	public abstract DayOfWeek GetDayOfWeek(DateTime time) { }

	public abstract int GetDaysInMonth(int year, int month, int era) { }

	public abstract int GetDaysInYear(int year, int era) { }

	public abstract int GetEra(DateTime time) { }

	public abstract int GetMonth(DateTime time) { }

	public abstract int GetMonthsInYear(int year, int era) { }

	internal static int GetSystemTwoDigitYearSetting(int CalID, int defaultYearValue) { }

	public abstract int GetYear(DateTime time) { }

	public override bool IsLeapYear(int year) { }

	public abstract bool IsLeapYear(int year, int era) { }

	internal override bool IsValidDay(int year, int month, int day, int era) { }

	internal override bool IsValidMonth(int year, int month, int era) { }

	internal override bool IsValidYear(int year, int era) { }

	public override void set_TwoDigitYearMax(int value) { }

	internal void SetReadOnlyState(bool readOnly) { }

	internal static long TimeToTicks(int hour, int minute, int second, int millisecond) { }

	public override DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) { }

	public abstract DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era) { }

	public override int ToFourDigitYear(int year) { }

	internal override bool TryToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era, out DateTime result) { }

	internal void VerifyWritable() { }

}

