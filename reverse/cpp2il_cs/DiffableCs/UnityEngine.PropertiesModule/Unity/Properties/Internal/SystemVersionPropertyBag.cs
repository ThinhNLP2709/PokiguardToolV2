namespace Unity.Properties.Internal;

internal class SystemVersionPropertyBag : ContainerPropertyBag<Version>
{
	private class BuildProperty : Property<Version, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public BuildProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Version container) { }

		public virtual void SetValue(ref Version container, int value) { }

	}

	private class MajorProperty : Property<Version, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public MajorProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Version container) { }

		public virtual void SetValue(ref Version container, int value) { }

	}

	private class MinorProperty : Property<Version, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public MinorProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Version container) { }

		public virtual void SetValue(ref Version container, int value) { }

	}

	private class RevisionProperty : Property<Version, Int32>
	{

		public virtual bool IsReadOnly
		{
			 get { } //Length: 3
		}

		public virtual string Name
		{
			 get { } //Length: 44
		}

		public RevisionProperty() { }

		public virtual bool get_IsReadOnly() { }

		public virtual string get_Name() { }

		public virtual int GetValue(ref Version container) { }

		public virtual void SetValue(ref Version container, int value) { }

	}


	public SystemVersionPropertyBag() { }

}

