using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FormDeviceAdmin : Form
    {
        private BindingList<Device> devices;
        private DataGridView dataGridView1;

        public FormDeviceAdmin()
        {
            InitializeComponent();

            // Initialize the device list
            devices = new BindingList<Device>();
            devices.Add(new Device { Id = 1, Name = "Device 1", Status = "Online" });
            devices.Add(new Device { Id = 2, Name = "Device 2", Status = "Offline" });

            // Create a DataGridView
            dataGridView1 = new DataGridView();
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(469, 240);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataSource = devices;

            // Create Buttons
            Button btnAdd = new Button();
            btnAdd.Location = new System.Drawing.Point(12, 267);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += BtnAdd_Click;

            Button btnEdit = new Button();
            btnEdit.Location = new System.Drawing.Point(93, 267);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += BtnEdit_Click;

            Button btnDelete = new Button();
            btnDelete.Location = new System.Drawing.Point(174, 267);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(75, 23);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += BtnDelete_Click;

            // Add controls to the form
            this.Controls.Add(btnDelete);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnAdd);
            this.Controls.Add(dataGridView1);
            this.Text = "Device Administration";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // This is a simple implementation for adding a device.
            // A more robust solution would use a separate form for input.
            string name = "Device " + (devices.Count + 1);
            devices.Add(new Device { Id = devices.Count + 1, Name = name, Status = "Online" });
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Device selectedDevice = (Device)dataGridView1.SelectedRows[0].DataBoundItem;
                if (selectedDevice != null)
                {
                    selectedDevice.Status = selectedDevice.Status == "Online" ? "Offline" : "Online";
                    devices.ResetBindings();
                }
            }
            else
            {
                MessageBox.Show("Please select a device to edit.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Device selectedDevice = (Device)dataGridView1.SelectedRows[0].DataBoundItem;
                if (selectedDevice != null)
                {
                    devices.Remove(selectedDevice);
                }
            }
            else
            {
                MessageBox.Show("Please select a device to delete.");
            }
        }
    }
}
