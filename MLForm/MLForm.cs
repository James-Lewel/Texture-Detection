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

        public MLForm()
        {
            InitializeComponent();
            PopulateCameraComboBox();

            // Create a timer to update the UI (60 FPS)
            Timer timer = new Timer();
            timer.Interval = 15; // 60 FPS
            timer.Tick += new EventHandler(UpdateUI);
            timer.Start();
        }

        // Populate the cameraComboBox with available camera devices
        private void PopulateCameraComboBox()
        {
            // Clear existing items in the comboBox
            cameraComboBox.Items.Clear();

            // Add an empty string as the first item
            cameraComboBox.Items.Add("");

            // Enumerate all available camera devices (up to 10)
            for (int cameraIndex = 0; cameraIndex < 10; cameraIndex++)
            {
                // Create a VideoCapture object to check if the camera is available
                capture = new VideoCapture(cameraIndex);
                if (capture.IsOpened())
                {
                    string cameraName = $"Camera {cameraIndex}";
                    cameraComboBox.Items.Add(cameraName);
                }
            }

            cameraComboBox.SelectedIndex = 0;
        }

        // Start capturing frames from the selected camera
        private async void StartCamera()
        {
            // Check if a valid camera is selected
            if (cameraComboBox.SelectedIndex < 1)
            {
                return;
            }

            int selectedCameraIndex = cameraComboBox.SelectedIndex;
            capture = new VideoCapture(selectedCameraIndex);

            // Check if the camera is opened successfully
            if (capture.IsOpened())
            {
                // Initialize the frame Mat object
                frame = new Mat();

                // Start capturing frames in a background task
                await Task.Run(() => CaptureFrames());
            }
            else
            {
                MessageBox.Show("Error opening the selected camera.");
            }
        }

        // Capture frames from the camera
        private void CaptureFrames()
        {
            while (capture.IsOpened())
            {
                // Capture a frame from the camera
                capture.Read(frame);

                // Check if the frame is valid
                if (!frame.Empty())
                {
                    // Ensure UI updates are done on the UI thread
                    BeginInvoke(new Action(() =>
                    {
                        cameraOutput.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame);
                    }));
                }
                else
                {
                    // Handle the case where the captured frame is null or empty
                    MessageBox.Show("Error capturing frame from the camera.");
                    break;
                }
            }

            // Release resources when done capturing frames
            capture.Release();
        }

        // Update the UI with frame information
        private void UpdateUI(object sender, EventArgs e)
        {
            // Check if the capture and frame are available
            if (capture != null && !frame.Empty())
            {
                // Process AI prediction
                UpdateAI();
            }

            // Calculate FPS
            UpdateFPS();
        }

        // Update the FPS label
        private void UpdateFPS()
        {
            // Calculate the time elapsed since the last frame
            TimeSpan elapsed = DateTime.Now - lastFrameTime;

            // Increment the frame count
            frameCount++;

            // Calculate FPS as frames per second
            double fps = frameCount / elapsed.TotalSeconds;

            // Update the fpsLabel with the calculated FPS
            fpsLabel.Text = $"FPS: {fps:F2}";

            // Reset frame count and update last frame time
            if (elapsed.TotalSeconds >= 1.0)
            {
                frameCount = 0;
                lastFrameTime = DateTime.Now;
            }
        }

        // Update the AI prediction
        private void UpdateAI()
        {
            // Convert the captured frame (Mat) to a byte array
            using (var ms = new MemoryStream())
            {
                OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame).Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                var imageBytes = ms.ToArray();

                // Create a ModelInput object for prediction
                MLApp.ModelInput sampleData = new MLApp.ModelInput()
                {
                    ImageSource = imageBytes,
                };

                // Make a prediction
                var predictionResult = MLApp.Predict(sampleData);

                // Update the outputLabel with the predicted label
                outputLabel.Text = $"Predicted Label:\n{predictionResult.PredictedLabel}";
            }
        }


        // Handle camera selection change event
        private void cameraComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Stop and release the previous camera capture (if any)
            if (capture != null)
            {
                capture.Release();
                capture = null;
            }

            // Start capturing from the selected camera
            StartCamera();
        }

        // Dispose of resources when the form is closed
        private void MLForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (capture != null)
            {
                capture.Release();
                capture = null;
            }
            frame?.Dispose();
        }
    }
}
