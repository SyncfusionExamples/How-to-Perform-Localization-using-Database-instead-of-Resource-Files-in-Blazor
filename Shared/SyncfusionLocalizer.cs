using Syncfusion.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using BlazorServerWithLocalization.Models;
using System.Collections;
using System.Linq;
using Syncfusion.Blazor.Data;
using System.Globalization;
using System.Collections.Generic;

namespace BlazorServerWithLocalization.Shared
{
    public class SyncfusionLocalizer : ISyncfusionStringLocalizer
    {
        public SyncLocalizationContext Localizer { get; set; }
        public SyncfusionLocalizer(SyncLocalizationContext StringLocalizer)
        {
            this.Localizer = StringLocalizer;
        }

        // To get the locale key from mapped resources file
        public string GetText(string key)
        {
            string cultureValue = "";
            //Code for retriving the localized strings based on the key. 
            IList<Table> table = Localizer.Tables.ToList();
            Table data = table.Where(obj => obj.Key == key).FirstOrDefault();
            if (data != null)
            {
                string culture = CultureInfo.CurrentCulture.Name;
                culture = char.ToUpper(culture[0]) + culture.Substring(1);
                //For Attribute Mapping purpose added this condition since we defined 'EnUS' in Model property 
                if(culture == "En-US")
                {
                    culture = "EnUs";
                }
                cultureValue = data.GetType().GetProperty(culture).GetValue(data, null).ToString();
                return cultureValue;
            }
            return cultureValue;
        }

        public System.Resources.ResourceManager ResourceManager
        {
            get
            {
                // Using resources(.resx) for localization 
                // Replace the ApplicationNamespace with your application name.
                // return BlazorServer.Resources.SfResources.ResourceManager;
                // or
                // Using Database for localization
                return null;
            }
        }
    }
}