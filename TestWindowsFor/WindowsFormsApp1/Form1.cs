using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Tools;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ErrorProvider _errorProvider;
        public Form1()
        {
            InitializeComponent();
            _errorProvider = new ErrorProvider();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool IsValid = true;
            if (string.IsNullOrEmpty(txt_userName.Text))
            {
                _errorProvider.SetError(txt_userName, "User Name is Requierd");
                IsValid = false;
            }
            if (string.IsNullOrEmpty(txt_Password.Text))
            {
                _errorProvider.SetError(txt_Password, "Password is Requierd");
                IsValid = false;
            }
            // بررسی وجود کاربر در دیتابیس
            // مطابقت اطلاعات ورودی با اطلاعات ذخیره شده
            // ذخیره کردن تاریخچه ورود


            if(IsValid)
            {
                using (var connection = new SqlConnection(SystemConsts.ConnectionString))
                {
                    var result = await connection.QueryAsync($@"select * from students
                                        where NationalCode = '{txt_userName.Text}'");

                }
            }

        }
    }
}
