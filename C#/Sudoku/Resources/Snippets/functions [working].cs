//Checking rows for an unique value

public int rowChk(int row, int cell, int val)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Convert.ToInt32(DGV.Rows[row].Cells[i].Value) == val)
                    count++;
            }
            if (count > 0)
                return 0;
            else return 1;
        }
		
//Checking columns for an unique value		
		
 public int colChk(int row, int cell, int val)
        {
            int count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (Convert.ToInt32(DGV.Rows[i].Cells[cell].Value) == val)
                    count++;
            }
            if (count > 0)
                return 0;
            else return 1;
        }
		
//Adding numbers to board
		
		private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            while (max >= 0)
            {
                int row_rnd = rnd.Next(DGV.Rows.Count);
                int cell_rnd = rnd.Next(DGV.ColumnCount);
                int val = rnd.Next(1, 10);

                if (rowChk(row_rnd, cell_rnd, val) == 1 && colChk(row_rnd, cell_rnd, val) == 1)
                {
                    DGV.Rows[row_rnd].Cells[cell_rnd].Value = val;
                    max--;
                }
                
            }     
        }