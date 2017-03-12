using System.Collections.Generic;
using alwfx.Devices.DTO;
using alwfx.Domain;

namespace alwfx.Devices.Manager
{
    /// <summary>
    /// Manager class for handling device entities
    /// </summary>
    public interface IDeviceManager
    {
        /// <summary>
        /// Reads devices in repository
        /// </summary>
        /// <returns>All devices in repository</returns>
        IEnumerable<Device> GetDevices();

        /// <summary>
        /// Updates a device entity in the device repository
        /// </summary>
        /// <param name="entity"></param>
        void UpdateDevice(Device entity);

        /// <summary>
        /// Runs every time interval to update the UI
        /// </summary>
        /// <param name="device"></param>
        /// <param name="timeEmulationInterval"></param>
        void UpdateUIDevice(ref DeviceDTO device, int timeEmulationInterval);
    }
}
