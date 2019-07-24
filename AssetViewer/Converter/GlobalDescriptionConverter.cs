﻿using System;
using System.Globalization;
using System.Windows.Data;
using AssetViewer.Library;

namespace AssetViewer.Converter {

  public class GlobalDescriptionConverter : IValueConverter {

    #region Public Methods
    public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
      var key = Int32.Parse(parameter.ToString());
      switch (App.Language) {
        case Languages.English:
          return App.Descriptions[key].EN;
        case Languages.German:
          return App.Descriptions[key].DE;
        case Languages.Korean:
          return App.Descriptions[key].KR;
        default:
          throw new NotImplementedException();
      }
    }
    public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
    #endregion

  }

}