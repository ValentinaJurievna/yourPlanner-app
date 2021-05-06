using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace yourPlanner.AdditionalElements
{
        public class TextBoxWithPlaceholder : TextBox
        {
            public string Placeholder
            {
                get { return (string)GetValue(PlaceholderProperty); }
                set { SetValue(PlaceholderProperty, value); }
            }
            public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register(
                nameof(Placeholder), typeof(string), typeof(TextBoxWithPlaceholder), new PropertyMetadata(""));

            public TextBoxWithPlaceholder()
            {
                DefaultStyleKey = typeof(TextBoxWithPlaceholder);
            }
        }
}
