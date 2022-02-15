using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;

namespace WlanLocationDLPPoc
{
    public partial class Form1 : Form
    {
        public byte[] key;
        public byte[] IV;

        private static string sDBFullPath = Application.StartupPath + "\\..\\database\\fingerdb.txt";        
        private static string sKeyFullPath = Application.StartupPath + "\\..\\key\\key.txt";
        private static string sConfigFullPath = Application.StartupPath + "\\config.txt";
        private static string sQuarantineDir = Application.StartupPath + "\\..\\quarantine\\";
        private static string sTempDir = Application.StartupPath + "\\..\\temp\\";
        private static string sDBEncryptFullPath = Application.StartupPath + "\\..\\database\\encryptiondb.txt";

        //Initial Form1, so that Form2 can update Form1 components.
        private string sSignalFrm2 = "";
        public string SignalTextFrm2
        {
            get { return sSignalFrm2; }
            set { sSignalFrm2 = value; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSetPolicy_Click(object sender, EventArgs e)
        {
            if ((txtSSID.Text == "") || (txtFilename.Text == ""))
            {
                MessageBox.Show("Please enter SSID and monitoring location");
            }
            else
            {
                //Step 1
                txtKeyword.Enabled = false;
                txtFilename.Enabled = false;
                txtSSID.Enabled = false;
                ckbCredit.Enabled = false;
                ckbIC.Enabled = false;
                ckbKeyword.Enabled = false;

                //Step 2
                btnSetPolicy.Enabled = false;
                btnCancelPolicy.Enabled = true;
                txtInfo.Text = "Monitoring Started...";

                //timer
                tmrMonitor.Enabled = true;          

            };

        }
        private void btnCancelPolicy_Click(object sender, EventArgs e)
        {

            //Step 1
            txtKeyword.Enabled = true;
            txtFilename.Enabled = true;
            txtSSID.Enabled = true;
            ckbCredit.Enabled = true;
            ckbIC.Enabled = true;
            ckbKeyword.Enabled = true;

            //Step 2
            btnSetPolicy.Enabled = true;
            btnCancelPolicy.Enabled = false;
            txtInfo.Text = "Monitoring Stopped...";
            lblStatus.Text = "";

            //Step 3

            //timer
            tmrMonitor.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line;
            string skey;
            string sIV;

            //Load settings from the configuration file
            try
            {
                if (File.Exists(sConfigFullPath) == true)
                {
                    FileStream aFile = new FileStream(sConfigFullPath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);

                    line = sr.ReadLine();
                    txtFilename.Text = line;

                    sr.Close();
                    aFile.Close();
                    aFile.Dispose();
                }
                else
                {
                    MessageBox.Show("Configuration file missing");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Startup Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //Step 2
            btnCancelPolicy.Enabled = false;
            lblStatus.Text = "";

            //Step 3

            //timer
            tmrMonitor.Interval = 1000;
            tmrMonitor.Enabled = false;

            //Cryptography
            RijndaelManaged myRijndael = new RijndaelManaged();
            
            //Create a new key and initialization vector.
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();

            //Get the key and IV.
            key = myRijndael.Key;
            IV = myRijndael.IV;

            //keep the keys into file
            try
            {
                if (File.Exists(sKeyFullPath) == true)
                {
                    FileStream aFile = new FileStream(sKeyFullPath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);

                    //Read line number 1 - key
                    line = sr.ReadLine(); //key
                    ConvertStringToByte(line, out key);

                    //Read line number 2 - IV
                    line = sr.ReadLine(); //IV
                    ConvertStringToByte(line, out IV);

                    sr.Close();
                    aFile.Close();
                    aFile.Dispose();
                }
                else
                {
                    //Write data onto key database
                    StreamWriter sw1 = File.CreateText(sKeyFullPath);

                    //Get the key and IV.
                    key = myRijndael.Key;
                    IV = myRijndael.IV;

                    //Write line number 1 - key
                    ConvertByteToString(key, out skey);
                    sw1.WriteLine(skey);

                    //Write line number 1 - IV
                    ConvertByteToString(IV, out sIV);
                    sw1.WriteLine(sIV);

                    sw1.Close();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Startup Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public static void ConvertStringToByte(string inString, out byte[] outBytes)
        {
            // string to byte[]
            outBytes = Encoding.Default.GetBytes(inString);
        }

        public static void ConvertByteToString(byte[] inBytes, out string outString)
        {
            // byte[] to string
            outString = Encoding.Default.GetString(inBytes);
        }


        private static void EncryptData(String inName, String outName, byte[] rijnKey, byte[] rijnIV)
        {
            try
            {
                //Create the file streams to handle the input and output files.
                FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                //Create variables to help with read and write.
                byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = fin.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.

                SymmetricAlgorithm rijn = SymmetricAlgorithm.Create(); //Creates the default implementation, which is RijndaelManaged.         
                CryptoStream encStream = new CryptoStream(fout, rijn.CreateEncryptor(rijnKey, rijnIV), CryptoStreamMode.Write);

                //Console.WriteLine("Encrypting...");

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    //Console.WriteLine("{0} bytes processed", rdlen);
                }

                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private static void DecryptData(String inName, String outName, byte[] rijnKey, byte[] rijnIV)
        {
            try
            {
                //Create the file streams to handle the input and output files.            
                FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
                FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
                fout.SetLength(0);

                //Create variables to help with read and write.
                byte[] bin = new byte[100]; //This is intermediate storage for the decryption.
                long rdlen = 0;              //This is the total number of bytes written.
                long totlen = fin.Length;    //This is the total length of the input file.
                int len;                     //This is the number of bytes to be written at a time.

                SymmetricAlgorithm rijn = SymmetricAlgorithm.Create(); //Creates the default implementation, which is RijndaelManaged.         
                CryptoStream decStream = new CryptoStream(fout, rijn.CreateDecryptor(rijnKey, rijnIV), CryptoStreamMode.Write);

                //Console.WriteLine("Decrypting...");

                //Read from the input file, then encrypt and write to the output file.
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    decStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                    //Console.WriteLine("{0} bytes processed", rdlen);
                }

                decStream.Close();
                fout.Close();
                fin.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            string output;
            string line;
            string sWlanConnectionStatus ="";
            string sWlanConnectedSSID = "";
            string sWlanConnectedBSSID = "";
            int iWlanConnectionStatus = 0;
            string sWlanAuthourisedSSID = "";

            sWlanAuthourisedSSID = txtSSID.Text.Trim();
            
            //WLAN Interfaces Status
            Process proc = new Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "netsh";
            proc.StartInfo.Arguments = "wlan show interfaces mode=bssid";
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false; // required for the Redirect setting above Process.Start(proc);
            proc.Start();
            output = proc.StandardOutput.ReadToEnd();
            proc.WaitForExit();

            txtInfo.Text = output;

            StringReader sr = new StringReader(output.ToString());
            line = null;
            

            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("General Failure"))
                {
                    iWlanConnectionStatus = 0;
                    break;
                }
                if (line.StartsWith("    State"))
                {
                    
                    sWlanConnectionStatus = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    if (sWlanConnectionStatus == "connected") iWlanConnectionStatus = 1; 
                    continue;
                }
                if (line.StartsWith("    SSID"))
                {
                    sWlanConnectedSSID = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    continue;
                }
                if (line.StartsWith("    BSSID"))
                {
                    sWlanConnectedBSSID = line.Substring(line.IndexOf(":") + 1).TrimStart(' ').TrimEnd(' ');
                    break;
                }
            }; //While loop

            if (iWlanConnectionStatus == 0)
            {
                lblStatus.Text = "Not connected. Action Taken: Sensitive data will be encrypted.";

                performEncryption();
            }
            else 
            {
                if (sWlanAuthourisedSSID == sWlanConnectedSSID)
                { 
                    lblStatus.Text = "Connected to authourised SSID: " +sWlanConnectedSSID+ " with MAC Address: " +sWlanConnectedBSSID;

                    performDecryption();
                }
                else 
                {
                    lblStatus.Text = "Connected to unauthourised SSID: " + sWlanConnectedSSID + " with MAC Address: " + sWlanConnectedBSSID
                        + ", Action Taken: Sensitive data will be encrypted.";

                    performEncryption();
                };
            };
        }

        private void performEncryption()
        {
            bool bScanStatus = false;
            string sScanStatus = "";
            string sDateTimeNow = "";            

            try
            {
                //Scanning activity start here...
                DirectoryInfo dir = new DirectoryInfo(txtFilename.Text);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    DocSensitiveDataRegexScanning(fi.FullName, out sScanStatus, out bScanStatus);

                    if (bScanStatus == true) //True = File has senstive data
                    {
                        Thread.Sleep(50);
                        sDateTimeNow = Convert.ToString(DateTime.Now.GetHashCode());

                        //Step 2
                        //lblStatus.Text = sScanStatus;

                        //Step 3
                        lbRetrieve.Items.Clear();
                        lbRetrieveHash.Items.Clear();
                        lbRetrieve.Enabled = false;
                        btnRetrieve.Enabled = false;

                        //Perform document encryption on the original source file
                        EncryptData(fi.FullName, fi.FullName + ".enc", key, IV);

                        //Copy encryption file to application temporary folder
                        File.Copy(fi.FullName + ".enc", sTempDir + sDateTimeNow + "." + fi.Name);

                        //Write data onto encryption database - a list that keep the file name of the recent encrypted file
                        if (!File.Exists(sDBEncryptFullPath))
                        {
                            //Write data onto database
                            StreamWriter sw1 = File.CreateText(sDBEncryptFullPath);
                            sw1.WriteLine(fi.FullName);
                            sw1.Close();
                        }
                        else
                        {
                            //Append data onto database
                            StreamWriter sw2 = File.AppendText(sDBEncryptFullPath);
                            sw2.WriteLine(fi.FullName);
                            sw2.Close();
                        }

                        //Delete the original source file
                        File.Delete(fi.FullName);
                    }
                }//foreach

                if (bScanStatus == false) //True = File has senstive data
                {
                    //Step 2
                    //lblStatus.Text = "Scanning completed. No sensitive data found in [" + dir.FullName + "] folder.";
                }
            }
            catch (Exception exp)
            {
                lblStatus.Text = "Error: " + exp.Message;
            }
        }

        private void performDecryption()
        {
            string line;

            try
            {
                if (File.Exists(sDBEncryptFullPath) == true)
                {
                    FileStream aFile = new FileStream(sDBEncryptFullPath, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    line = sr.ReadLine();

                    // Read data in line by line.
                    while (line != null)
                    {
                        if (line != "")
                        {
                            DecryptData(line + ".enc", line, key, IV);
                            File.Delete(line + ".enc");
                        }
                        line = sr.ReadLine();
                    }//while                    

                    sr.Close();
                    aFile.Close();
                    aFile.Dispose();

                    //Step 3
                    lbRetrieve.Items.Clear();
                    lbRetrieveHash.Items.Clear();
                    lbRetrieve.Enabled = false;
                    btnRetrieve.Enabled = false;

                    //Clean temp folder
                    DirectoryInfo dir = new DirectoryInfo(sTempDir);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        File.Delete(fi.FullName);
                    }//foreach

                    //Delete encryption database
                    File.Delete(sDBEncryptFullPath);
                }
            }            
            catch (Exception exp)
            {
                lblStatus.Text = "Error: " + exp.Message;
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtFilename.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)       
        {                        
            //if (MessageBox.Show("Do you want to decrypt the sensitive data?", "Data Decryption", 
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
            //{
            //    DecryptData(txtFilename.Text + ".enc", txtFilename.Text + ".dec", key, IV);
            //}
        }

        private void DocSensitiveDataRegexScanning(string sInFile, out string sScanStatus, out bool bScanStatus)
        {
            //Need using System.Text.RegularExpressions;

            bScanStatus = false;
            sScanStatus = "";

            string sPattern = "";
            string sICNoPattern1 = "";
            string sICNoPattern2 = "";
            string sCreditPattern1 = "";
            bool bDetectStatus = false;
            string sKeywordStatus = "";
            string sICStatus1 = "";
            string sICStatus2 = "";
            string sCreditStatus = "";
            string line;

            sPattern = txtKeyword.Text;
            sICNoPattern1 = @"\d{6}-\d{2}-\d{4}";
            sICNoPattern2 = @"\d{12}";
            sCreditPattern1 = @"\d{16}";

            try
            {
                Thread.Sleep(50); //Fuck ... need this to wait for the disposal of file stream 

                if (File.Exists(sInFile))
                {
                    FileStream aFile = new FileStream(sInFile, FileMode.Open);
                    StreamReader sr = new StreamReader(aFile);
                    line = sr.ReadLine();

                    // Read data in line by line.
                    while (line != null)
                    {
                        if (line != "")
                        {
                            //lbScanning.Items.Add(line);
                            if ((Regex.IsMatch(line, sPattern, RegexOptions.IgnoreCase)) && (ckbKeyword.Checked == true))
                            {
                                sKeywordStatus = " [" + sPattern + "] ";

                                bDetectStatus = true;
                            };

                            if (ckbIC.Checked == true)
                            {
                                Match Mymatch = Regex.Match(line, sICNoPattern1, RegexOptions.None);

                                if (Mymatch.Success)
                                {
                                    sICStatus1 = " [" + Mymatch.Value + "] ";

                                    bDetectStatus = true;
                                }

                            };

                            if (ckbIC.Checked == true)
                            {
                                Match Mymatch = Regex.Match(line, sICNoPattern2, RegexOptions.None);

                                if (Mymatch.Success)
                                {
                                    sICStatus2 = " [" + Mymatch.Value + "] ";

                                    bDetectStatus = true;
                                }
                            };

                            if (ckbCredit.Checked == true)
                            {
                                Match Mymatch = Regex.Match(line, sCreditPattern1, RegexOptions.None);

                                if (Mymatch.Success)
                                {
                                    sCreditStatus = " [" + Mymatch.Value + "] ";

                                    bDetectStatus = true;
                                }
                            };

                            if (bDetectStatus == true)
                            {
                                sScanStatus = "Sensitive data detected: " + sKeywordStatus + sICStatus1 + sICStatus2 + sCreditStatus + "in file [" + sInFile + "]. File will be fingerprint.";
                                bScanStatus = true;
                                break;
                            };
                        }
                        line = sr.ReadLine();
                    }//while

                    sr.Close();
                    aFile.Close();
                    aFile.Dispose();
                }

                return;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error: ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {            
            Form2 frm = new Form2(this);

            frm.Show();

            //Step4
            lbRetrieve.Enabled = false;
            btnRetrieve.Enabled = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (sSignalFrm2 == "Success")
            {
                //Step4
                UpdateRetrieveList();
                lbRetrieve.Enabled = true;
                btnRetrieve.Enabled = true;

                sSignalFrm2 = "";
            }
        }

        private void UpdateRetrieveList()
        {
            string[] saColumn;
            string sFn = "";
            string sTimeHash = "";
            string sFileName = "";
            string sFileExt = "";

            try
            {
                //Scan quarantine folder start here...
                DirectoryInfo dir = new DirectoryInfo(sTempDir);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    sFn = fi.Name;
                    saColumn = sFn.Split('.');
                    sTimeHash = saColumn[0];
                    sFileName = saColumn[1];
                    sFileExt = saColumn[2];

                    lbRetrieveHash.Items.Add(fi.FullName);
                    lbRetrieve.Items.Add(sFileName + "." + sFileExt);
                }//foreach 
            }
            catch (Exception exp)
            {
                lbRetrieve.Items.Add("Error: " + exp.Message);
                return;
            }
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            string sSourceFile = "";
            string sDestFile = "";

            if (lbRetrieve.SelectedIndex != -1)
            {
                saveFileDialog1.FileName = lbRetrieve.Items[lbRetrieve.SelectedIndex].ToString();
                sSourceFile = lbRetrieveHash.Items[lbRetrieve.SelectedIndex].ToString();

                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {
                    sDestFile = saveFileDialog1.FileName;
                    DecryptData(sSourceFile, sDestFile, key, IV);
                }
            }
            else
            {
                MessageBox.Show("Please select a file.");
            }

        }


    }
}
