using System;
using System.Xml.Linq;
using System.Xml.XPath;
using AssetViewer.Library;

namespace AssetViewer.Data {

  public class DataAllocation {

    #region Properties
    public String Icon {
      get {
        var allocation = this.Element.XPathSelectElement("Values/Item/Allocation")?.Value;
        if (allocation == null) {
          return "/AssetViewer;component/Resources/data/ui/2kimages/main/3dicons/icon_guildhouse_0.png";
        }
        switch (allocation) {
          case "HarborOffice":
            return "/AssetViewer;component/Resources/data/ui/2kimages/main/3dicons/icon_harbour_kontor_0.png";
          case "Museum":
            return "/AssetViewer;component/Resources/data/ui/2kimages/main/3dicons/icon_museum_0.png";
          default:
            return null;
        }
      }
    }
    public String Text1 {
      get {
        switch (App.Language) {
          case Languages.German:
            return "Hier ausgerüstet";
          case Languages.Korean:
            return "이곳에 배치됨";
          default:
            return "Equipped here";
        }
      }
    }
    public String Text2 {
      get {
        var allocation = this.Element.XPathSelectElement("Values/Item/Allocation")?.Value;
        switch (App.Language) {
          case Languages.German:
            switch (allocation) {
              case "HarborOffice":
                return "Hafenmeisterei";
              case "Museum":
                return "Museum";
              default:
                return "Handelskammer";
            }
          case Languages.Korean:
            switch (allocation) {
              case "HarborOffice":
                return "항만 관리소장실";
              case "Museum":
                return "박물관";
              default:
                return "무역 연합";
            }
          default:
            switch (allocation) {
              case "HarborOffice":
                return "Harbor office";
              case "Museum":
                return "Museum";
              default:
                return "Guild house";
            }
        }
      }
    }
    #endregion

    #region Fields
    private readonly XElement Element;
    #endregion

    #region Constructor
    public DataAllocation(XElement element) {
      this.Element = element;
    }
    #endregion

  }

}