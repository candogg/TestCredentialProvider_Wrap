using CredentialProvider.Interop;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TestCredentialProvider.Forms;

namespace TestCredentialProvider.Tile
{
    [ComVisible(true)]
    [Guid("6ecbe7b0-f277-480c-bb93-7eb42865d38a")]
    [ClassInterface(ClassInterfaceType.None)]
    /// <summary>
    /// Author: Can DOĞU
    /// </summary>
    public sealed class CredentialTile : ICredentialProviderCredential
    {
        private ICredentialProviderCredentialEvents2 credentialProviderCredentialEvents;
        private FrmTest otpForm;
        private readonly ICredentialProviderCredential originalTile;

        public CredentialTile(ICredentialProviderCredential originalTile)
        {
            this.originalTile = originalTile;
        }

        public int GetSerialization(out _CREDENTIAL_PROVIDER_GET_SERIALIZATION_RESPONSE pcpgsr, out _CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION pcpcs, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            ShowOtpForm();

            return originalTile.GetSerialization(out pcpgsr, out pcpcs, out ppszOptionalStatusText, out pcpsiOptionalStatusIcon);
        }

        public int Advise(ICredentialProviderCredentialEvents pcpce)
        {
            return originalTile.Advise(pcpce);
        }

        public int UnAdvise()
        {
            return originalTile.UnAdvise();
        }

        public int SetSelected(out int pbAutoLogon)
        {
            return originalTile.SetSelected(out pbAutoLogon);
        }

        public int SetDeselected()
        {
            return originalTile.SetDeselected();
        }

        public int GetFieldState(uint dwFieldID, out _CREDENTIAL_PROVIDER_FIELD_STATE pcpfs, out _CREDENTIAL_PROVIDER_FIELD_INTERACTIVE_STATE pcpfis)
        {
            return originalTile.GetFieldState(dwFieldID, out pcpfs, out pcpfis);
        }

        public int GetStringValue(uint dwFieldID, out string ppsz)
        {
            return originalTile.GetStringValue(dwFieldID, out ppsz);
        }

        public int GetBitmapValue(uint dwFieldID, out IntPtr phbmp)
        {
            return originalTile.GetBitmapValue(dwFieldID, out phbmp);
        }

        public int GetCheckboxValue(uint dwFieldID, out int pbChecked, out string ppszLabel)
        {
            return originalTile.GetCheckboxValue(dwFieldID, out pbChecked, out ppszLabel);
        }

        public int GetSubmitButtonValue(uint dwFieldID, out uint pdwAdjacentTo)
        {
            return originalTile.GetSubmitButtonValue(dwFieldID, out pdwAdjacentTo);
        }

        public int GetComboBoxValueCount(uint dwFieldID, out uint pcItems, out uint pdwSelectedItem)
        {
            return originalTile.GetComboBoxValueCount(dwFieldID, out pcItems, out pdwSelectedItem);
        }

        public int GetComboBoxValueAt(uint dwFieldID, uint dwItem, out string ppszItem)
        {
            return originalTile.GetComboBoxValueAt(dwFieldID, dwItem, out ppszItem);
        }

        public int SetStringValue(uint dwFieldID, string psz)
        {
            return originalTile.SetStringValue(dwFieldID, psz);
        }

        public int SetCheckboxValue(uint dwFieldID, int bChecked)
        {
            return originalTile.SetCheckboxValue(dwFieldID, bChecked);
        }

        public int SetComboBoxSelectedValue(uint dwFieldID, uint dwSelectedItem)
        {
            return originalTile.SetComboBoxSelectedValue(dwFieldID, dwSelectedItem);
        }

        public int ReportResult(int ntsStatus, int ntsSubstatus, out string ppszOptionalStatusText, out _CREDENTIAL_PROVIDER_STATUS_ICON pcpsiOptionalStatusIcon)
        {
            return originalTile.ReportResult(ntsStatus, ntsSubstatus, out ppszOptionalStatusText, out pcpsiOptionalStatusIcon);
        }

        public int CommandLinkClicked(uint dwFieldID)
        {
            return originalTile.CommandLinkClicked(dwFieldID);
        }

        private void ShowOtpForm()
        {
            credentialProviderCredentialEvents.OnCreatingWindow(out IntPtr phwndOwner);

            var nWindow = new NativeWindow();

            nWindow.AssignHandle(phwndOwner);

            otpForm = new FrmTest();

            otpForm.ShowDialog(nWindow);
            otpForm = null;
        }
    }
}
