using alwfx.Devices.DTO;

namespace alwfx.Devices.Mapper.Device
{
    /// <summary>
    /// Transforms a DeviceDTO to Device
    /// Demanding another layer of abstraction for parting as reusable code.
    /// </summary>
    public interface IUpdateDeviceMapper : ISingleMapper<DeviceDTO, Domain.Device>
    {
    }
}