using System;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Library;

namespace AssetViewer.Data {

  public class DataEffectTargets {

    #region Properties
    public String Text {
      get {
        var effect = this.Element.XPathSelectElement("Values/ItemEffect/EffectTargets");
        switch (App.Language) {
          case Languages.German:
            var sbDE = new StringBuilder();
            foreach (var item in effect.XPathSelectElements("Item")) {
              sbDE.Append(sbDE.Length == 0 ? "Beeinflusst " : ", ");
              sbDE.Append(item.XPathSelectElement("Description/DE/Short").Value);
            }
            return sbDE.ToString();
          case Languages.Korean:
            var sbKR = new StringBuilder();
            foreach (var item in effect.XPathSelectElements("Item")) {
              sbKR.Append(sbKR.Length == 0 ? "영향 " : ", ");
              sbKR.Append(item.XPathSelectElement("Description/KR/Short").Value);
            }
            return sbKR.ToString();
          default:
            var sbEN = new StringBuilder();
            foreach (var item in effect.XPathSelectElements("Item")) {
              sbEN.Append(sbEN.Length == 0 ? "Affect " : ", ");
              sbEN.Append(item.XPathSelectElement("Description/EN/Short").Value);
            }
            return sbEN.ToString();
        }
      }
    }
    #endregion

    #region Fields
    private readonly XElement Element;
    #endregion

    #region Constructor
    public DataEffectTargets(XElement element) {
      this.Element = element;
    }
    #endregion

  }

}