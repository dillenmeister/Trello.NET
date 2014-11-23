using System;
using System.ComponentModel;
using System.Globalization;

namespace TrelloNet.Internal
{
	internal class ColorConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof (string);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value == null) return null;

			var colorName = value as string;
			if (colorName != null)
			{
				return new Color(colorName);
			}
			else
			{
				throw new NotSupportedException(
					string.Format(
						"Conversion from {0} to Color is not supported",
						value.GetType().Name));
			}
		}
	}
}