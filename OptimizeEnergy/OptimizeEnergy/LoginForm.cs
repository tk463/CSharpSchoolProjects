using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Xml.Serialization;
using EnergyLib;

namespace OptimizeEnergy
{
    public partial class LoginForm : Form
    {
        public User adminUser { get; set; }
        public User currentUser { get; set; }
        public String pathUser { get; set; }
        public BindingList<User> userList { get; set; }

        public LoginForm()
        {
            InitializeComponent();
            CenterToParent();
            currentUser = new User();
            getAdmin();
            pathUser = Directory.GetCurrentDirectory();
            fillUserList();
        }
        public void getAdmin()
        {
            //get key Reg
            const string keyName = "HKEY_CURRENT_USER\\Software\\HEPL\\Administrator";
            String stringUser = (String)Registry.GetValue(keyName, "AdminLog", null);

            if (stringUser == null)
            {
                adminUser = new User("Admin","",Profil.Administrateur);
                Registry.SetValue(keyName, "AdminLog", adminUser);
            }
            else
            {
                if (stringUser.Length > stringUser.IndexOf('@') + 1) //si passwd existe
                    adminUser = new User(stringUser.Substring(0, stringUser.IndexOf('@')), stringUser.Substring(stringUser.IndexOf('@') + 1, stringUser.Length - (stringUser.IndexOf('@') + 1)), Profil.Administrateur);
                else
                    adminUser = new User(stringUser.Substring(0, stringUser.IndexOf('@')), "", Profil.Administrateur);
            }
        }
        public void fillUserList() // Directory change + List Loading
        {
            userList = new BindingList<User>();
            const string keyName = "HKEY_CURRENT_USER\\Software\\HEPL\\Users";
            pathUser = (String)Registry.GetValue(keyName, "UsersFilePath", null);
            if (pathUser == null)
            {
                Registry.SetValue(keyName, "usersFilePath", Directory.GetCurrentDirectory() + "\\");
                pathUser = Directory.GetCurrentDirectory();
            }

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<User>));
                StreamReader reader = new StreamReader(pathUser + "UserLogs.xml");
                userList = serializer.Deserialize(reader) as BindingList<User>;
                reader.Close();
            }
            catch (Exception)
            {
                // nothing to do
            }
        }

        private void checkLogin()
        {
            User temp = new User(textBox1.Text, textBox2.Text, Profil.Proprietaire);
            if (temp == adminUser)
            {
                currentUser.Auth = Profil.Administrateur;
                currentUser.Nom = adminUser.Nom;
                currentUser.Passwd = currentUser.Passwd;
                Close();
            }
            for (int i = 0; i < userList.Count; i++)
            {
                if (temp == userList[i])
                {
                    currentUser.Auth = userList[i].Auth;
                    currentUser.Nom = userList[i].Nom;
                    currentUser.Passwd = userList[i].Passwd;
                    Close();
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                checkLogin();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                checkLogin();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            checkLogin();
        }
    }
}
