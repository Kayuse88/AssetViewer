using System;

namespace AssetViewer.Library {

  public class Description {

    #region Properties
    public String ShortEN { get; set; }
    public String LongEN { get; set; }
    public String ShortDE { get; set; }
    public String LongDE { get; set; }
    public String ShortKR { get; set; }
    public String LongKR { get; set; }
    public String Short {
      get {
        switch (App.Language) {
          case Languages.German:
            return ShortDE;

          case Languages.Korean:
            return ShortKR;

          default:
            return ShortEN;
        }
      }
    }
    public String Long {
      get {
        switch (App.Language) {
          case Languages.German:
            return LongDE;

          case Languages.Korean:
            return LongKR;

          default:
            return LongEN;
        }
      }
    }
    #endregion

    #region Constructor
    public Description() {
    }
    public Description(String shortEN, String shortDE, String shortKR) {
      this.ShortEN = shortEN;
      this.ShortDE = shortDE;
      this.ShortKR = shortKR;
    }
    public Description(String shortEN, String longEN, String shortDE, String longDE, String shortKR, String longKR) {
      this.ShortEN = shortEN;
      this.LongEN = longEN;
      this.ShortDE = shortDE;
      this.LongDE = longDE;
      this.ShortKR = shortKR;
      this.LongKR = longKR;
    }
    #endregion

  }

}