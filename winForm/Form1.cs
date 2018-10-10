using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            InisialisasiListView();
        }

        private void InisialisasiListView()
        {
            lvwMahasiswa.View = System.Windows.Forms.View.Details;
            lvwMahasiswa.FullRowSelect = true;
            lvwMahasiswa.GridLines = true;

            lvwMahasiswa.Columns.Add("No.", 30, HorizontalAlignment.Center);
            lvwMahasiswa.Columns.Add("Npm", 70, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Nama", 180, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Jenis Kelamin", 80, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tempat Lahir", 75, HorizontalAlignment.Left);
            lvwMahasiswa.Columns.Add("Tgl. Lahir", 75, HorizontalAlignment.Left);

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!mskNpm.MaskFull)
            {
                MessageBox.Show("NPM harus diisi!!!", "Peringatan", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Exclamation);
                mskNpm.Focus();
                return;
            }

            var jeniskelamin = rdoLakilaki.Checked ? "Laki-laki" : "Perempuan";

            var result = MessageBox.Show("Apakah data ingin disimpan?", "Konfirmasi", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var noUrut = lvwMahasiswa.Items.Count + 1;

                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mskNpm.Text);
                item.SubItems.Add(txtNama.Text);
                item.SubItems.Add(jeniskelamin);
                item.SubItems.Add(txtTempatLahir.Text);
                item.SubItems.Add(dtpTanggalLahir.Value.ToString("dd/MM/yyyy"));

                lvwMahasiswa.Items.Add(item);

                ResetForm();
            }
        }

        private void ResetForm()
        {
            mskNpm.Clear();
            txtNama.Clear();
            rdoLakilaki.Checked = true;
            txtTempatLahir.Clear();
            dtpTanggalLahir.Value = DateTime.Today;

            mskNpm.Focus();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvwMahasiswa.SelectedItems.Count > 0)
            {
                var index = lvwMahasiswa.SelectedIndices[0];
                var nama = lvwMahasiswa.Items[index].SubItems[2].Text;

                var msg = string.Format("Apakah data mahasiswa '{0}' ingin di hapus ?", nama);

                var result = MessageBox.Show(msg, "konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    lvwMahasiswa.Items[index].Remove();
                }
            }

            else
            {
                MessageBox.Show("Data belum di pilih", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            var msg = "Apakah Anda Yakin ?";

            var result = MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
                this.Close();
        }
    }
}
