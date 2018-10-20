using Pluto.BLL.Services.Implementations;
using Pluto.BLL.Services.Interfaces;
using Pluto.DAL.Services.Implementations;
using Pluto.DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Pluto.BLL
{
    public class UnityBootstrapper
    {
        #region Singleton
        private static UnityBootstrapper unityBootstrapper = new UnityBootstrapper();
        public static UnityBootstrapper UnityBootstrapperInstance
        {
            get { return unityBootstrapper; }
        }

        private UnityBootstrapper()
        {
            container = new UnityContainer();

            ConfigureDependencies();
        }
        #endregion

        private IUnityContainer container;

        private void ConfigureDependencies()
        {
            container.RegisterType<ISubjectMapperService, SubjectMapperService>();
            container.RegisterType<ITermMapperService, TermMapperService>();
            container.RegisterType<IRegisteredSubjectMapperService, RegisteredSubjectMapperService>();
            container.RegisterType<IAttendanceMapperService, AttendanceMapperService>();

            container.RegisterType<ISubjectEntityService, SubjectEntityService>();
            container.RegisterType<ITermEntityService, TermEntityService>();
            container.RegisterType<IRegisteredSubjectEntityService, RegisteredSubjectEntityService>();
            container.RegisterType<IAttendanceEntityService, AttendanceEntityService>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
