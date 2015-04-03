using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OmnivoreClassLibrary
{
    /// <summary>
    /// Responsible for navigating around the API, figuring out what options are available - where can we go from here?
    /// </summary>
    public class APINavigator
    {
        public async Task<dynamic> GetRoot()
        {
            // go get the response from the API root address
            HttpResponseMessage response = await APIRequester.MakeAPIGETRequest(AppSettings.RootAddress);

            // pass that to our response handler to handle any HTML codes we want it to handle
            dynamic root = await ResponseHandler.HandleResponseCode(response);

            // find all the links of what I can do here
            List<dynamic> links = GetLinks(root);

            return new System.Dynamic.ExpandoObject(); // todo: take out later once I've handled everything.
        }
        
        public static List<dynamic> GetLinks(dynamic response)
        {
            JObject jObj = (JObject)response;

            List<dynamic> links = new List<dynamic>();

            JToken node = JToken.Parse(response);

            WalkNode(node, n =>
            {
                JToken token = n["_Links"];
                if (token != null)
                {
                    if (token.Type == JTokenType.Array)
                    {
                        JArray tokenArray = (JArray)token;
                        links.AddRange((dynamic)tokenArray);
                    }
                    else if (token.Type == JTokenType.Object)
                    {
                        links.Add((dynamic)token);
                    }
                }
            });

            //// get this level links:
            //JProperty sameLevelLinksProp = jObj.Properties().Where(p => p.Name == "_links").FirstOrDefault();
            //AddPropertiesToArray(links, sameLevelLinksProp);

            //// get embedded resources
            //JProperty embeddedProp = jObj.Properties().Where(p => p.Name == "_embedded").FirstOrDefault();
            //AddPropertiesToArray(links, embeddedProp);

            // now get their links...TODO: need to make this recursive I guess...?  But we don't want to go too deep here...

            return links;
        }

        private static void AddPropertiesToArray(List<dynamic> links, JProperty prop)
        {
            if (prop != null)
            {
                if (prop.Value is JArray)
                {
                    JArray items = (JArray)prop.Value;

                    foreach (JToken item in items)
                    {
                        links.Add((dynamic)item);
                    }
                }
                else if (prop.Value is JToken)
                {
                    links.Add((dynamic)prop.Value);
                }

                foreach (JToken item in prop.Children())
                {
                    //AddPropertiesToArray(links, item);
                }
            }
        }

        static void WalkNode(JToken node, Action<JObject> action)
        {
            if (node.Type == JTokenType.Object)
            {
                action((JObject)node);

                foreach (JProperty child in node.Children<JProperty>())
                {
                    WalkNode(child.Value, action);
                }
            }
            else if (node.Type == JTokenType.Array)
            {
                foreach (JToken child in node.Children())
                {
                    WalkNode(child, action);
                }
            }
        }




    }
}
