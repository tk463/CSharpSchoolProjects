using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Win32;
using EnergyLib;

namespace OptimizeEnergy
{
    public partial class Form1 : Form
    {
        Graphics graph;
        String userPathFile;
        int lastHouseId;
        bool simulation = false, resizing = false, dragging = false, draggingApp = false;
        int trancheHoraire;
        double wattPerDay;
        DateTime currentTime;
        Point LocDown;

        public User currentUser { get; set; }
        public House currentHouse { get; set; }
        public Floor currentFloor { get; set; }
        public Room currentRoom { get; set; }
        public Appareil currentApp { get; set; }
        public BindingList<User> userList { get; set; }
        public BindingList<House> houseList { get; set; }


        public Form1()
        {
            currentUser = new User();
            currentTime = new DateTime();
            InitializeComponent();
            panelAdmin.Hide();
            panelUser.Hide();
            graph = pictureBox1.CreateGraphics();
            deconnecterToolStripMenuItem.Enabled = false;
            houseList = new BindingList<House>();
        }

        private void connecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User temp = new User();
            if (currentUser == temp)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
                currentUser = loginForm.currentUser;
                connecterToolStripMenuItem.Enabled = false;
                deconnecterToolStripMenuItem.Enabled = true;

                if (loginForm.currentUser.Auth == Profil.Administrateur)
                {
                    userList = loginForm.userList;
                    bindingSourceUserList.DataSource = userList;
                    comboBoxUser.DataSource = bindingSourceUserList;
                    panelAdmin.Show();
                }
                else if (loginForm.currentUser.Auth == Profil.Proprietaire)
                {
                    loadHouses();
                    bindingSourceMaisonList.DataSource = houseList;
                    comboBoxMaisons.DataSource = bindingSourceMaisonList;
                    if (houseList.Count > 0)
                        lastHouseId = houseList[houseList.Count - 1].ID;
                    else
                        lastHouseId = 0;
                    panelUser.Show();
                }
                else
                {
                    connecterToolStripMenuItem.Enabled = true;
                    deconnecterToolStripMenuItem.Enabled = false;
                }
                userPathFile = loginForm.pathUser;
            }
        }

        private void loadHouses()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<House>));
                StreamReader Reader = new StreamReader(userPathFile + currentUser.Nom + "Houses.xml");
                houseList = serializer.Deserialize(Reader) as BindingList<House>;
                Reader.Close();
            }
            catch (Exception)
            {
                //nothing to do
            }
        }

        private void deconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            User temp = new User(); //empty user
            currentUser.Auth = temp.Auth;
            currentUser.Nom = temp.Nom;
            currentUser.Passwd = temp.Passwd;

            connecterToolStripMenuItem.Enabled = true;
            deconnecterToolStripMenuItem.Enabled = false;
            treeView.Nodes.Clear();
            pictureBox1.Image = null;
            panelAdmin.Hide();
            panelUser.Hide();
        }

        //Admin panel code
        private void buttonAddUser_Click(object sender, EventArgs e)
        {
            Adduser addUser = new Adduser();
            addUser.ShowDialog();
            bindingSourceUserList.Add(addUser.userToSerialize);
            saveUsers();
        }

        private void saveUsers()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BindingList<User>));
            StreamWriter writer = new StreamWriter(userPathFile + "UserLogs.xml");
            serializer.Serialize(writer, userList);
            writer.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            bindingSourceUserList.RemoveCurrent();
            saveUsers();
        }

        private void comboBoxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bindingSourceUserList.Count > 0)
            {
                textBoxLogin.Text = userList.ElementAt(bindingSourceUserList.Position).Nom;
                textBoxPassword.Text = userList.ElementAt(bindingSourceUserList.Position).Passwd;
                switch (userList.ElementAt(bindingSourceUserList.Position).Auth)
                {
                    case Profil.Administrateur:
                        radioButtonAdmin.Checked = true;
                        break;
                    case Profil.Proprietaire:
                        radioButtonOwner.Checked = true;
                        break;
                    case Profil.Unknown:
                        radioButtonOwner.Checked = true;
                        break;
                    default:
                        radioButtonOwner.Checked = true;
                        break;
                }
            }
            else
            {
                textBoxLogin.Clear();
                textBoxPassword.Clear();
            }
        }

        private void buttonApplyAdmin_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxAdminPasswd.Text) && !String.IsNullOrEmpty(textBoxAdminPasswdConfirm.Text))
            {
                labelErrorPasswdAdmin.Hide();
                if (textBoxAdminPasswd.Text == textBoxAdminPasswdConfirm.Text)
                {
                    labelErrorPasswdAdmin.Text = "Passwd changed";
                    labelErrorPasswdAdmin.Show();
                    const string keyName = "HKEY_CURRENT_USER\\Software\\HEPL\\Administrator";
                    User adminUser = new User("Admin", textBoxAdminPasswd.Text, Profil.Administrateur);
                    Registry.SetValue(keyName, "AdminLog", adminUser);
                }
                else
                {
                    labelErrorPasswdAdmin.Text = "Passwds don't match";
                    labelErrorPasswdAdmin.Show();
                }
            }
        }

        private void buttonApplyUser_Click(object sender, EventArgs e)
        {
            labelErrorUser.Hide();
            if (String.IsNullOrEmpty(textBoxLogin.Text) || String.IsNullOrEmpty(textBoxPassword.Text))
            {
                labelErrorUser.Show();
            }
            else
            {
                userList.ElementAt(bindingSourceUserList.Position).Nom = textBoxLogin.Text;
                userList.ElementAt(bindingSourceUserList.Position).Passwd = textBoxPassword.Text;
                if (radioButtonAdmin.Checked == true)
                    userList.ElementAt(bindingSourceUserList.Position).Auth = Profil.Administrateur;
                else if (radioButtonOwner.Checked == true)
                    userList.ElementAt(bindingSourceUserList.Position).Auth = Profil.Proprietaire;
                else
                    userList.ElementAt(bindingSourceUserList.Position).Auth = Profil.Unknown; // not supposed to go here
                saveUsers();
                bindingSourceUserList.ResetBindings(false);
            }
        }

        //User panel code
        private void buttonNewHouse_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Count != 0)
            {
                DialogResult dr = MessageBox.Show("Sauver la maison courante ?","Sauvegarde",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    saveHouses();
            }
            treeView.Nodes.Clear();
            TreeNode node = new TreeNode();
            node.Text = "Maison";
            node.Tag = new House(lastHouseId + 1);
            lastHouseId += 1;
            ((House)node.Tag).Nom = "House";
            treeView.Nodes.Add(node);
            currentHouse = node.Tag as House;
            bindingSourceMaisonList.Add(currentHouse);
        }

        private void buttonSaveMaison_Click(object sender, EventArgs e)
        {
            saveHouses();
        }

        private void saveHouses()
        {
            try
            {
                assignNames(treeView.Nodes[0]);
                XmlSerializer serializer = new XmlSerializer(typeof(BindingList<House>));
                Directory.CreateDirectory(userPathFile + currentUser.Nom);
                StreamWriter writer = new StreamWriter(userPathFile + currentUser.Nom + "Houses.xml");
                serializer.Serialize(writer, houseList);
                writer.Close();
                MessageBox.Show("House saved", "House saver");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Tree is empty", "House saver");
            }
            catch (IOException)
            {
                MessageBox.Show("File currently used elsewhere", "House saver");
            }
        }

        private void assignNames(TreeNode node) //recursive
        {
            switch (node.Level)
            {
                case 0:
                    ((House)node.Tag).Nom = node.Text;
                    break;
                case 1:
                    ((Floor)node.Tag).Nom = node.Text;
                    break;
                case 2:
                    ((Room)node.Tag).Nom = node.Text;
                    break;
                case 3:
                    ((Appareil)node.Tag).Modele = node.Text;
                    break;
            }
            foreach (TreeNode tn in node.Nodes)
            {
                assignNames(tn);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                switch (e.Node.Level)
                {
                    case 0: //House
                        contextMenuStrip.Items[0].Text = "Ajouter niveau";
                        contextMenuStrip.Items["selectImageToolStripMenuItem"].Visible = true;
                        contextMenuStrip.Show(treeView, new Point(e.X, e.Y));
                        break;
                    case 1: //Floor
                        contextMenuStrip.Items["selectImageToolStripMenuItem"].Visible = false;
                        contextMenuStrip.Items[0].Text = "Ajouter piece";
                        contextMenuStrip.Show(treeView, new Point(e.X, e.Y));
                        break;
                    case 2: //Room
                        contextMenuStrip.Items["selectImageToolStripMenuItem"].Visible = false;
                        contextMenuStrip.Items[0].Text = "Ajouter appareil";
                        contextMenuStrip.Show(treeView, new Point(e.X, e.Y));
                        break;
                    case 3 : //Device
                        contextMenuStrip.Items["selectImageToolStripMenuItem"].Visible = true;
                        contextMenuStrip.Items[0].Text = "Configure device";
                        contextMenuStrip.Show(treeView, new Point(e.X, e.Y));
                        break;
                    default:
                        break;
                }
            }
            else if (e.Node.Level == 0)
            {
                if (!String.IsNullOrEmpty(((House)e.Node.Tag).PicName)) //si image
                {
                    Bitmap image = new Bitmap(userPathFile + "\\" + ((House)e.Node.Tag).PicName);
                    image = ScaleImage(image, 386, 436);
                    Graphics g = Graphics.FromImage(image);

                    g.DrawString(currentHouse.Adresse.ToString(), new Font("Tahoma", 16), Brushes.Black, 10, 20);

                    pictureBox1.Image = image;
                }

            }
            else if (e.Node.Level == 1)
            {
                currentFloor = e.Node.Tag as Floor;
                drawFloor(e.Node.Tag as Floor);
            }
            else if (e.Node.Level == 2)
            {
                currentRoom = e.Node.Tag as Room;
                drawFloor(currentFloor);
            }
        }

        private void drawFloor(Floor floor)
        {
            Bitmap floorImage = new Bitmap(1000, 1000);
            Graphics g = Graphics.FromImage(floorImage);

            try
            {
                foreach (Room item in floor.roomList)
                {
                    if (item == currentRoom)
                        g.DrawRectangle(Pens.Red, item.surface);
                    else
                        g.DrawRectangle(Pens.Black, item.surface);

                    foreach (Appareil itemAppareil in item.listeAppareils)
                    {
                        if (itemAppareil == currentApp) // bordure sur l'app courant
                        {
                            g.DrawRectangle(Pens.Purple, new Rectangle(itemAppareil.Surface.X - 1, itemAppareil.Surface.Y - 1, itemAppareil.Surface.Width + 2, itemAppareil.Surface.Height + 2));
                        }
                        if (simulation)
                        {
                            if (itemAppareil.Autorisation[trancheHoraire] == true)
                            {
                                wattPerDay += (itemAppareil.Consommation / 2);
                                g.DrawRectangle(Pens.Black, new Rectangle(itemAppareil.Surface.X - 3, itemAppareil.Surface.Y - 3, itemAppareil.Surface.Width + 5, itemAppareil.Surface.Height + 5));
                            }
                        }
                        switch (itemAppareil.Type)
                        {
                            case TypeAppareil.Electromenager:
                                g.DrawImage(Properties.Resources.appliance, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                            case TypeAppareil.Media:
                                g.DrawImage(Properties.Resources.tv, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                            case TypeAppareil.Chauffage:
                                g.DrawImage(Properties.Resources.radiateur, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                            case TypeAppareil.Eclairage:
                                g.DrawImage(Properties.Resources.lighting, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                            case TypeAppareil.Autre:
                                g.DrawImage(Properties.Resources.other, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                            default:
                                g.DrawImage(Properties.Resources.other, new Point(itemAppareil.Surface.X, itemAppareil.Surface.Y));
                                break;
                        }
                    }
                    g.DrawString(item.Nom, new Font("Tahoma", 13), Brushes.Blue, (float)item.surface.X + 5, (float)item.surface.Y + 5);
                }
                pictureBox1.Image = floorImage;
                //pictureBox1.AllowDrop = true;
            }
            catch (Exception)
            {
                //nothing to do - NullReferenceException /probable clic sur une pièce avant un étage
            }
        }

        private static Bitmap ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        private void selectImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Choose a picture";
            openFileDialog1.ShowDialog();
            if (!String.IsNullOrEmpty(openFileDialog1.FileName))
            {
                saveHouses();
                if (treeView.SelectedNode.Tag is House)
                {
                    ((House)treeView.SelectedNode.Tag).PicName = openFileDialog1.SafeFileName;
                    System.IO.File.Copy(openFileDialog1.FileName, userPathFile + "\\" + openFileDialog1.SafeFileName);
                }
            }
        }

        private void ajoutNiveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode();
            switch (treeView.SelectedNode.Level)
            {
                case 0: //House
                    node.Text = "Floor";
                    node.Tag = new Floor();
                    ((Floor)node.Tag).Nom = "Floor";
                    ((House)treeView.SelectedNode.Tag).floorList.Add(node.Tag as Floor); // node Add
                    break;
                case 1: //Floor
                    node.Text = "Room";
                    node.Tag = new Room();
                    ((Room)node.Tag).Nom = "Room";
                    ((Floor)treeView.SelectedNode.Tag).roomList.Add(node.Tag as Room); //node Add
                    break;
                case 2: //Room
                    node.Text = "Device";
                    node.Tag = new Appareil();
                    ((Appareil)node.Tag).setSurface(((Room)treeView.SelectedNode.Tag).surface.X + 5, ((Room)treeView.SelectedNode.Tag).surface.Y + 5); //
                    ((Appareil)node.Tag).Modele = "Device";

                    ((Room)treeView.SelectedNode.Tag).listeAppareils.Add(node.Tag as Appareil);
                    break;
                case 3: //We clicked on edit a device, so we need to display the form to edit the device settings
                    editApp((Appareil)treeView.SelectedNode.Tag);
                    drawFloor(currentFloor);
                    return;
                default:
                    break;
            }
            treeView.SelectedNode.Nodes.Add(node);
            treeView.ExpandAll();
        }

        private void editApp(Appareil app)
        {
            EditDeviceSettingsForm editAppForm = new EditDeviceSettingsForm(app);
            editAppForm.ShowDialog();
            if ((Appareil)treeView.SelectedNode.Tag == currentApp)
                treeView.SelectedNode.Text = editAppForm.ModeleTextBox();
        }

        private void renommerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView.SelectedNode.BeginEdit();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e) // double click = edit apparreil
        {
            if (currentApp != null)
                editApp(currentApp);
        }

        private void consommationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (treeView.SelectedNode.Level)
            {
                case 0:
                    //We need to calculate the consumption for the entire house
                    MessageBox.Show(treeView.SelectedNode.Text + " consumes " + houseConsumption((House)treeView.SelectedNode.Tag).ToString() + " watt a day");
                    break;
                case 1:
                    //Calculate the consumption for a floor
                    MessageBox.Show(treeView.SelectedNode.Text + " consumes " + floorConsumption((Floor)treeView.SelectedNode.Tag).ToString() + " watt a day");
                    break;
                case 2:
                    //Calculate the consumption for a room
                    MessageBox.Show(treeView.SelectedNode.Text + " consumes " + roomConsumption((Room)treeView.SelectedNode.Tag).ToString() + " watt a day");
                    break;
                case 3:
                    //Calculate the consumption for a device
                    MessageBox.Show(treeView.SelectedNode.Text + " consumes " + deviceConsumption((Appareil)treeView.SelectedNode.Tag).ToString() + " watt a day");
                    break;
                default:
                    break;
            }
        }

        private double houseConsumption(House house)
        {
            double consumption = 0;
            foreach (Floor item in house.floorList)
            {
                consumption += floorConsumption(item);
            }
            return consumption;
        }

        private double floorConsumption(Floor floor)
        {
            double consumption = 0;
            foreach (Room item in floor.roomList)
            {
                consumption += roomConsumption(item);
            }
            return consumption;
        }

        private double roomConsumption(Room room)
        {
            double consumption = 0;
            foreach (Appareil item in room.listeAppareils)
            {
                consumption += deviceConsumption(item);
            }
            return consumption;
        }

        private double deviceConsumption(Appareil appareil)
        {
            int numberOfAnHalfHour = 0;
            for (int i = 0; i < 48; i++)
            {
                if (appareil.Autorisation[i])
                {
                    numberOfAnHalfHour++;
                }
            }
            return numberOfAnHalfHour * (appareil.Consommation / 2);
        }

        private void buttonLoadInTree_Click(object sender, EventArgs e)
        {
            TreeNode node, houseNode, floorNode, roomNode;
            if (treeView.Nodes.Count != 0)
            {
                DialogResult dr = MessageBox.Show("Would you like to save the current house first ? ", "SaveHouse", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    saveHouses();
                else
                    bindingSourceMaisonList.Remove(currentHouse);
            }
            if (bindingSourceMaisonList.Count > 0) // minimum une maison
            {
                node = new TreeNode();
                treeView.Nodes.Clear();
                currentHouse = (House)bindingSourceMaisonList.Current;

                node.Text = currentHouse.Nom;
                node.Tag = currentHouse;
                treeView.Nodes.Add(node);
                houseNode = node;

                foreach (Floor itemFloor in ((House)houseNode.Tag).floorList)
                {
                    node = new TreeNode();
                    node.Text = itemFloor.Nom;
                    node.Tag = itemFloor;
                    floorNode = node; //Reference to floorNode until the end of the loop
                    foreach (Room itemRoom in itemFloor.roomList)
                    {
                        node = new TreeNode();
                        node.Text = itemRoom.Nom;
                        node.Tag = itemRoom;
                        roomNode = node;
                        foreach (Appareil itemAppareil in itemRoom.listeAppareils)
                        {
                            node = new TreeNode();
                            node.Text = itemAppareil.Modele;
                            node.Tag = itemAppareil;
                            roomNode.Nodes.Add(node);
                        }
                        floorNode.Nodes.Add(roomNode);
                    }
                    houseNode.Nodes.Add(floorNode);
                }
            }
            treeView.ExpandAll();
        }

        private void buttonSimulation_Click(object sender, EventArgs e)
        {
            if (buttonSimulation.Text == "Stop simulation")
            {
                pictureBox1.Enabled = true;
                buttonSimulation.Text = "Simulation";
                buttonForward.Enabled = false;
                trancheHoraire = 0;
                simulation = false;
                wattPerDay = 0;
                labelTimer.Text = "0:00";
            }
            else
            {
                simulation = true;
                pictureBox1.Enabled = false;
                buttonSimulation.Text = "Stop simulation";
                buttonForward.Enabled = true;
            }
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            drawFloor(currentFloor);
            currentTime = currentTime.AddMinutes(30);
            labelTimer.Text = currentTime.ToString("HH:mm");
            trancheHoraire++;
            if (currentTime.Hour == 0 && currentTime.Minute == 0)
            {
                pictureBox1.Enabled = true;
                buttonSimulation.Text = "Simulation";
                buttonForward.Enabled = false;
                trancheHoraire = 0;
                simulation = false;
                MessageBox.Show(wattPerDay.ToString());
                wattPerDay = 0;
            }
        }

        private Room getCurrentRoom(Point location)
        {
            foreach (Room item in currentFloor.roomList)
            {
                if (location.X >= item.surface.X && location.X <= item.surface.X + item.surface.Width)
                {
                    //We clicked on the good width

                    if (location.Y >= item.surface.Y && location.Y <= item.surface.Y + item.surface.Height)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private Appareil getCurrentDevice(Point location)
        {
            foreach (Appareil item in currentRoom.listeAppareils)
            {
                if (location.X >= item.Surface.X && location.X <= item.Surface.X + item.Surface.Width)
                {
                    if (location.Y >= item.Surface.Y && location.Y <= item.Surface.Y + item.Surface.Height)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        private bool isResizing(Room roomToSee, Point location)
        {
            Rectangle resizeSurface = new Rectangle();

            resizeSurface.Width = roomToSee.surface.Width / 10;
            resizeSurface.Height = roomToSee.surface.Height / 10;
            resizeSurface.X = (roomToSee.surface.X + roomToSee.surface.Width) - resizeSurface.Width;
            resizeSurface.Y = (roomToSee.surface.Y + roomToSee.surface.Height) - resizeSurface.Height;

            if (location.X >= resizeSurface.X && location.X <= resizeSurface.X + resizeSurface.Width)
            {
                if (location.Y >= resizeSurface.Y && location.Y <= resizeSurface.Y + resizeSurface.Height)
                {
                    return true;
                }
            }
            return false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            LocDown = e.Location;
            currentRoom = getCurrentRoom(e.Location);
            if (currentRoom != null)
            {
                if (isResizing(currentRoom, e.Location))
                {
                    resizing = true;
                }
                else
                {
                    currentApp = getCurrentDevice(e.Location);
                    if (e.Button == MouseButtons.Right) //If right click, we move the device
                    {
                        if (currentApp != null)
                        {
                            draggingApp = true;
                        }
                    }
                    else //If left click, we move the room
                        dragging = true;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (LocDown.X == e.Location.X && LocDown.Y == e.Location.Y)//clic sans déplacement
            {
                if (dragging)
                    dragging = false;
                else if (draggingApp)
                    draggingApp = false;
                drawFloor(currentFloor);
            }
            else if (dragging == true)
            {
                foreach (Appareil item in currentRoom.listeAppareils) //Calcul de la position des App en fonction de la posi de la pièce
                {
                    item.setSurface(e.Location.X + (item.Surface.X - currentRoom.surface.X), e.Location.Y + (item.Surface.Y - currentRoom.surface.Y));
                }
                currentRoom.setSurface(new Point(e.Location.X, e.Location.Y)); //Affectation position pièce
                dragging = false;
                drawFloor(currentFloor);
            }
            else if (resizing == true)
            {
                currentRoom.resize(e.Location.X - currentRoom.surface.X, e.Location.Y - currentRoom.surface.Y);
                resizing = false;
                drawFloor(currentFloor);
            }
            else if (draggingApp == true)
            {
                Point coordonnates = new Point();

                //Check si App hors pièce
                if (e.Location.X >= currentRoom.surface.X && e.Location.X <= currentRoom.surface.X + currentRoom.surface.Width)
                {
                    if (e.Location.Y >= currentRoom.surface.Y && e.Location.Y <= currentRoom.surface.Y + currentRoom.surface.Height)
                    {
                        //calcul coord pour etre dans la pièce
                        if (e.Location.X + 50 > currentRoom.surface.X + currentRoom.surface.Width) //dehors à droite
                            coordonnates.X = (currentRoom.surface.X + currentRoom.surface.Width) - 50;
                        else
                            coordonnates.X = e.Location.X;

                        if (e.Location.Y + 50 > currentRoom.surface.Y + currentRoom.surface.Height) //dehors en bas
                            coordonnates.Y = (currentRoom.surface.Y + currentRoom.surface.Height) - 50;
                        else
                            coordonnates.Y = e.Location.Y;
                        currentApp.setSurface(coordonnates.X, coordonnates.Y);
                    }
                }
                this.drawFloor(currentFloor);
                draggingApp = false;
            }
        }
    }
}
