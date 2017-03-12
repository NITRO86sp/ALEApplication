using System;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using alwfx.Devices.DTO;
using alwfx.Devices.Manager;
using alwfx.Devices.Mapper.Device;
using alwfx.Domain;
using alwfx.UI.Infrastructure.Helpers;
using alwfx.UI.Properties;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace alwfx.UI
{
    public partial class Form1 : Form
    {
        private readonly IDeviceManager _deviceManager;
        private readonly IDeviceMapper _deviceMapper;
        private readonly IUpdateDeviceMapper _updateDeviceMapper;

        private int timerTaskInterval;
        private int oneMinuteEmulationInterval;
        private DeviceDTO[] _deviceDTOs;
        private Timer _emulationTimer;

        /// <summary>
        /// Arguments are injected from application module bindings
        /// </summary>
        /// <param name="deviceManager"></param>
        /// <param name="deviceMapper"></param>
        /// <param name="updateDeviceMapper"></param>
        public Form1(IDeviceManager deviceManager, IDeviceMapper deviceMapper, IUpdateDeviceMapper updateDeviceMapper)
        {
            timerTaskInterval = Int32.Parse(ConfigurationManager.AppSettings["timerTaskInterval"]);
            _deviceManager = deviceManager;
            _deviceMapper = deviceMapper;
            _updateDeviceMapper = updateDeviceMapper;
            oneMinuteEmulationInterval = Int32.Parse(ConfigurationManager.AppSettings["oneMinuteEmulationInterval"]);
            _emulationTimer = new Timer { Enabled = false, Interval = timerTaskInterval };
            _emulationTimer.Tick += Tick;
            InitializeComponent();
        }

        /// <summary>
        /// Runs on application launch
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            base.Text = "Assisted Living Emulation Application";
            //Set form title

            //Set time interval label text
            oneMinuteEmulationIntervalLabel.Text = (1000.0 / oneMinuteEmulationInterval).ToString("G3", CultureInfo.InvariantCulture) + "min/sec";

            //Get devices from the device manager
            var devices = _deviceManager.GetDevices();

            //We now know the number of devices so we initialize the array
            _deviceDTOs = new DeviceDTO[devices.Count()];
            var i = 0;

            //Generate UI elements for devices
            foreach (var device in devices)
            {
                var deviceDTO = _deviceMapper.Transform(device);

                //Add a panel for current device to contain its controls
                var deviceTablePanel = new TableLayoutPanel {Size = new Size(100, 140)};

                var deviceNameLabel = new Label
                {
                    Text = deviceDTO.Name,
                    Width = Convert.ToInt32(deviceTablePanel.Width * 0.9),
                    TextAlign = ContentAlignment.TopCenter
                };

                var deviceModeLabel = new Label
                {
                    Text = deviceDTO.Mode,
                    Width = Convert.ToInt32(deviceTablePanel.Width * 0.9),
                    TextAlign = ContentAlignment.TopCenter
                };

                //Bind current device's mode value to the text property of mode label
                deviceModeLabel.DataBindings.Add(new Binding("Text", deviceDTO, "Mode"));

                var deviceStatusLabel = new Label
                {
                    Text = deviceDTO.Status,
                    Width = Convert.ToInt32(deviceTablePanel.Width * 0.9),
                    TextAlign = ContentAlignment.TopCenter
                };

                //Bind current device's status value to the text property of status label
                deviceStatusLabel.DataBindings.Add(new Binding("Text", deviceDTO, "Status"));

                var timerProgressBar = new ProgressBar();

                timerProgressBar.Height = 18;
                timerProgressBar.Width = Convert.ToInt32(deviceTablePanel.Width*0.9);
                timerProgressBar.Value = deviceDTO.Remainingpercent;
                timerProgressBar.DataBindings.Add(new Binding("Value", deviceDTO, "Remainingpercent"));
                timerProgressBar.ForeColor =deviceDTO.ForeColorOfBar;
                timerProgressBar.Style = ProgressBarStyle.Continuous;
                Console.Out.WriteLine("MPHKE " + timerProgressBar.ForeColor + deviceDTO.ForeColorOfBar);
                timerProgressBar.DataBindings.Add(new Binding("ForeColor", deviceDTO, "ForeColorOfBar"));
                timerProgressBar.BackColor = deviceDTO.BackColorOfBar;
                Console.Out.WriteLine("MPHKE 2 " + timerProgressBar.BackColor + deviceDTO.BackColorOfBar);
                timerProgressBar.DataBindings.Add(new Binding("BackColor", deviceDTO, "BackColorOfBar"));


                var deviceSwitchButton = new Button()
                {
                    Width = Convert.ToInt32(deviceTablePanel.Width * 0.9),
                    Name = deviceDTO.Name
                };

                deviceSwitchButton.Text = deviceDTO.Mode.Equals(Mode.Off.ToString())
                    ? Resources.DeviceOff
                    : Resources.DeviceOn;
                
                deviceSwitchButton.BackColor = !deviceSwitchButton.Text.Equals(Resources.DeviceOff) ? Color.DarkGreen : Color.DarkRed;
                deviceSwitchButton.ForeColor = Color.White;

                deviceSwitchButton.Click += (sender, args) =>
                {
                    var currentButton = (Button)sender;

                    if (currentButton.Text.Equals(Resources.DeviceOn))
                    {
                        currentButton.Text = Resources.DeviceOff;
                        currentButton.BackColor = Color.DarkRed;

                        //Update device panel
                        deviceDTO.Mode = Mode.Off.ToString();
                        deviceDTO.Timer = 0;
                        timerProgressBar.Value = 0;
                        deviceDTO.ForeColorOfBar = Color.DarkGray;
                        deviceDTO.BackColorOfBar = Color.DarkGray;
                    }
                    else if (currentButton.Text.Equals(Resources.DeviceOff) &&
                       deviceDTO.Status == Status.Enabled.ToString())
                    {
                        currentButton.Text = Resources.DeviceOn;
                        currentButton.BackColor = Color.DarkGreen;
                        deviceDTO.ForeColorOfBar = Color.Lime;
                        deviceDTO.BackColorOfBar = Color.Yellow;

                        //Update device panel
                        deviceDTO.Mode = Mode.On.ToString();
                        deviceDTO.Timer = Int32.Parse(deviceDTO.ToNotification);
                    }
                };

                _deviceDTOs[i] = deviceDTO;
                i++;

                deviceTablePanel.Controls.Add(deviceNameLabel);
                deviceTablePanel.Controls.Add(deviceModeLabel);
                deviceTablePanel.Controls.Add(deviceStatusLabel);
                deviceTablePanel.Controls.Add(timerProgressBar);
                deviceTablePanel.Controls.Add(deviceSwitchButton);

                devicesArea.Controls.Add(deviceTablePanel);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //We don't mind to use foreach here because we don't need to iterate by reference.
            //After this, objects are disposed
            foreach (var device in _deviceDTOs)
                _deviceManager.UpdateDevice(_updateDeviceMapper.Transform(device));

            base.OnClosing(e);
        }

        #region Handlers

        #region Click Handlers

        /// <summary>
        /// Increase time interval for UI refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void increaseSpeed_Click(object sender, EventArgs e)
        {
            if (oneMinuteEmulationInterval <= 1000)
            {
                if (oneMinuteEmulationInterval > 125)
                    oneMinuteEmulationInterval = oneMinuteEmulationInterval / 2;
            }
            else
                oneMinuteEmulationInterval -= 1000;

            oneMinuteEmulationIntervalLabel.Text = (1000.0 / oneMinuteEmulationInterval).ToString("G3", CultureInfo.InvariantCulture) + "min/sec";
        }

        /// <summary>
        /// Decrease time interval for UI refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decreaseSpeed_Click(object sender, EventArgs e)
        {
            if (oneMinuteEmulationInterval < 1000)
                oneMinuteEmulationInterval *= 2;
            else if (oneMinuteEmulationInterval < 20000)
                oneMinuteEmulationInterval += 1000;

            oneMinuteEmulationIntervalLabel.Text = (1000.0 / oneMinuteEmulationInterval).ToString("G3", CultureInfo.InvariantCulture) + "min/sec";
        }

        /// <summary>
        /// Runs when the reset button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            if (_emulationTimer.Enabled)
            {
                _emulationTimer.Stop();
                emulationSwitch.Text = Resources.StartEmulation;
                emulationSwitch.BackColor = Color.DarkGreen;
                increaseSpeedButton.Enabled = true;
                decreaseSpeedButton.Enabled = true;
            }

            for (var i = 0; i < _deviceDTOs.Length; i++)
            {
                _deviceDTOs[i].Status = Status.Enabled.ToString();
                _deviceDTOs[i].Mode = Mode.Off.ToString();
                _deviceDTOs[i].Timer = 0;
                _deviceDTOs[i].Remainingpercent = 0;
                _deviceDTOs[i].ForeColorOfBar = Color.DarkGray;
                _deviceDTOs[i].BackColorOfBar = Color.DarkGray;
                var deviceButton = Controls.Find(_deviceDTOs[i].Name, true).Single();
                deviceButton.Enabled = true;
                deviceButton.Text = Resources.DeviceOff;
                deviceButton.BackColor = Color.DarkRed;
            }
        }

        #endregion

        /// <summary>
        /// Runs when toggling Start/Stop emulation button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void emulationTimer_Click(object sender, EventArgs e)
        {
            if (!_emulationTimer.Enabled)
            {
                _emulationTimer.Interval = timerTaskInterval;
                _emulationTimer.Start();
                emulationSwitch.Text = Resources.StopEmulation;
                emulationSwitch.BackColor = Color.DarkRed;
                increaseSpeedButton.Enabled = false;
                decreaseSpeedButton.Enabled = false;
            }
            else
            {
                _emulationTimer.Stop();
                emulationSwitch.Text = Resources.StartEmulation;
                emulationSwitch.BackColor = Color.DarkGreen;
                increaseSpeedButton.Enabled = true;
                decreaseSpeedButton.Enabled = true;
            }
        }

        /// <summary>
        /// Runs every time interval if emulation is running
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Tick(object sender, EventArgs e)
        {

        for (var i = 0; i < _deviceDTOs.Length; i++)
        {
            _deviceManager.UpdateUIDevice(ref _deviceDTOs[i], timerTaskInterval * 1000 / oneMinuteEmulationInterval);
                    
            if (_deviceDTOs[i].Status.Equals(Status.Disabled.ToString()))
            {
                _emulationTimer.Stop();
                emulationSwitch.Text = Resources.StartEmulation;
                emulationSwitch.BackColor = Color.DarkGreen;
                increaseSpeedButton.Enabled = true;
                decreaseSpeedButton.Enabled = true;
                        
                for (var j = 0; j < _deviceDTOs.Length; j++)
                {
                    _deviceDTOs[j].Status = Status.Disabled.ToString();
                    _deviceDTOs[j].ForeColorOfBar = Color.Gray;
                    _deviceDTOs[j].BackColorOfBar = Color.Gray;
                    ButtonHelpers.Disable((Button)Controls.Find(_deviceDTOs[j].Name, true).Single());
                }
            }
        }
        }

        #endregion
    }
}
