using System;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Library;

namespace AssetViewer.Data {

  public class DataRarity {

    #region Properties
    public String Text {
      get {
        switch (App.Language) {
          case Languages.German:
            switch (this.Element.XPathSelectElement("Values/Item/Rarity")?.Value) {
              case "Uncommon":
                return "Ungewöhnlich";
              case "Rare":
                return "Selten";
              case "Epic":
                return "Episch";
              case "Legendary":
                return "Legendär";
              default:
                return "Gewöhnlich";
            }
            break;
          case Languages.Korean:
            switch (this.Element.XPathSelectElement("Values/Item/Rarity")?.Value) {
              case "Uncommon":
                return "특별";
              case "Rare":
                return "희귀";
              case "Epic":
                return "에픽";
              case "Legendary":
                return "전설r";
              default:
                return "일반";
            }
            break;
        }
        return this.Element.XPathSelectElement("Values/Item/Rarity")?.Value ?? "Common";
      }
    }
    #endregion

    #region Fields
    private readonly XElement Element;
    #endregion

    #region Constructor
    public DataRarity(XElement element) {
      this.Element = element;
    }
    #endregion

  }

}