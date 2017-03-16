private void btnWrite_Click(object sender, EventArgs e)
        {
            System.IO.File.WriteAllText(@"C:\Users\Alexandru\Desktop\C#.txt", richTextBox1.Text, Encoding.ASCII);
        }

private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files|*.txt";
            sfd.DefaultExt = "txt";   
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter SW = new System.IO.StreamWriter(sfd.FileName, false, Encoding.ASCII);
                SW.Write(richTextBox1.Text);
                SW.Close();
            }
        }
 private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt";
            ofd.DefaultExt = "txt";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader SR = new System.IO.StreamReader(ofd.FileName);
                richTextBox1.Text = SR.ReadToEnd();
            }
        }