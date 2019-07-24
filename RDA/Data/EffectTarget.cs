﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RDA.Data {

  public class EffectTarget {

    #region Properties

    public Description Text { get; set; }
    public List<Description> Buildings { get; set; } = new List<Description>();

    #endregion Properties

    #region Constructors

    public EffectTarget(XElement element) {
      Text = new Description(Assets.DescriptionEN[element.Value], Assets.DescriptionDE[element.Value], Assets.DescriptionKR[element.Value]);
      var asset = Assets.Original.Descendants("Asset").FirstOrDefault(a => a
         .XPathSelectElement("Values/Standard/GUID")?
         .Value == element.Value);
      //Building

      //BuidlingPool
      var buildings = asset
         .XPathSelectElement("Values/ItemEffectTargetPool/EffectTargetGUIDs")?
         .Descendants("GUID");
      if (buildings != null) {
        Buildings = buildings
        .Where(a => Assets.DescriptionDE.ContainsKey(a.Value))
        .Select(a => new Description(a.Value))
        .ToList();
        return;
      }
      else {
        //if (asset.XPathSelectElement("Values/Building") != null || asset.XPathSelectElement("Values/PopulationLevel7") != null)
        Buildings.Add(new Description(asset.XPathSelectElement("Values/Standard/GUID").Value));
        return;
      }
    }

    #endregion Constructors

    #region Methods

    public XElement ToXml() {
      var result = new XElement("Target");
      result.Add(Text.ToXml("Text"));
      result.Add(new XElement("Buildings", Buildings.Select(b => b.ToXml("Text"))));
      return result;
    }

    #endregion Methods
  }
}