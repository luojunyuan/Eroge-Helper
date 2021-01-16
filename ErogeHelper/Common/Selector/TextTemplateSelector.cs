﻿using ErogeHelper.ViewModel.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ErogeHelper.Common.Selector
{
    class TextTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? OutLineDefaultTemplate { get; set; }
        public DataTemplate? OutLineBottomTemplate { get; set; }
        public DataTemplate? OutLineTopTemplate { get; set; }
        public DataTemplate? OutLineVerticalTemplate { get; set; }
        public override DataTemplate? SelectTemplate(object item, DependencyObject container)
        {
            // 可以通过container找keyname，也可以通过绑定的template直接返回
            if (container is FrameworkElement && item != null && item is SingleTextItem)
            {
                SingleTextItem textItem = (item as SingleTextItem)!;

                switch (textItem.TextTemplateType)
                {
                    case TextTemplateType.OutLineDefault:
                        return OutLineDefaultTemplate;
                    case TextTemplateType.OutLineKanaTop:
                        return OutLineTopTemplate;
                    case TextTemplateType.OutLineKanaBottom:
                        return OutLineBottomTemplate;
                    case TextTemplateType.OutLineVertical:
                        return OutLineVerticalTemplate;
                }
            }
            return null;
        }
    }

    public enum TextTemplateType
    {
        OutLineDefault,
        OutLineKanaTop,
        OutLineKanaBottom,
        OutLineVertical
    }
}
