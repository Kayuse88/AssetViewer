using AssetViewer.Data;
using AssetViewer.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AssetViewer.Comparer {
  public class RarityComparer : IComparer<string> {
    public static RarityComparer Default { get; } = new RarityComparer();
    private static List<string> RaritiesEN = new List<string>() { "Quest Item", "Common", "Uncommon", "Rare", "Epic", "Legendary" };
    private static List<string> RaritiesDE = new List<string>() { "Aufgaben-Item", "Gewöhnlich", "Ungewöhnlich", "Selten", "Episch", "Legendär" };
    private static List<string> RaritiesKR = new List<string>() { "퀘스트 아이템", "일반", "특별", "희귀", "에픽", "전설" };
    public int Compare(string x, string y) {
      if (App.Language == Languages.German) {
        return RaritiesDE.IndexOf(x).CompareTo(RaritiesDE.IndexOf(y));
      }
      else if (App.Language == Languages.Korean) {
        return RaritiesKR.IndexOf(x).CompareTo(RaritiesKR.IndexOf(y));
      }
      else {
        return RaritiesEN.IndexOf(x).CompareTo(RaritiesEN.IndexOf(y));
      }

    }
  }
}
