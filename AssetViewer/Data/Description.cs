using AssetViewer.Library;
using System;
using System.ComponentModel;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AssetViewer.Data {

 
  [Serializable]
  [DesignerCategory("code")]
  [XmlType(AnonymousType = true)]
  public class Description {

    #region Properties
    [XmlAttribute]
    public String ID { get; set; }
    public String EN { get; set; }
    public String DE { get; set; }
    public String KR { get; set; }
    public Icon Icon { get; set; }
    [XmlIgnore]
    public string CurrentLang {
      get {
        switch (App.Language) {
          case Languages.German:
            return DE;

          case Languages.Korean:
            return KR;

          default:
            return EN;
        }
      }
    } 
    [XmlAttribute]
    public DescriptionFontStyle FontStyle { get; set; }
    public Description AdditionalInformation { get; set; }
    #endregion

    #region Constructor
    public Description() {

    }
    public Description(XElement item) {
      this.ID = item.Attribute("ID")?.Value;
      this.EN = item.Element("EN")?.Value;
      this.DE = item.Element("DE")?.Value;
      this.KR = item.Element("KR")?.Value;
      this.Icon = item.Element("Icon")?.Value == null ? null : new Icon(item.Element("Icon"));
      var att = item.Attribute("FontStyle");
      if (att != null) {

      }
      this.FontStyle = item.Attribute("FontStyle") == null ? default : (DescriptionFontStyle)Convert.ToInt32(item.Attribute("FontStyle").Value) ;
      this.AdditionalInformation = item.Element("AdditionalInformation")?.Value == null ? null : new Description(item.Element("AdditionalInformation"));
    }
    public Description(String en, String de, String kr, Icon icon = null, Description AdditionalInformation = null) {
      this.ID = String.Empty;
      this.EN = en;
      this.DE = de;
      this.KR = kr;
      this.Icon = icon;
      this.AdditionalInformation = AdditionalInformation;
    }
    #endregion

  }

}