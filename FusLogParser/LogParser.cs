using System;
using System.Linq;
using System.Text;

namespace FusLogParser
{
    public class LogParser
    {
        private readonly string[] _logFile;

        public LogParser(string[] logFile)
        {
            _logFile = logFile;
        }

        private const string BindResultPrefix = "Bind result: ";
        private const string ExecutablePrefix = "Running under executable  ";
        private const string DisplayNamePrefix = "LOG: DisplayName = ";
        private const string WhereRefBindPrefix = "LOG: Where-ref bind. Location = ";
        private const string AppBasePrefix = "LOG: Appbase = ";
        private const string CallingAssemblyPrefix = "Calling assembly : ";
        private const string AppConfigPrefix = "LOG: Using application configuration file: ";
        private const string PostPolicyReferencePrefix = "LOG: Post-policy reference: ";
        private const string SuccessfulDownloadPrefix = "LOG: Assembly download was successful. Attempting setup of file: ";
        private const string AssemblyNameFullPrefix = "LOG: Assembly Name is: ";
        private const string NameMismatchPrefix = "WRN: Comparing the assembly name resulted in the mismatch: ";

        private string Extract(string line, string prefix)
        {
            return line.Substring(prefix.Length);
        }

        private string SimplifyAssemblyName(string name)
        {
            if (!name.Contains(','))
            {
                AssemblyName = name;
                return name;
            }

            try
            {
                // Newtonsoft.Json, Version=9.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed
                var parts = name.Split(',');
                var versionParts = parts[1].Split('=');
                var pkt = parts[3].Split('=');
                AssemblyToken = pkt[1].Trim('.');
                AssemblyVersion = versionParts[1].Trim();
                AssemblyName = parts[0].Trim();
                var newName = $"{AssemblyName} v{AssemblyVersion} ({AssemblyToken})";
                return newName;
            }
            catch (Exception)
            {
                return name;
            }
        }

        private string LocationToAssemblyName(string location)
        {
            var pathParts = location.Split('/');
            var name = pathParts[pathParts.Length - 1];
            AssemblyName = name;
            return name;
        }

        public string Summary { get; private set; }
        public string BindResult { get; private set; }
        public string Executable { get; private set; }
        public string DisplayName { get; private set; }
        public string AppBase { get; private set; }
        public string CallingAssembly { get; private set; }
        public string AppConfig { get; private set; }
        public string PostPolicyReference { get; private set; }
        public string SuccessfulDownload { get; private set; }
        public string AssemblyNameFull { get; private set; }
        private string AssemblyName { get; set; }
        private string AssemblyVersion { get; set; }
        private string AssemblyToken { get; set; }
        public string NameMismatch { get; private set; }

        public string DisplayAssemblyName { get; private set; }
        public string DisplayAssemblyVersion { get; private set; }
        public string DisplayAssemblyToken { get; private set; }

        public string CallingAssemblyName { get; private set; }
        public string CallingAssemblyVersion { get; private set; }
        public string CallingAssemblyToken { get; private set; }

        public void Parse()
        {
            foreach (var line in _logFile)
            {
                if (line.StartsWith(ExecutablePrefix)) Executable = Extract(line, ExecutablePrefix);
                else if (line.StartsWith(BindResultPrefix)) BindResult = GetBindResultText(Extract(line, BindResultPrefix));
                else if (line.StartsWith(DisplayNamePrefix))
                {
                    DisplayName = SimplifyAssemblyName(Extract(line, DisplayNamePrefix));
                    DisplayAssemblyName = AssemblyName;
                    DisplayAssemblyVersion = AssemblyVersion;
                    DisplayAssemblyToken = AssemblyToken;
                }
                else if (line.StartsWith(WhereRefBindPrefix)) DisplayName = LocationToAssemblyName(Extract(line, WhereRefBindPrefix));
                else if (line.StartsWith(AppBasePrefix)) AppBase = Extract(line, AppBasePrefix);
                else if (line.StartsWith(CallingAssemblyPrefix))
                {
                    CallingAssembly = SimplifyAssemblyName(Extract(line, CallingAssemblyPrefix));
                    CallingAssemblyName = AssemblyName;
                    CallingAssemblyVersion = AssemblyVersion;
                    CallingAssemblyToken = AssemblyToken;
                }
                else if (line.StartsWith(AppConfigPrefix)) AppConfig = Extract(line, AppConfigPrefix);
                else if (line.StartsWith(PostPolicyReferencePrefix))
                {
                    PostPolicyReference = SimplifyAssemblyName(Extract(line, PostPolicyReferencePrefix));
                }
                else if (line.StartsWith(SuccessfulDownloadPrefix)) SuccessfulDownload = Extract(line, SuccessfulDownloadPrefix);
                else if (line.StartsWith(AssemblyNameFullPrefix))
                {
                    AssemblyNameFull = SimplifyAssemblyName(Extract(line, AssemblyNameFullPrefix));
                }
                else if (line.StartsWith(NameMismatchPrefix)) NameMismatch = Extract(line, NameMismatchPrefix);
            }

            if (AssemblyName == null || AssemblyName == "(Unknown).") AssemblyName = DisplayName;

            switch (BindResult)
            {
                case "The system cannot find the file specified":
                    Summary = $"Can't find assembly ===>> {AssemblyName} <<=== in any of the expected locations. {Environment.NewLine}Recommendation: locate the assembly and copy it manually.";
                    break;
                case "No description available":
                    Summary = $"Found a different version of ===>> {AssemblyName} <<=== than expected. {Environment.NewLine}Recommendation: Either (1) Replace the assembly with the expected version, or (2) If multiple versions are being requested by different executables, add the specified bindingRedirect section to the specified app.config.";
                    break;
                default:
                    Summary = "No summary available";
                    break;
            }
        }

        public string GetBindingRedirect()
        {
            var sb = new StringBuilder();
            sb.AppendLine("      <dependentAssembly>");
            sb.AppendLine($"        <assemblyIdentity name=\"{AssemblyName}\" publicKeyToken=\"{AssemblyToken}\" culture=\"neutral\"/>");
            sb.AppendLine($"        <bindingRedirect oldVersion=\"0.0.0.0-{AssemblyVersion}\" newVersion=\"{AssemblyVersion}\"/>");
            sb.AppendLine("      </dependentAssembly>");

            return sb.ToString();
        }

        private string GetBindResultText(string bindResult)
        {
            var bindResultParts = bindResult.Split('.');
            return bindResultParts[1].Trim();
        }

        public string GetCopyCommand(string txtAssemblyLocation)
        {
            var e = Executable;
            var eParts = e.Split('\\');
            var sb = new StringBuilder();
            for (var i = 0; i < eParts.Length - 1; i++) sb.Append(eParts[i] + "\\");
            return $"copy /y \"{txtAssemblyLocation}\\{AssemblyName}.dll\" \"{sb}\"";
        }
    }
}
