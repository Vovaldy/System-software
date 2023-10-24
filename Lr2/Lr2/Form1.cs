using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox3.Text = (Convert.ToInt32(textBox1.Text)
            //+ Convert.ToInt32(textBox2.Text)).ToString();
            var process = new Process();

            if (textBox1.Text!=null && textBox2.Text !=null)
            {
                process.StartInfo.Arguments = $"{textBox1.Text}{textBox2.Text}";
                process.StartInfo.FileName = @"C:\Users\raek0\OneDrive\Документы\GitHub\System-software\Lr2\App2\bin\Release\net6.0\App2.exe";

                process.Start();
            }
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Создание участка разделяемой памяти
            //Первый параметр - название участка, 
            //второй - длина участка памяти в байтах: тип char  занимает 2 байта 
            //плюс четыре байта для одного объекта типа Integer
            int size = textBox1.Text.Length + textBox2.Text.Length;
            int[] message = new int[2];
            message[0] = Convert.ToInt32(textBox1.Text);
            message[1] = Convert.ToInt32(textBox2.Text);
            MemoryMappedFile sharedMemory = MemoryMappedFile.CreateOrOpen("MemoryFile", size * 4 + 4);

            //Создаем объект для записи в разделяемый участок памяти
            using (MemoryMappedViewAccessor writer = sharedMemory.CreateViewAccessor(0, size * 4 + 4))
            {
                //запись в разделяемую память
                //запис ь размера с нулевого байта в разделяемой памяти
                writer.Write(0, size);
                //запись сообщения с четвертого байта в разделяемой памяти
                writer.WriteArray<int>(4, message, 0, size);
            }
            var process = new Process();
            process.StartInfo.FileName = @"C:\Users\raek0\OneDrive\Документы\GitHub\System-software\Lr2\App2\bin\Release\net6.0\App2.exe";

            process.Start();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


    }
}
