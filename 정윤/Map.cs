using C_TeamProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace C_TeamProject 
{ 
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Locale> locales = KaKaoAPI.Search(textBox1.Text); // 대구라고 쿼리에 쳐서 그 응답한 값들이 나옴
            listBox1.Items.Clear();
            foreach (Locale item in locales)
                listBox1.Items.Add(item);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // 특정 키를 누르고 다시 그 키가 올라올 때 이벤트가 호출 됨
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) // 엔터 키 누르고 다시 올라올 때 
                button1.PerformClick(); // 클릭 강제 호출
        }

        // 특정 부분 클릭 시 이벤트 호출 
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                return;
            Locale ml = listBox1.SelectedItem as Locale; // 클릭한 걸 Locale로 변경
            object[] pos = new object[] { ml.Lat, ml.Lng };
            HtmlDocument hdoc = webBrowser1.Document;
            hdoc.InvokeScript("setCenter", pos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearForm();
            Hide();
            new Login().ShowDialog();
        }
        private void ClearForm()
        {
            textBox1.Text = "";
            
        }
    }
}
