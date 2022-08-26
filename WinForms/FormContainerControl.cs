using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
  public sealed class FormContainerControl : UserControl
  {
    public FormContainerControl()
    {
      const int rowCount = 100;
      const int columnCount = 2;

      SuspendLayout();

      TableLayoutPanel layout = new TableLayoutPanel
      {
        Name = nameof(layout),
        RowCount = rowCount,
        ColumnCount = columnCount,
        AutoSize = true,
        BackColor = Color.Green,
        Padding = new Padding(4)
      };

      layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
      layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));

      layout.SuspendLayout();

      for (int row = 0; row < rowCount; ++row)
      {
        layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));

        Label label = new Label
        {
          Name = $"label{row}",
          Text = $"Some label {row}"
        };

        layout.Controls.Add(label, 0, row);

        CheckBox box = new CheckBox
        {
          Name = $"box{row}",
          Text = $"Some check box {row}"
        };
        
        layout.Controls.Add(box, 1, row);
      }

      layout.ResumeLayout();

      Controls.Add(layout);

      AutoSizeMode = AutoSizeMode.GrowAndShrink;
      AutoScaleDimensions = new SizeF(6.0F, 13.0F);
      AutoScaleMode = AutoScaleMode.Font;
      AutoScroll = true;
      VScroll = true;

      //Size = layout.PreferredSize;

      ResumeLayout();
    }
  }
}
