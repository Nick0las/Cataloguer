using Cataloguer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Cataloguer.Resources
{
    internal class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType {get; private set;}

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
                throw new ArgumentException("Тип перечисления не должен быть нулевым и иметь тип перечисления");

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
