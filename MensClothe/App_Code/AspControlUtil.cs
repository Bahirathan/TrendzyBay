using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for AspControlUtil
/// </summary>
   public class AspControlUtil
    {
        public static Control FindControlRecursive(Control root, string id)
        {
            if (root.ID == id)
            {
                return root;
            }

            foreach (Control c in root.Controls)
            {
                Control t = FindControlRecursive(c, id);
                if (t != null)
                {
                    return t;
                }
            }

            return null;
        }

        public static string getAppPath()
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;
            if (!appPath.Trim().Equals("/"))
            {
                appPath = appPath + "/";
            }
            return appPath;
        }

        public static string GetAbsoluteAppPath()
        {
            return HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, getAppPath());
        }

        public static string getFullImagePath(string imageName)
        {
            return string.Format("{0}Images/{1}", getAppPath(), imageName);
        }

        public static string getFullFlashPath(string flashName)
        {
            return string.Format("{0}flash/{1}", getAppPath(), flashName);
        }

        public static string getFullAirLineImgPath(string airLineOperator)
        {
            return string.Format("{0}images/al/{1}.gif", getAppPath(), airLineOperator);
        }

        public static string getFullCarSupplierImgPath(string suppliercode)
        {
            return string.Format("{0}images/CarSupplier/{1}.gif", getAppPath(), suppliercode);
        }

        public static bool DoesImageExistRemotely(string urlToImage)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlToImage);
            request.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.Method = "HEAD";

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string[] SplitByString(string testString, string split)
        {
            int offset = 0;
            int index = 0;
            int[] offsets = new int[testString.Length + 1];

            while (index < testString.Length)
            {
                int indexOf = testString.IndexOf(split, index);
                if (indexOf != -1)
                {
                    offsets[offset++] = indexOf;
                    index = (indexOf + split.Length);
                }
                else
                {
                    index = testString.Length;
                }
            }

            string[] final = new string[offset + 1];
            if (offset == 0)
            {
                final[0] = testString;
            }
            else
            {
                offset--;
                final[0] = testString.Substring(0, offsets[0]);
                for (int i = 0; i < offset; i++)
                {
                    final[i + 1] = testString.Substring(offsets[i] + split.Length, offsets[i + 1] - offsets[i] - split.Length);
                }
                final[offset + 1] = testString.Substring(offsets[offset] + split.Length);
            }
            return final;
        }

        public static string getHttpsUrl(HttpRequest request, string pageName, bool isSecured)
        {
            string baseUrlComponent = null;
            if (isSecured)
            {
                if (request.Url.ToString().StartsWith("https"))
                {
                    baseUrlComponent = request.Url.ToString();
                }
                else
                {
                    baseUrlComponent = request.Url.ToString().Replace("http://", "https://");
                }
            }
            else
            {
                if (request.Url.ToString().StartsWith("https"))
                {
                    baseUrlComponent = request.Url.ToString().Replace("https://", "http://");
                }
                else
                {
                    baseUrlComponent = request.Url.ToString();
                }
            }

            string[] splitted = baseUrlComponent.Split(new char[] { '/', '\\' });
            string lastSection = splitted[splitted.Length - 1];

            //for web method calls
            if (!lastSection.Contains(".aspx"))
            {
                lastSection = splitted[splitted.Length - 2];
            }

            int lastLocation = baseUrlComponent.LastIndexOf(lastSection);
            return baseUrlComponent.Substring(0, lastLocation) + pageName;
        }


        public static string getHttpsUrl2(HttpRequest request, string pageName, bool isSecured)
        {
            string baseUrlComponent = null;
            if (isSecured)
            {
                if (request.Url.ToString().StartsWith("https"))
                {
                    baseUrlComponent = request.Url.ToString();
                }
                else
                {
                    baseUrlComponent = request.Url.ToString().Replace("http://", "https://");
                }
            }
            else
            {
                if (request.Url.ToString().StartsWith("https"))
                {
                    baseUrlComponent = request.Url.ToString().Replace("https://", "http://");
                }
                else
                {
                    baseUrlComponent = request.Url.ToString();
                }
            }

            string[] splitted = baseUrlComponent.Split(new char[] { '/', '\\' });
            string lastSection = splitted[splitted.Length - 1];

            //for web method calls
            if (!lastSection.Contains(".aspx"))
            {
                lastSection = splitted[splitted.Length - 2];
            }

            int lastLocation = baseUrlComponent.LastIndexOf(lastSection);
            return pageName;
        }

        public static void SetHistoryPageName(string pageName)
        {
            HttpCookie h = HttpContext.Current.Request.Cookies["history"];
            if (h == null)
                h = new HttpCookie("history");
            h.Value = pageName;
            h.Expires = DateTime.Now.AddMinutes(5d);

            HttpContext.Current.Response.Cookies.Add(h);
        }
        public static string RemoveHistoryPageName()
        {
            HttpCookie h = HttpContext.Current.Request.Cookies["history"];
            if (h != null)
            {
                h.Expires = DateTime.Now.AddMinutes(-5d);
                HttpContext.Current.Response.Cookies.Add(h);
            }

            return "Removed";
        }

        public static string formatPrice(double price)
        {
            price = Math.Round(price * (double)HttpContext.Current.Application["exRate"], 2);


            return (string)HttpContext.Current.Application["curSym"] + (String.Format("{0:#,##0.00;(#,##0.00);0.00}", price)).Replace("(", "-").Replace(")", "");
        }



   }
