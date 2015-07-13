﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SonarQube.Bootstrapper {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SonarQube.Bootstrapper.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to begin - perform pre-MSBuild analysis steps.
        /// </summary>
        public static string CmdLine_ArgDescription_Begin {
            get {
                return ResourceManager.GetString("CmdLine_ArgDescription_Begin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to end - perform post-MSBuild/post-test steps.
        /// </summary>
        public static string CmdLine_ArgDescription_End {
            get {
                return ResourceManager.GetString("CmdLine_ArgDescription_End", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The SonarQube URL must be supplied. The URL can be specified in a settings file or on the command line (e.g. using /d:sonar.host.url=http://myserver:9000)..
        /// </summary>
        public static string ERROR_Args_UrlRequired {
            get {
                return ResourceManager.GetString("ERROR_Args_UrlRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid command line parameters. Please specify either &apos;begin&apos; or &apos;end&apos;, not both..
        /// </summary>
        public static string ERROR_CmdLine_BothBeginAndEndSupplied {
            get {
                return ResourceManager.GetString("ERROR_CmdLine_BothBeginAndEndSupplied", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to update the SonarQube MSBuild Runner binaries. Check the server url, verify that the C# plugin is correctly installed on the SonarQube server and that the SonarQube server has been restarted..
        /// </summary>
        public static string ERROR_FailedToUpdateRunnerBinaries {
            get {
                return ResourceManager.GetString("ERROR_FailedToUpdateRunnerBinaries", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} failed. Exit code: {1}.
        /// </summary>
        public static string ERROR_ProcessingFailed {
            get {
                return ResourceManager.GetString("ERROR_ProcessingFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The C# plugin installed on the server is not compatible with the SonarQube.MSBuild.Runner.exe - either check the compatibility matrix or get the latest versions for both. .
        /// </summary>
        public static string ERROR_VersionMismatch {
            get {
                return ResourceManager.GetString("ERROR_VersionMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Downloading {0} from {1} to {2}.
        /// </summary>
        public static string INFO_Downloading {
            get {
                return ResourceManager.GetString("INFO_Downloading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Installed {0} to {1}.
        /// </summary>
        internal static string INFO_InstallTargets_Copy {
            get {
                return ResourceManager.GetString("INFO_InstallTargets_Copy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file {0} was overwritten at {1}.
        /// </summary>
        internal static string INFO_InstallTargets_Overwrite {
            get {
                return ResourceManager.GetString("INFO_InstallTargets_Overwrite", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file {0} is up to date at {1}.
        /// </summary>
        internal static string INFO_InstallTargets_UpToDate {
            get {
                return ResourceManager.GetString("INFO_InstallTargets_UpToDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} started..
        /// </summary>
        public static string INFO_ProcessingStarted {
            get {
                return ResourceManager.GetString("INFO_ProcessingStarted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} succeeded..
        /// </summary>
        public static string INFO_ProcessingSucceeded {
            get {
                return ResourceManager.GetString("INFO_ProcessingSucceeded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SonarQube server url: {0}.
        /// </summary>
        public static string INFO_ServerUrl {
            get {
                return ResourceManager.GetString("INFO_ServerUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Using environment variable &apos;{0}&apos;, value &apos;{1}&apos;.
        /// </summary>
        public static string INFO_UsingBuildEnvironmentVariable {
            get {
                return ResourceManager.GetString("INFO_UsingBuildEnvironmentVariable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Using environment variables to determine the download directory....
        /// </summary>
        public static string INFO_UsingEnvVarToGetDirectory {
            get {
                return ResourceManager.GetString("INFO_UsingEnvVarToGetDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Post-processing.
        /// </summary>
        public static string PhaseLabel_PostProcessing {
            get {
                return ResourceManager.GetString("PhaseLabel_PostProcessing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pre-processing.
        /// </summary>
        public static string PhaseLabel_PreProcessing {
            get {
                return ResourceManager.GetString("PhaseLabel_PreProcessing", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Please specify the command &apos;begin&apos; or &apos;end&apos; to indicate whether pre- or post-processing is required. These parameters will become mandatory in a later release..
        /// </summary>
        public static string WARN_CmdLine_v09_Compat {
            get {
                return ResourceManager.GetString("WARN_CmdLine_v09_Compat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This version of the bootstrapper automatically deploys {0}, however a copy has been found in {1}. Please remove it if it is not intentional..
        /// </summary>
        internal static string WARN_ExistingGlobalTargets {
            get {
                return ResourceManager.GetString("WARN_ExistingGlobalTargets", resourceCulture);
            }
        }
    }
}
