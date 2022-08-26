namespace WinForms
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.formContainerControl1 = new WinForms.FormContainerControl();
      this.SuspendLayout();
      // 
      // formContainerControl1
      // 
      this.formContainerControl1.AutoScroll = true;
      this.formContainerControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.formContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.formContainerControl1.Location = new System.Drawing.Point(0, 0);
      this.formContainerControl1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
      this.formContainerControl1.Name = "formContainerControl1";
      this.formContainerControl1.Size = new System.Drawing.Size(1016, 1035);
      this.formContainerControl1.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1016, 1035);
      this.Controls.Add(this.formContainerControl1);
      this.Name = "MainForm";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private FormContainerControl formContainerControl1;
  }
}

