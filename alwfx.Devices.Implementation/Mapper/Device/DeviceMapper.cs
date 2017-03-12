using System.Drawing;
using System.Globalization;
using alwfx.Devices.DTO;
using alwfx.Devices.Mapper.Device;

namespace alwfx.Devices.Implementation.Mapper.Device
{
    public class DeviceMapper : IDeviceMapper
    {
        /// <summary>
        /// The transform method of the IDeviceMapper
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DeviceDTO Transform(Domain.Device entity)
        {
            return new DeviceDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Mode = entity.Mode.ToString(),
                Status = entity.Status.ToString(),
                ToAlert = entity.ToAlert.ToString(CultureInfo.InvariantCulture),
                ToNotification = entity.ToNotification.ToString(CultureInfo.InvariantCulture),
                Timer = 0,
                Remainingpercent = 0,
                ForeColorOfBar = Color.DarkGray,
                BackColorOfBar = Color.DarkGray
            };
        }
    }
}
