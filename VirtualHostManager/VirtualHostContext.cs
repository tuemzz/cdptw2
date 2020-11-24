using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VirtualHostManager.Models;

namespace VirtualHostManager
{
    class VirtualHostContext
    {
        //private string filePath = @"C:\wamp64\bin\apache\apache2.4.39\conf\extra\httpd-vhosts.conf";
        private string filePath = @"C:\xampp\apache\conf\extra\httpd-vhosts.conf";
        public List<VirtualHost> data { get; set; }
        public VirtualHostContext()
        {
            string[] stringSeparators = new string[] { "\r\n" };
            Regex regex = new Regex(@"#*\s*<\s*VirtualHost[^>]*>(.*?)<\s*\/\s*VirtualHost>", RegexOptions.Singleline);
            var rawData = regex.Matches(File.ReadAllText(filePath))
                                .Cast<Match>()
                                .Select(m => m.Value)
                                .ToList();
            data = rawData.Select(x => 
                                        {
                                            var status = !x.StartsWith("#");
                                            var directoryConfig = Regex.Replace(Regex.Match(x, @"<\s*Directory[^>]*>(.*?)<\s*\/\s*Directory>", RegexOptions.Singleline).Value, @"<\s*Directory[^>]*>(.*?)(\r\n)?|<\s*\/\s*Directory>(.*?)(\r\n)?", "");
                                        
                                            if (!status)
                                            {
                                                directoryConfig = directoryConfig.Replace("#", "");
                                            }
                                            return new VirtualHost()
                                            {
                                                Port = Regex.Match(x, @"<VirtualHost.*?:.*?>").Value.Split(':').Last().Trim().Trim('>'),
                                                DirectoryConfig = directoryConfig,
                                                Directory = Regex.Match(x, @"<\s*Directory[^>]*>").Value.Split('"').ElementAtOrDefault(1),
                                                ServerName = Regex.Match(x, @"ServerName(.*?)\r\n", RegexOptions.Singleline).Value.Replace("ServerName", "").Replace("\r\n", "").Trim(),
                                                Status = status
                                            };
                                        }).ToList();
        }
        
        public void SaveChanges()
        {
            StringBuilder context = new StringBuilder();
            context.Append("# Virtual Hosts" + System.Environment.NewLine);
            context.Append("#" + System.Environment.NewLine);
            data.ForEach(x =>
            {
                var Prefix = x.Status ? "" : "##";
                var subContext = new StringBuilder();
                subContext.AppendFormat("<VirtualHost *:{0}>" + System.Environment.NewLine, x.Port);
                subContext.AppendFormat("ServerName  {0}" + System.Environment.NewLine, x.ServerName);
                subContext.AppendFormat("ServerAlias {0}" + System.Environment.NewLine, x.ServerName);
                subContext.AppendFormat("DocumentRoot \"{0}\"" + System.Environment.NewLine, x.Directory);
                subContext.AppendFormat("<Directory \"{0}\">" + System.Environment.NewLine, x.Directory);
                subContext.Append(x.DirectoryConfig + System.Environment.NewLine);
                subContext.AppendFormat("</Directory>" + System.Environment.NewLine);
                subContext.AppendFormat("</VirtualHost>");

                var result = subContext.ToString();
                if (!x.Status)
                {
                    result = string.Join(System.Environment.NewLine, result.Split(new[] { System.Environment.NewLine }, StringSplitOptions.None).Select(xx => Prefix + xx));
                }
                result += System.Environment.NewLine;
                context.Append(result);
            });
            File.WriteAllText(filePath, context.ToString());
        }
    }
}
