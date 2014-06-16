using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.Helpers;

namespace Search
{
    public class SmtpUtil
    {
        public const string HTML_HIDE_START = "<!--HIDE_IN_EMAIL-->";
        public const string HTML_HIDE_END = "<!--END_HIDE_IN_EMAIL-->";
        public const string EMAIL_HEADER = "<!--EMAIL_HEADER-->";


        public SmtpUtil()
        {
           
            //WebMail.SmtpServer = "smtp.gmail.com";
            //WebMail.EnableSsl = true;
            //WebMail.SmtpPort = 587;
            //WebMail.UserName = "rbahirathan";
            //WebMail.Password = "#rud_bah#";
            //WebMail.From = "rbahirathan@gmail.com";
            
        }

        public void send(string recipient, string subject, string html, string confirmationURL, string rawurl)
        {
            string reqBaseUri = confirmationURL.Split('?')[0]; //HttpContext.Current.Request.Url.AbsoluteUri;
            string baseUrl = reqBaseUri.Substring(0, reqBaseUri.IndexOf(rawurl));  //HttpContext.Current.Request.RawUrl));
            reqBaseUri = reqBaseUri.Substring(0, reqBaseUri.LastIndexOf("/") + 1);

            MailMessage mail = new MailMessage();
            MailAddress ma = new MailAddress("rbahirathan@gmail.com");
            mail.To.Add(recipient);
            mail.From = ma;
            mail.Subject = subject;
            mail.IsBodyHtml = true;

            HTMLUtil htmlUtil = new HTMLUtil();
            string formattedHTML = RemoveBetween(html);
            AlternateView alternateView = htmlUtil.generateInlineHTML(baseUrl, reqBaseUri, formattedHTML);
            mail.AlternateViews.Add(alternateView);

            SmtpClient smtp = new SmtpClient();
            NetworkCredential SMTPUserInfo = new NetworkCredential("rbahirathan@gmail.com", "#rud_bah#");
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = SMTPUserInfo;
            smtp.EnableSsl =true;
            smtp.Port = 587;
            smtp.Send(mail);


        }


//        public void send(string recipient, string subject, string html, Config config, string cc)
//        {
//            string reqBaseUri = HttpContext.Current.Request.Url.AbsoluteUri;
//            string baseUrl = reqBaseUri.Substring(0, reqBaseUri.IndexOf(HttpContext.Current.Request.RawUrl));
//            reqBaseUri = reqBaseUri.Substring(0, reqBaseUri.LastIndexOf("/") + 1);

//            string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
//                 + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
//				            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
//                 + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
//				            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
//                 + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

//            MailMessage mail = new MailMessage();
//            mail.To.Add(recipient);

//            if (!string.IsNullOrEmpty(cc))
//            {
//                string[] emailAddresses = cc.Split(',');
//                int arrEmails = emailAddresses.Count();

//                for (int i = 0; i <= arrEmails - 1; i++)
//                {
//                    if (Regex.IsMatch(emailAddresses[i].ToString(), MatchEmailPattern))
//                    {
//                        MailAddress ma = new MailAddress(emailAddresses[i].ToString());
//                        mail.CC.Add(ma);
//                    }
//                }
//            }



//            mail.Subject = subject;
//            mail.IsBodyHtml = true;

//            HTMLUtil htmlUtil = new HTMLUtil();
//            AlternateView alternateView = htmlUtil.generateInlineHTML(baseUrl, reqBaseUri, html);
//            mail.AlternateViews.Add(alternateView);

//            SmtpClient smtp = new SmtpClient();
//            mail.From = new MailAddress(config.SmtpMailAddress);
//            NetworkCredential SMTPUserInfo = new NetworkCredential(config.SmtpUsername, config.SmtpPassword);
//            smtp.Host = config.SmtpHost;
//            smtp.UseDefaultCredentials = false;
//            smtp.Credentials = SMTPUserInfo;
//            smtp.EnableSsl = config.SmtpEnableSSL;
//            smtp.Port = config.SmtpPort;
//            smtp.Send(mail);

//        }


