﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Data;

namespace AssetViewer.Converter {

  [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute"), SuppressMessage("ReSharper", "PossibleNullReferenceException")]
  public class DescriptionConverter : IValueConverter {

    #region Public Methods
    public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture) {
      var description = value as Description;
      if (description == null) return String.Empty;
      switch (App.Language) {
        case AssetViewer.Library.Languages.German:
          return description.DE;
        case AssetViewer.Library.Languages.Korean:
          return description.KR;
        default:
          return description.EN;
      }
    }
    public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture) {
      throw new NotImplementedException();
    }
    #endregion

  }

}