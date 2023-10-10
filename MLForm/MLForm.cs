using OpenCvSharp;
using Timer = System.Windows.Forms.Timer;

namespace Texture_Detection
{
    public partial class MLForm : Form
    {
        private VideoCapture capture;
        private Mat frame;
        private DateTime lastFrameTime = DateTime.Now;
        private int frameCount = 0;

        private readonly Timer predictTimer = new Timer();
        private readonly Timer fpsTimer = new Timer();
        private readonly SemaphoreSlim predictionSemaphore = new SemaphoreSlim(1);

        public MLForm()
        {
            InitializeComponent();
            PopulateCameraComboBox();

            fpsTimer.Interval = 33;
            fpsTimer.Tick += UpdateFPS;
            fpsTimer.Start();
        }

        private void PopulateCameraComboBox()
        {
            cameraComboBox.Items.Clear();
            cameraComboBox.Items.Add("");

            for (int cameraIndex = 0; cameraIndex < 10; cameraIndex++)
            {
                capture = new VideoCapture(cameraIndex);
                if (capture.IsOpened())
                {
                    cameraComboBox.Items.Add($"Camera {cameraIndex}");
                }
            }

            cameraComboBox.SelectedIndex = 0;
        }

        private async void StartCameraAsync()
        {
            if (cameraComboBox.SelectedIndex == 0) return;

            int selectedCameraIndex = cameraComboBox.SelectedIndex;
            capture = new VideoCapture(selectedCameraIndex);

            if (capture.IsOpened())
            {
                frame = new Mat();
                await Task.Run(CaptureFrames);
            }
            else
            {
                MessageBox.Show("Error opening the selected camera.");
            }
        }

        private void CaptureFrames()
        {
            while (capture.IsOpened())
            {
                capture.Read(frame);

                if (!frame.Empty())
                {
                    BeginInvoke(new Action(() =>
                    {
                        cameraOutput.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    }));
                }
                else
                {
                    MessageBox.Show("Error capturing frame from the camera.");
                    break;
                }
            }

            capture.Release();
        }

        private void UpdateFPS(object sender, EventArgs e)
        {
            TimeSpan elapsed = DateTime.Now - lastFrameTime;
            frameCount++;

            double fps = frameCount / elapsed.TotalSeconds;
            fpsLabel.Text = $"FPS: {fps:F2}";

            if (elapsed.TotalSeconds >= 1.0)
            {
                frameCount = 0;
                lastFrameTime = DateTime.Now;
            }
        }

        private async Task UpdateAIAsync()
        {
            await predictionSemaphore.WaitAsync();
            try
            {
                using (var ms = new MemoryStream())
                {
                    OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    var imageBytes = ms.ToArray();

                    MLApp.ModelInput sampleData = new MLApp.ModelInput()
                    {
                        ImageSource = imageBytes,
                    };

                    var predictionResult = await Task.Run(() => MLApp.Predict(sampleData));

                    BeginInvoke(new Action(() =>
                    {
                        outputLabel.Text = $"Predicted Label:\n{predictionResult.PredictedLabel}";
                    }));
                }
            }
            finally
            {
                predictionSemaphore.Release();
            }
        }

        private void MLForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            capture?.Release();
            frame?.Dispose();
        }

        private void predictButton_Click(object sender, EventArgs e)
        {
            if (cameraComboBox.SelectedIndex == 0) return;

            predictTimer.Interval = 500;
            predictTimer.Tick += async (s, args) => await UpdateAIAsync();
            predictTimer.Start();

            cameraComboBox.Enabled = false;
            predictButton.Enabled = false;
            stopButton.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            predictTimer.Stop();

            cameraComboBox.Enabled = true;
            predictButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (capture != null)
            {
                capture.Release();
                capture = null;
            }

            StartCameraAsync();
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            // Your captureButton_Click logic here
        }
    }
}