        //public static void send(string Recipient, string Subject, string Body, string Sender, string SenderEmail)
        //{
        //    Config Config = new Config();
        //    MailMessage mail = new MailMessage();
        //    mail.To.Add(Recipient);

        //    mail.Subject = Subject;
        //    mail.IsBodyHtml = true;

        //    SmtpClient smtp = new SmtpClient();
        //    mail.From = new MailAddress(SenderEmail);
        //    mail.ReplyTo = new MailAddress(SenderEmail);
        //    mail.Body = Body;
        //    NetworkCredential SMTPUserInfo = new NetworkCredential(Config.SmtpUsername, Config.SmtpPassword);
        //    smtp.Host = Config.SmtpHost;
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = SMTPUserInfo;
        //    smtp.EnableSsl = Config.SmtpEnableSSL;
        //    smtp.Port = Config.SmtpPort;
        //    smtp.Send(mail);
        //}


        public string RemoveBetween(string strSource)
        {
            /*
            string removedStr = strSource;

            while (removedStr.Contains(HTML_HIDE_START))
            {
                removedStr = RemoveBetween(HTML_HIDE_START, HTML_HIDE_END, removedStr, true, true);
            }

            return removedStr;
            */

            string content = strSource;
            string startTag = Regex.Escape("<HIDE_IN_EMAIL>");
            string endTag = Regex.Escape("</HIDE_IN_EMAIL>");
            string pattern = @"<HIDE_IN_EMAIL\b[^>]*>(?:(?>[^<]+)|<(?!HIDE_IN_EMAIL\b[^>]*>))*?</HIDE_IN_EMAIL>";

            content = Regex.Replace(content, @"\s(?!\w)", String.Empty, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, HTML_HIDE_START, startTag, RegexOptions.IgnoreCase);
            content = Regex.Replace(content, HTML_HIDE_END, endTag, RegexOptions.IgnoreCase);
            int contentLength = 0;

            while (content.Contains(startTag) && content.Contains(endTag) && content.Length != contentLength)
            {
                contentLength = content.Length;
                content = Regex.Replace(content, pattern, String.Empty, RegexOptions.IgnoreCase);
            }

            return content;
        }

        public static string RemoveBetween(string strBegin, string strEnd, string strSource, bool removeBegin, bool removeEnd)
        {
            string[] result = GetStringInBetween(strBegin, strEnd, strSource, removeBegin, removeEnd);

            if (result[0] != "")
            {
                return strSource.Replace(result[0], "");
            }
            return strSource;
        }

        public static string[] GetStringInBetween(string strBegin, string strEnd, string strSource, bool includeBegin, bool includeEnd)
        {
            string[] result = { "", "" };
            int iIndexOfBegin = strSource.IndexOf(strBegin);

            if (iIndexOfBegin != -1)
            {
                // include the Begin string if desired 
                if (includeBegin)
                    iIndexOfBegin -= strBegin.Length;
                strSource = strSource.Substring(iIndexOfBegin
                    + strBegin.Length);

                int iEnd = strSource.IndexOf(strEnd);

                if (iEnd != -1)
                {
                    // include the End string if desired 
                    if (includeEnd)
                        iEnd += strEnd.Length;

                    result[0] = strSource.Substring(0, iEnd);
                    // advance beyond this segment 
                    if (iEnd + strEnd.Length < strSource.Length)
                        result[1] = strSource.Substring(iEnd + strEnd.Length);

                }
            }
            else
                // stay where we are 
                result[1] = strSource;

            return result;
        }




        public static string AddEmailHeader(string source, string header, string searchType)
        {
            int iIndexHeader = source.IndexOf(EMAIL_HEADER);

            if (iIndexHeader != -1)
            {
                header = ReplaceEmailHeaderKeys(header, searchType);
                source = source.Replace(EMAIL_HEADER, header);
            }

            return source;
        }


        public static string ReplaceEmailHeaderKeys(string header, string replaceWord)
        {

            int iIndexHeader = header.IndexOf("{SearchType}");

            if (iIndexHeader != -1)
            {
                header = header.Replace("{SearchType}", replaceWord);
            }

            return header;
        }





    }
}
