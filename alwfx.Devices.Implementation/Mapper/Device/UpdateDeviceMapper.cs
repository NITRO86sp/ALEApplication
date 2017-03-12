using System;
using alwfx.Devices.DTO;
using alwfx.Devices.Mapper.Device;
using alwfx.Domain;

namespace alwfx.Devices.Implementation.Mapper.Device
{
    public class UpdateDeviceMapper : IUpdateDeviceMapper
    {
        /// <summary>
        /// The transform method of the IUpdateDeviceMapper
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Domain.Device Transform(DeviceDTO entity)
        {
            var device = new Domain.Device
            {
                Id = entity.Id,
                Name = entity.Name,
                ToAlert = Int32.Parse(entity.ToAlert),
                ToNotification = Int32.Parse(entity.ToNotification)
            };

            if (entity.Mode != Mode.Off.ToString())
                device.Status = Status.Disabled;
            else
            {
                device.Status = Status.Enabled;
                device.Mode = Mode.Off;
            }

            return device;
        }
    }
}
