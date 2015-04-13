using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Serialization;
using BrightcoveMapiWrapper.Util;

namespace BrightcoveMapiWrapper.Model.Items
{
    /// <summary>
    /// A source that provides captions for a video.
    /// </summary>
    public class BrightcoveCaptionSource : BrightcoveItem, IJavaScriptConvertable
    {
        /// <summary>
        /// A Boolean indicating whether a CaptionSource is usable
        /// </summary>
        public bool Complete { get; set; }

        /// <summary>
        /// The name of the caption source, which will be displayed in the Media module.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// A number that uniquely identifies this CaptionSource object, assigned by Video Cloud when this object is created.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// A Boolean indicating whether or not this CaptionSource is hosted on a remote server, as opposed to hosted by Brightcove.
        /// </summary>
        public bool IsRemote { get; set; }

        /// <summary>
        /// The complete path to the file.
        /// </summary>
        public string Url { get; set; }

        public IDictionary<string, object> Serialize(JavaScriptSerializer serializer)
        {
            IDictionary<string, object> serialized = new Dictionary<string, object>();

            serialized["complete"] = Complete;
            serialized["displayName"] = DisplayName;
            serialized["isRemote"] = IsRemote;
            serialized["url"] = Url;

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
                    case "complete":
                        Complete = Convert.ToBoolean(dictionary[key]);
                        break;
                    case "displayName":
                        DisplayName = (string) dictionary[key];
                        break;
                    case "isRemote":
                        IsRemote = Convert.ToBoolean(dictionary[key]);
                        break;
                    case "url":
                        Url = (string)dictionary[key];
                        break;

                    default:
                        break;
                }
            }
        }
    }
}