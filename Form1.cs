using Du_An_Mau.Models;
using Microsoft.EntityFrameworkCore;

namespace Du_An_Mau
{
    public partial class Form1 : Form
    {
        QuanLyChiTieuContext ql = new QuanLyChiTieuContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoatDanhSach();
        }

        private void LoatDanhSach()
        {
            dataGridView1.DataSource = ql.ViTiens.Include(x => x.IdNguoiDungNavigation).ToList().Select((x, index) => new
            {
                x.IdViTien,
                x.IdNguoiDung,
                x.Ten,
                x.SoDu,
                x.MoTa,
            }).ToList();

            comboBox1.DataSource = ql.NguoiDungs.ToList();
            comboBox1.DisplayMember = "ID_NguoiDung";
            comboBox1.ValueMember = "Ten";
        }
        private void ThemViTien()
        {
            ViTien VT = new ViTien();
            VT.Ten = textBox1.Text;
            VT.SoDu = decimal.Parse(textBox2.Text);
            VT.MoTa = textBox3.Text;
            ql.ViTiens.Add(VT);
            ql.SaveChanges();
            MessageBox.Show("Thêm Thành Công");

        }

        private void btnThemViTien_Click(object sender, EventArgs e)
        {
            ThemViTien();
            LoatDanhSach();
        }
    }
}
