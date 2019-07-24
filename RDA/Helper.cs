﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

// ReSharper disable IdentifierTypo
// ReSharper disable AssignNullToNotNullAttribute
// ReSharper disable InconsistentNaming
// ReSharper disable PossibleNullReferenceException
namespace RDA {

  public static class Helper {

    #region Internal Methods
    // Extraction
    internal static void ExtractTextEnglish(String path) {
      var element = XDocument.Load(path).Root;
      var result = new Dictionary<String, String>();
      // assets
      var values = element.XPathSelectElements("//Texts/Text");
      foreach (var value in values) {
        var id = value.XPathSelectElement("GUID").Value;
        if (!result.ContainsKey(id)) {
          var text = value.XPathSelectElement("Text")?.Value;
          if (text != null) result.Add(id, text);
        }
      }
      // finish
      using (var xmlWriter = XmlWriter.Create($@"{Program.PathRoot}\Modified\Texts_English.xml", new XmlWriterSettings() { Indent = true })) {
        xmlWriter.WriteStartElement("Texts");
        foreach (var item in result) {
          xmlWriter.WriteStartElement("Text");
          xmlWriter.WriteAttributeString("ID", item.Key);
          xmlWriter.WriteValue(item.Value);
          xmlWriter.WriteEndElement();
        }
      }
    }
    internal static void ExtractTextGerman(String path) {
      var element = XDocument.Load(path).Root;
      var result = new Dictionary<String, String>();
      // assets
      var values = element.XPathSelectElements("//Texts/Text");
      foreach (var value in values) {
        var id = value.XPathSelectElement("GUID").Value;
        if (!result.ContainsKey(id)) {
          var text = value.XPathSelectElement("Text")?.Value;
          if (text != null) result.Add(id, text);
        }
      }
      // finish
      using (var xmlWriter = XmlWriter.Create($@"{Program.PathRoot}\Modified\Texts_German.xml", new XmlWriterSettings() { Indent = true })) {
        xmlWriter.WriteStartElement("Texts");
        foreach (var item in result) {
          xmlWriter.WriteStartElement("Text");
          xmlWriter.WriteAttributeString("ID", item.Key);
          xmlWriter.WriteValue(item.Value);
          xmlWriter.WriteEndElement();
        }
      }
    }
    internal static void ExtractTextKorean(String path) {
      var element = XDocument.Load(path).Root;
      var result = new Dictionary<String, String>();
      // assets
      var values = element.XPathSelectElements("//Texts/Text");
      foreach (var value in values) {
        var id = value.XPathSelectElement("GUID").Value;
        if (!result.ContainsKey(id)) {
          var text = value.XPathSelectElement("Text")?.Value;
          if (text != null) result.Add(id, text);
        }
      }
      // finish
      using (var xmlWriter = XmlWriter.Create($@"{Program.PathRoot}\Modified\Texts_Korean.xml", new XmlWriterSettings() { Indent = true })) {
        xmlWriter.WriteStartElement("Texts");
        foreach (var item in result) {
          xmlWriter.WriteStartElement("Text");
          xmlWriter.WriteAttributeString("ID", item.Key);
          xmlWriter.WriteValue(item.Value);
          xmlWriter.WriteEndElement();
        }
      }
    }
    internal static void ExtractTemplateNames(String path) {
      var element = XDocument.Load(path).Root;
      var result = element.XPathSelectElements("//Asset/Template").Select(s => s.Value).Distinct().OrderBy(o => o);
      // finish
      using (var xmlWriter = XmlWriter.Create($@"{Program.PathRoot}\Modified\TemplateNames.xml", new XmlWriterSettings() { Indent = true })) {
        xmlWriter.WriteStartElement("Templates");
        foreach (var item in result) {
          xmlWriter.WriteStartElement("Template");
          xmlWriter.WriteValue(item);
          xmlWriter.WriteEndElement();
        }
      }
    }
    // Description
    //internal static String GetDescriptionID(String pattern) {
    //  switch (pattern) {
    //    case "Common":
    //    case "Quest":
    //      return "118002";
    //    case "HarborOffice":
    //      return "4065";
    //    case "TownHall":
    //      return "2347";
    //    case "GuildHouse":
    //      return "2346";
    //    case "Uncommon":
    //      return "118003";
    //    case "Rare":
    //      return "118004";
    //    case "Epic":
    //      return "118005";
    //    case "Legendary":
    //      return "118006";
    //    case "ProductivityUpgrade":
    //      return "14130";
    //    case "AdditionalOutput":
    //      return "20074";
    //    case "ReplaceInputs":
    //      return "20081";
    //    case "InputAmountUpgrade":
    //      return "100369";
    //    case "OutputAmountFactorUpgrade":
    //      return "100371";
    //    case "NeededAreaPercentUpgrade":
    //      return "3030";
    //    case "NeedsElectricity":
    //      return "12508";
    //    case "Hunting":
    //      return "3927";
    //    case "PerkFormerPirate":
    //      return "191598";
    //    case "PerkFemale":
    //      return "15798";
    //    case "PerkMale":
    //      return "15797";
    //    case "PerkDiver":
    //      return "3931";
    //    case "Navigation":
    //      return "3923";
    //    case "Crafting":
    //      return "3926";
    //    case "PerkZoologist":
    //      return "9998";
    //    case "Might":
    //      return "3922";
    //    case "Diplomacy":
    //      return "3920";
    //    case "Faith":
    //      return "3925";
    //    case "Melee":
    //      return "3921";
    //    case "Medicine":
    //      return "3924";
    //    case "PerkMilitaryShip":
    //      return "3932";
    //    case "PerkHypnotist":
    //      return "3929";
    //    case "PerkAnthropologist":
    //      return "3928";
    //    case "PerkPolyglot":
    //      return "12266";
    //    case "AttractivenessUpgrade":
    //      return "145011";
    //    case "MaintenanceUpgrade":
    //      return "2320";
    //    case "WorkforceAmountUpgrade":
    //      return "12337";
    //    case "ReplacingWorkforce":
    //      return "12480";
    //    case "ModuleLimitUpgrade":
    //      return "12075";
    //    case "AdditionalHappiness":
    //      return "12314";
    //    case "ResidentsUpgrade":
    //      return "12676";
    //    case "StressUpgrade":
    //      return "12227";
    //    case "ProvideElectricity":
    //      return "12485";
    //    case "InputBenefitModifier":
    //      return "12690";
    //    case "TaxModifierInPercent":
    //      return "15198";
    //    case "WorkforceModifierInPercent":
    //      return "12676";
    //    case "PerkArcheologist":
    //      return "12262";
    //    case "MaxHitpointsUpgrade":
    //      return "1154";
    //    case "Ship":
    //      return "2342";
    //    case "SailShip":
    //      return "2343";
    //    case "SteamShip":
    //      return "2344";
    //    case "Warship":
    //      return "12812";
    //    default:
    //      throw new KeyNotFoundException(pattern);
    //  }
    //}
    // Processing
    internal static void SetImage(XElement element) {
      var name = element.Value.Replace(".png", "_0.png");
      var source = Path.GetFullPath(Path.Combine(Program.PathRoot, "Resources", name));
      if (File.Exists(source)) {
        var destination = Path.GetFullPath(Path.Combine(Program.PathViewer, "Resources", name));
        if (!Directory.Exists(Path.GetDirectoryName(destination))) Directory.CreateDirectory(Path.GetDirectoryName(destination));
        File.Copy(source, destination, true);
        element.Value = name;
      } else
        element.Value = String.Empty;
    }
    internal static void TemplateBuildPermitBuilding(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Blocking").Remove();
      item.XPathSelectElement("Values/Building").Remove();
      item.XPathSelectElement("Values/Cost").Remove();
      item.XPathSelectElement("Values/Selection").Remove();
      item.XPathSelectElement("Values/Object").Remove();
      item.XPathSelectElement("Values/Constructable").Remove();
      item.XPathSelectElement("Values/Mesh").Remove();
      item.XPathSelectElement("Values/SoundEmitter").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/FeedbackController").Remove();
      item.XPathSelectElement("Values/AmbientMoodProvider").Remove();
      item.XPathSelectElement("Values/Pausable").Remove();
      item.XPathSelectElement("Values/BuildPermit").Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // ornament
      var ornamentGuid = item.XPathSelectElement("Values/Ornament/OrnamentDescritpion").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={ornamentGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={ornamentGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={ornamentGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textKR));
      item.XPathSelectElement("Values/Ornament").Remove();
      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    internal static void TemplateGuildhouseItem(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Item/MaxStackSize").Remove();
      item.XPathSelectElement("Values/Item/TradePrice").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/Buff").Remove();
      item.XPathSelectElement("Values/ExpeditionAttribute/FluffText")?.Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // info
      var infoGuid = item.XPathSelectElement("Values/Standard/InfoDescription").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={infoGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textKR));
      item.XPathSelectElement("Values/Standard/InfoDescription").Remove();
      // EffectTargets
      foreach (var effectTarget in item.XPathSelectElements("Values/ItemEffect/EffectTargets/Item")) {
        var effectTargetGuid = effectTarget.Element("GUID").Value;
        textEN = Assets.Original.Root.XPathSelectElement($"//Asset/Values/Standard[GUID={effectTargetGuid}]/../Text/LocaText/English/Text").Value;
        textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={effectTargetGuid}]/Text").Value;
        textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={effectTargetGuid}]/Text").Value;
        effectTarget.Add(new XElement("Description"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("EN"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("DE"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("KR"));
        effectTarget.XPathSelectElement("Description/EN").Add(new XElement("Short", textEN));
        effectTarget.XPathSelectElement("Description/DE").Add(new XElement("Short", textDE));
        effectTarget.XPathSelectElement("Description/KR").Add(new XElement("Short", textKR));
      }
      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    internal static void TemplateCultureItem(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Item/ItemType").Remove();
      item.XPathSelectElement("Values/Cost").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/ExpeditionAttribute/FluffText")?.Remove();
      item.XPathSelectElement("Values/CultureUpgrade/ChangeModule")?.Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // info
      var infoGuid = item.XPathSelectElement("Values/Standard/InfoDescription").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={infoGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textKR));
      item.XPathSelectElement("Values/Standard/InfoDescription").Remove();
      // ItemSet

      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    internal static void TemplateHarborOfficeItem(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Item/MaxStackSize").Remove();
      item.XPathSelectElement("Values/Item/HasAction")?.Remove();
      item.XPathSelectElement("Values/Item/TradePrice").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/ExpeditionAttribute/FluffText")?.Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // info
      var infoGuid = item.XPathSelectElement("Values/Standard/InfoDescription").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={infoGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textKR));
      item.XPathSelectElement("Values/Standard/InfoDescription").Remove();
      // EffectTargets
      foreach (var effectTarget in item.XPathSelectElements("Values/ItemEffect/EffectTargets/Item")) {
        var effectTargetGuid = effectTarget.Element("GUID").Value;
        textEN = Assets.Original.Root.XPathSelectElement($"//Asset/Values/Standard[GUID={effectTargetGuid}]/../Text/LocaText/English/Text").Value;
        textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={effectTargetGuid}]/Text").Value;
        textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={effectTargetGuid}]/Text").Value;
        effectTarget.Add(new XElement("Description"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("EN"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("DE"));
        effectTarget.XPathSelectElement("Description").Add(new XElement("KR"));
        effectTarget.XPathSelectElement("Description/EN").Add(new XElement("Short", textEN));
        effectTarget.XPathSelectElement("Description/DE").Add(new XElement("Short", textDE));
        effectTarget.XPathSelectElement("Description/KR").Add(new XElement("Short", textKR));
      }
      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    internal static void TemplateVehicleItem(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Item/MaxStackSize").Remove();
      item.XPathSelectElement("Values/Item/HasAction")?.Remove();
      item.XPathSelectElement("Values/Item/TradePrice").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/ExpeditionAttribute/FluffText")?.Remove();
      item.XPathSelectElement("Values/Cost")?.Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // info
      var infoGuid = item.XPathSelectElement("Values/Standard/InfoDescription").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={infoGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Standard/InfoDescription").Remove();
      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    internal static void TemplateActiveItem(XElement item) {
      item.XPathSelectElement("Values/Standard/Name").Remove();
      item.XPathSelectElement("Values/Item/MaxStackSize").Remove();
      item.XPathSelectElement("Values/Item/HasAction")?.Remove();
      item.XPathSelectElement("Values/Item/TradePrice").Remove();
      item.XPathSelectElement("Values/Locked").Remove();
      item.XPathSelectElement("Values/ExpeditionAttribute/FluffText")?.Remove();
      item.XPathSelectElement("Values/Cost")?.Remove();
      // text
      var itemGuid = item.XPathSelectElement("Values/Standard/GUID").Value;
      var textEN = item.XPathSelectElement("Values/Text/LocaText/English/Text").Value;
      var textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      var textKR = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={itemGuid}]/Text").Value;
      item.XPathSelectElement("Values/Standard").AddAfterSelf(new XElement("Description"));
      item.XPathSelectElement("Values/Description").Add(new XElement("EN"));
      item.XPathSelectElement("Values/Description").Add(new XElement("DE"));
      item.XPathSelectElement("Values/Description").Add(new XElement("KR"));
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Short", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textDE));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Short", textKR));
      item.XPathSelectElement("Values/Text").Remove();
      // info
      var infoGuid = item.XPathSelectElement("Values/Standard/InfoDescription").Value;
      textEN = Assets.Original.Root.XPathSelectElement($"//Asset[Template='Text']/Values/Standard[GUID={infoGuid}]/../Text/LocaText/English/Text").Value;
      textDE = Program.TextDE.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      textKR = Program.TextKR.Root.XPathSelectElement($"Texts/Text[GUID={infoGuid}]/Text").Value;
      item.XPathSelectElement("Values/Description/EN").Add(new XElement("Long", textEN));
      item.XPathSelectElement("Values/Description/DE").Add(new XElement("Long", textDE));
      item.XPathSelectElement("Values/Description/KR").Add(new XElement("Long", textKR));
      item.XPathSelectElement("Values/Standard/InfoDescription").Remove();
      // image
      Helper.SetImage(item.XPathSelectElement("Values/Standard/IconFilename"));
    }
    #endregion

  }

}