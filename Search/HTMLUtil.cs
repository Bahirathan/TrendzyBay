using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Search
{
    public class HTMLUtil
    {
        private static readonly Regex htmlResourcesRx =
        new Regex("<(\\w+)((\\s+(\\w|\\w[\\w-]*\\w)(\\s*=\\s*(?:\".*?\"|'.*?'|[^'\">\\s]+))?)+\\s*|\\s*)[/]*>");


        public static readonly string tempDumpPath = "C:\\cms\\cmsmail\\resdump";
        public static Dictionary<string, string> tagAttrbMap = new Dictionary<string, string>();

        public static Dictionary<string, string> mimeMap = new Dictionary<string, string>();
        public static Dictionary<string, string> mimeRvsMap = new Dictionary<string, string>();

        protected int resourceCount;

        static HTMLUtil()
        {
            tagAttrbMap.Add("img", "src");
            tagAttrbMap.Add("link", "href");
            tagAttrbMap.Add("input", "value");

            mimeMap.Add("aif", "audio/x-aiff");
            mimeMap.Add("aifc", "audio/x-aiff");
            mimeMap.Add("aiff", "audio/x-aiff");
            mimeMap.Add("asf", "video/x-ms-asf");
            mimeMap.Add("asr", "video/x-ms-asf");
            mimeMap.Add("asx", "video/x-ms-asf");
            mimeMap.Add("au", "audio/basic");
            mimeMap.Add("avi", "video/x-msvideo");
            mimeMap.Add("bas", "text/plain");
            mimeMap.Add("bmp", "image/bmp");
            mimeMap.Add("c", "text/plain");
            mimeMap.Add("cmx", "image/x-cmx");
            mimeMap.Add("cod", "image/cis-cod");
            mimeMap.Add("css", "text/css");
            mimeMap.Add("etx", "text/x-setext");
            mimeMap.Add("flr", "x-world/x-vrml");
            mimeMap.Add("gif", "image/gif");
            mimeMap.Add("gtar", "application/x-gtar");
            mimeMap.Add("gz", "application/x-gzip");
            mimeMap.Add("h", "text/plain");
            mimeMap.Add("htc", "text/x-component");
            mimeMap.Add("htm", "text/html");
            mimeMap.Add("html", "text/html");
            mimeMap.Add("htt", "text/webviewhtml");
            mimeMap.Add("ico", "image/x-icon");
            mimeMap.Add("ief", "image/ief");
            mimeMap.Add("jfif", "image/pipeg");
            mimeMap.Add("jpe", "image/jpeg");
            mimeMap.Add("jpeg", "image/jpeg");
            mimeMap.Add("jpg", "image/jpeg");
            mimeMap.Add("js", "application/x-javascript");
            mimeMap.Add("lsf", "video/x-la-asf");
            mimeMap.Add("lsx", "video/x-la-asf");
            mimeMap.Add("m3u", "audio/x-mpegurl");
            mimeMap.Add("mht", "message/rfc822");
            mimeMap.Add("mhtml", "message/rfc822");
            mimeMap.Add("mid", "audio/mid");
            mimeMap.Add("mov", "video/quicktime");
            mimeMap.Add("movie", "video/x-sgi-movie");
            mimeMap.Add("mp2", "video/mpeg");
            mimeMap.Add("mp3", "audio/mpeg");
            mimeMap.Add("mpa", "video/mpeg");
            mimeMap.Add("mpe", "video/mpeg");
            mimeMap.Add("mpeg", "video/mpeg");
            mimeMap.Add("mpg", "video/mpeg");
            mimeMap.Add("mpv2", "video/mpeg");
            mimeMap.Add("nws", "message/rfc822");
            mimeMap.Add("pbm", "image/x-portable-bitmap");
            mimeMap.Add("pgm", "image/x-portable-graymap");
            mimeMap.Add("pnm", "image/x-portable-anymap");
            mimeMap.Add("pot,", "application/vnd.ms-powerpoint");
            mimeMap.Add("ppm", "image/x-portable-pixmap");
            mimeMap.Add("qt", "video/quicktime");
            mimeMap.Add("ra", "audio/x-pn-realaudio");
            mimeMap.Add("ram", "audio/x-pn-realaudio");
            mimeMap.Add("ras", "image/x-cmu-raster");
            mimeMap.Add("rgb", "image/x-rgb");
            mimeMap.Add("rmi", "audio/mid");
            mimeMap.Add("rtx", "text/richtext");
            mimeMap.Add("sct", "text/scriptlet");
            mimeMap.Add("snd", "audio/basic");
            mimeMap.Add("stm", "text/html");
            mimeMap.Add("svg", "image/svg+xml");
            mimeMap.Add("tif", "image/tiff");
            mimeMap.Add("tiff", "image/tiff");
            mimeMap.Add("tsv", "text/tab-separated-values");
            mimeMap.Add("txt", "text/plain");
            mimeMap.Add("uls", "text/iuls");
            mimeMap.Add("vcf", "text/x-vcard");
            mimeMap.Add("vrml", "x-world/x-vrml");
            mimeMap.Add("wav", "audio/x-wav");
            mimeMap.Add("xbm", "image/x-xbitmap");
            mimeMap.Add("xof", "x-world/x-vrml");
            mimeMap.Add("xpm", "image/x-xpixmap");
            mimeMap.Add("xwd", "image/x-xwindowdump");

            mimeRvsMap.Add("audio/basic", "au");
            mimeRvsMap.Add("audio/mid", "mid");
            mimeRvsMap.Add("audio/mpeg", "mp3");
            mimeRvsMap.Add("audio/x-aiff", "aif");
            mimeRvsMap.Add("audio/x-mpegurl", "m3u");
            mimeRvsMap.Add("audio/x-pn-realaudio", "ra");
            mimeRvsMap.Add("audio/x-wav", "wav");
            mimeRvsMap.Add("image/bmp", "bmp");
            mimeRvsMap.Add("image/cis-cod", "cod");
            mimeRvsMap.Add("image/gif", "gif");
            mimeRvsMap.Add("image/ief", "ief");
            mimeRvsMap.Add("image/jpeg", "jpg");
            mimeRvsMap.Add("image/pipeg", "jfif");
            mimeRvsMap.Add("image/svg+xml", "svg");
            mimeRvsMap.Add("image/tiff", "tif");
            mimeRvsMap.Add("image/x-cmu-raster", "ras");
            mimeRvsMap.Add("image/x-cmx", "cmx");
            mimeRvsMap.Add("image/x-icon", "ico");
            mimeRvsMap.Add("image/x-portable-anymap", "pnm");
            mimeRvsMap.Add("image/x-portable-bitmap", "pbm");
            mimeRvsMap.Add("image/x-portable-graymap", "pgm");
            mimeRvsMap.Add("image/x-portable-pixmap", "ppm");
            mimeRvsMap.Add("image/x-rgb", "rgb");
            mimeRvsMap.Add("image/x-xbitmap", "xbm");
            mimeRvsMap.Add("image/x-xpixmap", "xpm");
            mimeRvsMap.Add("image/x-xwindowdump", "xwd");
            mimeRvsMap.Add("message/rfc822", "mht");
            mimeRvsMap.Add("text/css", "css");
            mimeRvsMap.Add("text/h323", "323");
            mimeRvsMap.Add("text/html", "html");
            mimeRvsMap.Add("text/iuls", "uls");
            mimeRvsMap.Add("text/plain", "txt");
            mimeRvsMap.Add("text/richtext", "rtx");
            mimeRvsMap.Add("text/scriptlet", "sct");
            mimeRvsMap.Add("text/tab-separated-values", "tsv");
            mimeRvsMap.Add("text/webviewhtml", "htt");
            mimeRvsMap.Add("text/x-component", "htc");
            mimeRvsMap.Add("text/x-setext", "etx");
            mimeRvsMap.Add("text/x-vcard", "vcf");
            mimeRvsMap.Add("video/mpeg", "mpeg");
            mimeRvsMap.Add("video/quicktime", "mov");
            mimeRvsMap.Add("video/x-la-asf", "lsf");
            mimeRvsMap.Add("video/x-ms-asf", "asf");
            mimeRvsMap.Add("video/x-msvideo", "avi");
            mimeRvsMap.Add("video/x-sgi-movie", "movie");
        }

        /*
                public AlternateView generateInlineHTML(string lcUrl)
                {
                    HttpWebRequest httpReqUrl = (HttpWebRequest)WebRequest.Create(lcUrl);
                    httpReqUrl.Timeout = 10000;     // 10 secs
                    httpReqUrl.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";

                    HttpWebResponse response = (HttpWebResponse)httpReqUrl.GetResponse();
                    Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page

                    StreamReader responseStream = new StreamReader(response.GetResponseStream(), enc);
                    string html = responseStream.ReadToEnd();
                    AlternateView view1 = AlternateView.CreateAlternateViewFromString(html,
                                                                            null,
                                                                            "text/html");
                    view1.BaseUri = new Uri(lcUrl);
                    return view1;
                }
        */

        public AlternateView generateInlineHTML(string lcUrl, string reqBaseUrl, string htmlContent)
        {
            string html;
            if (string.IsNullOrEmpty(htmlContent))
            {
                HttpWebRequest httpReqUrl = (HttpWebRequest)WebRequest.Create(lcUrl);
                httpReqUrl.Timeout = 10000;     // 10 secs
                httpReqUrl.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";

                HttpWebResponse response = (HttpWebResponse)httpReqUrl.GetResponse();
                Encoding enc = Encoding.GetEncoding(1252);  // Windows default Code Page

                StreamReader responseStream = new StreamReader(response.GetResponseStream(), enc);
                html = responseStream.ReadToEnd();
            }
            else
            {
                html = htmlContent;                
            }

            Dictionary<string, string> fNameToCidMap = new Dictionary<string, string>();
            ArrayList linkResList = new ArrayList();

            MatchCollection matches = htmlResourcesRx.Matches(html);
            string cidCmnPart = "cms_notific_";
            for (int i = 0; i < matches.Count; i++)
            {
                Match match = matches[i];
                string tagName = match.Groups[1].Value;
                if (tagAttrbMap.ContainsKey(tagName) &&
                    match.Groups.Count > 5)
                {
                    string atrbName;
                    tagAttrbMap.TryGetValue(tagName, out atrbName);
                    Group grp = match.Groups[4];
                    int index = 0;
                    foreach (Capture capture in grp.Captures)
                    {
                        string resourceUrl = match.Groups[5].Captures[index].Value;
                        if (capture.Value.Equals(atrbName) &&
                            !fNameToCidMap.ContainsKey(resourceUrl) &&
                            resourceUrl.Length > 3)
                        {
                            if (tagName.Equals("input") && atrbName.Equals("value"))
                            {
                                html = html.Replace(resourceUrl, "=\"\"");
                            }
                            else
                            {
                                DownloadedResource dwRes = downloadResource(lcUrl, reqBaseUrl, resourceUrl.Substring(2, resourceUrl.Length - 3));
                                if (dwRes != null)
                                {
                                    string cid = string.Format("{0}{1}", cidCmnPart, resourceCount);
                                  //  string cid = string.Format("{0}",  resourceCount);
                                    LinkedResource attachment = new CMSLinkedResource(dwRes.DownloadedPath);
                                    attachment.ContentId = cid;
                                    attachment.ContentType.MediaType = dwRes.MimeType;
                                    attachment.ContentType.Name = dwRes.FileName;
                                    linkResList.Add(attachment);
                                    html = html.Replace(resourceUrl, string.Format("=\"cid:{0}\"", cid));
                                    fNameToCidMap.Add(resourceUrl, cid);
                                }
                            }
                        }
                        index++;
                    }
                }
            }
            AlternateView view1 = AlternateView.CreateAlternateViewFromString(html,
                                                                                null,
                                                                                "text/html");
            view1.TransferEncoding = TransferEncoding.QuotedPrintable;
            foreach (LinkedResource res in linkResList)
            {
                view1.LinkedResources.Add(res);
            }
            return view1;
        }

        public DownloadedResource downloadResource(string baseUrl, string reqBaseUri, string resourceUrl)
        {
            string url = resourceUrl;
            if (!resourceUrl.StartsWith("http"))
            {
                if (resourceUrl.StartsWith("/"))
                {
                    url = string.Format("{0}{1}", baseUrl, resourceUrl);
                }
                else
                {
                    url = string.Format("{0}{1}", reqBaseUri, resourceUrl);
                }
            }
            else
            {
                if (resourceUrl.StartsWith("https"))
                {
                    return null;
                }
            }
            HttpWebRequest httpReqUrl = (HttpWebRequest)WebRequest.Create(url);
            httpReqUrl.Timeout = 10000;     // 10 secs
            httpReqUrl.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
            try
            {
                HttpWebResponse response = (HttpWebResponse)httpReqUrl.GetResponse();
                string ext;
                string mimeType = response.ContentType;
                mimeRvsMap.TryGetValue(mimeType, out ext);
                string sjExt = Path.GetExtension(resourceUrl);
                string fileName;
                if (!string.IsNullOrEmpty(sjExt))
                {
                    sjExt = sjExt.Substring(1, sjExt.Length - 1);
                    fileName = string.Format("{0}{1}.{2}",
                                  Path.GetFileNameWithoutExtension(resourceUrl),
                                  resourceCount++,
                                  sjExt);

                }
                else
                {
                    fileName = string.Format("{0}{1}.{2}",
                                  "resource",
                                  resourceCount++,
                                  ext);
                }

                if (!Directory.Exists(tempDumpPath))
                {
                    Directory.CreateDirectory(tempDumpPath);
                }

                string filePath = string.Format("{0}{1}{2}", tempDumpPath, Path.DirectorySeparatorChar, fileName);
                FileStream fout = File.Create(filePath);
                Stream resStream = response.GetResponseStream();
                int n;
                byte[] bytes = new byte[1024];
                while ((n = resStream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    fout.Write(bytes, 0, n);
                }
                fout.Close();
                response.Close();
                return new DownloadedResource(filePath, fileName, mimeType);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class CMSLinkedResource : LinkedResource
    {
        private string path;
        public CMSLinkedResource(string fileName)
            : base(fileName)
        {
            path = fileName;
        }

        public CMSLinkedResource(string fileName, string mediaType)
            : base(fileName, mediaType)
        {
            path = fileName;
        }

        public CMSLinkedResource(string fileName, ContentType contentType)
            : base(fileName, contentType)
        {
            path = fileName;
        }

        public CMSLinkedResource(Stream contentStream)
            : base(contentStream)
        {
        }

        public CMSLinkedResource(Stream contentStream, string mediaType)
            : base(contentStream, mediaType)
        {
        }

        public CMSLinkedResource(Stream contentStream, ContentType contentType)
            : base(contentStream, contentType)
        {
        }

        public void Close()
        {
            ContentStream.Close();
            if (path != null)
            {
                File.Delete(path);
            }
        }
    }

    public class DownloadedResource
    {
        private string downloadedPath;
        private string fileName;
        private string mimeType;

        public DownloadedResource(string downloadedPath, string fileName, string mimeType)
        {
            this.downloadedPath = downloadedPath;
            this.fileName = fileName;
            this.mimeType = mimeType;
        }

        public string MimeType
        {
            get { return mimeType; }
            set { mimeType = value; }
        }

        public string DownloadedPath
        {
            get { return downloadedPath; }
            set { downloadedPath = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
    }
}
