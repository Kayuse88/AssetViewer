using AssetViewer.Data;
using AssetViewer.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows;
using System.Xml.Linq;

namespace AssetViewer {

  [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute"), SuppressMessage("ReSharper", "PossibleNullReferenceException")]
  public partial class App : Application {

    #region Properties

    public static Dictionary<Int32, Data.Description> Descriptions {
      get {
        var result = new Dictionary<Int32, Data.Description>();
        result.Add(101, new Data.Description("Asset:", "Gegenstand:", "에셋:"));
        result.Add(102, new Data.Description("Improvements", "Verbesserungen", "아이템 및 전문가"));
        result.Add(103, new Data.Description("Harbor office items", "Hafenmeisterei Gegenstände", "항만 관리소장실 아이템"));
        result.Add(104, new Data.Description("Town hall items", "Rathaus Gegenstände", "시청 아이템"));
        result.Add(105, new Data.Description("World Fair", "Weltausstellung", "만국박람회"));
        result.Add(106, new Data.Description("Equipped in", "Ausgerüstet in", "배치 가능 건물"));
        result.Add(107, new Data.Description("Topic", "Thema", "테마"));
        result.Add(108, new Data.Description("Size", "Grösse", "규모"));
        result.Add(109, new Data.Description("Level", "Stufe", "보상"));
        result.Add(110, new Data.Description("Third Party", "Gegenspieler", "중립 세력"));
        result.Add(120, new Data.Description("Expedition Events", "Expedition Events", "탐험 이벤트"));
        result.Add(121, new Data.Description("Tourism", "Tourismus", "관광"));
        result.Add(1001, new Data.Description("Rarity", "Rarität", "희귀도"));
        result.Add(1002, new Data.Description("Type", "Typ", "타입"));
        result.Add(1003, new Data.Description("Affect Building Group", "Beeinflusst Gebäude Gruppe", "영향 받는 건물 그룹"));
        result.Add(1004, new Data.Description("Search", "Suchen", "검색"));
        result.Add(1005, new Data.Description("Source", "Quelle", "원천"));
        result.Add(1006, new Data.Description("Attribute", "Eigenschaft", "속성"));
        result.Add(1007, new Data.Description("Patch Version", "Patch Version", "패치 버전"));
        result.Add(1008, new Data.Description("Detailed Sources", "Detaillierte Quellen", "상세 원천"));
        result.Add(1011, new Data.Description("Has Factory Upgrades", "Hat Fabrik-Erweiterungen", "공장 업그레이드"));
        result.Add(1012, new Data.Description("Has Building Upgrades", "Hat Gebäude-Erweiterungen", "건물 업그레이드"));
        result.Add(1021, new Data.Description("Common", "Allgemein", "공통"));
        result.Add(1022, new Data.Description("Specialist", "Spezialist", "전문가"));
        result.Add(1023, new Data.Description("Rarity", "Seltenheit", "희귀도"));
        result.Add(1024, new Data.Description("Effect Targets:", "Beeinflusste Gebäude:", "효과 대상"));
        result.Add(1046, new Data.Description("Has Population Upgrade", "Hat Bevölkerung-Erweiterungen", "인구 업그레이드"));
        result.Add(1047, new Data.Description("Has Residence Upgrade", "Hat Einwohne-Erweiterungen", "주거 업그레이드"));
        result.Add(1048, new Data.Description("Progression", "Fortschritt", "진행도"));
        result.Add(1049, new Data.Description("Player", "Spieler", "NPC 플레이어"));
        result.Add(1100, new Data.Description("Reset Filters", "Filter zurücksetzen", "필터 초기화"));
        result.Add(1101, new Data.Description("Only available items ", "Nur verfügbare Items ", "사용 가능한 아이템만"));
        result.Add(1102, new Data.Description("Affect Building", "Beeinflusst Gebäude", "영향 받는 건물"));
        result.Add(1103, new Data.Description("Sort by", "Sortieren nach", "정렬 기준"));
        return result;
      }
    }

    public static Dictionary<String, Tuple<String, String, String>> Translations {
      get {
        var result = new Dictionary<String, Tuple<String, String, String>>();
        result.Add("IncidentInfectableUpgrade", new Tuple<String, String, String>("Infectable", "Infizierungen", "감염"));
        result.Add("IncidentRiotIncreaseUpgrade", new Tuple<String, String, String>("Riot", "Aufstand", "폭동"));
        result.Add("IncidentFireIncreaseUpgrade", new Tuple<String, String, String>("Fire", "Feuer", "화재"));
        result.Add("IncidentExplosionIncreaseUpgrade", new Tuple<String, String, String>("Explosion", "Explosion", "폭발"));
        result.Add("IncidentIllnessIncreaseUpgrade", new Tuple<String, String, String>("Illness", "Krankheit", "질병"));
        result.Add("ElectricUpgrade", new Tuple<String, String, String>("Electric", "Elektrizität", "전기"));
        result.Add("ProvideElectricity", new Tuple<String, String, String>("Provide Electricity", "Liefert Elektrizität", "전기 제공"));
        result.Add("BuildingUpgrade", new Tuple<String, String, String>("Building", "Gebäude", "시청 아이템"));
        result.Add("ReplacingWorkforce", new Tuple<String, String, String>("Replacing Workforce", "Ersetzt Arbeitskraft", "시청 아이템"));
        result.Add("MaintenanceUpgrade", new Tuple<String, String, String>("Maintenance", "Wartung", "유지비"));
        result.Add("WorkforceAmountUpgrade", new Tuple<String, String, String>("Workforce Amount", "Arbeitskraft", "시청 아이템"));
        result.Add("ResolverUnitCountUpgrade", new Tuple<String, String, String>("Resolver Unit Count", "Einheitenanzahl", "필요 노동력"));
        result.Add("PublicServiceFullSatisfactionDistance", new Tuple<String, String, String>("Public Service Full Satisfaction Distance", "Public Service Full Satisfaction Distance", "공공시설 최대 만족 거리"));
        result.Add("PublicServiceNoSatisfactionDistance", new Tuple<String, String, String>("Public Service No Satisfaction Distance", "Public Service No Satisfaction Distance", "공공시절 불만족 거리"));
        result.Add("ResolverUnitMovementSpeedUpgrade", new Tuple<String, String, String>("Resolver Unit Movement Speed", "Einheitenschnelligkeit", "이동 속도"));
        result.Add("AdditionalOutput", new Tuple<String, String, String>("Additional Output", "Zusatzprodukte", "추가 생산"));
        result.Add("Cycle", new Tuple<String, String, String>("Cycle", "Zyklus", "사이클"));
        result.Add("Amount", new Tuple<String, String, String>("Amount", "Anzahl", "양"));
        result.Add("InputAmountUpgrade", new Tuple<String, String, String>("Input Amount", "Eingabeanzahl", "요구량"));
        result.Add("NeededAreaPercentUpgrade", new Tuple<String, String, String>("Needed Area", "Benötigte Fläche", "필요 구역"));
        result.Add("OutputAmountFactorUpgrade", new Tuple<String, String, String>("Output Amount", "Ausgabebetrag", "산출량"));
        result.Add("ProductivityUpgrade", new Tuple<String, String, String>("Productivity", "Produktivität", "생산성"));
        result.Add("AddedFertility", new Tuple<String, String, String>("Added Fertility", "Fruchtbarkeit", "작물 제공"));
        result.Add("NeedsElectricity", new Tuple<String, String, String>("Needs Electricity", "Benötigt Energie", "전기 필요"));
        result.Add("ReplaceInputs", new Tuple<String, String, String>("Replace Inputs", "Ersetzt Eingabematerialien", "투입 자원 변경"));
        result.Add("Old", new Tuple<String, String, String>("Old", "Alt", "예전"));
        result.Add("New", new Tuple<String, String, String>("New", "Neu", "새것"));
        result.Add("FactoryUpgrade", new Tuple<String, String, String>("Factory", "Fabrik", "공장"));
        result.Add("CultureUpgrade", new Tuple<String, String, String>("Culture", "Kultur", "시청 아이템"));
        result.Add("AttractivenessUpgrade", new Tuple<String, String, String>("Attractiveness", "Attraktivität", "시청 아이템"));
        result.Add("ModuleOwnerUpgrade", new Tuple<String, String, String>("Module Owner", "Module", "모듈 베이스"));
        result.Add("ModuleLimitUpgrade", new Tuple<String, String, String>("Module Limit", "Modullimit", "모듈 제한"));
        result.Add("IncidentInfluencerUpgrade", new Tuple<String, String, String>("Influencer", "Einflüsse", "영향력"));
        result.Add("SpecialUnitHappinessThresholdUpgrade", new Tuple<String, String, String>("Happiness Threshold", "Glücksschwelle", "행복도"));
        result.Add("FireInfluenceUpgrade", new Tuple<String, String, String>("Fire Influence", "Feuereinfluss", "화재확률"));
        result.Add("IllnessInfluenceUpgrade", new Tuple<String, String, String>("Illness Influence", "Krankheitseinfluss", "질병확률"));
        result.Add("RiotInfluenceUpgrade", new Tuple<String, String, String>("Riot Influence", "Aufstand Einfluss", "폭동확률"));
        result.Add("DistanceUpgrade", new Tuple<String, String, String>("Distance", "Distanz", "범위"));
        result.Add("ResidenceUpgrade", new Tuple<String, String, String>("Residence", "Wohnsitz", "주거지"));
        result.Add("AdditionalHappiness", new Tuple<String, String, String>("Additional Happiness", "Zusätzliche Zufriedenheit", "추가 행복도"));
        result.Add("PopulationUpgrade", new Tuple<String, String, String>("Population", "Bevölkerung", "인구"));
        result.Add("ResidentsUpgrade", new Tuple<String, String, String>("Residents", "Einwohner", "주민"));
        result.Add("StressUpgrade", new Tuple<String, String, String>("Stress", "Stress", "복잡도"));
        result.Add("ExpeditionAttribute", new Tuple<String, String, String>("Expedition", "Expedition", "탐험"));
        result.Add("BaseMorale", new Tuple<String, String, String>("Base Morale", "Basismoral", "기본 사기"));
        result.Add("ItemDifficulties", new Tuple<String, String, String>("Difficulties", "Schwierigkeit", "난이도"));
        result.Add("PerkMale", new Tuple<String, String, String>("Perk Male", "Vorteil männlich", "남성 특성"));
        result.Add("PerkFemale", new Tuple<String, String, String>("Perk Female", "Vorteil weiblich", "여성 특성"));
        result.Add("PerkFormerPirate", new Tuple<String, String, String>("Perk Former Pirate", "Vorteil Pirat", "해적 특성"));
        result.Add("PerkDiver", new Tuple<String, String, String>("Perk Diver", "Vorteil Taucher", "잠수부 특성"));
        result.Add("PerkZoologist", new Tuple<String, String, String>("PerkZoologist", "Vorteil Zoo", "동물학자 특성"));
        result.Add("PerkMilitaryShip", new Tuple<String, String, String>("Perk Military Ship", "Vorteil Militärschiff", "군함 특성"));
        result.Add("PerkHypnotist", new Tuple<String, String, String>("Perk Hypnotist", "Vorteil Hypnose", "최면술사 특성"));
        result.Add("PerkAnthropologist", new Tuple<String, String, String>("Perk Anthropologist", "Vorteil Anthropologe", "인류학자 특성"));
        result.Add("PerkPolyglot", new Tuple<String, String, String>("Perk Polyglot", "Vorteil Mehrsprachigkeit", "다국어 사용자 특성"));
        result.Add("PerkSteamShip", new Tuple<String, String, String>("Perk Steam Ship", "Vorteil Dampfschiff", "증기선 특성"));
        result.Add("PerkSailingShip", new Tuple<String, String, String>("Perk Sailing Ship", "Vorteil Segelschiff", "범선 특성"));
        result.Add("Medicine", new Tuple<String, String, String>("Medicine", "Heilkunst", "의약품"));
        result.Add("Melee", new Tuple<String, String, String>("Force", "Kampfkraft", "무력"));
        result.Add("Crafting", new Tuple<String, String, String>("Crafting", "Geschick", "제조"));
        result.Add("Hunting", new Tuple<String, String, String>("Hunting", "Jagdglück", "사냥"));
        result.Add("Navigation", new Tuple<String, String, String>("Navigation", "Navigation", "항해"));
        result.Add("Might", new Tuple<String, String, String>("Naval Power", "Gefechtskunde", "해군력"));
        result.Add("Diplomacy", new Tuple<String, String, String>("Diplomacy", "Redegabe", "외교"));
        result.Add("Faith", new Tuple<String, String, String>("Faith", "Glaube", "신앙"));
        return result;
      }
    }

    #endregion Properties

    #region Fields

    public static Languages Language = Languages.English;

    #endregion Fields

    #region Constructors

    public App() {
      if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName == "DEU") {
        Language = Languages.German;
      }
      else if (CultureInfo.CurrentCulture.ThreeLetterWindowsLanguageName == "KOR") {
        Language = Languages.Korean;
      }
    }

    #endregion Constructors

    #region Methods

    public static String GetTranslation(String key) {
      switch (App.Language) {
        case Languages.German:
          return App.Translations[key].Item2;
        
        case Languages.Korean:
          return App.Translations[key].Item3;
                    
        default:
          return App.Translations[key].Item1;
      }
    }
    public static String GetTranslation(XElement element) {
      var result = String.Empty;
      switch (App.Language) {
        case Languages.German:
          return element.Element("DE").Element("Short").Value;
        
        case Languages.Korean:
          return element.Element("KR").Element("Short").Value;
      }
      if (result == String.Empty)
        result = element.Element("EN").Element("Short").Value;
      return result;
    }

    #endregion Methods
  }
}