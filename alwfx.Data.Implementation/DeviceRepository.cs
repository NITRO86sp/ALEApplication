using System.Collections.Specialized;
using System.Data.Common;
using System.Globalization;
using System.Xml;
using alwfx.Data.Implementation.Properties;
using alwfx.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace alwfx.Data.Implementation
{
    public class DeviceRepository : IRepository<Device>
    {
        /// <summary>
        /// Gets all devices from the data repository
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Device> GetAll()
        {

            XDocument xml = XDocument.Load(@"Devices.xml");

            return xml.Descendants("device")
                .Select(d => new Device{
                    Id = Int32.Parse(d.Element("id").Value),
                    Name = d.Element("name").Value,
                    Mode = (Mode)Enum.Parse(typeof(Mode), d.Element("mode").Value),
                    Status = (Status)Enum.Parse(typeof(Status), d.Element("status").Value),
                    ToNotification = Int32.Parse(d.Element("toNotification").Value),
                    ToAlert = Int32.Parse(d.Element("toAlert").Value)                    
                }).OrderBy(d => d.Id);
        }

        /// <summary>
        /// Updates a device in the data repository
        /// </summary>
        /// <param name="entity"></param>
        public void Update(Device entity)
        {
            XDocument xml = XDocument.Load(@"Devices.xml");

            var deviceToUpdate = xml.Descendants("device").First(d => d.Element("id").Value.Equals(entity.Id.ToString(CultureInfo.InvariantCulture)));

            deviceToUpdate.Element("name").Value = entity.Name;
            deviceToUpdate.Element("mode").Value = entity.Mode.ToString();
            deviceToUpdate.Element("status").Value = entity.Status.ToString();
            deviceToUpdate.Element("toNotification").Value = entity.ToNotification.ToString(CultureInfo.InvariantCulture);
            deviceToUpdate.Element("toAlert").Value = entity.ToAlert.ToString(CultureInfo.InvariantCulture);

            xml.Save(@"Devices.xml");
        }
    }
}
