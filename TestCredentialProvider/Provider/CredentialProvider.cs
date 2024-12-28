using CredentialProvider.Interop;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using TestCredentialProvider.Native;
using TestCredentialProvider.Tile;

namespace TestCredentialProvider.Provider
{
    [ComVisible(true)]
    [Guid("8541b5d0-6200-462b-90fb-f20ba9bf0923")]
    [ProgId("CanoWARProvider_Passwordless")]
    [ClassInterface(ClassInterfaceType.None)]
    public class CredentialProvider : ICredentialProvider
    {
        private readonly ICredentialProvider originalCredentialProvider;

        public ICredentialProviderEvents credentialProviderEvents;

        public CredentialProvider()
        {
            var clsidPasswordCredentialProvider = new Guid("D6886603-9D2F-4EB2-B667-1971041FA96B");

            try
            {
                Type comType = Type.GetTypeFromCLSID(clsidPasswordCredentialProvider);
                originalCredentialProvider = (ICredentialProvider)Activator.CreateInstance(comType);

                WriteLog("Provider created");
            }
            catch (Exception ex)
            {
                WriteLog(ex);
            }
        }

        public virtual int SetUsageScenario(_CREDENTIAL_PROVIDER_USAGE_SCENARIO cpus, uint dwFlags)
        {
            originalCredentialProvider.SetUsageScenario(cpus, dwFlags);

            switch (cpus)
            {
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_LOGON:
                case _CREDENTIAL_PROVIDER_USAGE_SCENARIO.CPUS_UNLOCK_WORKSTATION:
                    return HResult.Ok;
                default:
                    return HResult.InvalidArg;
            }
        }

        public virtual int SetSerialization(ref _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs)
        {
            return originalCredentialProvider.SetSerialization(ref pcpcs);
        }

        public virtual int Advise(ICredentialProviderEvents pcpe, ulong upAdviseContext)
        {
            WriteLog("Advise Called!!!");

            return originalCredentialProvider.Advise(pcpe, upAdviseContext);
        }

        public virtual int UnAdvise()
        {
            return originalCredentialProvider.UnAdvise();
        }

        public virtual int GetFieldDescriptorCount(out uint pdwCount)
        {
            return originalCredentialProvider.GetFieldDescriptorCount(out pdwCount);
        }

        public virtual int GetFieldDescriptorAt(uint dwIndex, [Out] IntPtr ppcpfd)
        {
            return originalCredentialProvider.GetFieldDescriptorAt(dwIndex, ppcpfd);
        }

        public virtual int GetCredentialCount(out uint pdwCount, out uint pdwDefault, out int pbAutoLogonWithDefault)
        {
            var result = originalCredentialProvider.GetCredentialCount(out pdwCount, out pdwDefault, out pbAutoLogonWithDefault);

            WriteLog(pdwCount);

            return result;
        }

        public virtual int GetCredentialAt(uint dwIndex, out ICredentialProviderCredential ppcpc)
        {
            //I cannot make it happen in this section, what should i do here?

            var result = originalCredentialProvider.GetCredentialAt(dwIndex, out ppcpc);

            var myTile = new CredentialTile(ppcpc);

            ppcpc = myTile;

            return result;
        }

        private void WriteLog(object log)
        {
            try
            {
                EventLog.WriteEntry("Application", log.ToString());
            }
            catch
            { }
        }
    }
}
