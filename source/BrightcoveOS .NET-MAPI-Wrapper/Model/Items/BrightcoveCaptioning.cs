using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;
using BrightcoveMapiWrapper.Util.Extensions;

namespace BrightcoveMapiWrapper.Model.Items
{
    /// <summary>
    /// Brightcove object that represents captioning information
    /// </summary>
    public class BrightcoveCaptioning : BrightcoveItem, IJavaScriptConvertable
    {
        /// <summary>
        /// Captioning object id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Set of caption sources
        /// </summary>
        public ICollection<BrightcoveCaptionSource> CaptionSources { get; set; }

        public BrightcoveCaptioning()
        {
            CaptionSources = new List<BrightcoveCaptionSource>();
        }

        public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialized = new Dictionary<string, object>();

            serialized["captionSources"] = CaptionSources;

            if (Id != 0)
            {
                serialized["id"] = Id;
            }

            return serialized;
        }

        public void Deserialize(IDictionary<string, object> dictionary, JavaScriptSerializer serializer)
        {
            foreach (string key in dictionary.Keys)
            {
                switch (key)
                {
                    case "error":
                        ApiUtil.ThrowIfError(dictionary, key, serializer);
                        break;

                    case "id":
                        Id = Convert.ToInt64(dictionary[key]);
                        break;

                    case "captionSources":
                        CaptionSources.Clear();
                        CaptionSources.AddRange(serializer.ConvertToType<List<BrightcoveCaptionSource>>(dictionary[key]));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}