using client_desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace client_desktop
{
    class StatusToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value.Equals(ChoreItem.StatusEnum.To_Be_Done))
            {
                return 2;
            }
            if (value.Equals(ChoreItem.StatusEnum.Done))
            {
                return 1;
            }
            if (value.Equals(ChoreItem.StatusEnum.In_Progress))
            {
                return 0;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
