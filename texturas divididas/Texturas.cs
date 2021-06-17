using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{




    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection(@"server=PRINCIPESCO-PC;database=dataImagen;integrated security=true");
        int cc, re1, re2;
        int cR, cG, cB;
        int cRt, cGt, cBt;
        string aa;
        string colR, colG, colB;
        int suma;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Bitmap bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(20, 20);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();

        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Color c = new Color();
            c = bmp.GetPixel(e.X, e.Y);
            cR = c.R; cG = c.G; cB = c.B;

            cRt = 0; cGt = 0; cBt = 0;
            for (int i = e.X; i < e.X + 5; i++)
                for (int j = e.Y; j < e.Y + 5; j++)
                {
                    c = bmp.GetPixel(i, j);
                    cRt = c.R + cRt; cGt = c.G + cGt; cBt = c.B + cBt;
                }
            cRt = cRt / 25;
            cGt = cGt / 25;
            cBt = cBt / 25;
            textBox1.Text = c.R.ToString() + " " + cRt.ToString();
            textBox2.Text = c.G.ToString() + " " + cGt.ToString();
            textBox3.Text = c.B.ToString() + " " + cBt.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 50; i < 100; i++)
                for (int j = 50; j < 100; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R, 0, 0));
                }
            pictureBox2.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (c.R != cR && c.G != cG && c.B != cB)
                        bmp2.SetPixel(i, j, c);
                    else
                        bmp2.SetPixel(i, j, Color.Black);

                }
            pictureBox2.Image = bmp2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string cadena = "select * from imagenes2 where nombre='LAGO' ";//Consulta
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())//leer los datos en REGISTRO
            {
                aa = registro["nombre"].ToString();
                colR = registro["valor1"].ToString();
                colG = registro["valor2"].ToString();
                colB = registro["valor3"].ToString();
                cR = Int32.Parse(colR);
                cG = Int32.Parse(colG);
                cB = Int32.Parse(colB);



            }
            else
            {
                MessageBox.Show("No existe esa IMAGEN");
            }
            Console.WriteLine(aa + colR + colG + colB);

            conexion.Close();


            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (cR - 120 <= c.R && c.R <= cR + 120 && cG - 170 <= c.G && c.G <= cG + 170 && cB - 100 <= c.B && c.B <= cB + 100)

                        bmp2.SetPixel(i, j, Color.Black);
                    else
                        bmp2.SetPixel(i, j, c);

                }
            pictureBox2.Image = bmp2;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conexion.Open();

            string cadena = "select * from imagenes2 where nombre='tierra'";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                aa = registro["nombre"].ToString();
                colR = registro["valor1"].ToString();
                colG = registro["valor2"].ToString();
                colB = registro["valor3"].ToString();
                cR = Int32.Parse(colR);
                cG = Int32.Parse(colG);
                cB = Int32.Parse(colB);



            }
            else
            {
                MessageBox.Show("No existe esa IMAGEN o Dato");
            }
            Console.WriteLine(aa + colR + colG + colB);

            conexion.Close();


            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (cR - 110 <= c.R && c.R <= cR + 200 && cG - 40 <= c.G && c.G <= cG + 200 && cB - 9 <= c.B && c.B <= cB + 250)

                        bmp2.SetPixel(i, j, Color.Black);
                    else
                        bmp2.SetPixel(i, j, c);

                }
            pictureBox2.Image = bmp2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    if (cR - 15 <= c.R && c.R <= cR + 15 && cG - 15 <= c.G && c.G <= cG + 15 && cB - 15 <= c.B && c.B <= cB + 0)

                        bmp2.SetPixel(i, j, Color.Black);
                    else
                        bmp2.SetPixel(i, j, c);

                }
            pictureBox2.Image = bmp2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            for (int i = 0; i < bmp.Width - 20; i = i + 10)
                for (int j = 0; j < bmp.Height - 20; j = j + 10)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 10; k++)
                        for (int l = j; l < j + 10; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 100;
                    cGto = cGto / 100;
                    cBto = cBto / 100;
                    c = bmp.GetPixel(i, j);
                    if (((cRt - 50 <= cRto) && (cRto <= cRt + 50)) && ((cGto - 50 <= cGt) && (cGt <= cGto + 50)) && ((cBto - 50 <= cBt) && (cBt <= cBto + 50)))
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                bmp2.SetPixel(k, l, Color.Black);
                            }
                    else
                        for (int k = i; k < i + 10; k++)
                            for (int l = j; l < j + 10; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                }
            pictureBox2.Image = bmp2;
        }

        private void button9_Click(object sender, EventArgs e)//PRENDA 1 DELICADA
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 10;
                    cGt = 42;
                    cBt = 60;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 73)) && ((cGt <= cGto) && (cGto <= cGt + 140)) && ((cBt <= cBto) && (cBto <= cBt + 165)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 2 && i > 140 && j > 82 && i < 200 && j < 300)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido CELESTE";
        }

        private void button10_Click(object sender, EventArgs e)//PRENDA 1 SIN DELICAR
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();

            for (int i = 0; i < bmp.Width - 20; i = i + 3)
                for (int j = 0; j < bmp.Height - 20; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 10;
                    cGt = 42;
                    cBt = 60;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 73)) && ((cGt <= cGto) && (cGto <= cGt + 140)) && ((cBt <= cBto) && (cBto <= cBt + 165)))
                    {

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                bmp2.SetPixel(k, l, Color.Red);




                            }
                    }
                    else
                    {

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido CELESTE";
        }

        private void button11_Click(object sender, EventArgs e)//PRENDA 2 
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 3;
                    cGt = 7;
                    cBt = 14;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 37)) && ((cGt <= cGto) && (cGto <= cGt + 54)) && ((cBt <= cBto) && (cBto <= cBt + 103)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 2 && j > 70 && i < 80)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido AZUL";
        }

        private void button12_Click(object sender, EventArgs e)//PRENDA 3
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 119;
                    cGt = 27;
                    cBt = 2;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 101)) && ((cGt <= cGto) && (cGto <= cGt + 104)) && ((cBt <= cBto) && (cBto <= cBt + 39)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 2 && j > 70 && i > 55 && i < 126)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido NARANJA-CAFE";
        }

        private void button13_Click(object sender, EventArgs e)//PRENDA 4
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 22;
                    cGt = 21;
                    cBt = 12;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 73)) && ((cGt <= cGto) && (cGto <= cGt + 87)) && ((cBt <= cBto) && (cBto <= cBt + 81)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 70 && i > 95 && i < 121 && j < 240)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido VERDE";
        }

        private void button14_Click(object sender, EventArgs e)// 5
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 64;
                    cGt = 35;
                    cBt = 41;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 96)) && ((cGt <= cGto) && (cGto <= cGt + 114)) && ((cBt <= cBto) && (cBto <= cBt + 123)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 70 && i > 110 && i < 150 && j < 220)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido VERDE-CELESTE";
        }

        private void button15_Click(object sender, EventArgs e)// 6
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 100;
                    cGt = 8;
                    cBt = 32;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 135)) && ((cGt <= cGto) && (cGto <= cGt + 64)) && ((cBt <= cBto) && (cBto <= cBt + 102)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 133 && i > 182 && i < 243 && j < 277)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido ROSADO";
        }

        private void button16_Click(object sender, EventArgs e)// 7
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 27;
                    cGt = 19;
                    cBt = 16;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 96)) && ((cGt <= cGto) && (cGto <= cGt + 91)) && ((cBt <= cBto) && (cBto <= cBt + 71)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 80 && i > 305 && i < 350 && j < 250)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido VERDE OSCURO";
        }

        private void button17_Click(object sender, EventArgs e)// 8
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 3; i = i + 3)
                for (int j = 0; j < bmp.Height - 3; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 52;
                    cGt = 84;
                    cBt = 24;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 108)) && ((cGt <= cGto) && (cGto <= cGt + 101)) && ((cBt <= cBto) && (cBto <= cBt + 90)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 34 && i > 380 && j < 347)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cc = 0;
                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {
                                c = bmp.GetPixel(k, l);
                                bmp2.SetPixel(k, l, c);
                            }
                    }
                }
            pictureBox2.Image = bmp2;
            textBox4.Text = "Se detecto vestido VERDE CLARO";
        }

        private void button18_Click(object sender, EventArgs e)// todos
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 3;
                    cGt = 7;
                    cBt = 14;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 12)) && ((cGt <= cGto) && (cGto <= cGt + 18)) && ((cBt <= cBto) && (cBto <= cBt + 34)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 70 && i < 80)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {
                        cRt = 3;
                        cGt = 7;
                        cBt = 14;
                        if (((cRt <= cRto) && (cRto <= cRt + 12 + 12)) && ((cGt <= cGto) && (cGto <= cGt + 18 + 18)) && ((cBt <= cBto) && (cBto <= cBt + 34 + 34)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 70 && i < 80)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {
                            cRt = 3;
                            cGt = 7;
                            cBt = 14;
                            if (((cRt <= cRto) && (cRto <= cRt + 12 + 12 + 12)) && ((cGt <= cGto) && (cGto <= cGt + 18 + 18 + 18)) && ((cBt <= cBto) && (cBto <= cBt + 34 + 34 + 34)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 70 && i < 80)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button19_Click(object sender, EventArgs e)//prenda 3 divide
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 119;
                    cGt = 27;
                    cBt = 2;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 34)) && ((cGt <= cGto) && (cGto <= cGt + 35)) && ((cBt <= cBto) && (cBto <= cBt + 13)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 2 && j > 70 && i > 55 && i < 126)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 34 + 34)) && ((cGt <= cGto) && (cGto <= cGt + 35 + 35)) && ((cBt <= cBto) && (cBto <= cBt + 13 + 13)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 2 && j > 70 && i > 55 && i < 126)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 34 + 34 + 34)) && ((cGt <= cGto) && (cGto <= cGt + 35 + 35 + 35)) && ((cBt <= cBto) && (cBto <= cBt + 13 + 13 + 13)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 2 && j > 70 && i > 55 && i < 126)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button20_Click(object sender, EventArgs e)//prenda 4 divide
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 22;
                    cGt = 21;
                    cBt = 12;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 25)) && ((cGt <= cGto) && (cGto <= cGt + 29)) && ((cBt <= cBto) && (cBto <= cBt + 27)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 70 && i > 95 && i < 121 && j < 240)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 25 * 2)) && ((cGt <= cGto) && (cGto <= cGt + 29 * 2)) && ((cBt <= cBto) && (cBto <= cBt + 27 * 2)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 70 && i > 95 && i < 121 && j < 240)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 25 * 3)) && ((cGt <= cGto) && (cGto <= cGt + 29 * 3)) && ((cBt <= cBto) && (cBto <= cBt + 27 * 3)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 70 && i > 95 && i < 121 && j < 240)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 64;
                    cGt = 35;
                    cBt = 41;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 32)) && ((cGt <= cGto) && (cGto <= cGt + 38)) && ((cBt <= cBto) && (cBto <= cBt + 41)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 70 && i > 110 && i < 150 && j < 220)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 32 * 2)) && ((cGt <= cGto) && (cGto <= cGt + 38 * 2)) && ((cBt <= cBto) && (cBto <= cBt + 41 * 2)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 70 && i > 110 && i < 150 && j < 220)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 32 * 3)) && ((cGt <= cGto) && (cGto <= cGt + 38 * 3)) && ((cBt <= cBto) && (cBto <= cBt + 41 * 3)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 70 && i > 110 && i < 150 && j < 220)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button22_Click(object sender, EventArgs e)//dividir 6
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 100;
                    cGt = 8;
                    cBt = 32;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 45)) && ((cGt <= cGto) && (cGto <= cGt + 22)) && ((cBt <= cBto) && (cBto <= cBt + 34)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 133 && i > 182 && i < 243 && j < 277)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 45 * 2)) && ((cGt <= cGto) && (cGto <= cGt + 22 * 2)) && ((cBt <= cBto) && (cBto <= cBt + 34 * 2)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 133 && i > 182 && i < 243 && j < 277)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 45 * 3)) && ((cGt <= cGto) && (cGto <= cGt + 22 * 3)) && ((cBt <= cBto) && (cBto <= cBt + 34 * 3)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 133 && i > 182 && i < 243 && j < 277)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button23_Click(object sender, EventArgs e)//dividir 7
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 27;
                    cGt = 19;
                    cBt = 16;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 32)) && ((cGt <= cGto) && (cGto <= cGt + 31)) && ((cBt <= cBto) && (cBto <= cBt + 24)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 1 && j > 80 && i > 305 && i < 350 && j < 250)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 32 * 2)) && ((cGt <= cGto) && (cGto <= cGt + 31 * 2)) && ((cBt <= cBto) && (cBto <= cBt + 24 * 2)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 80 && i > 305 && i < 350 && j < 250)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 32 * 3)) && ((cGt <= cGto) && (cGto <= cGt + 31 * 3)) && ((cBt <= cBto) && (cBto <= cBt + 24 * 3)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 80 && i > 305 && i < 350 && j < 250)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }

        private void button24_Click(object sender, EventArgs e)//dividir 8
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            int cRto, cGto, cBto;
            Color c = new Color();
            cc = 0;
            for (int i = 0; i < bmp.Width - 10; i = i + 3)
                for (int j = 0; j < bmp.Height - 10; j = j + 3)
                {

                    cRto = 0; cGto = 0; cBto = 0;
                    for (int k = i; k < i + 3; k++)
                        for (int l = j; l < j + 3; l++)
                        {
                            c = bmp.GetPixel(k, l);
                            cRto = c.R + cRto; cGto = c.G + cGto; cBto = c.B + cBto;
                        }
                    cRto = cRto / 9;
                    cGto = cGto / 9;
                    cBto = cBto / 9;
                    cRt = 52;
                    cGt = 84;
                    cBt = 24;

                    c = bmp.GetPixel(i, j);
                    if (((cRt <= cRto) && (cRto <= cRt + 36)) && ((cGt <= cGto) && (cGto <= cGt + 34)) && ((cBt <= cBto) && (cBto <= cBt + 30)))
                    {
                        cc = cc + 1;

                        for (int k = i; k < i + 3; k++)
                            for (int l = j; l < j + 3; l++)
                            {

                                if (cc >= 5 && j > 34 && i > 380 && j < 347)
                                {


                                    bmp2.SetPixel(k, l, Color.Red);


                                }
                                else
                                {

                                    c = bmp.GetPixel(k, l);
                                    bmp2.SetPixel(k, l, c);
                                }



                            }
                    }
                    else
                    {

                        if (((cRt <= cRto) && (cRto <= cRt + 36 * 2)) && ((cGt <= cGto) && (cGto <= cGt + 34 * 2)) && ((cBt <= cBto) && (cBto <= cBt + 30 * 2)))
                        {
                            cc = cc + 1;

                            for (int k = i; k < i + 3; k++)
                                for (int l = j; l < j + 3; l++)
                                {

                                    if (cc >= 1 && j > 34 && i > 380 && j < 347)
                                    {


                                        bmp2.SetPixel(k, l, Color.Yellow);


                                    }
                                    else
                                    {

                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }



                                }

                        }
                        else
                        {

                            if (((cRt <= cRto) && (cRto <= cRt + 36 * 3)) && ((cGt <= cGto) && (cGto <= cGt + 34 * 3)) && ((cBt <= cBto) && (cBto <= cBt + 30 * 3)))
                            {
                                cc = cc + 1;

                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {

                                        if (cc >= 1 && j > 34 && i > 380 && j < 347)
                                        {


                                            bmp2.SetPixel(k, l, Color.White);


                                        }
                                        else
                                        {

                                            c = bmp.GetPixel(k, l);
                                            bmp2.SetPixel(k, l, c);
                                        }



                                    }

                            }
                            else
                            {
                                cc = 0;
                                for (int k = i; k < i + 3; k++)
                                    for (int l = j; l < j + 3; l++)
                                    {
                                        c = bmp.GetPixel(k, l);
                                        bmp2.SetPixel(k, l, c);
                                    }
                            }



                        }
                    }
                    //------------------------------------------------------------------------


                }
            pictureBox2.Image = bmp2;
        }
    }
}
