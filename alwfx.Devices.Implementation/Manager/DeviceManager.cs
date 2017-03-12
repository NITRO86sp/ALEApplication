using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using alwfx.Data;
using alwfx.Devices.DTO;
using alwfx.Devices.Manager;
using alwfx.Domain;

namespace alwfx.Devices.Implementation.Manager
{
    /// <summary>
    /// Manager class for handling device entities
    /// </summary>
    public class DeviceManager : IDeviceManager
    {
        private readonly IRepository<Device> _deviceRepository;

        public DeviceManager(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        /// <summary>
        /// Reads devices in repository
        /// </summary>
        /// <returns>All devices in repository</returns>
        public IEnumerable<Device> GetDevices()
        {
            return _deviceRepository.GetAll();
        }

        /// <summary>
        /// Updates a device entity in the device repository
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateDevice(Device entity)
        {
            _deviceRepository.Update(entity);
        }

        /// <summary>
        /// Runs every time interval to update the UI
        /// </summary>
        public void UpdateUIDevice(ref DeviceDTO device, int timeEmulationInterval)
        {
            if (device.Status == Status.Enabled.ToString())
            {
                
                if (device.Mode == Mode.On.ToString())
                {
                    //during normal Use
                    device.Timer = device.Timer - timeEmulationInterval;
                    var newRemaining = 100*device.Timer/Int32.Parse(device.ToNotification);
                    if (0 <= newRemaining)
                        device.Remainingpercent = newRemaining;
                    if (device.Timer <= 0)
                    {
                        //entering notification mode
                        device.Timer = Int32.Parse(device.ToAlert);
                        device.Remainingpercent = 100;
                        device.Mode = Mode.Notification.ToString();
                        device.ForeColorOfBar = Color.Yellow;
                        device.BackColorOfBar = Color.DarkOrange;
                    }
                }
                else if (device.Mode == Mode.Notification.ToString())
                {
                    device.Timer = device.Timer - timeEmulationInterval;
                    var newRemaining = 100 * device.Timer / Int32.Parse(device.ToAlert);
                    if (0 <= newRemaining)
                        device.Remainingpercent = newRemaining;
                    //during notification
                    if (device.Timer <= 0)
                    {
                        //entering alert mode
                        device.Timer = Int32.Parse(ConfigurationManager.AppSettings["alertTime"]);
                        device.Remainingpercent = 100;
                        device.Mode = Mode.Alert.ToString();
                        device.ForeColorOfBar = Color.DarkOrange;
                        device.BackColorOfBar = Color.Red;
                    }
                }
                else if (device.Mode == Mode.Alert.ToString())
                {
                    device.Timer = device.Timer - timeEmulationInterval;

                    var newRemaining = 100 * device.Timer / Int32.Parse(ConfigurationManager.AppSettings["alertTime"]);
                    if (0 <= newRemaining)
                        device.Remainingpercent = newRemaining;
                    //during alert
                    if (device.Timer <= 0)
                    {
                        //disable power
                        device.Timer = 0;
                        device.Mode = Mode.Off.ToString();
                        device.Status = Status.Disabled.ToString();
                    }
                }
            }
            else
            {
                //device resets
                device.Mode = Mode.Off.ToString();
                device.Timer = 0;
                //if we wish to have a full reset situation instead of a "screenshot" of the timers when mass reset occurs, we add device.Remainingpercent = 0;
            }
        }
    }
}
