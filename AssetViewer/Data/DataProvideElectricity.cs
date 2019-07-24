using System;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Library;

namespace AssetViewer.Data {

  public class DataProvideElectricity {

    #region Properties
    public String Text {
      get {
        switch (App.Language) {
          case Languages.German:
            return "Liefert Elektrizität";
          case Languages.Korean:
            return "전기 제공";
          default:
            return "Provide Electricity";
        }
      }
    }
    #endregion

    #region Fields
    private readonly XElement Element;
    #endregion

    #region Constructor
    public DataProvideElectricity(XElement element) {
      this.Element = element;
    }
    #endregion

  }

}