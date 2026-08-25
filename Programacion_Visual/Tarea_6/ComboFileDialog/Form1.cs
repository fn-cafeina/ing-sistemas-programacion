namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            if (comboBox1.SelectedIndex == 2)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            }

            if (comboBox1.SelectedIndex == 3)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }

            if (comboBox1.SelectedIndex == 4)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.Title = "Selecciona una imagen";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
