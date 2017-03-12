using alwfx.Data;
using alwfx.Data.Implementation;
using alwfx.Devices.Implementation.Manager;
using alwfx.Devices.Implementation.Mapper.Device;
using alwfx.Devices.Manager;
using alwfx.Devices.Mapper.Device;
using alwfx.Domain;
using Ninject.Modules;

namespace alwfx.UI.Infrastructure
{
    /// <summary>
    /// Dependency injection module
    /// </summary>
    public class ApplicationModule : NinjectModule
    {
        /// <summary>
        /// Custom bindings
        /// </summary>
        public override void Load()
        {
            //Use only a single instance of the Device Repository
            Bind<IRepository<Device>>().To<DeviceRepository>().InSingletonScope();
            Bind<IDeviceManager>().To<DeviceManager>();
            Bind<IDeviceMapper>().To<DeviceMapper>();
            Bind<IUpdateDeviceMapper>().To<UpdateDeviceMapper>();
        }
    }
}
