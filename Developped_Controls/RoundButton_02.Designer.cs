
namespace Applications_01.Developped_Controls
{
    partial class RoundButton_02
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RoundButton_02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "RoundButton_02";
            this.Size = new System.Drawing.Size(167, 54);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnDraw);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseButton_Down);
            this.MouseLeave += new System.EventHandler(this.MouseLeft);
            this.MouseHover += new System.EventHandler(this.MouseHovered);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Mouse_Up);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
