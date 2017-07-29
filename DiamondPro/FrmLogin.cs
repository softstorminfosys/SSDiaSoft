using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DiamondPro.BLL.Function_Class;
using DiamondPro.DLL;
using System.Management;
using System.Security.Cryptography;
using DiamondPro.DLL;

namespace DiamondPro
{
    public partial class FrmLogin : Form
    {
        DataTable dtDetail = new DataTable();

        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion
            
        #region Main Event
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //identifier();
        }
        #endregion

        #region Click Event
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text.Length <= 0)
                {
                    XtraMessageBox.Show("Please Provide UserName","LogIn Validation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtUserName.Focus();                    
                    return;
                }

                if (txtPassword.Text.Length <= 0)
                {                    
                    XtraMessageBox.Show("Please Provide Password","LogIn Validation",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    txtPassword.Focus();
                    return;
                }

                dtDetail = new Login_Function().GetUserDetail(txtUserName.Text,txtPassword.Text);

                if (dtDetail.Rows.Count == 1)
                {                    
                    //MDIParent1 frm = new MDIParent1();
                    //frm.ShowDialog();
                    Type t = Type.GetType(Operation.MDI);
                    Form c = Activator.CreateInstance(t) as Form;
                    this.Hide();
                    c.Show();
                }
                else
                {
                    XtraMessageBox.Show("User is not valid...!!!","Log In",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Log In Click",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region KeyDown Event
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message,"Log In",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "UserName KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{Tab}");
                    BtnLogin.Focus();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Password KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion              

        #region Function
        private string parseSerialFromDeviceID(string deviceId)
        {
            string[] splitDeviceId = deviceId.Split('\\');
            string[] serialArray;
            string serial;
            int arrayLen = splitDeviceId.Length - 1;

            serialArray = splitDeviceId[arrayLen].Split('&');
            serial = serialArray[0];

            return serial;
        }

        public static string EncryptString(string Message, string Passphrase)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        private void identifier()
        {
            try
            {
                //GetNistTime();
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive where InterfaceType !='USB'");
                foreach (ManagementObject currentObject in theSearcher.Get())
                {
                    String srno = parseSerialFromDeviceID(currentObject["SerialNumber"].ToString());
                    String srnomy = System.Configuration.ConfigurationManager.AppSettings.GetValues("my")[0];
                    if (EncryptString(srno, "Zxcv@1989#") != srnomy)
                    {
                        MessageBox.Show("Unauthenticate Hardware.", "ERROR");
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }    
        #endregion

    }
}
