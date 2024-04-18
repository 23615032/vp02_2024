using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using static System.Net.WebRequestMethods;

namespace _023_Firebase
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = " kzKbPHhg3tsTmJbGatHwZSOxyzSwOHLckuW8tMmm ",
            BasePath = " https://fir-project-eba94-default-rtdb.firebaseio.com/ "
        };
        IFirebaseClient client;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null )
            {
                MessageBox.Show("Connection 성공!");
            }
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            var data = new Data  // 원래는 Data data = new Data
            {
                ID = txtID.Text,
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text

            };

            SetResponse response = await client.SetAsync("Phonebook/" + txtID.Text, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted : Id = " + result.ID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtSId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private async void btnRetrieve_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
                client.GetAsync("Phonebook/" + txtID.Text);
            Data obj = response.ResultAs<Data>();

            txtID.Text = obj.ID;
            txtSId.Text = obj.SId;
            txtName.Text = obj.Name;
            txtPhone.Text = obj.Phone;

            MessageBox.Show("Data retrieved successfully!");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Data data = new Data
            {
                ID = txtID.Text,
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            FirebaseResponse response = await
                client.UpdateAsync("Phonebook/" + txtID.Text, data);
            Data result =  response.ResultAs<Data>();
            MessageBox.Show("Data updated successfullt! : Id = " + result.ID);
        }
    }
}
