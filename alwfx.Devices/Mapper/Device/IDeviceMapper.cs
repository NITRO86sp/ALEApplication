using alwfx.Devices.DTO;

namespace alwfx.Devices.Mapper.Device
{
    /// <summary>
    /// Transforms a Device to DeviceDTO
    /// Demanding another layer of abstraction for parting as reusable code.
    /// </summary>
    public interface IDeviceMapper : ISingleMapper<Domain.Device, DeviceDTO>
    {
    }
}