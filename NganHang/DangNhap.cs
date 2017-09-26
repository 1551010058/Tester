﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace NganHang
{
    public partial class DangNhap : Form
    {
        
        public DangNhap()
        {
            InitializeComponent();

        }
        public string getdangnhap()
        {
            return txtTendangnhap.Text;
        }
        public static string user = "", user1 = " ", user2 = " ", user3 = " ", user4 = " ";
        
        private void btdangnhap_Click(object sender, EventArgs e)
        {
            Init();
        }
        private void Init()
        {
            SqlConnection ketnoi = new SqlConnection(@"Data Source=DESKTOP-FPNJFC5;Initial Catalog=NganHang;Integrated Security=True");
            try
            {
                ketnoi.Open();
                string tk = getdangnhap();
                string mk = txtmatkhau.Text;
                string sql = "select *from KhachHang where TenDangNhap='" + tk + "' and MatKhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, ketnoi);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("Đăng Nhập Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrangChinh frm = new TrangChinh();
                    TrangChinh.user = txtTendangnhap.Text;//luu ten dang nhap
                    ThongTinTaiKhoan.user1 = txtTendangnhap.Text;
                    GuiTien.user2 = txtTendangnhap.Text;
                    ChuyenTien.user3 = txtTendangnhap.Text;
                    RutTien.user4 = txtTendangnhap.Text;
                    frm.Show();
                    this.Hide();
                    cmd.Dispose();
                    dta.Close();
                    dta.Dispose();
                }
                else
                    MessageBox.Show("Đăng Nhập không Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Lỗi Kết Nối ");
            }
        }
        private void btthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btdangky_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.Show();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Init();
            }
            if (keyData == Keys.Escape)
                 this.Close();
            return base.ProcessDialogKey(keyData);
        }
             
      

      
    }
}
