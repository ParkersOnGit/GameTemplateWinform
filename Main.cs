namespace GameTemplate
{
    public partial class Main : Form
    {
        /*
            Setup:
            - Copy base code from Main.cs (namespace, class, and constructor may be differently named) or you could rename class to "Main"
            - Change BackgroundImageLayout to Zoom
            - Set BackColor to any color (will be the back of the color when the window is not the frameBuffer size ratio)
            - Code you game!!
         */
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private Bitmap frameBuffer;
        private Graphics g => Graphics.FromImage(frameBuffer);
        Size windowSize;

        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            Size frameSize = new Size(1920, 1080);
            frameBuffer = new Bitmap(frameSize.Width, frameSize.Height);

            gameTimer.Interval = 17; // ~60 FPS
            gameTimer.Tick += (s, e) =>
            {
                UpdateGameLogic();
                DrawGraphics();
            };
            gameTimer.Start();
        }

        private void UpdateGameLogic()
        {
            // Update your game logic here
        }

        private void DrawGraphics()
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(Color.Black); // can be any color
            
            // do drawing stuff here
            
            this.BackgroundImage = frameBuffer;
            GC.Collect();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Fullscreen toggle
                case Keys.Tab:
                case Keys.F11:
                    if (this.FormBorderStyle == FormBorderStyle.Sizable)
                    {
                        windowSize = this.Size;
                        this.FormBorderStyle = FormBorderStyle.None;
                        this.WindowState = FormWindowState.Maximized;
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.Sizable;
                        this.Size = windowSize;
                    }
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
