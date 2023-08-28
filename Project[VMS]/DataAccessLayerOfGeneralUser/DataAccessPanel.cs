using DataAccessLayerOfGeneralUser.DataBase;
using DataAccessLayerOfGeneralUser.Repos;
using DataAccessLayerVMS.Interface;
using DataAccessLayerVMS.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayerVMS
{
    public class DataAccessPanel
    {
        public static BasicOperation <UserVM, int, bool> UserData()
        {
            return new GeneralUserManage();
        }

        public static BasicOperation<UserVM, int, bool> AdminControl()
        {
            return new AdminControl();
        }

        public static BasicOperation<UserVM, int, bool> DriverControl()
        {
            return new DriverManage();
        }

        public static BasicOperation<DriverLicense, int, bool> LicenseControl()
        {
            return new DriverLicenseManage();
        }

        public static BasicOperation<Vehicle, int, bool> VehicleControl()
        {
            return new VehicleManage();
        }

        public static BasicOperation<SOSinfo, int, bool> SOScontrol()
        {
            return new SOScontactManage();
        }
        public static BasicOperation<AccessToken, int, AccessToken> TokenControl()
        {
            return new TokenManage();
        }
        public static BasicOperation<NotePad, int, bool> NotePadControl()
        {
            return new NotePadManage();
        }
        public static BasicOperation<HiringInfo, int, bool> HireValueControl()
        {
            return new DriverHiringManage();
        }
        public static BasicOperation<Notification, int, bool> NotificationControl()
        {
            return new NotificationManage();
        }
    }
}
