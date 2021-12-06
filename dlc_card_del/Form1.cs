using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dlc_card_del
{
    public partial class Form1 : Form
    {



        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;

            //工号
            //string id = "";

            //检查工号
            if (textBox1.Text.Equals("") || textBox1.Text.Length < 8)
            {
                MessageBox.Show("检查工号");
                return;
            }

            textBox2.Text = "";


            //准备连接数据库

            textBox2.Text = "准备连接数据库...";
            textBox2.Text += "\r\n";

            //string SQLCONNECT = @"server=192.168.9.100;database=dlcpro;uid=sa;pwd=";
            string SQLCONNECT = @"server=127.0.0.1;database=dlcpro;uid=sa;pwd=";
            SqlConnection conn = new SqlConnection(SQLCONNECT);



            try
            {
                // 引起异常的语句
                conn.Open();
                textBox2.Text += "打开数据库...";
                textBox2.Text += "\r\n";


                //连接数据库之后就可以执行SQL命令了
                //使用SqlCommand类的ExecuteReader()返回执行的结果
                //select * from kq_cardlist where empno = '13030195'
                //string SQLCOMMAND = "delete from kq_cardlist where empno = '" + textBox1.Text + "'";
                string SQLCOMMAND = "select id, empno, empname, deptname, phyid ,modifytime from kq_cardlist where empno = '" + textBox1.Text + "'";

                // '13030195'";
                //id = " '" + textBox1.Text + "'";
                //SQLCOMMAND += id;
                SqlCommand sqlcmd = new SqlCommand(SQLCOMMAND, conn);

                textBox2.Text += "查询数据库...";
                textBox2.Text += "\r\n";
                SqlDataReader sr = sqlcmd.ExecuteReader();
                int nSqlCol = sr.FieldCount;
                //for (int i = 0; i < nSqlCol; ++i){
                //    textBox2.Text += "\r\n";
                //    textBox2.Text += sr.GetFieldType(i);
                // }      ;


                int count = 0;
                while (sr.Read())
                {
                    string line = "";
                    textBox2.Text += "第" + count + 1 + "条数据：";
                    textBox2.Text += "\r\n";
                    for (int i = 0; i < nSqlCol; i++)
                    {
                        line = line + sr[i].ToString() + "\t"; ;

                    }
                    textBox2.Text += line;
                    textBox2.Text += "\r\n";
                    //Console.WriteLine();

                    button2.Enabled = true;
                    count++;
                }

                sr.Close();

                if (count < 1)
                {
                    textBox2.Text = "没有查询到数据！！！！！！！！！";
                    textBox2.Text += "\r\n";
                    textBox2.Text += "没有查询到数据！！！！！！！！！";
                    textBox2.Text += "\r\n";
                    textBox2.Text += "没有查询到数据！！！！！！！！！";
                    textBox2.Text += "\r\n";
                }


                ////通过SqlCommand 类的ExecuteNonQuery()来返回受影响的行数。
                //string SQLCOMMAND2 = "update dbo.Messages set MessageNum='15' where MessageID='2'";
                //SqlCommand sqlcmd2 = new SqlCommand(SQLCOMMAND2, conn);//也可以用sqlcmd. ConnectionString = SQLCOMMAND2 代替
                //int nResult = sqlcmd2.ExecuteNonQuery();
                //Console.WriteLine("受影响行数:" + nResult);

                conn.Close();
            }
            catch (Exception ex)
            {
                // 错误处理代码
                textBox2.Text += "打开数据库错误.";
                textBox2.Text += "\r\n";
                textBox2.Text += SQLCONNECT;
                textBox2.Text += "\r\n";
                textBox2.Text += ex.Message.ToString();
                textBox2.Text += "\r\n";
            }
            finally
            {
                // 要执行的语句
                conn.Close();
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            //工号
            //string id = "";

            //检查工号
            if (textBox1.Text.Equals("") || textBox1.Text.Length < 8)
            {
                MessageBox.Show("检查工号");
                return;
            }

            textBox2.Text = "";


            //准备连接数据库

            textBox2.Text = "准备连接数据库...";
            textBox2.Text += "\r\n";

            //string SQLCONNECT = @"server=192.168.9.100;database=dlcpro;uid=sa;pwd=";
            string SQLCONNECT = @"server=127.0.0.1;database=dlcpro;uid=sa;pwd=";
            SqlConnection conn = new SqlConnection(SQLCONNECT);





            try
            {
                // 引起异常的语句
                conn.Open();
                textBox2.Text += "打开数据库...";
                textBox2.Text += "\r\n";

                //连接数据库之后就可以执行SQL命令了
                //使用SqlCommand类的ExecuteReader()返回执行的结果
                //select * from kq_cardlist where empno = '13030195'
                string SQLCOMMAND = "delete from kq_cardlist where empno = '" + textBox1.Text + "'";

                // '13030195'";
                //id = " '" + textBox1.Text + "'";
                //SQLCOMMAND += id;
                SqlCommand sqlcmd = new SqlCommand(SQLCOMMAND, conn);

                textBox2.Text += "正在删除该数据...";
                textBox2.Text += "\r\n";
                int n = sqlcmd.ExecuteNonQuery();

                if (n > 0)
                {

                    MessageBox.Show("删除成功!");

                }

                textBox2.Text += "删除成功！";
                textBox2.Text += "\r\n";



                conn.Close();

                button2.Enabled = false;
            }
            catch (Exception ex)
            {
                // 错误处理代码
                textBox2.Text += "打开数据库错误.";
                textBox2.Text += "\r\n";
                textBox2.Text += SQLCONNECT;
                textBox2.Text += "\r\n";
                textBox2.Text += ex.Message.ToString();
                textBox2.Text += "\r\n";

            }
            finally
            {
                // 要执行的语句
                conn.Close();
                button2.Enabled = false;
            }


        }


    }
}
