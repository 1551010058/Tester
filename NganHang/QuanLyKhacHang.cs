﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
namespace NganHang
{
    public partial class QuanLyKhacHang : Form
    {
        SqlConnection ketnoi = new SqlConnection(@"Data Source=DESKTOP-FPNJFC5;Initial Catalog=NganHang;Integrated Security=True");
        public QuanLyKhacHang()
        {
            InitializeComponent();
        }
        private void QuanLyKhacHang_Load(object sender, EventArgs e)
        {
            ketnoi.Open();
            hienthi();
        }
        private void QuanLyKhacHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            ketnoi.Close();
        }
        public void hienthi()
        {
            string sqlselect = "SELECT *FROM KhachHang";
            SqlCommand command = new SqlCommand(sqlselect, ketnoi);
            SqlDataReader rd = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rd);
            dataDanhSach.DataSource = dt;

        }
        private void btnThemmoi_Click(object sender, EventArgs e)
        {
            if (kiemtrataikhoantontai() == true && kiemtrasdttontai() == true && kiemtraCMNDtontai() == true)
            {
                Loi4.Text = " * ";
                Loi7.Text = " * ";
                Loi5.Text = " * ";
            }
            else if (kiemtrataikhoantontai() == true && kiemtrasdttontai() == true)
            {
                Loi5.Text = null;
                Loi4.Text = " * ";
                Loi7.Text = " * ";
            }
            else if (kiemtrataikhoantontai() == true && kiemtraCMNDtontai() == true)
            {
                Loi4.Text = null;
                Loi7.Text = " * ";
                Loi5.Text = " * ";
            }
            else if (kiemtraCMNDtontai() == true && kiemtraCMNDtontai() == true)
            {
                Loi7.Text = null;
                Loi4.Text = " * ";
                Loi5.Text = " * ";
            }
            else if (kiemtrataikhoantontai() == true)
            {
                Loi4.Text = null;
                Loi5.Text = null;
                Loi7.Text = " * ";
            }
            else if (kiemtrasdttontai() == true)
            {
                Loi7.Text = null;
                Loi5.Text = null;
                Loi4.Text = " * ";
            }
            else if (kiemtraCMNDtontai() == true)
            {
                Loi4.Text = null;
                Loi5.Text = " * ";
                Loi7.Text = null;
            }
            else if (txtuser.Text == " " || txtpasswork.Text == " " || txtHo.Text == " " || txtTen.Text == " " || cboGioiTinh.Text == "" ||
                txtSDT.Text == ""|| txtDiaChi.Text=="" )
            {
                MessageBox.Show(" Bạn Chưa Nhập Dử Liệu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(txtpasswork.Text != txtagainpasswork.Text)
            {
                MessageBox.Show(" Mật khẩu không đúng ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ketnoi.Open();
                string nhap = "Insert Into KhachHang(MaQuyen,TenDangNhap,MatKhau,Ho,Ten,GioiTinh,SDT,CMND,DiaChi,Tien)" + "Values ('" + cboQuyen.Text + "',N'" + txtuser.Text + "',N'" + txtpasswork.Text + "',N'" + txtHo.Text + "',N'" + txtTen.Text + "',N'" + cboGioiTinh.Text + "',N'" + txtSDT.Text + "',N'" + txtCMND.Text + "',N'" + txtDiaChi.Text + "',N'" + txtmoney.Text + "')";
                SqlCommand command = new SqlCommand(nhap, ketnoi);
                command.ExecuteNonQuery();
                MessageBox.Show(" Bạn Thêm Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                hienthi();
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            
            string update = "Update KhachHang Set TenDangNhap=@TenDangNhap,MaQuyen=@MaQuyen,MatKhau=@MatKhau,Ho=@Ho,Ten=@Ten,GioiTinh=@GioiTinh,SDT=@SDT,CMND=@CMND,DiaChi=@DiaChi,Tien=@Tien where MaThe=@MaThe";
            SqlCommand command = new SqlCommand(update, ketnoi);
            command.Parameters.AddWithValue("MaThe", txtSearchmathe.Text);
            command.Parameters.AddWithValue("TenDangNhap", txtuser.Text);
            command.Parameters.AddWithValue("MaQuyen", cboQuyen.Text);
            command.Parameters.AddWithValue("MatKhau", txtpasswork.Text);
            command.Parameters.AddWithValue("Ho", txtHo.Text);
            command.Parameters.AddWithValue("Ten", txtTen.Text);
            command.Parameters.AddWithValue("GioiTinh", cboGioiTinh.Text);
            command.Parameters.AddWithValue("SDT", txtSDT.Text);
            command.Parameters.AddWithValue("CMND", txtCMND.Text);
            command.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
            command.Parameters.AddWithValue("Tien", txtmoney.Text);
            command.ExecuteNonQuery();
            MessageBox.Show(" Bạn Sửa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hienthi();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string xoa = "Delete from KhachHang where TenDangNhap=@TenDangNhap";
            SqlCommand command = new SqlCommand(xoa, ketnoi);
            command.Parameters.AddWithValue("MaQuyen", cboQuyen.Text);
            command.Parameters.AddWithValue("TenDangNhap", txtuser.Text);
            command.Parameters.AddWithValue("MatKhau", txtpasswork.Text);
            command.Parameters.AddWithValue("Ho", txtHo.Text);
            command.Parameters.AddWithValue("Ten", txtTen.Text);
            command.Parameters.AddWithValue("GioiTinh", cboGioiTinh.Text);
            command.Parameters.AddWithValue("SDT", txtSDT.Text);
            command.Parameters.AddWithValue("CMND", txtCMND.Text);
            command.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
            command.Parameters.AddWithValue("Tien", txtmoney.Text);
            command.ExecuteNonQuery();
            MessageBox.Show(" Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            hienthi();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select MaQuyen from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string maquyen = (string)command.ExecuteScalar();
            SqlCommand command1 = new SqlCommand("select TenDangNhap from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string tendangnhap = (string)command1.ExecuteScalar();
            SqlCommand command2 = new SqlCommand("select MatKhau from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string mk = (string)command2.ExecuteScalar();
            SqlCommand command3 = new SqlCommand("select Ho from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string ho = (string)command3.ExecuteScalar();
            SqlCommand command4 = new SqlCommand("select Ten from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string ten = (string)command4.ExecuteScalar();
            SqlCommand command5 = new SqlCommand("select GioiTinh from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string gioitinh = (string)command5.ExecuteScalar();
            SqlCommand command6 = new SqlCommand("select SDT from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string sdt = (string)command6.ExecuteScalar();
            SqlCommand command7 = new SqlCommand("select CMND from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string cmnd = (string)command7.ExecuteScalar();
            SqlCommand command8 = new SqlCommand("select DiaChi from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            string diachi = (string)command8.ExecuteScalar();
            SqlCommand command9 = new SqlCommand("select Tien from KhachHang where MaThe='" + txtSearchmathe.Text + "'", ketnoi);
            int tien = (int)command9.ExecuteScalar();
            

            cboQuyen.Text = maquyen.ToString();
            txtuser.Text = tendangnhap.ToString();
            txtpasswork.Text = mk.ToString();
            txtHo.Text = ho.ToString();
            txtTen.Text = ten.ToString();
            cboGioiTinh.Text = gioitinh.ToString();
            txtSDT.Text = sdt.ToString();
            txtCMND.Text = cmnd.ToString();
            txtDiaChi.Text = diachi.ToString();
            txtmoney.Text = tien.ToString();
            txtagainpasswork.Text = mk.ToString();
            // cap nhap a
            string tk = "select *from KhachHang where MaThe=@MaThe";
            SqlCommand command0 = new SqlCommand(tk, ketnoi);
            command0.Parameters.AddWithValue("MaThe", txtSearchmathe.Text);
            command0.Parameters.AddWithValue("MaQuyen", cboQuyen.Text);
            command0.Parameters.AddWithValue("TenDangNhap", txtuser.Text);
            command0.Parameters.AddWithValue("MatKhau", txtpasswork.Text);
            command0.Parameters.AddWithValue("Ho", txtHo.Text);
            command0.Parameters.AddWithValue("Ten", txtTen.Text);
            command0.Parameters.AddWithValue("GioiTinh", cboGioiTinh.Text);
            command0.Parameters.AddWithValue("SDT", txtSDT.Text);
            command0.Parameters.AddWithValue("CMND", txtCMND.Text);
            command0.Parameters.AddWithValue("DiaChi", txtDiaChi.Text);
            command0.Parameters.AddWithValue("Tien", txtmoney.Text);
            command0.ExecuteNonQuery();
            SqlDataReader dr = command0.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataDanhSach.DataSource = dt;
                
        }
        private bool kiemtrataikhoantontai()
        {
            bool kt = false;
            string tdn = txtuser.Text;
            SqlDataAdapter da_kt = new SqlDataAdapter("Select * from KhachHang where TenDangNhap='" + tdn + "'", ketnoi);
            DataTable dt_kiemtra = new DataTable();
            da_kt.Fill(dt_kiemtra);
            if (dt_kiemtra.Rows.Count > 0)
            {
                kt = true;

            }
            da_kt.Dispose();
            ketnoi.Close();
            return kt;
        }
        private bool kiemtrasdttontai()
        {
            string tdn;
            try
            {
                tdn =String.Format(txtSDT.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(" Nhập Sai ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bool kt = false;
            tdn = String.Format(txtSDT.Text);
            SqlDataAdapter da_kt = new SqlDataAdapter("Select * from KhachHang where SDT='" + tdn + "'", ketnoi);
            DataTable dt_kiemtra = new DataTable();
            da_kt.Fill(dt_kiemtra);
            if (dt_kiemtra.Rows.Count > 0)
            {
                kt = true;

            }
            da_kt.Dispose();
            ketnoi.Close();
            return kt;
        }
        private bool kiemtraCMNDtontai()
        {
            string tdn;
            try
            {
                tdn = String.Format(txtCMND.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Nhập Sai ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            bool kt = false;
            tdn = String.Format(txtCMND.Text);
            SqlDataAdapter da_kt = new SqlDataAdapter("Select * from KhachHang where CMND='" + tdn + "'", ketnoi);
            DataTable dt_kiemtra = new DataTable();
            da_kt.Fill(dt_kiemtra);
            if (dt_kiemtra.Rows.Count > 0)
            {
                kt = true;

            }
            da_kt.Dispose();
            ketnoi.Close();
            return kt;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            txtCMND.Text = null;
            txtagainpasswork.Text = null;
            txtDiaChi.Text = null;
            txtHo.Text = null;
            txtmoney.Text = "100000";
            txtNgaySinh.Text = null;
            txtpasswork.Text = null;
            txtSDT.Text = null;
            txtSearchmathe.Text = null;
            txtTen.Text = null;
            txtuser.Text = null;
            cboGioiTinh.Text = null;
            cboQuyen.Text = null;
            hienthi();
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessDialogKey(keyData);
        }

    }
}
